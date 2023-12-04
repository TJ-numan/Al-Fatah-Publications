using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_VacancyRequisitionManager
{
	public Li_VacancyRequisitionManager()
	{
	}

    public static List<Li_VacancyRequisition> GetAllLi_VacancyRequisitions()
    {
        List<Li_VacancyRequisition> li_VacancyRequisitions = new List<Li_VacancyRequisition>();
        SqlLi_VacancyRequisitionProvider sqlLi_VacancyRequisitionProvider = new SqlLi_VacancyRequisitionProvider();
        li_VacancyRequisitions = sqlLi_VacancyRequisitionProvider.GetAllLi_VacancyRequisitions();
        return li_VacancyRequisitions;
    }


    public static Li_VacancyRequisition GetLi_VacancyRequisitionByID(int id)
    {
        Li_VacancyRequisition li_VacancyRequisition = new Li_VacancyRequisition();
        SqlLi_VacancyRequisitionProvider sqlLi_VacancyRequisitionProvider = new SqlLi_VacancyRequisitionProvider();
        li_VacancyRequisition = sqlLi_VacancyRequisitionProvider.GetLi_VacancyRequisitionByID(id);
        return li_VacancyRequisition;
    }


    public static int InsertLi_VacancyRequisition(Li_VacancyRequisition li_VacancyRequisition)
    {
        SqlLi_VacancyRequisitionProvider sqlLi_VacancyRequisitionProvider = new SqlLi_VacancyRequisitionProvider();
        return sqlLi_VacancyRequisitionProvider.InsertLi_VacancyRequisition(li_VacancyRequisition);
    }


    public static bool UpdateLi_VacancyRequisition(Li_VacancyRequisition li_VacancyRequisition)
    {
        SqlLi_VacancyRequisitionProvider sqlLi_VacancyRequisitionProvider = new SqlLi_VacancyRequisitionProvider();
        return sqlLi_VacancyRequisitionProvider.UpdateLi_VacancyRequisition(li_VacancyRequisition);
    }

    public static bool DeleteLi_VacancyRequisition(int li_VacancyRequisitionID)
    {
        SqlLi_VacancyRequisitionProvider sqlLi_VacancyRequisitionProvider = new SqlLi_VacancyRequisitionProvider();
        return sqlLi_VacancyRequisitionProvider.DeleteLi_VacancyRequisition(li_VacancyRequisitionID);
    }
}
