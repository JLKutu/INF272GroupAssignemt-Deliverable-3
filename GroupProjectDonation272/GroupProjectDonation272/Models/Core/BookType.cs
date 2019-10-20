
using System.Collections.Generic;

namespace GroupProjectDonation272.Models.Core
{
    public class BookType
    {
        public BookType()
        {
           Books = new List<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        //BookType has a collection of books, one book type has many books associated with it
        public virtual List<Book> Books { get; set; }

    }
}