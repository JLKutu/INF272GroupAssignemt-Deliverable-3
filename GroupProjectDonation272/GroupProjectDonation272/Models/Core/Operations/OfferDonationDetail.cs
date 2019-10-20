using System.ComponentModel.DataAnnotations;

namespace SDG_Education.Models.Core.Operations
{
    public class OfferDonationDetail
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public int Quantity { get; set; }


        //Relationships
        public int? StationaryId { get; set; } //nullable
        public virtual Stationary Stationary { get; set; }
        public int? BookId { get; set; } //nullable
        public virtual Book Book { get; set; }
        public int OfferDonationId { get; set; }
        public virtual OfferDonation OfferDonation { get; set; }
    }
}