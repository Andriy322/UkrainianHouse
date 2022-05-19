using System;
using System.Collections.Generic;

#nullable disable

namespace UkrainianHouse.Models
{
    public partial class ManagerView
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int OperationId { get; set; }
        public DateTime CalendarDate { get; set; }
    }
}
