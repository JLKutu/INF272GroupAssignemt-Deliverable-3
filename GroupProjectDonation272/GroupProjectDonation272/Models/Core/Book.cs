using System.Collections.Generic;
using GroupProjectDonation272.Models.Core.Operations;

namespace GroupProjectDonation272.Models.Core
{
    public class Book
    {
        public Book()
        {
            ReceiveDonationDetails = new List<ReceiveDonationDetail>();
            OfferDonationDetails = new List<OfferDonationDetail>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Edition { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }


        //Relationship
        public int BookTypeId { get; set; } //foreign key
        public virtual BookType BookType { get; set; } //navigation property

        public virtual List<ReceiveDonationDetail> ReceiveDonationDetails { get; set; }
        public virtual List<OfferDonationDetail> OfferDonationDetails { get; set; }


    }
}