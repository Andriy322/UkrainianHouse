using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UkrainianHouse.Models
{
    [Table("Status")]
    public partial class Status
    {
        public Status()
        {
            Tasks = new HashSet<Task>();
        }

        [Key]
        [Column("status_id")]
        public int StatusId { get; set; }
        [Required]
        [Column("status_name")]
        [StringLength(255)]
        public string StatusName { get; set; }

        [InverseProperty(nameof(Task.Status))]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
