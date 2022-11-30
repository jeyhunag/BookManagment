using System;
using System.Collections.Generic;

namespace BookManagment.Models
{
    public partial class AuthorContact
    {
        public int Id { get; set; }
        public string ContactNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int AuthorId { get; set; }

        public  Author? Author { get; set; } = null!;
    }
}
