using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_ThanaManager
{
	public li_ThanaManager()
	{
	}

    public static List<li_Thana> GetAll_Thanas()
    {
        List<li_Thana> li_Thanas = new List<li_Thana>();
        Sql_li_ThanaProvider Sql_li_ThanaProvider = new Sql_li_ThanaProvider();
        li_Thanas = Sql_li_ThanaProvider.GetAll_Thanas();
        return li_Thanas;
    }

    public static DataSet GetAll_ThanasWithRelation(string thnanaName)
    {
       
        Sql_li_ThanaProvider Sql_li_ThanaProvider = new Sql_li_ThanaProvider();
       return     Sql_li_ThanaProvider.GetAll_ThanasInfoWithRelation(thnanaName);
     
    }
    public static DataSet GetAll_ThanasWithRelationByThanaId(string ThanaId)
    {
       
        Sql_li_ThanaProvider Sql_li_ThanaProvider = new Sql_li_ThanaProvider();
        return Sql_li_ThanaProvider.SMPM_li_GetAll_ThanasWithRelationByThana(ThanaId);
     
    }
    public static DataSet GetOne_ThanasWithRelationByThana(string ThanaId)
    {
       
        Sql_li_ThanaProvider Sql_li_ThanaProvider = new Sql_li_ThanaProvider();
        return Sql_li_ThanaProvider.GetOne_ThanasWithRelationByThana(ThanaId);
     
    }
    public static DataTable GetThanasByDistrictAndTerritory(int districtId, string territoryCode)
    {       
        Sql_li_ThanaProvider Sql_li_ThanaProvider = new Sql_li_ThanaProvider();
        return Sql_li_ThanaProvider.GetThanasByDistrictAndTerritory(districtId, territoryCode);
     
    }
    public static List<li_Thana> Get_ThanaByDistrictID(int DistrictID)
    {
        List<li_Thana> li_Thana = new List<li_Thana>();
        Sql_li_ThanaProvider Sql_li_ThanaProvider = new Sql_li_ThanaProvider();
        li_Thana = Sql_li_ThanaProvider.Get_ThanaByDistrictID(DistrictID);
        return li_Thana;
    }

    public static li_Thana Get_ThanaByThanaID(int ThanaID)
    {
        li_Thana li_Thana = new li_Thana();
        Sql_li_ThanaProvider Sql_li_ThanaProvider = new Sql_li_ThanaProvider();
        li_Thana = Sql_li_ThanaProvider.Get_ThanaByThanaID(ThanaID);
        return li_Thana;
    }

    public static List<li_Thana> Get_ThanaByDistrictID(string  Territory,int DistrictID)
    {
        List<li_Thana> li_Thana = new List<li_Thana>();
        Sql_li_ThanaProvider Sql_li_ThanaProvider = new Sql_li_ThanaProvider();
        li_Thana = Sql_li_ThanaProvider.Get_ThanaByDistrictID(Territory,DistrictID );
        return li_Thana;
    }
    public static int Insert_Thana(li_Thana li_Thana)
    {
        Sql_li_ThanaProvider Sql_li_ThanaProvider = new Sql_li_ThanaProvider();
        return Sql_li_ThanaProvider.Insert_Thana(li_Thana);
    }


    public static bool Update_Thana(li_Thana li_Thana)
    {
        Sql_li_ThanaProvider Sql_li_ThanaProvider = new Sql_li_ThanaProvider();
        return Sql_li_ThanaProvider.Update_Thana(li_Thana);
    }

    public static bool Delete_Thana(int li_ThanaID)
    {
        Sql_li_ThanaProvider Sql_li_ThanaProvider = new Sql_li_ThanaProvider();
        return Sql_li_ThanaProvider.Delete_Thana(li_ThanaID);
    }

   
}

