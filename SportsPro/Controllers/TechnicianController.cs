using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    //Technician Controller
    public class TechnicianController : Controller
    {
        private SportsProContext context { get; set; }

        public TechnicianController(SportsProContext ctx)
        {
            context = ctx;
        }

        //Get method for the list view
        [Route("/Technicians/")]
        public IActionResult List()
        {
            var technician = context.Technicians.OrderBy(m => m.Name).ToList();
            return View("list", technician);
        }

        //Get method for the edit view
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
           
            return View("Edit", new Technician());
        }

        //Get method for the edit view
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var technician = context.Technicians.Find(id);
            return View(technician);
        }

        //Post method redirecting to the list view
        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
           
                if (technician.TechnicianID == 0)
                    context.Technicians.Add(technician);
                else
                    context.Technicians.Update(technician);
                context.SaveChanges();
                return RedirectToAction("List", "Technician");          
        }

        //Get method for the delete view
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var technician = context.Technicians.Find(id);
            return View(technician);
        }

        //Post method redirecting to the list view
        [HttpPost]
        public IActionResult Delete(Technician technician)
        {
            context.Technicians.Remove(technician);
            context.SaveChanges();
            return RedirectToAction("List", "Technician");
        }



    }
}
