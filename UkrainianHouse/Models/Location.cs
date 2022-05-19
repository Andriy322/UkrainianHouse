using System;
using System.Collections.Generic;

#nullable disable

namespace UkrainianHouse.Models
{
    public partial class Location
    {
        public Location()
        {
            Projects = new HashSet<Project>();
        }

        public int LocationId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
