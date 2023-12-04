using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Book_SessionProvider:DataAccessObject
{
	public SqlLi_Book_SessionProvider()
    {
    }


    public bool DeleteLi_Book_Session(int li_Book_SessionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Book_Session", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Book_SessionID", SqlDbType.Int).Value = li_Book_SessionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Book_Session> GetAllLi_Book_Sessions()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Book_Sessions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Book_SessionsFromReader(reader);
        }
    }
    public List<Li_Book_Session> GetLi_Book_SessionsFromReader(IDataReader reader)
    {
        List<Li_Book_Session> li_Book_Sessions = new List<Li_Book_Session>();

        while (reader.Read())
        {
            li_Book_Sessions.Add(GetLi_Book_SessionFromReader(reader));
        }
        return li_Book_Sessions;
    }

    public Li_Book_Session GetLi_Book_SessionFromReader(IDataReader reader)
    {
        try
        {
            Li_Book_Session li_Book_Session = new Li_Book_Session
                (
                    
                    (int)reader["SessionID"],
                    reader["SessionName"].ToString(),
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    reader["SessDetail"].ToString() 
                );
             return li_Book_Session;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Book_Session GetLi_Book_SessionByID(int li_Book_SessionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Book_SessionByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SectionID", SqlDbType.Int).Value = li_Book_SessionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Book_SessionFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Book_Session(Li_Book_Session li_Book_Session)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Book_Session", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@SessionID", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SessionName", SqlDbType.VarChar).Value = li_Book_Session.SessionName;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Book_Session.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Book_Session.CreatedBy;
            cmd.Parameters.Add("@SessDetail", SqlDbType.VarChar).Value = li_Book_Session.SessDetail;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_Book_Session(Li_Book_Session li_Book_Session)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Book_Session", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@SessionID", SqlDbType.Int).Value = li_Book_Session.SessionID;
            cmd.Parameters.Add("@SessionName", SqlDbType.VarChar).Value = li_Book_Session.SessionName;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Book_Session.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Book_Session.CreatedBy;
            cmd.Parameters.Add("@SessDetail", SqlDbType.VarChar).Value = li_Book_Session.SessDetail;
    
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
