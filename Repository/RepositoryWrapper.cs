using Library_Management_SYS.Entities;
using Library_Management_SYS.Application.Interfaces;

namespace Library_Management_SYS.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly LibraryDbContext _context;
        private IAdminService _adminService;
        private IBookService _bookService;
        private IStudentService _studentService;
        public RepositoryWrapper(LibraryDbContext context)
        {
            _context = context;
        }

        public IAdminService AdminService
        {
            get
            {
                if (_adminService == null) _adminService = new AdminRepository(_context);

                return _adminService;
            }
        }
        public IBookService BookService
        {
            get
            {
                if (_bookService == null) _bookService = new BookRepository(_context);
                return _bookService;
            }
        }
        public IStudentService StudentService
        {
            get
            {
                if (_studentService == null) _studentService = new StudentRepositary(_context);
                return _studentService;
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
