using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpPassportVisaManager
{
    public Li_EmpPassportVisaManager()
    {
    }

    public static List<Li_EmpPassportVisa> GetAllLi_EmpPassportVisas()
    {
        List<Li_EmpPassportVisa> li_EmpPassportVisas = new List<Li_EmpPassportVisa>();
        SqlLi_EmpPassportVisaProvider sqlLi_EmpPassportVisaProvider = new SqlLi_EmpPassportVisaProvider();
        li_EmpPassportVisas = sqlLi_EmpPassportVisaProvider.GetAllLi_EmpPassportVisas();
        return li_EmpPassportVisas;
    }


    public static Li_EmpPassportVisa GetLi_EmpPassportVisaByID(int id)
    {
        Li_EmpPassportVisa li_EmpPassportVisa = new Li_EmpPassportVisa();
        SqlLi_EmpPassportVisaProvider sqlLi_EmpPassportVisaProvider = new SqlLi_EmpPassportVisaProvider();
        li_EmpPassportVisa = sqlLi_EmpPassportVisaProvider.GetLi_EmpPassportVisaByID(id);
        return li_EmpPassportVisa;
    }


    public static int InsertLi_EmpPassportVisa(Li_EmpPassportVisa li_EmpPassportVisa)
    {
        SqlLi_EmpPassportVisaProvider sqlLi_EmpPassportVisaProvider = new SqlLi_EmpPassportVisaProvider();
        return sqlLi_EmpPassportVisaProvider.InsertLi_EmpPassportVisa(li_EmpPassportVisa);
    }


    public static bool UpdateLi_EmpPassportVisa(Li_EmpPassportVisa li_EmpPassportVisa)
    {
        SqlLi_EmpPassportVisaProvider sqlLi_EmpPassportVisaProvider = new SqlLi_EmpPassportVisaProvider();
        return sqlLi_EmpPassportVisaProvider.UpdateLi_EmpPassportVisa(li_EmpPassportVisa);
    }

    public static bool DeleteLi_EmpPassportVisa(int li_EmpPassportVisaID)
    {
        SqlLi_EmpPassportVisaProvider sqlLi_EmpPassportVisaProvider = new SqlLi_EmpPassportVisaProvider();
        return sqlLi_EmpPassportVisaProvider.DeleteLi_EmpPassportVisa(li_EmpPassportVisaID);
    }
    public static DataTable  LoadEmpPassport( )
    {
        SqlLi_EmpPassportVisaProvider sqlLi_EmpPassportVisaProvider = new SqlLi_EmpPassportVisaProvider();
        return sqlLi_EmpPassportVisaProvider.LoadGvEmployeePassport  ();
    }
}
