using System.Collections.Generic;

namespace GroupProjectDonation272.Models.Core
{
    public class CenterType
    {
        public CenterType()
        {
            Centers = new List<Center>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Center> Centers { get; set; }
    }
}