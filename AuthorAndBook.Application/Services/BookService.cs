using AuthorAndBook.Core.DTOs.BookDTO;
using AuthorAndBook.Core.Entities;
using AuthorAndBook.Core.Interfeces;
using AuthorAndBook.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAndBook.Application.Services
{
    public class BookService
    {

        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
        {
            return await _unitOfWork.Book.GetAllAsync();
        }

        public async Task<IEnumerable<BookDTO?>> GetAllLatestBooksAsync()
        {
            return await _unitOfWork.Book.GetLatestAsync();
        }

        public async Task AddBookAsync(AddBookDTO bookDto)
        {
            await _unitOfWork.Book.AddAsync(bookDto);
            await _unitOfWork.Book.SaveChanges();
        }

        public async Task UpdateBookAsync(Book book)
        {
            await _unitOfWork.Book.UpdateAsync(book);
            await _unitOfWork.Book.SaveChanges();
        }

        public async Task DeleteBookAsync(Book book)
        {
            await _unitOfWork.Book.DeleteAsync(book);
            await _unitOfWork.Book.SaveChanges();
        }
    }
}
