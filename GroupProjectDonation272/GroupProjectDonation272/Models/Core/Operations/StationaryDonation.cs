using System.ComponentModel.DataAnnotations;

namespace GroupProjectDonation272.Models.Core.Operations
{
    public class StationaryDonation
    {

        public int Id { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Stationary Description")]
        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 1000, ErrorMessage = "Sorry Address can not more then 1000 characters")]
        public string Description { get; set; }

        [Display(Name = "Donation Status")]
        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 500, ErrorMessage = "Sorry Address can not more then 1000 characters")]
        public string Status { get; set; }
        [Display(Name = "Stationary Type")]
        public int StationaryTypeId { get; set; }
        public virtual StationaryType StationaryType { get; set; }
        [Display(Name = "Center")]
        public int CenterId { get; set; }
        public virtual Center Center { get; set; }
        [Display(Name = "Sponsor")]
        public int SponsorId { get; set; }
        public virtual Sponsor Sponsor { get; set; }
    }
}