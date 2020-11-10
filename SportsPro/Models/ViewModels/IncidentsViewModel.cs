using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models
{
    //View model for incident class to transfer data from incident controller to the view
    public class IncidentsViewModel
    {
        public List<Incident> Incidents;
        public string IncidentTitle;
    }
}
