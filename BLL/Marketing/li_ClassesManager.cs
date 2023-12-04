using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;

 


public class Li_ClassesManager
{
	public Li_ClassesManager()
	{
	}

    public static List<Li_Classes> GetAllLi_Classess()
    {
        List<Li_Classes> li_Classess = new List<Li_Classes>();
        SqlLi_ClassesProvider sqlLi_ClassesProvider = new SqlLi_ClassesProvider();
        li_Classess = sqlLi_ClassesProvider.GetAllLi_Classess();
        return li_Classess;
    }

  public static List<Li_Classes> GetAllLi_ClassessByGroup( string Category, int groupID)
    {
        List<Li_Classes> li_Classess = new List<Li_Classes>();
        SqlLi_ClassesProvider sqlLi_ClassesProvider = new SqlLi_ClassesProvider();
        li_Classess = sqlLi_ClassesProvider.GetAllLi_ClassessByGroup(Category, groupID);
        return li_Classess;
    }

    public static Li_Classes GetLi_ClassesByID(int id)
    {
        Li_Classes li_Classes = new Li_Classes();
        SqlLi_ClassesProvider sqlLi_ClassesProvider = new SqlLi_ClassesProvider();
        li_Classes = sqlLi_ClassesProvider.GetLi_ClassesByID(id);
        return li_Classes;
    }


    public static int InsertLi_Classes(Li_Classes li_Classes)
    {
        SqlLi_ClassesProvider sqlLi_ClassesProvider = new SqlLi_ClassesProvider();
        return sqlLi_ClassesProvider.InsertLi_Classes(li_Classes);
    }


    public static bool UpdateLi_Classes(Li_Classes li_Classes)
    {
        SqlLi_ClassesProvider sqlLi_ClassesProvider = new SqlLi_ClassesProvider();
        return sqlLi_ClassesProvider.UpdateLi_Classes(li_Classes);
    }

    public static bool DeleteLi_Classes(int li_ClassesID)
    {
        SqlLi_ClassesProvider sqlLi_ClassesProvider = new SqlLi_ClassesProvider();
        return sqlLi_ClassesProvider.DeleteLi_Classes(li_ClassesID);
    }


    public static List<Li_Classes> GetComboSourceData_Classess()
    {
        List<Li_Classes> li_Classess = new List<Li_Classes>();
        SqlLi_ClassesProvider sqlLi_ClassesProvider = new SqlLi_ClassesProvider();
        li_Classess = sqlLi_ClassesProvider.GetComboSourceData_Classess();
        return li_Classess;
    }

     public static DataSet GetClassBySession(int SessionID, int Section)
    {
        DataSet ds = new DataSet();
        SqlLi_ClassesProvider sqlLi_ClassesProvider = new SqlLi_ClassesProvider();
        ds =sqlLi_ClassesProvider.GetClassBySession(SessionID, Section);
        return ds;

    }
     public static List<Li_Classes> GetLi_ClassesByUserID(int UserID)
     {
         List<Li_Classes> li_Classess = new List<Li_Classes>();
         SqlLi_ClassesProvider sqlLi_ClassesProvider = new SqlLi_ClassesProvider();
         li_Classess = sqlLi_ClassesProvider.GetLi_ClassesByUserID(UserID);
         return li_Classess;
     }
     public static List<Li_Classes> GetLi_ClassesByUserIDQawmi(int UserID)
     {
         List<Li_Classes> li_Classess = new List<Li_Classes>();
         SqlLi_ClassesProvider sqlLi_ClassesProvider = new SqlLi_ClassesProvider();
         li_Classess = sqlLi_ClassesProvider.GetLi_ClassesByUserIDQawmi(UserID);
         return li_Classess;
     }
     public static List<Li_Classes> GetLi_ClassesWorkOrderByUserID(int UserID)
     {
         List<Li_Classes> li_Classess = new List<Li_Classes>();
         SqlLi_ClassesProvider sqlLi_ClassesProvider = new SqlLi_ClassesProvider();
         li_Classess = sqlLi_ClassesProvider.GetLi_ClassesWorkOrderByUserID(UserID);
         return li_Classess;
     }
     public static List<Li_Classes> GetLi_ClassesByUserIDForTecherEntry(int UserID)
     {
         List<Li_Classes> li_Classess = new List<Li_Classes>();
         SqlLi_ClassesProvider sqlLi_ClassesProvider = new SqlLi_ClassesProvider();
         li_Classess = sqlLi_ClassesProvider.GetLi_ClassesByUserIDForTecherEntry(UserID);
         return li_Classess;
     }
     public static List<Li_Classes> GetLi_ClassesByUserIDGraphics(int UserID)
     {
         List<Li_Classes> li_Classess = new List<Li_Classes>();
         SqlLi_ClassesProvider sqlLi_ClassesProvider = new SqlLi_ClassesProvider();
         li_Classess = sqlLi_ClassesProvider.GetLi_ClassesByUserIDGraphics(UserID);
         return li_Classess;
     }
    
}
