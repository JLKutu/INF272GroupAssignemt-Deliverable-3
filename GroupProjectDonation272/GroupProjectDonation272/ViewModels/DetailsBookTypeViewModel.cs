using System.Collections.Generic;
using GroupProjectDonation272.Models.Core;


namespace SDG_Education.ViewModels
{
    public class DetailsBookTypeViewModel
    {
        public BookType BookType { get; set; }
        public Book Book { get; set; }
        public List<Book> Books { get; set; }
    }
}