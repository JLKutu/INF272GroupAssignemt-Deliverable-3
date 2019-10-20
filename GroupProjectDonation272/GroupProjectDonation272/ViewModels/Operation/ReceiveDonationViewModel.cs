using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDG_Education.DAL;
using SDG_Education.Models.Core;
using SDG_Education.Models.Core.Operations;

namespace SDG_Education.ViewModels.Operation
{
    public class ReceiveDonationViewModel
    {
        public List<Employee> Employees { get; set; }
        public List<Center> Centers { get; set; }
        public List<Sponsor> Sponsors { get; set; }
        public ReceiveDonation ReceiveDonation { get; set; }

        public List<Book> Books { get; set; }
        public List<Stationary> Stationaries { get; set; }
        public Book Book { get; set; }
        public Stationary Stationary { get; set; }

        //public TYPE Type { get; set; }

    }
}