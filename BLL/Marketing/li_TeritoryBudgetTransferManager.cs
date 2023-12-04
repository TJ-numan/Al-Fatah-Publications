using Common.Marketing;
using DAL.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL.Marketing
{
   public class li_TeritoryBudgetTransferManager
    {
       public static String InsertLi_TeritoryBudgetTransfer(li_TeritoryBudgetTransfer teritorybudget)
       {
           SqlLi_TeritoryBudgetTransferProvider sqlLi_TerBudgetTransfer = new SqlLi_TeritoryBudgetTransferProvider();
           return sqlLi_TerBudgetTransfer.InsertLi_TeritoryBudgetTransfer(teritorybudget);
       }

       public static DataSet Get_DonationTeritoryWiseBudget(string TeritoryId, int DoDesId, string AgrYear)
       {
           SqlLi_TeritoryBudgetTransferProvider sqlLi_TerBudgetTransfer = new SqlLi_TeritoryBudgetTransferProvider();
           return  sqlLi_TerBudgetTransfer.Get_DonationTeritoryWiseBudget(TeritoryId,DoDesId,AgrYear);
       }
       public static DataSet Get_DonationTeritoryWiseBudget_Paid(string TeritoryId, int DoDesId, string AgrYear)
       {
           SqlLi_TeritoryBudgetTransferProvider sqlLi_TerBudgetTransfer = new SqlLi_TeritoryBudgetTransferProvider();
           return  sqlLi_TerBudgetTransfer.Get_DonationTeritoryWiseBudget_Paid(TeritoryId,DoDesId, AgrYear);
       }
    }
}
