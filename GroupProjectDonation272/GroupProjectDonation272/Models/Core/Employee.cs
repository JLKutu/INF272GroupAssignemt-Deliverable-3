using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GroupProjectDonation272.Models.Core
{
    public class Employee
    {
        public Employee()
        {
            OfferDonations = new List<OfferDonation>();
            ReceiveDonations= new List<ReceiveDonation>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
       
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        public string Code { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        public string ContactNo { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 1000, ErrorMessage = "Sorry Address can not more then 1000 characters")]
        public string Address { get; set; }

        public int CenterId { get; set; }
        public virtual Center Center { get; set; }

        public virtual List<OfferDonation> OfferDonations { get; set; }
        public virtual List<ReceiveDonation> ReceiveDonations { get; set; }
    }
}