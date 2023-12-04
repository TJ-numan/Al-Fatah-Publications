using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_QuestionTemplateManager
{
	public Li_QuestionTemplateManager()
	{
	}

    public static List<Li_QuestionTemplate> GetAllLi_QuestionTemplates()
    {
        List<Li_QuestionTemplate> li_QuestionTemplates = new List<Li_QuestionTemplate>();
        SqlLi_QuestionTemplateProvider sqlLi_QuestionTemplateProvider = new SqlLi_QuestionTemplateProvider();
        li_QuestionTemplates = sqlLi_QuestionTemplateProvider.GetAllLi_QuestionTemplates();
        return li_QuestionTemplates;
    }


    public static Li_QuestionTemplate GetLi_QuestionTemplateByID(int id)
    {
        Li_QuestionTemplate li_QuestionTemplate = new Li_QuestionTemplate();
        SqlLi_QuestionTemplateProvider sqlLi_QuestionTemplateProvider = new SqlLi_QuestionTemplateProvider();
        li_QuestionTemplate = sqlLi_QuestionTemplateProvider.GetLi_QuestionTemplateByID(id);
        return li_QuestionTemplate;
    }


    public static int InsertLi_QuestionTemplate(Li_QuestionTemplate li_QuestionTemplate)
    {
        SqlLi_QuestionTemplateProvider sqlLi_QuestionTemplateProvider = new SqlLi_QuestionTemplateProvider();
        return sqlLi_QuestionTemplateProvider.InsertLi_QuestionTemplate(li_QuestionTemplate);
    }


    public static bool UpdateLi_QuestionTemplate(Li_QuestionTemplate li_QuestionTemplate)
    {
        SqlLi_QuestionTemplateProvider sqlLi_QuestionTemplateProvider = new SqlLi_QuestionTemplateProvider();
        return sqlLi_QuestionTemplateProvider.UpdateLi_QuestionTemplate(li_QuestionTemplate);
    }

    public static bool DeleteLi_QuestionTemplate(int li_QuestionTemplateID)
    {
        SqlLi_QuestionTemplateProvider sqlLi_QuestionTemplateProvider = new SqlLi_QuestionTemplateProvider();
        return sqlLi_QuestionTemplateProvider.DeleteLi_QuestionTemplate(li_QuestionTemplateID);
    }
}
