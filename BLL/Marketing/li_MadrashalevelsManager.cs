using Common.Marketing;
using DAL.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL.Marketing
{
   public class li_MadrashalevelsManager
    {
       public li_MadrashalevelsManager()
        { 
        }
        public static List<Li_Level> GetAllLi_MadrashaLevels()
        {
            List<Li_Level> li_levels = new List<Li_Level>();
            Sql_Madrasha_Provider sqlLi_levelProvider = new Sql_Madrasha_Provider();
            li_levels = sqlLi_levelProvider.GetAllMadrasha_Level();
            return li_levels;
        }

        public static DataSet Get_LiMadrasah_Somitee_AgrNo(string AgrYear,string AgrNo)
        {
            Sql_Madrasha_Provider sqlLi_MadrashaSomitee = new Sql_Madrasha_Provider();
            return sqlLi_MadrashaSomitee.Get_LiMadrasah_SomiteeBy_AgrNo(AgrYear,AgrNo);
        }
    }
}
