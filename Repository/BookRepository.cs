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
    public class BookRepository : RepositoryBase<Book>, IBookService    
    {
        public BookRepository(LibraryDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await FindAll().ToListAsync();
        }
        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            return await FindByCondition(book => book.BookId == bookId).FirstOrDefaultAsync();
        }
        public void CreateBookAsync(int AdminId, Book book)
        {
            Create(book);
        }
        public void UpdateBookAsync(int AdminId, Book book)
        {
            Update(book);
        }
        public void DeleteBookAsync(int AdminId, int bookId)
        {
            var book = FindByCondition(b => b.BookId == bookId).FirstOrDefault();
            if (book != null)
            {
                Delete(book);
            }
        }
    }
}
