using AuthorAndBook.Application.Services;
using AuthorAndBook.Core.DTOs.AuthorDTO;
using AuthorAndBook.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.Metrics;

namespace AuthorAndBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService;
        public AuthorController(AuthorService author)
        {
            _authorService = author;
        }

        // GET: api/authors
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }

        // ST: api/authors
        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AddAuthorDTO author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (author == null)
            {
                return BadRequest("Author cannot be null.");
            }

            await _authorService.AddAuthorAsync(author);
            return CreatedAtAction(nameof(GetAuthors), new { }, author);
        }      


    }
}