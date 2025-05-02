using AuthorAndBook.Core.DTOs.AuthorDTO;
using AuthorAndBook.Core.DTOs.BookDTO;
using AuthorAndBook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAndBook.Core.Interfeces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Author, AuthorDTO, AddAuthorDTO> Author { get; }
        IRepository<Book, BookDTO, AddBookDTO> Book { get; }

        Task<int> SaveChangesAsync();
    }
}
