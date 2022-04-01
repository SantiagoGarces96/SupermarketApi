using System;
using System.Collections.Generic;

#nullable disable

namespace SupermarketApi.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Quantify { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Description { get; set; }
        public int IdBranchOffice { get; set; }

        public virtual BranchOffice IdBranchOfficeNavigation { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
