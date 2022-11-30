using System;
using System.Collections.Generic;

namespace BookManagment.Models
{
    public partial class BookCategory
    {
        public BookCategory()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public  ICollection<Book>? Books { get; set; }
    }
}
