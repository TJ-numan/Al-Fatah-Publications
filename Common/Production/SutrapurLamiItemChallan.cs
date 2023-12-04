using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Production
{
   public class SutrapurLamiItemChallan
    {
        public string ChallanID { get; set; }
        public string RefNo { get; set; }
        public string PartyID { get; set; }
        public DateTime ChallanDate { get; set; }
        public Decimal TotalAmount { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Char Status_D { get; set; }
        public string CauseOfDelete { get; set; }
    }
}
