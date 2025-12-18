using Library_Management_SYS.Application.Interfaces;
//using Library_Management_SYS.Data;
using Library_Management_SYS.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_SYS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public BooksController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _repository.BookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _repository.BookService.GetBookByIdAsync(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost("{adminId}")]
        public async Task<IActionResult> CreateBook(int adminId, [FromBody] Book book)
        {
            _repository.BookService.CreateBookAsync(adminId, book);
            await _repository.SaveAsync();
            return Ok("Book Created Successfully");
        }

        [HttpPut("{adminId}")]
        public async Task<IActionResult> UpdateBook(int adminId, [FromBody] Book book)
        {
            _repository.BookService.UpdateBookAsync(adminId, book);
            await _repository.SaveAsync();
            return Ok("Book Updated Successfully");
        }

        [HttpDelete("{adminId}/{bookId}")]
        public async Task<IActionResult> DeleteBook(int adminId, int bookId)
        {
            _repository.BookService.DeleteBookAsync(adminId, bookId);
            await _repository.SaveAsync();
            return Ok("Book Deleted Successfully");
        }
    }
}