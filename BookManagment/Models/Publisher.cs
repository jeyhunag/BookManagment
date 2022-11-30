using System;
using System.Collections.Generic;

namespace BookManagment.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Book>? Books { get; set; }
    }
}
