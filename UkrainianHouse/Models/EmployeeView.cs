using System;
using System.Collections.Generic;

#nullable disable

namespace UkrainianHouse.Models
{
    public partial class EmployeeView
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public int? Salary { get; set; }
        public DateTime CalendarDate { get; set; }
    }
}
