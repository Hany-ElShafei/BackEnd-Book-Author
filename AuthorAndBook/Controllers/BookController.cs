using AuthorAndBook.Application.Services;
using AuthorAndBook.Core.DTOs.BookDTO;
using AuthorAndBook.Core.Entities;
using AuthorAndBook.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace AuthorAndBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;
        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var authors = await _bookService.GetAllBooksAsync();
            return Ok(authors);
        }

        // GET: api/ Latest Books
        [HttpGet("GetLatestBooks")]
        public async Task<IActionResult> GetLatestBooks()
        {
            var books = await _bookService.GetAllLatestBooksAsync();

            if (books == null)
                return BadRequest("No Book!");

            return Ok(books);
        }

        // ST: api/authors
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] AddBookDTO book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (book == null)
            {
                return BadRequest("Country cannot be null.");
            }

            await _bookService.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBooks), new { }, book);
        }
    }
}
