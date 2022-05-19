using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UkrainianHouse.Models
{
    [Table("Project")]
    public partial class Project
    {
        public Project()
        {
            BridgeEmployeeProjects = new HashSet<BridgeEmployeeProject>();
            Operations = new HashSet<Operation>();
        }

        [Key]
        [Column("project_id")]
        public int ProjectId { get; set; }
        [Required]
        [Column("project_name")]
        [StringLength(255)]
        public string ProjectName { get; set; }
        [Required]
        [Column("project_status")]
        [StringLength(255)]
        public string ProjectStatus { get; set; }
        [Column("location_id")]
        public int? LocationId { get; set; }

        [ForeignKey(nameof(LocationId))]
        [InverseProperty("Projects")]
        public virtual Location Location { get; set; }
        [InverseProperty(nameof(BridgeEmployeeProject.Project))]
        public virtual ICollection<BridgeEmployeeProject> BridgeEmployeeProjects { get; set; }
        [InverseProperty(nameof(Operation.Project))]
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
