using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_JobDesEducationalReqProvider:DataAccessObject
{
	public SqlLi_JobDesEducationalReqProvider()
    {
    }


    public bool DeleteLi_JobDesEducationalReq(int li_JobDesEducationalReqID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_JobDesEducationalReq", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EduReqId", SqlDbType.Int).Value = li_JobDesEducationalReqID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_JobDesEducationalReq> GetAllLi_JobDesEducationalReqs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_JobDesEducationalReqs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_JobDesEducationalReqsFromReader(reader);
        }
    }
    public List<Li_JobDesEducationalReq> GetLi_JobDesEducationalReqsFromReader(IDataReader reader)
    {
        List<Li_JobDesEducationalReq> li_JobDesEducationalReqs = new List<Li_JobDesEducationalReq>();

        while (reader.Read())
        {
            li_JobDesEducationalReqs.Add(GetLi_JobDesEducationalReqFromReader(reader));
        }
        return li_JobDesEducationalReqs;
    }

    public Li_JobDesEducationalReq GetLi_JobDesEducationalReqFromReader(IDataReader reader)
    {
        try
        {
            Li_JobDesEducationalReq li_JobDesEducationalReq = new Li_JobDesEducationalReq
                (
                 
                    (int)reader["EduReqId"],
                    reader["EduReq"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_JobDesEducationalReq;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_JobDesEducationalReq GetLi_JobDesEducationalReqByID(int li_JobDesEducationalReqID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_JobDesEducationalReqByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EduReqId", SqlDbType.Int).Value = li_JobDesEducationalReqID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_JobDesEducationalReqFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_JobDesEducationalReq(Li_JobDesEducationalReq li_JobDesEducationalReq)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_JobDesEducationalReq", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@EduReqId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EduReq", SqlDbType.VarChar).Value = li_JobDesEducationalReq.EduReq;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_JobDesEducationalReq.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_JobDesEducationalReq.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobDesEducationalReq.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobDesEducationalReq.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobDesEducationalReq.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EduReqId"].Value;
        }
    }

    public bool UpdateLi_JobDesEducationalReq(Li_JobDesEducationalReq li_JobDesEducationalReq)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_JobDesEducationalReq", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@EduReqId", SqlDbType.Int).Value = li_JobDesEducationalReq.EduReqId;
            cmd.Parameters.Add("@EduReq", SqlDbType.VarChar).Value = li_JobDesEducationalReq.EduReq;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_JobDesEducationalReq.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_JobDesEducationalReq.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobDesEducationalReq.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobDesEducationalReq.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobDesEducationalReq.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
