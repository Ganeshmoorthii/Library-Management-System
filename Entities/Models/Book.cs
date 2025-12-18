using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_SYS.Entities.Models
{
    public class Book
    {
        [Key]
        [Column("book_id")]
        public int BookId { get; set; }

        [Column("book_name")]
        public string BookName { get; set; }

        [Column("book_author")]
        public string BookAuthor { get; set; }

        [Column("publication_date")]
        public DateTime publication_date { get; set; }
    }
}
