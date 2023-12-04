using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Marketing
{
    public class li_TeritoryBudgetTransfer
    {
        public string RefNo { get; set; }
        public int DoDesId { get; set; }
        public string FromTeritoryID { get; set; }
        public string ToTeritoryID { get; set; }
        public decimal TransferAmount { get; set; }
        public DateTime TransferDate { get; set; }
        public decimal FromTeritoryBudget { get; set; }
        public decimal ToTeritoryBudget { get; set; }
        public string AgrYear { get; set; }
    }
}
