using AuthorAndBook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAndBook.Core.DTOs.AuthorDTO
{
    public class AuthorDTO : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string ImageAuthor { get; set; } = default!;
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; } = default!;
    }
}
