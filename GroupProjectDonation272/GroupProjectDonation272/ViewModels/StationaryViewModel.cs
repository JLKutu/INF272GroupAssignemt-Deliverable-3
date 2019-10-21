using System.Collections.Generic;
using GroupProjectDonation272.Models.Core;

namespace GroupProjectDonation272.ViewModels
{
    public class StationaryViewModel
    {
        public Stationary Stationary { get; set; }
        public List<StationaryType> StationaryTypes { get; set; }
    }
}