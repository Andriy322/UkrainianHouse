using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UkrainianHouse.Models
{
    [Table("Accounting")]
    [Index(nameof(EmployeeId), Name = "index3")]
    public partial class Accounting
    {
        [Key]
        [Column("transaction_id")]
        public int TransactionId { get; set; }
        [Column("salary")]
        public int? Salary { get; set; }
        [Column("employee_id")]
        public int? EmployeeId { get; set; }
        [Column("date_id")]
        public int? DateId { get; set; }

        [ForeignKey(nameof(DateId))]
        [InverseProperty("Accountings")]
        public virtual Date Date { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("Accountings")]
        public virtual Employee Employee { get; set; }
    }
}
