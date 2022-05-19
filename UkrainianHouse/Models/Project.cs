using System;
using System.Collections.Generic;

#nullable disable

namespace UkrainianHouse.Models
{
    public partial class Project
    {
        public Project()
        {
            BridgeEmployeeProjects = new HashSet<BridgeEmployeeProject>();
            Operations = new HashSet<Operation>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectStatus { get; set; }
        public int? LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<BridgeEmployeeProject> BridgeEmployeeProjects { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
