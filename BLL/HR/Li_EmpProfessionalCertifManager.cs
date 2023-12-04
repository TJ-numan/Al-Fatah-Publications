using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpProfessionalCertifManager
{
	public Li_EmpProfessionalCertifManager()
	{
	}

    public static List<Li_EmpProfessionalCertif> GetAllLi_EmpProfessionalCertifs()
    {
        List<Li_EmpProfessionalCertif> li_EmpProfessionalCertifs = new List<Li_EmpProfessionalCertif>();
        SqlLi_EmpProfessionalCertifProvider sqlLi_EmpProfessionalCertifProvider = new SqlLi_EmpProfessionalCertifProvider();
        li_EmpProfessionalCertifs = sqlLi_EmpProfessionalCertifProvider.GetAllLi_EmpProfessionalCertifs();
        return li_EmpProfessionalCertifs;
    }


    public static Li_EmpProfessionalCertif GetLi_EmpProfessionalCertifByID(int id)
    {
        Li_EmpProfessionalCertif li_EmpProfessionalCertif = new Li_EmpProfessionalCertif();
        SqlLi_EmpProfessionalCertifProvider sqlLi_EmpProfessionalCertifProvider = new SqlLi_EmpProfessionalCertifProvider();
        li_EmpProfessionalCertif = sqlLi_EmpProfessionalCertifProvider.GetLi_EmpProfessionalCertifByID(id);
        return li_EmpProfessionalCertif;
    }


    public static int InsertLi_EmpProfessionalCertif(Li_EmpProfessionalCertif li_EmpProfessionalCertif)
    {
        SqlLi_EmpProfessionalCertifProvider sqlLi_EmpProfessionalCertifProvider = new SqlLi_EmpProfessionalCertifProvider();
        return sqlLi_EmpProfessionalCertifProvider.InsertLi_EmpProfessionalCertif(li_EmpProfessionalCertif);
    }


    public static bool UpdateLi_EmpProfessionalCertif(Li_EmpProfessionalCertif li_EmpProfessionalCertif)
    {
        SqlLi_EmpProfessionalCertifProvider sqlLi_EmpProfessionalCertifProvider = new SqlLi_EmpProfessionalCertifProvider();
        return sqlLi_EmpProfessionalCertifProvider.UpdateLi_EmpProfessionalCertif(li_EmpProfessionalCertif);
    }

    public static bool DeleteLi_EmpProfessionalCertif(int li_EmpProfessionalCertifID)
    {
        SqlLi_EmpProfessionalCertifProvider sqlLi_EmpProfessionalCertifProvider = new SqlLi_EmpProfessionalCertifProvider();
        return sqlLi_EmpProfessionalCertifProvider.DeleteLi_EmpProfessionalCertif(li_EmpProfessionalCertifID);
    }

    public static DataTable  LoadGvProfessionalCertificate()
    {
        SqlLi_EmpProfessionalCertifProvider sqlLi_EmpProfessionalCertifProvider = new SqlLi_EmpProfessionalCertifProvider();
        return sqlLi_EmpProfessionalCertifProvider.LoadGvProfessionalCertificate() ;
    }
}
