using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_InfoStatusProvider:DataAccessObject
{
	public SqlLi_InfoStatusProvider()
    {
    }


    public bool DeleteLi_InfoStatus(int li_InfoStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_InfoStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_InfoStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_InfoStatus> GetAllLi_InfoStatuss()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_InfoStatuss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_InfoStatussFromReader(reader);
        }
    }
    public List<Li_InfoStatus> GetLi_InfoStatussFromReader(IDataReader reader)
    {
        List<Li_InfoStatus> li_InfoStatuss = new List<Li_InfoStatus>();

        while (reader.Read())
        {
            li_InfoStatuss.Add(GetLi_InfoStatusFromReader(reader));
        }
        return li_InfoStatuss;
    }

    public Li_InfoStatus GetLi_InfoStatusFromReader(IDataReader reader)
    {
        try
        {
            Li_InfoStatus li_InfoStatus = new Li_InfoStatus
                (
                 
                    (int)reader["InfStId"],
                    reader["InfStatus"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"]
                );
             return li_InfoStatus;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_InfoStatus GetLi_InfoStatusByID(int li_InfoStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_InfoStatusByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_InfoStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_InfoStatusFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_InfoStatus(Li_InfoStatus li_InfoStatus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_InfoStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@InfStId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@InfStatus", SqlDbType.VarChar).Value = li_InfoStatus.InfStatus;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_InfoStatus.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_InfoStatus.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_InfoStatus.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_InfoStatus.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@InfStId"].Value;
        }
    }

    public bool UpdateLi_InfoStatus(Li_InfoStatus li_InfoStatus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_InfoStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
      
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_InfoStatus.InfStId;
            cmd.Parameters.Add("@InfStatus", SqlDbType.VarChar).Value = li_InfoStatus.InfStatus;
 
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_InfoStatus.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_InfoStatus.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
