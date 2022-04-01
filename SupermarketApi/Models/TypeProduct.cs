using System;
using System.Collections.Generic;

#nullable disable

namespace SupermarketApi.Models
{
    public partial class TypeProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdProduct { get; set; }

        public virtual Product IdProductNavigation { get; set; }
    }
}
