using Common.Marketing;
using DAL.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL.Marketing
{
    public class li_DonPaymentReturnManager
    {
        public li_DonPaymentReturnManager()
        { }
        public static int InsertLi_DonPaymentShedule(li_DonPaymentReturn li_donPaymentReturn)
        {
            SqlLi_DonPaymentReturnProvider sqlLi_DonPaymentReturnProvider = new SqlLi_DonPaymentReturnProvider();
            return sqlLi_DonPaymentReturnProvider.InsertLi_DonPaymentReturn(li_donPaymentReturn);
        }

        public static DataSet GetDonationPaymentReturn(int DetId, int DoDesId)
        {
            SqlLi_DonPaymentReturnProvider sqlLi_DonPaymentReturnProvider = new SqlLi_DonPaymentReturnProvider();
            return sqlLi_DonPaymentReturnProvider.GetDonationPaymentReturn(DetId, DoDesId);
        }
    }
}
