using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Marketing;
using DAL.Marketing;

namespace BLL.Marketing
{
    public class Li_CategoryManager
    {
        public static List<li_Category> GetAllCategories()
        {
            SqlLi_CategoryProvider categoryProvider = new SqlLi_CategoryProvider();
           return categoryProvider.GetAllCategories();
        }
    }
}
