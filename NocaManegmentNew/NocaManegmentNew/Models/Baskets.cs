using System;
using System.Collections.Generic;

namespace NocaManegmentNew.Models
{
    public partial class Baskets
    {
        public Baskets()
        {
            Sales = new HashSet<Sales>();
        }

        public int Id { get; set; }
        public int Num { get; set; }

        public virtual ICollection<Sales> Sales { get; set; }
    }
}
