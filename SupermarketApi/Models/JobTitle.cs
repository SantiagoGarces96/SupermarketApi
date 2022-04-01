using System;
using System.Collections.Generic;

#nullable disable

namespace SupermarketApi.Models
{
    public partial class JobTitle
    {
        public JobTitle()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string WorkPosition { get; set; }
        public string JobDescrption { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
