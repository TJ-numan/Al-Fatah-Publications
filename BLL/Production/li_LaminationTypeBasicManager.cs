using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_LaminationTypeBasicManager
{
	public Li_LaminationTypeBasicManager()
	{
	}

    public static List<Li_LaminationTypeBasic> GetAllLi_LaminationTypeBasics()
    {
        List<Li_LaminationTypeBasic> li_LaminationTypeBasics = new List<Li_LaminationTypeBasic>();
        SqlLi_LaminationTypeBasicProvider sqlLi_LaminationTypeBasicProvider = new SqlLi_LaminationTypeBasicProvider();
        li_LaminationTypeBasics = sqlLi_LaminationTypeBasicProvider.GetAllLi_LaminationTypeBasics();
        return li_LaminationTypeBasics;
    }


    public static Li_LaminationTypeBasic GetLi_LaminationTypeBasicByID(int id)
    {
        Li_LaminationTypeBasic li_LaminationTypeBasic = new Li_LaminationTypeBasic();
        SqlLi_LaminationTypeBasicProvider sqlLi_LaminationTypeBasicProvider = new SqlLi_LaminationTypeBasicProvider();
        li_LaminationTypeBasic = sqlLi_LaminationTypeBasicProvider.GetLi_LaminationTypeBasicByID(id);
        return li_LaminationTypeBasic;
    }


    public static string  InsertLi_LaminationTypeBasic(Li_LaminationTypeBasic li_LaminationTypeBasic)
    {
        SqlLi_LaminationTypeBasicProvider sqlLi_LaminationTypeBasicProvider = new SqlLi_LaminationTypeBasicProvider();
        return sqlLi_LaminationTypeBasicProvider.InsertLi_LaminationTypeBasic(li_LaminationTypeBasic);
    }


    public static bool UpdateLi_LaminationTypeBasic(Li_LaminationTypeBasic li_LaminationTypeBasic)
    {
        SqlLi_LaminationTypeBasicProvider sqlLi_LaminationTypeBasicProvider = new SqlLi_LaminationTypeBasicProvider();
        return sqlLi_LaminationTypeBasicProvider.UpdateLi_LaminationTypeBasic(li_LaminationTypeBasic);
    }

    public static bool DeleteLi_LaminationTypeBasic(int li_LaminationTypeBasicID)
    {
        SqlLi_LaminationTypeBasicProvider sqlLi_LaminationTypeBasicProvider = new SqlLi_LaminationTypeBasicProvider();
        return sqlLi_LaminationTypeBasicProvider.DeleteLi_LaminationTypeBasic(li_LaminationTypeBasicID);
    }
}
