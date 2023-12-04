using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.MIS;
using DAL.MIS;

namespace BLL.MIS
{
    public class Li_FormListManager
    {
        public static List<li_Form> GetAllForm()
        {
            SqlLi_FormListProvider formList = new SqlLi_FormListProvider();
            return formList.GetAllForm();
        }
    }
}
