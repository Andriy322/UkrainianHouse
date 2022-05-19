using System;
using System.Collections.Generic;

#nullable disable

namespace UkrainianHouse.Models
{
    public partial class ProjectView
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MaterialName { get; set; }
        public int Count { get; set; }
        public DateTime CalendarDate { get; set; }
        public int StorageId { get; set; }
    }
}
