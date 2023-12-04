using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpLanguageManager
{
    public Li_EmpLanguageManager()
    {
    }

    public static List<Li_EmpLanguage> GetAllLi_EmpLanguages()
    {
        List<Li_EmpLanguage> li_EmpLanguages = new List<Li_EmpLanguage>();
        SqlLi_EmpLanguageProvider sqlLi_EmpLanguageProvider = new SqlLi_EmpLanguageProvider();
        li_EmpLanguages = sqlLi_EmpLanguageProvider.GetAllLi_EmpLanguages();
        return li_EmpLanguages;
    }


    public static Li_EmpLanguage GetLi_EmpLanguageByID(int id)
    {
        Li_EmpLanguage li_EmpLanguage = new Li_EmpLanguage();
        SqlLi_EmpLanguageProvider sqlLi_EmpLanguageProvider = new SqlLi_EmpLanguageProvider();
        li_EmpLanguage = sqlLi_EmpLanguageProvider.GetLi_EmpLanguageByID(id);
        return li_EmpLanguage;
    }


    public static int InsertLi_EmpLanguage(Li_EmpLanguage li_EmpLanguage)
    {
        SqlLi_EmpLanguageProvider sqlLi_EmpLanguageProvider = new SqlLi_EmpLanguageProvider();
        return sqlLi_EmpLanguageProvider.InsertLi_EmpLanguage(li_EmpLanguage);
    }


    public static bool UpdateLi_EmpLanguage(Li_EmpLanguage li_EmpLanguage)
    {
        SqlLi_EmpLanguageProvider sqlLi_EmpLanguageProvider = new SqlLi_EmpLanguageProvider();
        return sqlLi_EmpLanguageProvider.UpdateLi_EmpLanguage(li_EmpLanguage);
    }


    public static bool DeleteLi_EmpLanguage(int li_EmpLanguageID)
    {
        SqlLi_EmpLanguageProvider sqlLi_EmpLanguageProvider = new SqlLi_EmpLanguageProvider();
        return sqlLi_EmpLanguageProvider.DeleteLi_EmpLanguage(li_EmpLanguageID);
    }

    public static DataTable LoadGvEmployeeLanguage()
    {
        SqlLi_EmpLanguageProvider sqlLi_EmpLanguageProvider = new SqlLi_EmpLanguageProvider();
        return sqlLi_EmpLanguageProvider.LoadGvEmployeeLanguage();
    }

}
