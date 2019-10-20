using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SDG_Education.Models.Core.Operations
{
    /// <summary>
    /// Represents the donations received by the center from sponsors
    /// </summary>
    public class ReceiveDonation
    {
        public ReceiveDonation()
        {
            ReceiveDonationDetails = new List<ReceiveDonationDetail>();
        }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        [Display(Name = "Reference")]
        public string ReceiveDonationReference { get; set; }

        [Required]
        [Display(Name = "Donation Date")]
        public DateTime DonationDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }


        [Display(Name = "Center")]
        public int CenterId { get; set; }
        public virtual Center Center { get; set; }

     

        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }


        [Display(Name = "Sponsor Name")]
        public int SponsorId { get; set; }
        public virtual Sponsor Sponsor { get; set; }

        public virtual List<ReceiveDonationDetail> ReceiveDonationDetails { get; set; }
    }
}