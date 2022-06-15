using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;



namespace SupermarketApi.Models.DB
{
    [Table("Users")]
    public class Users
    {
        
        [Key]
        public int id { get; set; }
        public string surnames { get; set; }
        public string names { get; set; }
        public string email { get; set; }
        public string usename { get; set; }
        public string passwor { get; set; }
    
    }
}
