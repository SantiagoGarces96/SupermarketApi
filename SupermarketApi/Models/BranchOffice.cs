using System;
using System.Collections.Generic;

#nullable disable

namespace SupermarketApi.Models
{
    public partial class BranchOffice
    {
        public BranchOffice()
        {
            Inventories = new HashSet<Inventory>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public int IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
