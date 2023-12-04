using Common.Marketing;
using DAL.Marketing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Marketing
{
   public class li_DonLetterPaymentManager
    {
       public static int InsertLi_DonLetterPayment(Li_DonLetterPayment li_DonLetterPayment)
       {
           li_DonLetterPaymentProvider sqlLi_DonProvider = new li_DonLetterPaymentProvider();
           return sqlLi_DonProvider.InsertLi_DonLetterPayment(li_DonLetterPayment);
       }
    }
}
