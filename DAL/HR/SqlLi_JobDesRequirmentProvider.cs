using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_JobDesRequirmentProvider:DataAccessObject
{
	public SqlLi_JobDesRequirmentProvider()
    {
    }


    public bool DeleteLi_JobDesRequirment(int li_JobDesRequirmentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_JobDesRequirment", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobReqId", SqlDbType.Int).Value = li_JobDesRequirmentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_JobDesRequirment> GetAllLi_JobDesRequirments()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_JobDesRequirments", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_JobDesRequirmentsFromReader(reader);
        }
    }
    public List<Li_JobDesRequirment> GetLi_JobDesRequirmentsFromReader(IDataReader reader)
    {
        List<Li_JobDesRequirment> li_JobDesRequirments = new List<Li_JobDesRequirment>();

        while (reader.Read())
        {
            li_JobDesRequirments.Add(GetLi_JobDesRequirmentFromReader(reader));
        }
        return li_JobDesRequirments;
    }

    public Li_JobDesRequirment GetLi_JobDesRequirmentFromReader(IDataReader reader)
    {
        try
        {
            Li_JobDesRequirment li_JobDesRequirment = new Li_JobDesRequirment
                (
                 
                    (int)reader["JobReqId"],
                    reader["JobReq"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_JobDesRequirment;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_JobDesRequirment GetLi_JobDesRequirmentByID(int li_JobDesRequirmentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_JobDesRequirmentByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@JobReqId", SqlDbType.Int).Value = li_JobDesRequirmentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_JobDesRequirmentFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_JobDesRequirment(Li_JobDesRequirment li_JobDesRequirment)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_JobDesRequirment", connection);
            cmd.CommandType = CommandType.StoredProcedure;
      
            cmd.Parameters.Add("@JobReqId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@JobReq", SqlDbType.VarChar).Value = li_JobDesRequirment.JobReq;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_JobDesRequirment.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_JobDesRequirment.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobDesRequirment.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobDesRequirment.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobDesRequirment.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@JobReqId"].Value;
        }
    }

    public bool UpdateLi_JobDesRequirment(Li_JobDesRequirment li_JobDesRequirment)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_JobDesRequirment", connection);
            cmd.CommandType = CommandType.StoredProcedure;
      
            cmd.Parameters.Add("@JobReqId", SqlDbType.Int).Value = li_JobDesRequirment.JobReqId;
            cmd.Parameters.Add("@JobReq", SqlDbType.VarChar).Value = li_JobDesRequirment.JobReq;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_JobDesRequirment.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_JobDesRequirment.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobDesRequirment.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobDesRequirment.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobDesRequirment.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
