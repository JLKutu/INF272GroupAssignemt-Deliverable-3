using System.ComponentModel.DataAnnotations;

namespace GroupProjectDonation272.Models.Core.Operations
{
    public class BookDonation
    {
        public int Id { get; set; }

        [Display(Name = "Book Title")]
        public string BookTitle { get; set; }
        [Display(Name = "Book Author")]
        public string BookAuthor { get; set; }
        [Display(Name = "Book Publisher")]
        public string BookPublisher { get; set; }
        [Display(Name = "Publication Year")]
        public int BookPublicationYear { get; set; }
        public int Quantity { get; set; }


        [Display(Name = "Donation Status")]
        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 500, ErrorMessage = "Sorry Address can not more then 1000 characters")]
        public string Status { get; set; }

        [Display(Name = "Book Type")]
        public int BookTypeId { get; set; }
        public virtual BookType BookType { get; set; }
        [Display(Name = "Center")]
        public int CenterId { get; set; }
        public virtual Center Center { get; set; }
        [Display(Name = "Sponsor")]
        public int SponsorId { get; set; }
        public virtual Sponsor Sponsor { get; set; }

    }
}