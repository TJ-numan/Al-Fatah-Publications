using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Marketing
{
    public class li_Payment
    {
        public int PaySl { get; set; }
        public DateTime PayDate { get; set; }
        public string LibraryID { get; set; }
        public int PayforID { get; set; }
        public string BankID { get; set; }

        public string AcNo { get; set; }
        public int TransactionID { get; set; }
        public string Branch { get; set; }
        public decimal Amount { get; set; }

        public int CreateBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public Char Statud_d { get; set; }

        public string CauseOfDel { get; set; }
        public int DelBy { get; set; }
    }
}
