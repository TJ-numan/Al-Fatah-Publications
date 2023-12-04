using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpSkillsManager
{
	public Li_EmpSkillsManager()
	{
	}

    public static List<Li_EmpSkills> GetAllLi_EmpSkillss()
    {
        List<Li_EmpSkills> li_EmpSkillss = new List<Li_EmpSkills>();
        SqlLi_EmpSkillsProvider sqlLi_EmpSkillsProvider = new SqlLi_EmpSkillsProvider();
        li_EmpSkillss = sqlLi_EmpSkillsProvider.GetAllLi_EmpSkillss();
        return li_EmpSkillss;
    }


    public static Li_EmpSkills GetLi_EmpSkillsByID(int id)
    {
        Li_EmpSkills li_EmpSkills = new Li_EmpSkills();
        SqlLi_EmpSkillsProvider sqlLi_EmpSkillsProvider = new SqlLi_EmpSkillsProvider();
        li_EmpSkills = sqlLi_EmpSkillsProvider.GetLi_EmpSkillsByID(id);
        return li_EmpSkills;
    }


    public static int InsertLi_EmpSkills(Li_EmpSkills li_EmpSkills)
    {
        SqlLi_EmpSkillsProvider sqlLi_EmpSkillsProvider = new SqlLi_EmpSkillsProvider();
        return sqlLi_EmpSkillsProvider.InsertLi_EmpSkills(li_EmpSkills);
    }


    public static bool UpdateLi_EmpSkills(Li_EmpSkills li_EmpSkills)
    {
        SqlLi_EmpSkillsProvider sqlLi_EmpSkillsProvider = new SqlLi_EmpSkillsProvider();
        return sqlLi_EmpSkillsProvider.UpdateLi_EmpSkills(li_EmpSkills);
    }

    public static bool DeleteLi_EmpSkills(int li_EmpSkillsID)
    {
        SqlLi_EmpSkillsProvider sqlLi_EmpSkillsProvider = new SqlLi_EmpSkillsProvider();
        return sqlLi_EmpSkillsProvider.DeleteLi_EmpSkills(li_EmpSkillsID);
    } 
    public static DataTable LoadGvEmpSkill() 
    {
        SqlLi_EmpSkillsProvider sqlLi_EmpSkillsProvider = new SqlLi_EmpSkillsProvider();
        return sqlLi_EmpSkillsProvider.LoadGvEmpSkill();
    }
}
