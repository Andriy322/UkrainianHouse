using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UkrainianHouse.Models
{
    public class EmployeeProject
    {
        public Employee employeedetails { get; set; }

        public Project projectdetails { get; set; }

        public BridgeEmployeeProject bridgeEmployeedetails { get; set; }
    }
}
