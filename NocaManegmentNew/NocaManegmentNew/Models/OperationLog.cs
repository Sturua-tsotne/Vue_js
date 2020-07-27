using System;
using System.Collections.Generic;

namespace NocaManegmentNew.Models
{
    public partial class OperationLog
    {
        public OperationLog()
        {
            Sales = new HashSet<Sales>();
        }

        public int Id { get; set; }
        public string JsonData { get; set; }

        public virtual ICollection<Sales> Sales { get; set; }
    }
}
