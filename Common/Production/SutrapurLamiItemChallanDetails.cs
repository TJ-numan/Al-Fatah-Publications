using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Production
{
   public class SutrapurLamiItemChallanDetails
    {
       public String ChallanID { get; set; }
        public String TypeId { get; set; }
        public String SizeID { get; set; }
        public Decimal Quantity { get; set; }
        public String UnitMeasure { get; set; }
        public Decimal UnitPrice { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Status_D { get; set; }
        public string CauseOfDelete { get; set; }
    }
}
