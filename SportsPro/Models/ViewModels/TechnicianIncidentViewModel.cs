using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models
{
    //View model for Technician-incident class to transfer data from controller to the view
    public class TechnicianIncidentViewModel
    {
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


        public Technician CurrentTechnician { get;set; }

        
    }
}
