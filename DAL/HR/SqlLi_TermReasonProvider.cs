using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_TermReasonProvider:DataAccessObject
{
	public SqlLi_TermReasonProvider()
    {
    }


    public bool DeleteLi_TermReason(int li_TermReasonID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_TermReason", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TeReId", SqlDbType.Int).Value = li_TermReasonID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_TermReason> GetAllLi_TermReasons()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_TermReasons", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_TermReasonsFromReader(reader);
        }
    }
    public List<Li_TermReason> GetLi_TermReasonsFromReader(IDataReader reader)
    {
        List<Li_TermReason> li_TermReasons = new List<Li_TermReason>();

        while (reader.Read())
        {
            li_TermReasons.Add(GetLi_TermReasonFromReader(reader));
        }
        return li_TermReasons;
    }

    public Li_TermReason GetLi_TermReasonFromReader(IDataReader reader)
    {
        try
        {
            Li_TermReason li_TermReason = new Li_TermReason
                (
                  
                    (int)reader["TeReId"],
                    reader["TeReName"].ToString(),
                    reader["TeReDes"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_TermReason;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_TermReason GetLi_TermReasonByID(int li_TermReasonID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_TermReasonByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TeReId", SqlDbType.Int).Value = li_TermReasonID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_TermReasonFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_TermReason(Li_TermReason li_TermReason)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_TermReason", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@TeReId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TeReName", SqlDbType.VarChar).Value = li_TermReason.TeReName;
            cmd.Parameters.Add("@TeReDes", SqlDbType.VarChar).Value = li_TermReason.TeReDes;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_TermReason.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TermReason.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_TermReason.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_TermReason.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_TermReason.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@TeReId"].Value;
        }
    }

    public bool UpdateLi_TermReason(Li_TermReason li_TermReason)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_TermReason", connection);
            cmd.CommandType = CommandType.StoredProcedure;
   
            cmd.Parameters.Add("@TeReId", SqlDbType.Int).Value = li_TermReason.TeReId;
            cmd.Parameters.Add("@TeReName", SqlDbType.VarChar).Value = li_TermReason.TeReName;
            cmd.Parameters.Add("@TeReDes", SqlDbType.VarChar).Value = li_TermReason.TeReDes; 
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_TermReason.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_TermReason.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_TermReason.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
