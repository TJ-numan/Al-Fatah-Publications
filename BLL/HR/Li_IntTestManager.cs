using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_IntTestManager
{
	public Li_IntTestManager()
	{
	}

    public static List<Li_IntTest> GetAllLi_IntTests()
    {
        List<Li_IntTest> li_IntTests = new List<Li_IntTest>();
        SqlLi_IntTestProvider sqlLi_IntTestProvider = new SqlLi_IntTestProvider();
        li_IntTests = sqlLi_IntTestProvider.GetAllLi_IntTests();
        return li_IntTests;
    }


    public static Li_IntTest GetLi_IntTestByID(int id)
    {
        Li_IntTest li_IntTest = new Li_IntTest();
        SqlLi_IntTestProvider sqlLi_IntTestProvider = new SqlLi_IntTestProvider();
        li_IntTest = sqlLi_IntTestProvider.GetLi_IntTestByID(id);
        return li_IntTest;
    }


    public static int InsertLi_IntTest(Li_IntTest li_IntTest)
    {
        SqlLi_IntTestProvider sqlLi_IntTestProvider = new SqlLi_IntTestProvider();
        return sqlLi_IntTestProvider.InsertLi_IntTest(li_IntTest);
    }


    public static bool UpdateLi_IntTest(Li_IntTest li_IntTest)
    {
        SqlLi_IntTestProvider sqlLi_IntTestProvider = new SqlLi_IntTestProvider();
        return sqlLi_IntTestProvider.UpdateLi_IntTest(li_IntTest);
    }

    public static bool DeleteLi_IntTest(int li_IntTestID)
    {
        SqlLi_IntTestProvider sqlLi_IntTestProvider = new SqlLi_IntTestProvider();
        return sqlLi_IntTestProvider.DeleteLi_IntTest(li_IntTestID);
    }
}
