using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SDG_Education.Models.Core.Operations
{
    /// <summary>
    /// Represents the donations given to Donees by the center
    /// </summary>
    public class OfferDonation
    {
        public OfferDonation()
        {
            OfferDonationDetails = new List<OfferDonationDetail>();
        }
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
        [Display(Name = "Reference")]
        public string OfferDonationReference { get; set; }

        [Required]
        [Display(Name = "Donation Date")]
        public DateTime DonationDate { get; set; }

        [Display(Name = "Center")]
        public int CenterId { get; set; }
        public virtual Center Center { get; set; }

      

        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }


        [Display(Name = "Donee")]
        public int DoneeId { get; set; }
        public virtual Donee Donee { get; set; }

        public virtual List<OfferDonationDetail> OfferDonationDetails { get; set; }
    }
}