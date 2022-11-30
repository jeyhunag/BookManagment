using System;
using System.Collections.Generic;

namespace BookManagment.Models
{
    public partial class Author
    {
        public Author()
        {
            AuthorContacts = new HashSet<AuthorContact>();
            BookAuthors = new HashSet<BookAuthor>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<AuthorContact>? AuthorContacts { get; set; }
        public virtual ICollection<BookAuthor>? BookAuthors { get; set; }
    }
}
