using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_ResourcePerSkillManager
{
	public Li_ResourcePerSkillManager()
	{
	}

    public static List<Li_ResourcePerSkill> GetAllLi_ResourcePerSkills()
    {
        List<Li_ResourcePerSkill> li_ResourcePerSkills = new List<Li_ResourcePerSkill>();
        SqlLi_ResourcePerSkillProvider sqlLi_ResourcePerSkillProvider = new SqlLi_ResourcePerSkillProvider();
        li_ResourcePerSkills = sqlLi_ResourcePerSkillProvider.GetAllLi_ResourcePerSkills();
        return li_ResourcePerSkills;
    }


    public static Li_ResourcePerSkill GetLi_ResourcePerSkillByID(int id)
    {
        Li_ResourcePerSkill li_ResourcePerSkill = new Li_ResourcePerSkill();
        SqlLi_ResourcePerSkillProvider sqlLi_ResourcePerSkillProvider = new SqlLi_ResourcePerSkillProvider();
        li_ResourcePerSkill = sqlLi_ResourcePerSkillProvider.GetLi_ResourcePerSkillByID(id);
        return li_ResourcePerSkill;
    }


    public static int InsertLi_ResourcePerSkill(Li_ResourcePerSkill li_ResourcePerSkill)
    {
        SqlLi_ResourcePerSkillProvider sqlLi_ResourcePerSkillProvider = new SqlLi_ResourcePerSkillProvider();
        return sqlLi_ResourcePerSkillProvider.InsertLi_ResourcePerSkill(li_ResourcePerSkill);
    }


    public static bool UpdateLi_ResourcePerSkill(Li_ResourcePerSkill li_ResourcePerSkill)
    {
        SqlLi_ResourcePerSkillProvider sqlLi_ResourcePerSkillProvider = new SqlLi_ResourcePerSkillProvider();
        return sqlLi_ResourcePerSkillProvider.UpdateLi_ResourcePerSkill(li_ResourcePerSkill);
    }

    public static bool DeleteLi_ResourcePerSkill(int li_ResourcePerSkillID)
    {
        SqlLi_ResourcePerSkillProvider sqlLi_ResourcePerSkillProvider = new SqlLi_ResourcePerSkillProvider();
        return sqlLi_ResourcePerSkillProvider.DeleteLi_ResourcePerSkill(li_ResourcePerSkillID);
    }
}
