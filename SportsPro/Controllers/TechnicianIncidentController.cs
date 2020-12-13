using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using SportsPro.Models.DataLayer;

namespace SportsPro.Controllers
{
    //Technician-Incident Controller bbb
    [Authorize]
    public class TechnicianIncidentController : Controller
    {
        private SportProUnitOfWork data { get; set; }
        public TechnicianIncidentController(SportsProContext ctx) => data = new SportProUnitOfWork(ctx);

        //Get method for the get view
        public IActionResult get()
        {
            var technicianOptions = new QueryOptions<Technician> { };
            technicianOptions.OrderBy = g => g.Name;
            var technicians = new IncidentEditViewModel
            {
                
                Technicians = data.Technicians.List(technicianOptions).ToList(),
                CurrentTechnician = new Technician()
            };
            ViewBag.Current = new Technician();

            return View(technicians);
        }
            
        //Post method for the list view
        [HttpPost]
        public IActionResult list(IncidentEditViewModel inc)
        {
            var incidentOptions = new QueryOptions<Incident>
            {
                Includes = "Customer, Product, Technician",

            };
            var technicianOptions = new QueryOptions<Technician> { };
            technicianOptions.Where = g=> g.TechnicianID == inc.CurrentTechnician.TechnicianID;
            incidentOptions.Where = g => g.TechnicianID == inc.CurrentTechnician.TechnicianID;
            incidentOptions.Where = g => g.DateClosed ==null;
            var incident = new IncidentEditViewModel();
            var technician = new Technician();
            technician = data.Technicians.Get(technicianOptions);
            incident.Incidents = data.Incidents.List(incidentOptions).ToList();
            ViewBag.Current = technician.Name;
            return View(incident);
        }

        //Get method for the edit view
        [HttpGet]
        public IActionResult Edit(int id)
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
         
            return View(IncidentModel);
        }

        //Post method for the list view
        [HttpPost]
        public IActionResult Edit(IncidentEditViewModel inc)
        {          
            if (inc.CurrentIncident == null)
                data.Incidents.Insert(inc.CurrentIncident);
            else
                data.Incidents.Update(inc.CurrentIncident);
            data.Save();
          
            var Id = inc.CurrentIncident.TechnicianID;
            var technician = new IncidentEditViewModel();
            technician.CurrentTechnician = data.Technicians.Get((int)Id);

            var incidentOptions = new QueryOptions<Incident>
            {
                Includes = "Customer, Product, Technician",

            };
            incidentOptions.Where = g => g.TechnicianID == technician.CurrentTechnician.TechnicianID;
            incidentOptions.Where = g => g.DateClosed == null;
            var incident = new IncidentEditViewModel();
            incident.Incidents = data.Incidents.List(incidentOptions).ToList();
            ViewBag.Current = data.Incidents.Get(incidentOptions).Technician.Name;

            return View("list", incident);        
        }
    }
}
