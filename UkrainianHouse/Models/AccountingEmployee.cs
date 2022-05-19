using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UkrainianHouse.Models
{
    public class AccountingEmployee
    {
        public Accounting accountingdetails { get; set; }

        public Employee employeedetails { get; set; }

        public Date datedetails { get; set; }
    }
}
