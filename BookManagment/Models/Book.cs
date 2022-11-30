using System;
using System.Collections.Generic;

namespace BookManagment.Models
{
    public partial class Book
    {
        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }

        public  BookCategory? Category { get; set; } 
        public  Publisher? Publisher { get; set; } 
        public  ICollection<BookAuthor>? BookAuthors { get; set; }
    }
}
