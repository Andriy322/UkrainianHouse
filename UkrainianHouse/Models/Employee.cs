using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UkrainianHouse.Models
{
    [Table("Employee")]
    public partial class Employee
    {
        public Employee()
        {
            Accountings = new HashSet<Accounting>();
            BridgeEmployeeProjects = new HashSet<BridgeEmployeeProject>();
            Tasks = new HashSet<Task>();
        }

        [Key]
        [Column("employee_id")]
        public int EmployeeId { get; set; }
        [Required]
        [Column("first_name")]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name")]
        [StringLength(255)]
        public string LastName { get; set; }
        [Column("age")]
        public int? Age { get; set; }
        [Column("phone")]
        [StringLength(255)]
        public string Phone { get; set; }
        [Column("active_flag")]
        public int? ActiveFlag { get; set; }
        [Column("specialization")]
        [StringLength(255)]
        public string Specialization { get; set; }

        [InverseProperty(nameof(Accounting.Employee))]
        public virtual ICollection<Accounting> Accountings { get; set; }
        [InverseProperty(nameof(BridgeEmployeeProject.Employee))]
        public virtual ICollection<BridgeEmployeeProject> BridgeEmployeeProjects { get; set; }
        [InverseProperty(nameof(Task.Employee))]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
