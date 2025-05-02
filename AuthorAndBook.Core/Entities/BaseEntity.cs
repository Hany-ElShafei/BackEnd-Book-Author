using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAndBook.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; } = default!;
    }
}
