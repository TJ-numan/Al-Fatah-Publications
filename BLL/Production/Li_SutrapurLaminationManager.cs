using Common.Production;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Production
{
  public  class Li_SutrapurLaminationManager
    {
      public Li_SutrapurLaminationManager()
      {
      }
      public static DataSet GetAllLi_LemiSupplyPartyInfo()
      {
          Li_SutrapurLaminationProvider sqlLi_LeminatioPartyInfoProvider = new Li_SutrapurLaminationProvider();
          return sqlLi_LeminatioPartyInfoProvider.GetAllLi_LemiSupplyPartyInfo();

      }

      public static DataSet GetAllLi_LemiSizeBasics()
      {
          Li_SutrapurLaminationProvider sqlLi_LeminatioPartyInfoProvider = new Li_SutrapurLaminationProvider();
          return sqlLi_LeminatioPartyInfoProvider.GetAllLi_LemiSizeBasics();

      }

      public static String InsertLi_SutrapurLaminationGodownReceive(SutrapurLamination SutrapurLamiGodownRcv)
      {
          Li_SutrapurLaminationProvider proSutrapurLamiGodownRcv = new Li_SutrapurLaminationProvider();
          return proSutrapurLamiGodownRcv.InsertLi_SutrapurLaminationGodownReceive(SutrapurLamiGodownRcv);
      }

      public static int InsertLi_SutrapurLaminationGodownReceiveDetails(SutrapurLaminationDetails SutrapurLamiGodownRcvDet)
      {
          Li_SutrapurLaminationProvider proSutrapurLamiGodownRcvDet = new Li_SutrapurLaminationProvider();
          return proSutrapurLamiGodownRcvDet.InsertLi_SutrapurLaminationGodownReceiveDetails(SutrapurLamiGodownRcvDet);
      }

      public static String InsertLi_SutrapurLaminationItemChallan(SutrapurLamiItemChallan SutrapurLamiItemChallan)
      {
          Li_SutrapurLaminationProvider proSutrapurLamiGodownRcv = new Li_SutrapurLaminationProvider();
          return proSutrapurLamiGodownRcv.InsertLi_SutrapurLaminationItemChallan(SutrapurLamiItemChallan);
      }


      public static int InsertLi_SutrapurLaminationItemChallanDetails(SutrapurLamiItemChallanDetails SutrapurLamiItemChallanDet)
      {
          Li_SutrapurLaminationProvider proSutrapurLamiGodownRcvDet = new Li_SutrapurLaminationProvider();
          return proSutrapurLamiGodownRcvDet.InsertLi_SutrapurLaminationItemChallanDetails(SutrapurLamiItemChallanDet);
      }

    }
}
