using System;

namespace SupermarketApi.Entities
{
    public class Inventory
    {
        public string Quantify { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Description { get; set; }
        
    }
}
