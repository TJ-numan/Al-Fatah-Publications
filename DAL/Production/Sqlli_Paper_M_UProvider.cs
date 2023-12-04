using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Paper_M_UProvider:DataAccessObject
{
	public SqlLi_Paper_M_UProvider()
    {
    }


    public bool DeleteLi_Paper_M_U(int li_Paper_M_UID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Paper_M_U", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Paper_M_UID", SqlDbType.Int).Value = li_Paper_M_UID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Paper_M_U> GetAllLi_Paper_M_Us(string PaperType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Paper_M_Us", connection);
            command.CommandType = CommandType.StoredProcedure;
             command. Parameters.Add("@PaperType", SqlDbType.VarChar).Value =  PaperType;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Paper_M_UsFromReader(reader);
        }
    }
    public List<Li_Paper_M_U> GetLi_Paper_M_UsFromReader(IDataReader reader)
    {
        List<Li_Paper_M_U> li_Paper_M_Us = new List<Li_Paper_M_U>();

        while (reader.Read())
        {
            li_Paper_M_Us.Add(GetLi_Paper_M_UFromReader(reader));
        }
        return li_Paper_M_Us;
    }

    public Li_Paper_M_U GetLi_Paper_M_UFromReader(IDataReader reader)
    {
        try
        {
            Li_Paper_M_U li_Paper_M_U = new Li_Paper_M_U
                (
                   
                    (int)reader["Pap_U_ID"],
                    reader["Pap_U_Name"].ToString(),
                    reader["PaperType"].ToString() 
                );
             return li_Paper_M_U;
        }
        catch(Exception )
        {
            return null;
        }
    }

    public Li_Paper_M_U GetLi_Paper_M_UByID(int li_Paper_M_UID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Paper_M_UByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Paper_M_UID", SqlDbType.Int).Value = li_Paper_M_UID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Paper_M_UFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Paper_M_U(Li_Paper_M_U li_Paper_M_U)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Paper_M_U", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@Pap_U_ID", SqlDbType.Int).Value = li_Paper_M_U.Pap_U_ID;
            cmd.Parameters.Add("@Pap_U_Name", SqlDbType.VarChar).Value = li_Paper_M_U.Pap_U_Name;
            cmd.Parameters.Add("@PaperType", SqlDbType.VarChar).Value = li_Paper_M_U.PaperType;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@Li_Paper_M_UID"].Value;
        }
    }

    public bool UpdateLi_Paper_M_U(Li_Paper_M_U li_Paper_M_U)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Paper_M_U", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@Pap_U_ID", SqlDbType.Int).Value = li_Paper_M_U.Pap_U_ID;
            cmd.Parameters.Add("@Pap_U_Name", SqlDbType.VarChar).Value = li_Paper_M_U.Pap_U_Name;
            cmd.Parameters.Add("@PaperType", SqlDbType.VarChar).Value = li_Paper_M_U.PaperType;
  
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
