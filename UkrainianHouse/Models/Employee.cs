using System;
using System.Collections.Generic;

#nullable disable

namespace UkrainianHouse.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Accountings = new HashSet<Accounting>();
            BridgeEmployeeProjects = new HashSet<BridgeEmployeeProject>();
            Tasks = new HashSet<Task>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Phone { get; set; }
        public int? ActiveFlag { get; set; }
        public string Specialization { get; set; }

        public virtual ICollection<Accounting> Accountings { get; set; }
        public virtual ICollection<BridgeEmployeeProject> BridgeEmployeeProjects { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
