﻿using System.Collections.Generic;

namespace SDG_Education.Models.Core
{
    public class StationaryType
    {
        public StationaryType()
        {
            Stationaries = new List<Stationary>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

     
        public virtual List<Stationary> Stationaries { get; set; }

    }
}