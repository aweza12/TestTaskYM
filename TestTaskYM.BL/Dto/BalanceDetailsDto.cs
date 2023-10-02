using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskYM.BL.Dto
{
    public class BalanceDetailsDto
    {
        public decimal Balance { get; set; }
        public decimal Available { get; set; }
        public string PaymentDue { get; set; }
        public string DailyPoints { get; set; }
    }
}
