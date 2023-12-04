using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Marketing;
using DAL.Marketing;

namespace BLL.Marketing
{
    public class li_DepositInformationManager
    {
        public static List<li_DepositInformation> GetDepositInformationByMRno(string memoNo)
        {
           Sqlli_DepositInformationProvider aDepositInformationProvider = new Sqlli_DepositInformationProvider();
           return aDepositInformationProvider.GetDepositInformationByMRno(memoNo);
        }

        public static List<li_DepositInformation> GetDepositInformationByMRno_Q(string memoNo)
        {
            Sqlli_DepositInformationProvider aDepositInformationProvider = new Sqlli_DepositInformationProvider();
            return aDepositInformationProvider.GetDepositInformationByMRno_Q(memoNo);
        }


    }
}
