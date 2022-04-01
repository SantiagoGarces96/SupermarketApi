using System;
using System.Collections.Generic;

#nullable disable

namespace SupermarketApi.Models
{
    public partial class ProductProvider
    {
        public int IdProduct { get; set; }
        public int IdProvider { get; set; }

        public virtual Provider IdProduct1 { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
