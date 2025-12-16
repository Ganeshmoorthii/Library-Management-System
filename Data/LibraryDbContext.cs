using Microsoft.EntityFrameworkCore;
using Library_Management_SYS.Models;

namespace Library_Management_SYS.Data    
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Student> Student { get; set; }
    }
}
