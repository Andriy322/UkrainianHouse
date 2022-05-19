using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UkrainianHouse.Models
{
    [Table("Location")]
    public partial class Location
    {
        public Location()
        {
            Projects = new HashSet<Project>();
        }

        [Key]
        [Column("location_id")]
        public int LocationId { get; set; }
        [Required]
        [Column("country")]
        [StringLength(255)]
        public string Country { get; set; }
        [Required]
        [Column("city")]
        [StringLength(255)]
        public string City { get; set; }
        [Required]
        [Column("address")]
        [StringLength(255)]
        public string Address { get; set; }

        [InverseProperty(nameof(Project.Location))]
        public virtual ICollection<Project> Projects { get; set; }
    }
}
