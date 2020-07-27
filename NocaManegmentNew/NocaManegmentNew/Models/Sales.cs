using System;
using System.Collections.Generic;

namespace NocaManegmentNew.Models
{
    public partial class Sales
    {
        public Sales()
        {
            SaleProducts = new HashSet<SaleProducts>();
        }

        public int Id { get; set; }
        public int? LogId { get; set; }
        public int BasketId { get; set; }
        public DateTime Tdate { get; set; }
        public short Coeff { get; set; }

        public virtual Baskets Basket { get; set; }
        public virtual OperationLog Log { get; set; }
        public virtual ICollection<SaleProducts> SaleProducts { get; set; }
    }
}
