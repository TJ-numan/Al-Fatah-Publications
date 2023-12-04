using Common.Marketing;
using DAL.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Marketing
{
   public class li_PrimaryObservationManager
    {
       public static int InsertLi_PrimaryObservation(li_DonPrimaryObservation li_PrimaryObs)
       {
           li_PrimaryObservationProvider sqlLi_DonPrimaryObservationProvider = new li_PrimaryObservationProvider();
           return sqlLi_DonPrimaryObservationProvider.InsertLi_PrimaryObservation(li_PrimaryObs);
       }
       public static int InsertLi_DonInformarDetails(li_DonInformar li_DonInformar)
       {
           li_PrimaryObservationProvider sqlLi_DonPrimaryObservationProvider = new li_PrimaryObservationProvider();
           return sqlLi_DonPrimaryObservationProvider.InsertLi_DonInformarDetails(li_DonInformar);
       }

       public static DataSet GetDonationExisting_POR(string AgrNo, int DoFId, string AgYear)
       {
           li_PrimaryObservationProvider sqlLi_DonPrimaryObservationProvider = new li_PrimaryObservationProvider();
           return sqlLi_DonPrimaryObservationProvider.GetDonationExisting_POR(AgrNo, DoFId, AgYear);
       }

    }
}
