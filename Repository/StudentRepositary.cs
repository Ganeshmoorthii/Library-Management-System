using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Management_SYS.Application.Interfaces;
using Library_Management_SYS.Entities.Models;
using Library_Management_SYS.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_SYS.Repository
{
    public class StudentRepositary : RepositoryBase<Student>, IStudentService
    {
        public StudentRepositary(LibraryDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await FindAll().ToListAsync();
        }
        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            return await FindByCondition(student => student.StudentId == studentId).FirstOrDefaultAsync();
        }
        public void CreateStudentAsync(Student student)
        {
            Create(student);
        }
        public void UpdateStudentAsync(Student student)
        {
            Update(student);
        }
        public void DeleteStudentAsync(int studentId)
        {
            var student = FindByCondition(s => s.StudentId == studentId).FirstOrDefault();
            if (student != null)
            {
                Delete(student);
            }
        }
    }
}
