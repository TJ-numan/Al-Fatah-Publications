using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PrintReqAppliedProvider:DataAccessObject
{
	public SqlLi_PrintReqAppliedProvider()
    {
    }


    public bool DeleteLi_PrintReqApplied(int li_PrintReqAppliedID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PrintReqApplied", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PrintReqAppliedID", SqlDbType.Int).Value = li_PrintReqAppliedID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PrintReqApplied> GetAllLi_PrintReqApplieds()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PrintReqApplieds", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PrintReqAppliedsFromReader(reader);
        }
    }
    public List<Li_PrintReqApplied> GetLi_PrintReqAppliedsFromReader(IDataReader reader)
    {
        List<Li_PrintReqApplied> li_PrintReqApplieds = new List<Li_PrintReqApplied>();

        while (reader.Read())
        {
            li_PrintReqApplieds.Add(GetLi_PrintReqAppliedFromReader(reader));
        }
        return li_PrintReqApplieds;
    }

    public Li_PrintReqApplied GetLi_PrintReqAppliedFromReader(IDataReader reader)
    {
        try
        {
            Li_PrintReqApplied li_PrintReqApplied = new Li_PrintReqApplied
                (
                     
                    (int)reader["Sl"],
                    reader["ReqNo"].ToString(),
                    (int)reader["ReqForID"],
                    (bool)reader["IsApplied"] 
                );
             return li_PrintReqApplied;
        }
        catch(Exception )
        {
            return null;
        }
    }

    public Li_PrintReqApplied GetLi_PrintReqAppliedByID(int li_PrintReqAppliedID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PrintReqAppliedByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PrintReqAppliedID", SqlDbType.Int).Value = li_PrintReqAppliedID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PrintReqAppliedFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PrintReqApplied(Li_PrintReqApplied li_PrintReqApplied)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PrintReqApplied", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@Sl", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ReqNo", SqlDbType.VarChar).Value = li_PrintReqApplied.ReqNo;
            cmd.Parameters.Add("@ReqForID", SqlDbType.Int).Value = li_PrintReqApplied.ReqForID;
            cmd.Parameters.Add("@IsApplied", SqlDbType.Bit).Value = li_PrintReqApplied.IsApplied;
  
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@Li_PrintReqAppliedID"].Value;
        }
    }

    public bool UpdateLi_PrintReqApplied(Li_PrintReqApplied li_PrintReqApplied)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PrintReqApplied", connection);
            cmd.CommandType = CommandType.StoredProcedure;
    
             cmd.Parameters.Add("@ReqNo", SqlDbType.VarChar).Value = li_PrintReqApplied.ReqNo;
             cmd.Parameters.Add("@ReqForID", SqlDbType.Int).Value = li_PrintReqApplied.ReqForID;
  
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
