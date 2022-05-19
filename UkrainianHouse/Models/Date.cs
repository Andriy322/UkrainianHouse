using System;
using System.Collections.Generic;

#nullable disable

namespace UkrainianHouse.Models
{
    public partial class Date
    {
        public Date()
        {
            Accountings = new HashSet<Accounting>();
            Operations = new HashSet<Operation>();
        }

        public int DateId { get; set; }
        public DateTime CalendarDate { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }

        public virtual ICollection<Accounting> Accountings { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
