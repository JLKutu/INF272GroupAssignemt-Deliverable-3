using System.Collections.Generic;

namespace SDG_Education.Models.Core
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