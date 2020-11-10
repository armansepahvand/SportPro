using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    //Customer Controller
    public class CustomerController : Controller
    {
        private SportsProContext context { get; set; }

        public CustomerController(SportsProContext ctx)
        {
            context = ctx;
        }

        //Get method for the list view
        [Route("/Customers/")]
        public IActionResult List()
        {
            var customers = context.Customers.OrderBy(m => m.FirstName).ToList();
            return View("list", customers);
        }

        //Get Method for the add view
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Countries = context.Countries.OrderBy(g => g.Name).ToList();

            return View("Edit", new Customer());
        }

        //Get method for the edit view
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Countries = context.Countries.OrderBy(g => g.Name).ToList();
            var customer = context.Customers.Find(id);
            return View(customer);
        }

        //Post method for the edit view
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
           
                if (customer.CustomerID == 0)
                    context.Customers.Add(customer);
                else
                    context.Customers.Update(customer);
                context.SaveChanges();
                return RedirectToAction("List", "Customer");
           
        }

        //Get method for delete
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = context.Customers.Find(id);
            return View(customer);
        }

        //Post method for delete
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("List", "Customer");
        }
    }
}
