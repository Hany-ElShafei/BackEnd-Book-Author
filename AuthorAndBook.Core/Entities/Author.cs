using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AuthorAndBook.Core.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string ImageAuthor { get; set; } = default!;
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; } = default!;

        // Navigation Property for Books
        public ICollection<Book> Books { get; set; } = default!;
    }
}
