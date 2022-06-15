using SupermarketApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketApi.Entities
{
    public class Product
    {

        [Key]
        public string Name { get; set; }
        public string ProductElaborationDate { get; set; }
        public string ProductExpirationDate { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Stock { get; set; }
        
    }
}
