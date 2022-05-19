using System;
using System.Collections.Generic;

#nullable disable

namespace UkrainianHouse.Models
{
    public partial class Storage
    {
        public int StorageId { get; set; }
        public int MaterialId { get; set; }
        public int Count { get; set; }
        public string Comments { get; set; }

        public virtual Material Material { get; set; }
    }
}
