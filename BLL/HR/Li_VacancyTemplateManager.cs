using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_VacancyTemplateManager
{
	public Li_VacancyTemplateManager()
	{
	}

    public static List<Li_VacancyTemplate> GetAllLi_VacancyTemplates()
    {
        List<Li_VacancyTemplate> li_VacancyTemplates = new List<Li_VacancyTemplate>();
        SqlLi_VacancyTemplateProvider sqlLi_VacancyTemplateProvider = new SqlLi_VacancyTemplateProvider();
        li_VacancyTemplates = sqlLi_VacancyTemplateProvider.GetAllLi_VacancyTemplates();
        return li_VacancyTemplates;
    }


    public static Li_VacancyTemplate GetLi_VacancyTemplateByID(int id)
    {
        Li_VacancyTemplate li_VacancyTemplate = new Li_VacancyTemplate();
        SqlLi_VacancyTemplateProvider sqlLi_VacancyTemplateProvider = new SqlLi_VacancyTemplateProvider();
        li_VacancyTemplate = sqlLi_VacancyTemplateProvider.GetLi_VacancyTemplateByID(id);
        return li_VacancyTemplate;
    }


    public static int InsertLi_VacancyTemplate(Li_VacancyTemplate li_VacancyTemplate)
    {
        SqlLi_VacancyTemplateProvider sqlLi_VacancyTemplateProvider = new SqlLi_VacancyTemplateProvider();
        return sqlLi_VacancyTemplateProvider.InsertLi_VacancyTemplate(li_VacancyTemplate);
    }


    public static bool UpdateLi_VacancyTemplate(Li_VacancyTemplate li_VacancyTemplate)
    {
        SqlLi_VacancyTemplateProvider sqlLi_VacancyTemplateProvider = new SqlLi_VacancyTemplateProvider();
        return sqlLi_VacancyTemplateProvider.UpdateLi_VacancyTemplate(li_VacancyTemplate);
    }

    public static bool DeleteLi_VacancyTemplate(int li_VacancyTemplateID)
    {
        SqlLi_VacancyTemplateProvider sqlLi_VacancyTemplateProvider = new SqlLi_VacancyTemplateProvider();
        return sqlLi_VacancyTemplateProvider.DeleteLi_VacancyTemplate(li_VacancyTemplateID);
    }
}
