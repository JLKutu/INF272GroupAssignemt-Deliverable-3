using System.Collections.Generic;
using GroupProjectDonation272.Models.Core;

namespace GroupProjectDonation272.ViewModels
{
    public class DetailsStationaryTypeViewModel
    {
        public StationaryType StationaryType { get; set; }
        public Stationary Stationary { get; set; }
        public List<Stationary> Stationaries { get; set; }
    }
}