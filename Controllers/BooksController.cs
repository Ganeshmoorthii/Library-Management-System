using Library_Management_SYS.Data;
using Microsoft.AspNetCore.Mvc;
using Library_Management_SYS.Models;

namespace Library_Management_SYS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet] 
        public IActionResult getBooks()
        {
            var books = _context.Books.ToList();
            return Ok(books);
        }

        
        [HttpPost("{id}")]
        public async Task<ActionResult<Book>> CreateBook(int id, [FromBody] Book book)
        {
            var admin = await _context.Admin.FindAsync(id);
            if (admin == null)
                return Forbid(); 

            
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(getBooks), null, book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, [FromBody] Book book)
        {
            var admin = await _context.Admin.FindAsync(id);
            if (admin == null)
                return Forbid();

            Book getBook = await _context.Books.FindAsync(book.BookId);
            if (getBook == null)
            {
                return NotFound();
            }
            //getBook.BookId = book.BookId;
            getBook.BookName = book.BookName;
            getBook.BookAuthor = book.BookAuthor;
            getBook.publication_date = book.publication_date;
            _context.Books.Update(getBook);
            await _context.SaveChangesAsync();

            return Ok("Book Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id, [FromBody] int bookId)
        {
            var admin = await _context.Admin.FindAsync(id);
            if (admin == null)
                return Forbid();

            Book getBook = await _context.Books.FindAsync(bookId);
            if(getBook == null)
            {
                return NotFound();
            }
            _context.Books.Remove(getBook);
            await _context.SaveChangesAsync();

            return Ok("Book Deleted Successfully");
        }
    }
}
