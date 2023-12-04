using Common;
using Common.Marketing;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Marketing
{
   public class Li_DonLetterManager
    {
       public static string InsertLi_DonBasicLetter(Li_DonBasicLetter donBasicLetter)
       {
           SqlLi_DonLetterProvider sqlLi_DonLetterProvider = new SqlLi_DonLetterProvider();
           return sqlLi_DonLetterProvider.InsertLi_DonBasicLetter(donBasicLetter);
       }
       public static int InsertLi_DonLetterDetail(Li_DonLetter Li_DonLetter)
       {
           SqlLi_DonLetterProvider sqlLi_DonLetterProvider = new SqlLi_DonLetterProvider();
           return sqlLi_DonLetterProvider.InsertLi_DonLetterDetail(Li_DonLetter);
       }
    }
}
