using System;
using System.Collections.Generic;

#nullable disable

namespace UkrainianHouse.Models
{
    public partial class Material
    {
        public Material()
        {
            Operations = new HashSet<Operation>();
            Storages = new HashSet<Storage>();
        }

        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int Price { get; set; }
        public string Comments { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<Storage> Storages { get; set; }
    }
}
