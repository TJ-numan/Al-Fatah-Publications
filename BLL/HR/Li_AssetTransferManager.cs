using Common.HR;
using DAL.HR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.HR
{
   public class Li_AssetTransferManager
    {
       public static int InsertLi_AssetTransfer(li_AssetTransfer li_AssetTrsf)
       {
           SqlLi_AssetTransferProvider sqlLi_AssettransferProvider = new SqlLi_AssetTransferProvider();
           return sqlLi_AssettransferProvider.InsertLi_AssetTransfer(li_AssetTrsf);
       }

       public static DataTable GetAssetInfoForTransferByAssetCode(string AssetCode)
       {
           DataTable dt = new DataTable();
           SqlLi_AssetTransferProvider sqlLi_AssetListProvider = new SqlLi_AssetTransferProvider();
           dt = sqlLi_AssetListProvider.GetAssetInfoForTransferByAssetCode(AssetCode);
           return dt;
       }
    }
}
