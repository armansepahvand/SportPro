using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models
{
    //View model for incident class to transfer data from incident controller to the view
    public class IncidentEditViewModel
    {
       private List<Customer> customers;
        public List<Customer> Customers
        {
            get => customers;
            set
            {
                customers = new List<Customer>();
                customers.AddRange(value);
            }
        }

        private List<Incident> incidents;
        public List<Incident> Incidents
        {
            get => incidents;
            set
            {
                incidents = new List<Incident>();
                incidents.AddRange(value);
            }
        }


        private List<Product> products;
        public List<Product> Products
        {
            get => products;
            set
            {
                products = new List<Product>();
                products.AddRange(value);
            }
        }

        private List<Technician> technicians;
        public List<Technician> Technicians
        {
            get => technicians;
            set
            {
                technicians = new List<Technician> ();
                technicians.AddRange(value);
            }
        }

        public Technician CurrentTechnician { get; set; }
        public Incident CurrentIncident { get;set; }
        public string AddOrEdit;
        public string Mode { get; set; }

    }
}
