using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_MaritalStatusProvider:DataAccessObject
{
	public SqlLi_MaritalStatusProvider()
    {
    }


    public bool DeleteLi_MaritalStatus(int li_MaritalStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_MaritalStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MarStId", SqlDbType.Int).Value = li_MaritalStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_MaritalStatus> GetAllLi_MaritalStatuss()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_MaritalStatuss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_MaritalStatussFromReader(reader);
        }
    }
    public List<Li_MaritalStatus> GetLi_MaritalStatussFromReader(IDataReader reader)
    {
        List<Li_MaritalStatus> li_MaritalStatuss = new List<Li_MaritalStatus>();

        while (reader.Read())
        {
            li_MaritalStatuss.Add(GetLi_MaritalStatusFromReader(reader));
        }
        return li_MaritalStatuss;
    }

    public Li_MaritalStatus GetLi_MaritalStatusFromReader(IDataReader reader)
    {
        try
        {
            Li_MaritalStatus li_MaritalStatus = new Li_MaritalStatus
                (
                     
                    (int)reader["MarStId"],
                    reader["MarStName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_MaritalStatus;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_MaritalStatus GetLi_MaritalStatusByID(int li_MaritalStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_MaritalStatusByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MarStId", SqlDbType.Int).Value = li_MaritalStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_MaritalStatusFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_MaritalStatus(Li_MaritalStatus li_MaritalStatus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_MaritalStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
   
            cmd.Parameters.Add("@MarStId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MarStName", SqlDbType.VarChar).Value = li_MaritalStatus.MarStName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_MaritalStatus.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_MaritalStatus. CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_MaritalStatus.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_MaritalStatus.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_MaritalStatus.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@MarStId"].Value;
        }
    }

    public bool UpdateLi_MaritalStatus(Li_MaritalStatus li_MaritalStatus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_MaritalStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@MarStId", SqlDbType.Int).Value = li_MaritalStatus.MarStId;
            cmd.Parameters.Add("@MarStName", SqlDbType.VarChar).Value = li_MaritalStatus.MarStName; 
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_MaritalStatus.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_MaritalStatus.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_MaritalStatus.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
