using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using SportsPro.Models.DataLayer;

namespace SportsPro.Controllers
{
    //Incident Controller
    public class IncidentController : Controller
    {
        private SportProUnitOfWork data { get; set; }
        public IncidentController(SportsProContext ctx) => data = new SportProUnitOfWork(ctx);
        
        //Get method for the incident filtering
        [Route("/Incidents/")]
        public IActionResult List(String filter)
        {
            var incidentOptions = new QueryOptions<Incident>
            {
                Includes = "Customer, Product, Technician"
            };
            if (filter == null || filter == "All")
            {
                //var incident = context.Incidents.Include(m=>m.Customer).Include(m=>m.Product).Include(m => m.Technician).OrderBy(m => m.IncidentID).ToList();
                incidentOptions.OrderBy = c => c.Title;
                var incidents = new IncidentsViewModel
                {
                    Incidents = (List<Incident>)data.Incidents.List(incidentOptions),
                    IncidentTitle = " Incident Manager"
                };
                ViewBag.ALink = "All";
                return View("list", incidents);
            }
            else if (filter == "Open")
            {
                incidentOptions.Where = c => c.DateClosed == null;
                incidentOptions.OrderBy = c => c.Title;
                var incidents = new IncidentsViewModel
                {
                    Incidents = (List<Incident>)data.Incidents.List(incidentOptions),
                    IncidentTitle = " Incident Manager"
                   
                };
                ViewBag.ALink = "Open";
                return View("list", incidents);
            }
            else
            { incidentOptions.Where = c => c.DateClosed == null;
                incidentOptions.OrderBy = c => c.Title;
                var incidents = new IncidentsViewModel
                {
                    Incidents = (List<Incident>)data.Incidents.List(incidentOptions),
                    IncidentTitle = " Incident Manager"
                };
                ViewBag.ALink = "Unassigned";
                return View("list", incidents);

            }
            
        }

       //Get method for the edit view
        [HttpGet]
        public IActionResult Add()
        {
            var customerOptions = new QueryOptions<Customer> { };
            customerOptions.OrderBy = g => g.FirstName;
            var productOptions = new QueryOptions<Product> { };
            productOptions.OrderBy = g => g.Name;
            var technicianOptions = new QueryOptions<Technician> { };
            technicianOptions.OrderBy = g => g.Name;

   
            var IncidentModel = new IncidentEditViewModel
            {
                CurrentIncident = new Incident(),
                Customers = data.Customers.List(customerOptions).ToList(),
                Products = data.Products.List(productOptions).ToList(),
                Technicians = data.Technicians.List(technicianOptions).ToList(),
                AddOrEdit= "Add"
            };

            return View("Edit", IncidentModel);
        }

        //Get method for the edit view
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id, string slug)
        {
            var customerOptions = new QueryOptions<Customer> { };
            customerOptions.OrderBy = g => g.FirstName;
            var productOptions = new QueryOptions<Product> { };
            productOptions.OrderBy = g => g.Name;
            var technicianOptions = new QueryOptions<Technician> { };
            technicianOptions.OrderBy = g => g.Name;

      
            var IncidentModel = new IncidentEditViewModel
            {
                CurrentIncident = data.Incidents.Get(id),
                Customers = data.Customers.List(customerOptions).ToList(),
                Products = data.Products.List(productOptions).ToList(),
                Technicians = data.Technicians.List(technicianOptions).ToList(),
                AddOrEdit = "Edit"
            };
            if (slug == "TechInc")
            {
                IncidentModel.Mode = slug;
            }

            return View(IncidentModel);
        }

        //Post method for redirecting to the list method
        [HttpPost]
        public IActionResult Edit(IncidentEditViewModel inc)
        {
         
                
                if (inc.CurrentIncident==null)
                    data.Incidents.Insert(inc.CurrentIncident);
                else
                    data.Incidents.Update(inc.CurrentIncident);
            data.Save();
          
                return RedirectToAction("List", "Incident");   
        }

        //Get method for delete view
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = data.Incidents.Get(id);
            return View(incident);
        }

        //Post method redirecting to the list method
        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            data.Incidents.Delete(incident);
            data.Save();
            return RedirectToAction("List", "Incident");
        }

    }
}

