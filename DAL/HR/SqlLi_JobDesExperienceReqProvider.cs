using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_JobDesExperienceReqProvider:DataAccessObject
{
	public SqlLi_JobDesExperienceReqProvider()
    {
    }


    public bool DeleteLi_JobDesExperienceReq(int li_JobDesExperienceReqID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_JobDesExperienceReq", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExpReqId", SqlDbType.Int).Value = li_JobDesExperienceReqID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_JobDesExperienceReq> GetAllLi_JobDesExperienceReqs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_JobDesExperienceReqs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_JobDesExperienceReqsFromReader(reader);
        }
    }
    public List<Li_JobDesExperienceReq> GetLi_JobDesExperienceReqsFromReader(IDataReader reader)
    {
        List<Li_JobDesExperienceReq> li_JobDesExperienceReqs = new List<Li_JobDesExperienceReq>();

        while (reader.Read())
        {
            li_JobDesExperienceReqs.Add(GetLi_JobDesExperienceReqFromReader(reader));
        }
        return li_JobDesExperienceReqs;
    }

    public Li_JobDesExperienceReq GetLi_JobDesExperienceReqFromReader(IDataReader reader)
    {
        try
        {
            Li_JobDesExperienceReq li_JobDesExperienceReq = new Li_JobDesExperienceReq
                (
                     
                    (int)reader["ExpReqId"],
                    reader["ExpReq"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_JobDesExperienceReq;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_JobDesExperienceReq GetLi_JobDesExperienceReqByID(int li_JobDesExperienceReqID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_JobDesExperienceReqByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExpReqId", SqlDbType.Int).Value = li_JobDesExperienceReqID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_JobDesExperienceReqFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_JobDesExperienceReq(Li_JobDesExperienceReq li_JobDesExperienceReq)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_JobDesExperienceReq", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@ExpReqId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ExpReq", SqlDbType.VarChar).Value = li_JobDesExperienceReq.ExpReq;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_JobDesExperienceReq.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_JobDesExperienceReq.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobDesExperienceReq.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobDesExperienceReq.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobDesExperienceReq.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ExpReqId"].Value;
        }
    }

    public bool UpdateLi_JobDesExperienceReq(Li_JobDesExperienceReq li_JobDesExperienceReq)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_JobDesExperienceReq", connection);
            cmd.CommandType = CommandType.StoredProcedure;
   
            cmd.Parameters.Add("@ExpReqId", SqlDbType.Int).Value = li_JobDesExperienceReq.ExpReqId;
            cmd.Parameters.Add("@ExpReq", SqlDbType.VarChar).Value = li_JobDesExperienceReq.ExpReq;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_JobDesExperienceReq.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_JobDesExperienceReq.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobDesExperienceReq.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobDesExperienceReq.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobDesExperienceReq.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
