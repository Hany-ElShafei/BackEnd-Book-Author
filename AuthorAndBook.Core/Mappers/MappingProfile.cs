using AuthorAndBook.Core.DTOs.AuthorDTO;
using AuthorAndBook.Core.DTOs.BookDTO;
using AuthorAndBook.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAndBook.Core.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Book DTO
            CreateMap<Book, BookDTO>();
            CreateMap<Book, AddBookDTO>().ReverseMap();

            // Author DTO
            CreateMap<Author, AuthorDTO>();
            CreateMap<Author, AddAuthorDTO>().ReverseMap();
        }
    }
}
