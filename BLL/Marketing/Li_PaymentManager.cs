using Common.Marketing;
using DAL.Marketing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Marketing
{
   public class Li_PaymentManager
    {
       public Li_PaymentManager()
       {}
       public static int InsertLi_Payments(li_Payment li_Payment)
       {
           SqlLi_PaymentProvider sqlLi_PaymentProvider = new SqlLi_PaymentProvider();
           int rowInsert= sqlLi_PaymentProvider.InsertLi_Payments(li_Payment);
          
           return rowInsert;
       }
       public static int InsertLi_CashPayments(li_Payment li_Payment)
       {
           SqlLi_PaymentProvider sqlLi_PaymentProvider = new SqlLi_PaymentProvider();
           int rowInsert = sqlLi_PaymentProvider.InsertLi_CashPayments(li_Payment);

           return rowInsert;
       }
    }
}
