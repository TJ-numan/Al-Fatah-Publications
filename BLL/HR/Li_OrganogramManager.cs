using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_OrganogramManager
{
	public Li_OrganogramManager()
	{
	}

    public static List<Li_Organogram> GetAllLi_Organograms()
    {
        List<Li_Organogram> li_Organograms = new List<Li_Organogram>();
        SqlLi_OrganogramProvider sqlLi_OrganogramProvider = new SqlLi_OrganogramProvider();
        li_Organograms = sqlLi_OrganogramProvider.GetAllLi_Organograms();
        return li_Organograms;
    }


    public static Li_Organogram GetLi_OrganogramByID(int id)
    {
        Li_Organogram li_Organogram = new Li_Organogram();
        SqlLi_OrganogramProvider sqlLi_OrganogramProvider = new SqlLi_OrganogramProvider();
        li_Organogram = sqlLi_OrganogramProvider.GetLi_OrganogramByID(id);
        return li_Organogram;
    }


    public static int InsertLi_Organogram(Li_Organogram li_Organogram)
    {
        SqlLi_OrganogramProvider sqlLi_OrganogramProvider = new SqlLi_OrganogramProvider();
        return sqlLi_OrganogramProvider.InsertLi_Organogram(li_Organogram);
    }


    public static bool UpdateLi_Organogram(Li_Organogram li_Organogram)
    {
        SqlLi_OrganogramProvider sqlLi_OrganogramProvider = new SqlLi_OrganogramProvider();
        return sqlLi_OrganogramProvider.UpdateLi_Organogram(li_Organogram);
    }

    public static bool DeleteLi_Organogram(int li_OrganogramID)
    {
        SqlLi_OrganogramProvider sqlLi_OrganogramProvider = new SqlLi_OrganogramProvider();
        return sqlLi_OrganogramProvider.DeleteLi_Organogram(li_OrganogramID);
    }
}
