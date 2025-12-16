using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_SYS.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public string name { get; set; }
        public string Email { get; set; }
    }
}
