using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UkrainianHouse.Models
{
    [Table("Operation")]
    [Index(nameof(ProjectId), Name = "index1")]
    [Index(nameof(MaterialId), Name = "index2")]
    public partial class Operation
    {
        [Key]
        [Column("operation_id")]
        public int OperationId { get; set; }
        [Column("material_id")]
        public int? MaterialId { get; set; }
        [Column("count")]
        public int Count { get; set; }
        [Column("project_id")]
        public int? ProjectId { get; set; }
        [Column("date_id")]
        public int? DateId { get; set; }

        [ForeignKey(nameof(DateId))]
        [InverseProperty("Operations")]
        public virtual Date Date { get; set; }
        [ForeignKey(nameof(MaterialId))]
        [InverseProperty("Operations")]
        public virtual Material Material { get; set; }
        [ForeignKey(nameof(ProjectId))]
        [InverseProperty("Operations")]
        public virtual Project Project { get; set; }
    }
}
