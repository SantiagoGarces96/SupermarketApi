using System;
using System.Collections.Generic;

#nullable disable

namespace SupermarketApi.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Invoices = new HashSet<Invoice>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CellPhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public int IdJobTitle { get; set; }

        public virtual JobTitle IdJobTitleNavigation { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
