using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskYM.DL.Entities
{
    public class Transaction : BaseDbModel
    {
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public bool isPending { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string AuthorizedUser { get; set; }
        public string Icon { get; set; }
    }
}
