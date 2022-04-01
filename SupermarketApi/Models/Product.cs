using System;
using System.Collections.Generic;

#nullable disable

namespace SupermarketApi.Models
{
    public partial class Product
    {
        public Product()
        {
            TypeProducts = new HashSet<TypeProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ProductElaborationDate { get; set; }
        public DateTime ProductExpirationDate { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Stock { get; set; }
        public int IdBranchOffice { get; set; }

        public virtual BranchOffice IdBranchOfficeNavigation { get; set; }
        public virtual ICollection<TypeProduct> TypeProducts { get; set; }
    }
}
