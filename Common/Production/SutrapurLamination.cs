using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Production
{
   public class SutrapurLamination
    {
       public string ReceivedID { get; set; }
       public string ReceiveMemo { get; set; }
       public string SupplierBillNo { get; set; }
       public string SupplierID { get; set; }
       public DateTime SupplyDate { get; set; }
       public DateTime RcvDate { get; set; }
       public Decimal TotalAmount { get; set; }
       public string Remarks { get; set; }
       public int CreatedBy { get; set; }
       public DateTime CreatedDate { get; set; }
       public int ModifiedBy { get; set; }
       public DateTime ModifiedDate { get; set; }
       public Char Status_D { get; set; }
       public bool IsPaid { get; set; }
       
    }
}
