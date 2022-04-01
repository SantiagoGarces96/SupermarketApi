using System;
using System.Collections.Generic;

#nullable disable

namespace SupermarketApi.Models
{
    public partial class User
    {
        public User()
        {
            BranchOffices = new HashSet<BranchOffice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int IdEmployee { get; set; }
        public int IdInventory { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Inventory IdInventoryNavigation { get; set; }
        public virtual ICollection<BranchOffice> BranchOffices { get; set; }
    }
}
