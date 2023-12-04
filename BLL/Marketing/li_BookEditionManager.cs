using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace BLL.Marketing
{
   public class li_BookEditionManager
    {
       public static List<BookEdition> GetAllEdition()
       {
          SqlLi_EditionProvider aEditionProvider = new SqlLi_EditionProvider();
           return aEditionProvider.GetAllEdition();
       }
    }
}
