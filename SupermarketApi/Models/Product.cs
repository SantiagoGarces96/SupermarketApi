using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SupermarketApi.Models
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            TypeProducts = new HashSet<TypeProduct>();
        }

        [Key]
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
