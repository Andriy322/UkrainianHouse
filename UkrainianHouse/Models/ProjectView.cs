using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UkrainianHouse.Models
{
    [Keyless]
    public partial class ProjectView
    {
        [Column("project_id")]
        public int ProjectId { get; set; }
        [Required]
        [Column("project_name")]
        [StringLength(255)]
        public string ProjectName { get; set; }
        [Required]
        [Column("city")]
        [StringLength(255)]
        public string City { get; set; }
        [Required]
        [Column("address")]
        [StringLength(255)]
        public string Address { get; set; }
        [Required]
        [Column("first_name")]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name")]
        [StringLength(255)]
        public string LastName { get; set; }
        [Required]
        [Column("material_name")]
        [StringLength(255)]
        public string MaterialName { get; set; }
        [Column("count")]
        public int Count { get; set; }
        [Column("calendar_date", TypeName = "date")]
        public DateTime CalendarDate { get; set; }
        [Column("storage_id")]
        public int StorageId { get; set; }
    }
}
