using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskYM.DL.Entities
{
    public class Balance : BaseDbModel
    {
        public int UserId { get; set; }
        public decimal Max { get; set; }
        public decimal Current { get; set; }
    }
}
