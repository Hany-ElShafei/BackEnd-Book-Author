using AuthorAndBook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAndBook.Core.DTOs.BookDTO
{
    public class BookDTO : BaseEntity
    {
        public string Title { get; set; } = default!;
        public string ImageBook { get; set; } = default!;
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; } = default!;
        public decimal Price { get; set; }
        public int Pages { get; set; }
        public string Category { get; set; } = default!;

        // Foreign Key for Author
        public int AuthorId { get; set; }
    }
}
