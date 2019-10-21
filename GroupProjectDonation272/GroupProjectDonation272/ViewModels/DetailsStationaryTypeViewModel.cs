using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupProjectDonation272.Models.Core;


namespace SDG_Education.ViewModels
{
    public class DetailsStationaryTypeViewModel
    {
        public StationaryType StationaryType { get; set; }
        public Stationary Stationary { get; set; }
        public List<Stationary> Stationaries { get; set; }
    }
}