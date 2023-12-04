using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_InterviewTypeProvider:DataAccessObject
{
	public SqlLi_InterviewTypeProvider()
    {
    }


    public bool DeleteLi_InterviewType(int li_InterviewTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_InterviewType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InTypeId", SqlDbType.Int).Value = li_InterviewTypeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_InterviewType> GetAllLi_InterviewTypes()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_InterviewTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_InterviewTypesFromReader(reader);
        }
    }
    public List<Li_InterviewType> GetLi_InterviewTypesFromReader(IDataReader reader)
    {
        List<Li_InterviewType> li_InterviewTypes = new List<Li_InterviewType>();

        while (reader.Read())
        {
            li_InterviewTypes.Add(GetLi_InterviewTypeFromReader(reader));
        }
        return li_InterviewTypes;
    }

    public Li_InterviewType GetLi_InterviewTypeFromReader(IDataReader reader)
    {
        try
        {
            Li_InterviewType li_InterviewType = new Li_InterviewType
                (
                    
                    (int)reader["InTypeId"],
                    reader["IntType"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_InterviewType;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_InterviewType GetLi_InterviewTypeByID(int li_InterviewTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_InterviewTypeByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@InTypeId", SqlDbType.Int).Value = li_InterviewTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_InterviewTypeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_InterviewType(Li_InterviewType li_InterviewType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_InterviewType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@InTypeId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@IntType", SqlDbType.VarChar).Value = li_InterviewType.IntType;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_InterviewType.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_InterviewType.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_InterviewType.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_InterviewType.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_InterviewType.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@InTypeId"].Value;
        }
    }

    public bool UpdateLi_InterviewType(Li_InterviewType li_InterviewType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_InterviewType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
  
            cmd.Parameters.Add("@InTypeId", SqlDbType.Int).Value = li_InterviewType.InTypeId;
            cmd.Parameters.Add("@IntType", SqlDbType.VarChar).Value = li_InterviewType.IntType;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_InterviewType.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_InterviewType.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_InterviewType.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_InterviewType.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_InterviewType.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
