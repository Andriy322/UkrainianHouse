using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UkrainianHouse.Models
{
    [Keyless]
    [Table("ErrorLog")]
    public partial class ErrorLog
    {
        public int? ErrorNumber { get; set; }
        public int? ErrorSeverity { get; set; }
        public int? ErrorState { get; set; }
        [StringLength(128)]
        public string ErrorProcedure { get; set; }
        public int? ErrorLine { get; set; }
        [StringLength(4000)]
        public string ErrorMessage { get; set; }
    }
}
