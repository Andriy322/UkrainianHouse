using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UkrainianHouse.Models
{
    [Table("Date")]
    public partial class Date
    {
        public Date()
        {
            Accountings = new HashSet<Accounting>();
            Operations = new HashSet<Operation>();
        }

        [Key]
        [Column("date_id")]
        public int DateId { get; set; }
        [Column("calendar_date", TypeName = "date")]
        public DateTime CalendarDate { get; set; }
        [Column("year")]
        public int? Year { get; set; }
        [Column("month")]
        public int? Month { get; set; }
        [Column("day")]
        public int? Day { get; set; }

        [InverseProperty(nameof(Accounting.Date))]
        public virtual ICollection<Accounting> Accountings { get; set; }
        [InverseProperty(nameof(Operation.Date))]
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
