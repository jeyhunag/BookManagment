using System;
using System.Collections.Generic;

namespace BookManagment.Models
{
    public partial class BookAuthor
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public  Author Author { get; set; } = null!;
        public  Book Book { get; set; } = null!;
    }
}
