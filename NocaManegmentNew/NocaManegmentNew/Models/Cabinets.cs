using System;
using System.Collections.Generic;

namespace NocaManegmentNew.Models
{
    public partial class Cabinets
    {
        public Cabinets()
        {
            Shelfes = new HashSet<Shelfes>();
        }

        public int Id { get; set; }
        public int Num { get; set; }

        public virtual ICollection<Shelfes> Shelfes { get; set; }
    }
}
