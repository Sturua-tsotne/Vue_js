using System;
using System.Collections.Generic;

namespace NocaManegmentNew.Models
{
    public partial class Products
    {
        public Products()
        {
            SaleProducts = new HashSet<SaleProducts>();
            Shelfes = new HashSet<Shelfes>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public bool IsWeight { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<SaleProducts> SaleProducts { get; set; }
        public virtual ICollection<Shelfes> Shelfes { get; set; }
    }
}
