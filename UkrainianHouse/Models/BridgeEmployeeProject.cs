using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UkrainianHouse.Models
{
    [Table("BridgeEmployeeProject")]
    public partial class BridgeEmployeeProject
    {
        [Key]
        [Column("employee_project_id")]
        public int EmployeeProjectId { get; set; }
        [Column("project_id")]
        public int? ProjectId { get; set; }
        [Column("employee_id")]
        public int? EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("BridgeEmployeeProjects")]
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(ProjectId))]
        [InverseProperty("BridgeEmployeeProjects")]
        public virtual Project Project { get; set; }
    }
}
