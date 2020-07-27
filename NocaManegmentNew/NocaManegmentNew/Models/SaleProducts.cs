using System;
using System.Collections.Generic;

namespace NocaManegmentNew.Models
{
    public partial class SaleProducts
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int ShelfId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual Products Product { get; set; }
        public virtual Sales Sale { get; set; }
        public virtual Shelfes Shelf { get; set; }
    }
}
