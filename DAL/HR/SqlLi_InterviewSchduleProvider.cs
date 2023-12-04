using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_InterviewSchduleProvider:DataAccessObject
{
	public SqlLi_InterviewSchduleProvider()
    {
    }


    public bool DeleteLi_InterviewSchdule(int li_InterviewSchduleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_InterviewSchdule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IntSchId", SqlDbType.Int).Value = li_InterviewSchduleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_InterviewSchdule> GetAllLi_InterviewSchdules()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_InterviewSchdules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_InterviewSchdulesFromReader(reader);
        }
    }
    public List<Li_InterviewSchdule> GetLi_InterviewSchdulesFromReader(IDataReader reader)
    {
        List<Li_InterviewSchdule> li_InterviewSchdules = new List<Li_InterviewSchdule>();

        while (reader.Read())
        {
            li_InterviewSchdules.Add(GetLi_InterviewSchduleFromReader(reader));
        }
        return li_InterviewSchdules;
    }

    public Li_InterviewSchdule GetLi_InterviewSchduleFromReader(IDataReader reader)
    {
        try
        {
            Li_InterviewSchdule li_InterviewSchdule = new Li_InterviewSchdule
                (
                     
                    (int)reader["IntSchId"],
                    reader["SchTitle"].ToString(),
                    (int)reader["InTypeId"],
                    (DateTime)reader["TimeSt"],
                    (DateTime)reader["TimeEn"],
                    (int)reader["CanNo"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_InterviewSchdule;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_InterviewSchdule GetLi_InterviewSchduleByID(int li_InterviewSchduleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_InterviewSchduleByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@IntSchId", SqlDbType.Int).Value = li_InterviewSchduleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_InterviewSchduleFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_InterviewSchdule(Li_InterviewSchdule li_InterviewSchdule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_InterviewSchdule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@IntSchId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SchTitle", SqlDbType.VarChar).Value = li_InterviewSchdule.SchTitle;
            cmd.Parameters.Add("@InTypeId", SqlDbType.Int).Value = li_InterviewSchdule.InTypeId;
            cmd.Parameters.Add("@TimeSt", SqlDbType.DateTime).Value = li_InterviewSchdule.TimeSt;
            cmd.Parameters.Add("@TimeEn", SqlDbType.DateTime ).Value = li_InterviewSchdule.TimeEn;
            cmd.Parameters.Add("@CanNo", SqlDbType.Int).Value = li_InterviewSchdule.CanNo;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_InterviewSchdule.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_InterviewSchdule.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_InterviewSchdule.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_InterviewSchdule.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_InterviewSchdule.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_InterviewSchdule.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@IntSchId"].Value;
        }
    }

    public bool UpdateLi_InterviewSchdule(Li_InterviewSchdule li_InterviewSchdule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_InterviewSchdule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@IntSchId", SqlDbType.Int).Value = li_InterviewSchdule.IntSchId;
            cmd.Parameters.Add("@SchTitle", SqlDbType.VarChar).Value = li_InterviewSchdule.SchTitle;
            cmd.Parameters.Add("@InTypeId", SqlDbType.Int).Value = li_InterviewSchdule.InTypeId;
            cmd.Parameters.Add("@TimeSt", SqlDbType.DateTime).Value = li_InterviewSchdule.TimeSt;
            cmd.Parameters.Add("@TimeEn", SqlDbType.DateTime).Value = li_InterviewSchdule.TimeEn;
            cmd.Parameters.Add("@CanNo", SqlDbType.Int).Value = li_InterviewSchdule.CanNo;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_InterviewSchdule.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_InterviewSchdule.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_InterviewSchdule.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_InterviewSchdule.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_InterviewSchdule.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_InterviewSchdule.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
