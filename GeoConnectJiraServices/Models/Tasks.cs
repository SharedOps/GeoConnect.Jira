using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeoConnectJiraServices.Models
{
    public class Tasks
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string TaskName { get; set; }

        public string TaskDescription { get; set; }

        public int AssignedTo { get; set; }

        public string TaskStatus { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}