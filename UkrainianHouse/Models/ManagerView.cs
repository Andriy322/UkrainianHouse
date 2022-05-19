using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UkrainianHouse.Models
{
    [Keyless]
    public partial class ManagerView
    {
        [Column("project_id")]
        public int ProjectId { get; set; }
        [Required]
        [Column("project_name")]
        [StringLength(255)]
        public string ProjectName { get; set; }
        [Required]
        [Column("city")]
        [StringLength(255)]
        public string City { get; set; }
        [Required]
        [Column("address")]
        [StringLength(255)]
        public string Address { get; set; }
        [Column("operation_id")]
        public int OperationId { get; set; }
        [Column("calendar_date", TypeName = "date")]
        public DateTime CalendarDate { get; set; }
    }
}
