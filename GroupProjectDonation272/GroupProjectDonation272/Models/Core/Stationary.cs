using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GroupProjectDonation272.Models.Core.Operations;

namespace GroupProjectDonation272.Models.Core
{
    public class Stationary
    {
        public Stationary()
        {
            ReceiveDonationDetails = new List<ReceiveDonationDetail>();
            OfferDonationDetails = new List<OfferDonationDetail>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        //Relationship
        [Display(Name = "Stationary Type Name")]
        public int StationaryTypeId { get; set; }
        public virtual StationaryType StationaryType { get; set; }

        public virtual List<ReceiveDonationDetail> ReceiveDonationDetails { get; set; }
        public virtual List<OfferDonationDetail> OfferDonationDetails { get; set; }

    }
}