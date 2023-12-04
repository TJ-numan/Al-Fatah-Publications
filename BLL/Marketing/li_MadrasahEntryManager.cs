using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_MadrasahEntryManager
{
	public Li_MadrasahEntryManager()
	{
	}

    public static List<Li_MadrasahEntry> GetAllLi_MadrasahEntries(int thanaId)
    {
        List<Li_MadrasahEntry> li_MadrasahEntries = new List<Li_MadrasahEntry>();
        SqlLi_MadrasahEntryProvider sqlLi_MadrasahEntryProvider = new SqlLi_MadrasahEntryProvider();
        li_MadrasahEntries = sqlLi_MadrasahEntryProvider.GetAllLi_MadrasahEntries(thanaId);
        return li_MadrasahEntries;
    }


    public static Li_MadrasahEntry GetLi_MadrasahEntryByID(string  id)
    {
        Li_MadrasahEntry li_MadrasahEntry = new Li_MadrasahEntry();
        SqlLi_MadrasahEntryProvider sqlLi_MadrasahEntryProvider = new SqlLi_MadrasahEntryProvider();
        li_MadrasahEntry = sqlLi_MadrasahEntryProvider.GetLi_MadrasahEntryByID(id);
        return li_MadrasahEntry;
    }


    public static int InsertLi_MadrasahEntry(Li_MadrasahEntry li_MadrasahEntry)
    {
        SqlLi_MadrasahEntryProvider sqlLi_MadrasahEntryProvider = new SqlLi_MadrasahEntryProvider();
        return sqlLi_MadrasahEntryProvider.InsertLi_MadrasahEntry(li_MadrasahEntry);
    }


    public static bool UpdateLi_MadrasahEntry(Li_MadrasahEntry li_MadrasahEntry)
    {
        SqlLi_MadrasahEntryProvider sqlLi_MadrasahEntryProvider = new SqlLi_MadrasahEntryProvider();
        return sqlLi_MadrasahEntryProvider.UpdateLi_MadrasahEntry(li_MadrasahEntry);
    }

    public static bool DeleteLi_MadrasahEntry(int li_MadrasahEntryID)
    {
        SqlLi_MadrasahEntryProvider sqlLi_MadrasahEntryProvider = new SqlLi_MadrasahEntryProvider();
        return sqlLi_MadrasahEntryProvider.DeleteLi_MadrasahEntry(li_MadrasahEntryID);
    }

    public static DataSet GetAllLi_MadrasahEntryByEIIN(string EIIN)
    {
        SqlLi_MadrasahEntryProvider sqlLi_MadrasahEntryProvider = new SqlLi_MadrasahEntryProvider();
        return sqlLi_MadrasahEntryProvider.GetAllLi_MadrasahEntryByEIIN(EIIN);
    }
    public static DataSet GetAllMadrasahEntry()
    {
        SqlLi_MadrasahEntryProvider sqlLi_MadrasahEntryProvider = new SqlLi_MadrasahEntryProvider();
        return sqlLi_MadrasahEntryProvider.GetAllMadrasahEntry();

    }
    public static DataSet GetMadrasahEntryByMadrashName(string MadName)
    {
        SqlLi_MadrasahEntryProvider sqlLi_MadrasahEntryProvider = new SqlLi_MadrasahEntryProvider();
        return sqlLi_MadrasahEntryProvider.GetMadrasahEntryByMadrashName(MadName);
    }
    public static DataSet GetAllLi_MadrasahEntryByTerCodeAndEIIN(string EIIN, string TerCode)
    {
        SqlLi_MadrasahEntryProvider sqlLi_MadrasahEntryProvider = new SqlLi_MadrasahEntryProvider();
        return sqlLi_MadrasahEntryProvider.GetAllLi_MadrasahEntryByTerCodeAndEIIN(EIIN,TerCode);
    }
    public static DataSet GetAllLi_MadrasahEntryByEIINandTerritoryID(string EIIN, int DetID)
    {
        SqlLi_MadrasahEntryProvider sqlLi_MadrasahEntryProvider = new SqlLi_MadrasahEntryProvider();
        return sqlLi_MadrasahEntryProvider.GetAllLi_MadrasahEntryByEIINandTerritoryID(EIIN, DetID);
    }
    public static DataSet Get_MadrasahInfoByRegDivTer(int RegID, int DivID,string TerCode)
    {
        SqlLi_MadrasahEntryProvider sqlLi_MadrasahEntryProvider = new SqlLi_MadrasahEntryProvider();
        return sqlLi_MadrasahEntryProvider.Get_MadrasahInfoByRegDivTer(RegID, DivID, TerCode);
    }
    public static DataSet Get_MadrasahInfoByEIIN( string eiin)
    {
        SqlLi_MadrasahEntryProvider sqlLi_MadrasahEntryProvider = new SqlLi_MadrasahEntryProvider();
        return sqlLi_MadrasahEntryProvider.Get_MadrasahInfoByEIIN(eiin);
    }
}
