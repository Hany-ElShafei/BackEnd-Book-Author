using AuthorAndBook.Core.DTOs.AuthorDTO;
using AuthorAndBook.Core.DTOs.BookDTO;
using AuthorAndBook.Core.Entities;
using AuthorAndBook.Core.Interfeces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAndBook.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;


        public IRepository<Author, AuthorDTO, AddAuthorDTO> Author { get; private set; }

        public IRepository<Book, BookDTO, AddBookDTO> Book { get; private set; }

        public UnitOfWork(
            AppDbContext appDbContext,
            IRepository<Author, AuthorDTO, AddAuthorDTO> author,
            IRepository<Book, BookDTO, AddBookDTO> book

            )
        {
            _context = appDbContext;
            Author = author;
            Book = book;
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
