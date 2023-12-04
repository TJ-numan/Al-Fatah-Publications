using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using Common.Marketing; 


public class Li_StudentR2Manager
{
	public Li_StudentR2Manager()
	{
	}

    public static List<Li_StudentR2> GetAllLi_StudentR2s()
    {
        List<Li_StudentR2> li_StudentR2s = new List<Li_StudentR2>();
        SqlLi_StudentR2Provider sqlLi_StudentR2Provider = new SqlLi_StudentR2Provider();
        li_StudentR2s = sqlLi_StudentR2Provider.GetAllLi_StudentR2s();
        return li_StudentR2s;
    }


    public static Li_StudentR2 GetLi_StudentR2ByID(int id)
    {
        Li_StudentR2 li_StudentR2 = new Li_StudentR2();
        SqlLi_StudentR2Provider sqlLi_StudentR2Provider = new SqlLi_StudentR2Provider();
        li_StudentR2 = sqlLi_StudentR2Provider.GetLi_StudentR2ByID(id);
        return li_StudentR2;
    }


    public static int InsertLi_StudentR2(Li_StudentR2 li_StudentR2)
    {
        SqlLi_StudentR2Provider sqlLi_StudentR2Provider = new SqlLi_StudentR2Provider();
        return sqlLi_StudentR2Provider.InsertLi_StudentR2(li_StudentR2);
    }


    public static bool UpdateLi_StudentR2(Li_StudentR2 li_StudentR2)
    {
        SqlLi_StudentR2Provider sqlLi_StudentR2Provider = new SqlLi_StudentR2Provider();
        return sqlLi_StudentR2Provider.UpdateLi_StudentR2(li_StudentR2);
    }

    public static bool DeleteLi_StudentR2(int li_StudentR2ID)
    {
        SqlLi_StudentR2Provider sqlLi_StudentR2Provider = new SqlLi_StudentR2Provider();
        return sqlLi_StudentR2Provider.DeleteLi_StudentR2(li_StudentR2ID);
    }

    public static DataSet GetLi_StudentR2By_MadId(string MadId)
    {
        SqlLi_StudentR2Provider sqlLi_StudentR2Provider = new SqlLi_StudentR2Provider();
        return sqlLi_StudentR2Provider.GetLi_StudentR2By_MadId(MadId);
    }

    public static int InsertLi_StudentAdvanced(Li_StudentAdvanced li_StudentAdv)
    {
        SqlLi_StudentR2Provider sqlLi_MadrasahInfoProvider = new SqlLi_StudentR2Provider();
        return sqlLi_MadrasahInfoProvider.InsertLi_StudentAdvanced(li_StudentAdv);
    }
    public static int InsertLi_TeacherNoAdvanced(Li_TeacherNoAdvanced li_TeacherNoAdv)
    {
        SqlLi_StudentR2Provider sqlLi_MadrasahInfoProvider = new SqlLi_StudentR2Provider();
        return sqlLi_MadrasahInfoProvider.InsertLi_TeacherNoAdvanced(li_TeacherNoAdv);
    }
    public static int UpdateLi_StudentAdvanced(Li_StudentAdvanced li_StudentAdv)
    {
        SqlLi_StudentR2Provider sqlLi_MadrasahInfoProvider = new SqlLi_StudentR2Provider();
        return sqlLi_MadrasahInfoProvider.UpdateLi_StudentAdvanced(li_StudentAdv);
    }
    public static int UpdateLi_TeacherNoAdvanced(Li_TeacherNoAdvanced li_TeacherNoAdv)
    {
        SqlLi_StudentR2Provider sqlLi_MadrasahInfoProvider = new SqlLi_StudentR2Provider();
        return sqlLi_MadrasahInfoProvider.UpdateLi_TeacherNoAdvanced(li_TeacherNoAdv);
    }
}
