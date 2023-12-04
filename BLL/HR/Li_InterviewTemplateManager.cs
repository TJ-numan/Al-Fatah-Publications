using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_InterviewTemplateManager
{
	public Li_InterviewTemplateManager()
	{
	}

    public static List<Li_InterviewTemplate> GetAllLi_InterviewTemplates()
    {
        List<Li_InterviewTemplate> li_InterviewTemplates = new List<Li_InterviewTemplate>();
        SqlLi_InterviewTemplateProvider sqlLi_InterviewTemplateProvider = new SqlLi_InterviewTemplateProvider();
        li_InterviewTemplates = sqlLi_InterviewTemplateProvider.GetAllLi_InterviewTemplates();
        return li_InterviewTemplates;
    }


    public static Li_InterviewTemplate GetLi_InterviewTemplateByID(int id)
    {
        Li_InterviewTemplate li_InterviewTemplate = new Li_InterviewTemplate();
        SqlLi_InterviewTemplateProvider sqlLi_InterviewTemplateProvider = new SqlLi_InterviewTemplateProvider();
        li_InterviewTemplate = sqlLi_InterviewTemplateProvider.GetLi_InterviewTemplateByID(id);
        return li_InterviewTemplate;
    }


    public static int InsertLi_InterviewTemplate(Li_InterviewTemplate li_InterviewTemplate)
    {
        SqlLi_InterviewTemplateProvider sqlLi_InterviewTemplateProvider = new SqlLi_InterviewTemplateProvider();
        return sqlLi_InterviewTemplateProvider.InsertLi_InterviewTemplate(li_InterviewTemplate);
    }


    public static bool UpdateLi_InterviewTemplate(Li_InterviewTemplate li_InterviewTemplate)
    {
        SqlLi_InterviewTemplateProvider sqlLi_InterviewTemplateProvider = new SqlLi_InterviewTemplateProvider();
        return sqlLi_InterviewTemplateProvider.UpdateLi_InterviewTemplate(li_InterviewTemplate);
    }

    public static bool DeleteLi_InterviewTemplate(int li_InterviewTemplateID)
    {
        SqlLi_InterviewTemplateProvider sqlLi_InterviewTemplateProvider = new SqlLi_InterviewTemplateProvider();
        return sqlLi_InterviewTemplateProvider.DeleteLi_InterviewTemplate(li_InterviewTemplateID);
    }
}
