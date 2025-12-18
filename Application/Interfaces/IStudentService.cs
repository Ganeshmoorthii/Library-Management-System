using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library_Management_SYS.Entities.Models;

namespace Library_Management_SYS.Application.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int studentId);
        void CreateStudentAsync(Student student);
        void UpdateStudentAsync(Student student);
        void DeleteStudentAsync(int studentId);

    }
}
