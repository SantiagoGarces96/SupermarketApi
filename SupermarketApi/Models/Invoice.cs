using System;
using System.Collections.Generic;

#nullable disable

namespace SupermarketApi.Models
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int IdClient { get; set; }
        public int IdEmployee { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
