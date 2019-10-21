using System.Collections.Generic;
using GroupProjectDonation272.Models.Core;


namespace SDG_Education.ViewModels
{
    public class StationaryViewModel
    {
        public Stationary Stationary { get; set; }
        public List<StationaryType> StationaryTypes { get; set; }
    }
}