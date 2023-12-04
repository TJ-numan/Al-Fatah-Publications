using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_TransportInfoProvider:DataAccessObject
{
	public SqlLi_TransportInfoProvider()
    {
    }


    public bool DeleteLi_TransportInfo(int li_TransportInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_TransportInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_TransportInfoID", SqlDbType.Int).Value = li_TransportInfoID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_TransportInfo> GetAllLi_TransportInfos()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_TransportInfos", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_TransportInfosFromReader(reader);
        }
    }
    public List<Li_TransportInfo> GetLi_TransportInfosFromReader(IDataReader reader)
    {
        List<Li_TransportInfo> li_TransportInfos = new List<Li_TransportInfo>();

        while (reader.Read())
        {
            li_TransportInfos.Add(GetLi_TransportInfoFromReader(reader));
        }
        return li_TransportInfos;
    }

    public Li_TransportInfo GetLi_TransportInfoFromReader(IDataReader reader)
    {
        try
        {
            Li_TransportInfo li_TransportInfo = new Li_TransportInfo
                (
                     
                    reader["TransportID"].ToString(),
                    reader["TransportName"].ToString(),
                    reader["Address"].ToString(),
                    reader["Phone"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"] 
                     
                );
             return li_TransportInfo;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_TransportInfo GetLi_TransportInfoByID(int li_TransportInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_TransportInfoByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_TransportInfoID", SqlDbType.Int).Value = li_TransportInfoID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_TransportInfoFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_TransportInfo(Li_TransportInfo li_TransportInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_TransportInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@TransportID", SqlDbType.VarChar,50) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TransportName", SqlDbType.VarChar).Value = li_TransportInfo.TransportName;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_TransportInfo.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_TransportInfo.Phone;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_TransportInfo.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TransportInfo.CreatedDate;
              connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@TransportID"].Value.ToString ();
        }
    }

    public bool UpdateLi_TransportInfo(Li_TransportInfo li_TransportInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_TransportInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@TransportID", SqlDbType.VarChar).Value = li_TransportInfo.TransportID;
            cmd.Parameters.Add("@TransportName", SqlDbType.VarChar).Value = li_TransportInfo.TransportName;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_TransportInfo.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_TransportInfo.Phone;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_TransportInfo.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TransportInfo.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
