using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UkrainianHouse.Models
{
    public class EmployeeTask
    {
        public Employee employeedetails { get; set; } 

        public Task taskdetails { get; set; }

        public Status statusdetails { get; set; }
    }
}
