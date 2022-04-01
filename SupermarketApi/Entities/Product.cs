using System;

namespace SupermarketApi.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public DateTime ProductElaborationDate { get; set; }
        public DateTime ProductExpirationDate { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Stock { get; set; }
        public int IdBranchOffice { get; set; }
    }
}
