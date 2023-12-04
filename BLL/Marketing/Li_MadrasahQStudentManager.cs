using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_MadrasahQStudentManager
{
	public Li_MadrasahQStudentManager()
	{
	}

    public static List<Li_MadrasahQStudent> GetAllLi_MadrasahQStudents()
    {
        List<Li_MadrasahQStudent> li_MadrasahQStudents = new List<Li_MadrasahQStudent>();
        SqlLi_MadrasahQStudentProvider sqlLi_MadrasahQStudentProvider = new SqlLi_MadrasahQStudentProvider();
        li_MadrasahQStudents = sqlLi_MadrasahQStudentProvider.GetAllLi_MadrasahQStudents();
        return li_MadrasahQStudents;
    }


    public static Li_MadrasahQStudent GetLi_MadrasahQStudentByID(int id)
    {
        Li_MadrasahQStudent li_MadrasahQStudent = new Li_MadrasahQStudent();
        SqlLi_MadrasahQStudentProvider sqlLi_MadrasahQStudentProvider = new SqlLi_MadrasahQStudentProvider();
        li_MadrasahQStudent = sqlLi_MadrasahQStudentProvider.GetLi_MadrasahQStudentByID(id);
        return li_MadrasahQStudent;
    }


    public static int InsertLi_MadrasahQStudent(Li_MadrasahQStudent li_MadrasahQStudent)
    {
        SqlLi_MadrasahQStudentProvider sqlLi_MadrasahQStudentProvider = new SqlLi_MadrasahQStudentProvider();
        return sqlLi_MadrasahQStudentProvider.InsertLi_MadrasahQStudent(li_MadrasahQStudent);
    }


    public static bool UpdateLi_MadrasahQStudent(Li_MadrasahQStudent li_MadrasahQStudent)
    {
        SqlLi_MadrasahQStudentProvider sqlLi_MadrasahQStudentProvider = new SqlLi_MadrasahQStudentProvider();
        return sqlLi_MadrasahQStudentProvider.UpdateLi_MadrasahQStudent(li_MadrasahQStudent);
    }

    public static bool DeleteLi_MadrasahQStudent(int li_MadrasahQStudentID)
    {
        SqlLi_MadrasahQStudentProvider sqlLi_MadrasahQStudentProvider = new SqlLi_MadrasahQStudentProvider();
        return sqlLi_MadrasahQStudentProvider.DeleteLi_MadrasahQStudent(li_MadrasahQStudentID);
    }
}
