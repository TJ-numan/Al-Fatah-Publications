using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Marketing
{
    public class li_DepositInformation
    {

        public DateTime MRDate { get; set; }
        public DateTime DepositedDate { get; set; }      
        public DateTime ClearDate { get; set; }
        public string BankAddress { get; set; }
        public string BankSlipNo { get; set; }
        //public string BankName { get; set; }
        public string BankCode { get; set; }
        public decimal AmountOfMoney { get; set; }
        public string Remark { get; set; }
        public string VerifiedBy { get; set; }
        public string TranbType { get; set; }
        public int TrannID { get; set; }
        public int DepositForID { get; set; }
        public string LibraryName { get; set; }
        public string LibraryID { get; set; }

        public int AssetId { get; set; }

    }
}
