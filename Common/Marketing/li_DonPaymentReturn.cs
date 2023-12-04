using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Marketing
{
   public class li_DonPaymentReturn
    {
       public int Ret_ID { get; set; }
       public int DetId { get; set; }
       public int DoDesId  { get; set; }
       public decimal ReturnAmt { get; set; }
       public string CauseOfReturn { get; set; }
    }
}
