﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GroupProjectDonation272.Models.Core.Operations
{
    public class OfferStationary
    {
        public int Id { get; set; }


        [Required]
        [Display(Name = "Donation Date")]
        public DateTime DonationDate { get; set; }

        [Display(Name = "Center")]
        public int CenterId { get; set; }
        public virtual Center Center { get; set; }



        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int StationaryDonationId { get; set; }
        public virtual StationaryDonation StationaryDonation { get; set; }

        [Display(Name = "Donee")]
        public int DoneeId { get; set; }
        public virtual Donee Donee { get; set; }
    }
}