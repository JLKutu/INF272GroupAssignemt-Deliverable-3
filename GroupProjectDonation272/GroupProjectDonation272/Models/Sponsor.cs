//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GroupProjectDonation272.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sponsor
    {
        public int SponsorID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string PhysicalAddress { get; set; }
        public int ContactNumber { get; set; }
        public System.DateTime DateOfDelivery { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual SponsorType SponsorType { get; set; }
    }
}
