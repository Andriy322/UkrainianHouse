using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UkrainianHouse.Models
{
    [Table("Task")]
    public partial class Task
    {
        [Key]
        [Column("task_id")]
        public int TaskId { get; set; }
        [Column("task_name")]
        [StringLength(255)]
        public string TaskName { get; set; }
        [Column("emp_task_info")]
        [StringLength(255)]
        public string EmpTaskInfo { get; set; }
        [Column("employee_id")]
        public int? EmployeeId { get; set; }
        [Column("status_id")]
        public int? StatusId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("Tasks")]
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty("Tasks")]
        public virtual Status Status { get; set; }
    }
}
