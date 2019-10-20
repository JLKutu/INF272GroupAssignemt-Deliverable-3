using System.Collections.Generic;
using SDG_Education.Models.Core;

namespace SDG_Education.ViewModels
{
    public class StationaryViewModel
    {
        public Stationary Stationary { get; set; }
        public List<StationaryType> StationaryTypes { get; set; }
    }
}