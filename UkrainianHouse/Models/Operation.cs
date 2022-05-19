using System;
using System.Collections.Generic;

#nullable disable

namespace UkrainianHouse.Models
{
    public partial class Operation
    {
        public int OperationId { get; set; }
        public int? MaterialId { get; set; }
        public int Count { get; set; }
        public int? ProjectId { get; set; }
        public int? DateId { get; set; }

        public virtual Date Date { get; set; }
        public virtual Material Material { get; set; }
        public virtual Project Project { get; set; }
    }
}
