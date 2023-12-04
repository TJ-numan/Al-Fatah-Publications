using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_LetterTemplateManager
{
	public Li_LetterTemplateManager()
	{
	}

    public static List<Li_LetterTemplate> GetAllLi_LetterTemplates()
    {
        List<Li_LetterTemplate> li_LetterTemplates = new List<Li_LetterTemplate>();
        SqlLi_LetterTemplateProvider sqlLi_LetterTemplateProvider = new SqlLi_LetterTemplateProvider();
        li_LetterTemplates = sqlLi_LetterTemplateProvider.GetAllLi_LetterTemplates();
        return li_LetterTemplates;
    }


    public static Li_LetterTemplate GetLi_LetterTemplateByID(int id)
    {
        Li_LetterTemplate li_LetterTemplate = new Li_LetterTemplate();
        SqlLi_LetterTemplateProvider sqlLi_LetterTemplateProvider = new SqlLi_LetterTemplateProvider();
        li_LetterTemplate = sqlLi_LetterTemplateProvider.GetLi_LetterTemplateByID(id);
        return li_LetterTemplate;
    }


    public static int InsertLi_LetterTemplate(Li_LetterTemplate li_LetterTemplate)
    {
        SqlLi_LetterTemplateProvider sqlLi_LetterTemplateProvider = new SqlLi_LetterTemplateProvider();
        return sqlLi_LetterTemplateProvider.InsertLi_LetterTemplate(li_LetterTemplate);
    }


    public static bool UpdateLi_LetterTemplate(Li_LetterTemplate li_LetterTemplate)
    {
        SqlLi_LetterTemplateProvider sqlLi_LetterTemplateProvider = new SqlLi_LetterTemplateProvider();
        return sqlLi_LetterTemplateProvider.UpdateLi_LetterTemplate(li_LetterTemplate);
    }

    public static bool DeleteLi_LetterTemplate(int li_LetterTemplateID)
    {
        SqlLi_LetterTemplateProvider sqlLi_LetterTemplateProvider = new SqlLi_LetterTemplateProvider();
        return sqlLi_LetterTemplateProvider.DeleteLi_LetterTemplate(li_LetterTemplateID);
    }
}
