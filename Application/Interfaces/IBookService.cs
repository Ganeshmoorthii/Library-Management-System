using Library_Management_SYS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library_Management_SYS.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int bookId);
        void CreateBookAsync(int AdminId,Book book);
        void UpdateBookAsync(int AdminId, Book book);
        void DeleteBookAsync(int AdminId, int bookId);
    }
}
