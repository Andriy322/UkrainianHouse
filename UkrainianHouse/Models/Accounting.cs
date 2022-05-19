using System;
using System.Collections.Generic;

#nullable disable

namespace UkrainianHouse.Models
{
    public partial class Accounting
    {
        public int TransactionId { get; set; }
        public int? Salary { get; set; }
        public int? EmployeeId { get; set; }
        public int? DateId { get; set; }

        public virtual Date Date { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
