using Microsoft.EntityFrameworkCore;
using Library_Management_SYS.Entities.Models;

namespace Library_Management_SYS.Entities    
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Student> Student { get; set; }
    }
}
