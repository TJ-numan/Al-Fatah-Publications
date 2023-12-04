using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_GenderManager
{
	public Li_GenderManager()
	{
	}

    public static List<Li_Gender> GetAllLi_Genders()
    {
        List<Li_Gender> li_Genders = new List<Li_Gender>();
        SqlLi_GenderProvider sqlLi_GenderProvider = new SqlLi_GenderProvider();
        li_Genders = sqlLi_GenderProvider.GetAllLi_Genders();
        return li_Genders;
    }


    public static Li_Gender GetLi_GenderByID(int id)
    {
        Li_Gender li_Gender = new Li_Gender();
        SqlLi_GenderProvider sqlLi_GenderProvider = new SqlLi_GenderProvider();
        li_Gender = sqlLi_GenderProvider.GetLi_GenderByID(id);
        return li_Gender;
    }


    public static int InsertLi_Gender(Li_Gender li_Gender)
    {
        SqlLi_GenderProvider sqlLi_GenderProvider = new SqlLi_GenderProvider();
        return sqlLi_GenderProvider.InsertLi_Gender(li_Gender);
    }


    public static bool UpdateLi_Gender(Li_Gender li_Gender)
    {
        SqlLi_GenderProvider sqlLi_GenderProvider = new SqlLi_GenderProvider();
        return sqlLi_GenderProvider.UpdateLi_Gender(li_Gender);
    }

    public static bool DeleteLi_Gender(int li_GenderID)
    {
        SqlLi_GenderProvider sqlLi_GenderProvider = new SqlLi_GenderProvider();
        return sqlLi_GenderProvider.DeleteLi_Gender(li_GenderID);
    }
}
