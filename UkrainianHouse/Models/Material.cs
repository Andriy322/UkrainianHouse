using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UkrainianHouse.Models
{
    [Table("Material")]
    public partial class Material
    {
        public Material()
        {
            Operations = new HashSet<Operation>();
            Storages = new HashSet<Storage>();
        }

        [Key]
        [Column("material_id")]
        public int MaterialId { get; set; }
        [Required]
        [Column("material_name")]
        [StringLength(255)]
        public string MaterialName { get; set; }
        [Column("price")]
        public int Price { get; set; }
        [Column("comments")]
        [StringLength(255)]
        public string Comments { get; set; }

        [InverseProperty(nameof(Operation.Material))]
        public virtual ICollection<Operation> Operations { get; set; }
        [InverseProperty(nameof(Storage.Material))]
        public virtual ICollection<Storage> Storages { get; set; }
    }
}
