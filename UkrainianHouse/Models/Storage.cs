using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UkrainianHouse.Models
{
    [Table("Storage")]
    public partial class Storage
    {
        [Key]
        [Column("storage_id")]
        public int StorageId { get; set; }
        [Column("material_id")]
        public int MaterialId { get; set; }
        [Column("count")]
        public int Count { get; set; }
        [Column("comments")]
        [StringLength(255)]
        public string Comments { get; set; }

        [ForeignKey(nameof(MaterialId))]
        [InverseProperty("Storages")]
        public virtual Material Material { get; set; }
    }
}
