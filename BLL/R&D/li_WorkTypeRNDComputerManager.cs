using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_WorkTypeRNDComputerManager
{
	public Li_WorkTypeRNDComputerManager()
	{
	}

    public static List<Li_WorkTypeRNDComputer> GetAllLi_WorkTypeRNDComputers()
    {
        List<Li_WorkTypeRNDComputer> li_WorkTypeRNDComputers = new List<Li_WorkTypeRNDComputer>();
        SqlLi_WorkTypeRNDComputerProvider sqlLi_WorkTypeRNDComputerProvider = new SqlLi_WorkTypeRNDComputerProvider();
        li_WorkTypeRNDComputers = sqlLi_WorkTypeRNDComputerProvider.GetAllLi_WorkTypeRNDComputers();
        return li_WorkTypeRNDComputers;
    }


    public static Li_WorkTypeRNDComputer GetLi_WorkTypeRNDComputerByID(int id)
    {
        Li_WorkTypeRNDComputer li_WorkTypeRNDComputer = new Li_WorkTypeRNDComputer();
        SqlLi_WorkTypeRNDComputerProvider sqlLi_WorkTypeRNDComputerProvider = new SqlLi_WorkTypeRNDComputerProvider();
        li_WorkTypeRNDComputer = sqlLi_WorkTypeRNDComputerProvider.GetLi_WorkTypeRNDComputerByID(id);
        return li_WorkTypeRNDComputer;
    }


    public static int InsertLi_WorkTypeRNDComputer(Li_WorkTypeRNDComputer li_WorkTypeRNDComputer)
    {
        SqlLi_WorkTypeRNDComputerProvider sqlLi_WorkTypeRNDComputerProvider = new SqlLi_WorkTypeRNDComputerProvider();
        return sqlLi_WorkTypeRNDComputerProvider.InsertLi_WorkTypeRNDComputer(li_WorkTypeRNDComputer);
    }


    public static bool UpdateLi_WorkTypeRNDComputer(Li_WorkTypeRNDComputer li_WorkTypeRNDComputer)
    {
        SqlLi_WorkTypeRNDComputerProvider sqlLi_WorkTypeRNDComputerProvider = new SqlLi_WorkTypeRNDComputerProvider();
        return sqlLi_WorkTypeRNDComputerProvider.UpdateLi_WorkTypeRNDComputer(li_WorkTypeRNDComputer);
    }

    public static bool DeleteLi_WorkTypeRNDComputer(int li_WorkTypeRNDComputerID)
    {
        SqlLi_WorkTypeRNDComputerProvider sqlLi_WorkTypeRNDComputerProvider = new SqlLi_WorkTypeRNDComputerProvider();
        return sqlLi_WorkTypeRNDComputerProvider.DeleteLi_WorkTypeRNDComputer(li_WorkTypeRNDComputerID);
    }
}
