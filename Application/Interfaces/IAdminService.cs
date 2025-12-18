using System.Collections.Generic;
using Library_Management_SYS.Entities.Models;

namespace Library_Management_SYS.Application.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<Admin>> GetAllAdminsAsync();
        Task<Admin> GetAdminByIdAsync(int adminId);
        void CreateAdminAsync(Admin admin);
        void UpdateAdminAsync(Admin admin);
        void DeleteAdminAsync(int adminId);

    }
}
