using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_SYS.Entities.Models
{
    public class Admin
    {
        [Key]
        public int  AdminId { get; set; }
        public string name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
