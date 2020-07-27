using System;
using System.Collections.Generic;

namespace NocaManegmentNew.Models
{
    public partial class Shelfes
    {
        public Shelfes()
        {
            SaleProducts = new HashSet<SaleProducts>();
        }

        public int Id { get; set; }
        public int CabinetId { get; set; }
        public int Num { get; set; }
        public int? ProductId { get; set; }

        public virtual Cabinets Cabinet { get; set; }
        public virtual Products Product { get; set; }
        public virtual ICollection<SaleProducts> SaleProducts { get; set; }
    }
}
