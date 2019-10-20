using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GroupProjectDonation272.Models.Core
{
    public class SponsorType
    {
        public SponsorType()
        {
           Sponsors = new List<Sponsor>();
        }
        public int Id { get; set; }
        [Display(Name="Stationary Type Name")]
        public string Name { get; set; }
        public virtual List<Sponsor> Sponsors { get; set; }



    }
}