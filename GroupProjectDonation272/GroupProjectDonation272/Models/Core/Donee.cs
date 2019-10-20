using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GroupProjectDonation272.Models.Core
{
    public class Donee
    {
        public Donee()
        {
            OfferDonations = new List<OfferDonation>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [Display(Name = "Contact Number")]
        public string ContactNo { get; set; }

        [Required]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 1000, ErrorMessage = "Sorry Address can not more then 1000 characters")]
        public string Address { get; set; }

        public virtual List<OfferDonation> OfferDonations { get; set; }

    }
}