using AuthorAndBook.Core.DTOs.AuthorDTO;
using AuthorAndBook.Core.Entities;
using AuthorAndBook.Core.Interfeces;
using AuthorAndBook.Infrastructure.Persistence.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAndBook.Application.Services
{
    public class AuthorService
    {
        private readonly IUnitOfWork _unotOfWork;

        public AuthorService(IUnitOfWork unotOfWork)
        {
            _unotOfWork = unotOfWork;
        }

        public async Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync() =>
                    await _unotOfWork.Author.GetAllAsync();



        public async Task AddAuthorAsync(AddAuthorDTO author)
        {
            await _unotOfWork.Author.AddAsync(author);
            await _unotOfWork.SaveChangesAsync();
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            await _unotOfWork.Author.UpdateAsync(author);
            await _unotOfWork.SaveChangesAsync();
        }

        public async Task DeleteAuthorAsync(Author author)
        {
            await _unotOfWork.Author.DeleteAsync(author);
            await _unotOfWork.SaveChangesAsync();
        }
    }
}
