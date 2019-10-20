﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GroupProjectDonation272.Models.Core
{
    public class Center
    {
        public Center()
        {
            Employees = new List<Employee>();
            ReceiveDonations = new List<ReceiveDonation>();
            OfferDonations  = new List<OfferDonation>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Center Code")]
        public string Code { get; set; }
        [Display(Name = "Contact Number")]
        public string ContactNo { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 1000, ErrorMessage = "Address can not be more then 1000 characters")]
        public string Address { get; set; }

        //Relationships

        public int CenterTypeId { get; set; }
        public virtual CenterType CenterType { get; set; }

        public virtual List<Employee> Employees { get; set; }
        public virtual List<ReceiveDonation> ReceiveDonations { get; set; }
        public virtual List<OfferDonation> OfferDonations { get; set; }

    }
}