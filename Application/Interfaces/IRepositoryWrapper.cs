using Library_Management_SYS.Application.Interfaces;

namespace Library_Management_SYS.Application.Interfaces
{
    public interface IRepositoryWrapper
    {
        IAdminService AdminService { get; }
        IBookService BookService { get; }
        IStudentService StudentService { get; }
        Task SaveAsync();
    }
}
