using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Management_SYS.Application.Interfaces;
using Library_Management_SYS.Entities.Models;       
using Microsoft.EntityFrameworkCore;
using Library_Management_SYS.Entities;

namespace Library_Management_SYS.Repository
{
    public class AdminRepository : RepositoryBase<Admin>, IAdminService
    {
        public AdminRepository(LibraryDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
        {
            return await FindAll().ToListAsync();
        }
        public async Task<Admin> GetAdminByIdAsync(int adminId)
        {
            return await FindByCondition(admin => admin.AdminId == adminId).FirstOrDefaultAsync();
        }
        public void CreateAdminAsync(Admin admin)
        {
            Create(admin);
        }
        public void UpdateAdminAsync(Admin admin)
        {
            Update(admin);
        }
        public void DeleteAdminAsync(int adminId)
        {
            var admin = LibraryDbContext.Admin.Find(adminId);
            if (admin != null)
            {
                Delete(admin);
            }
        }

    }
}
