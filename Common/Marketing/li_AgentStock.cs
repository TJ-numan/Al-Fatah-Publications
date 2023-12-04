using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Marketing
{
   public class li_AgentStock
   {
       public string BookAcCode { get; set; }
       public string LibraryID { get; set; }
       public int StockQty { get; set; }
       public int StockApproveQty { get; set; }
       public int StockProjectID { get; set; }
       public int StockProjectBookID { get; set; }
       public int CreatedBy { get; set; }
       public DateTime CreatedDate { get; set; }
       public int ModifiedBy { get; set; }
       public DateTime ModifiedDate { get; set; }
       public int ApprovedBy { get; set; }
       public DateTime ApprovedDate { get; set; }

    }
}
