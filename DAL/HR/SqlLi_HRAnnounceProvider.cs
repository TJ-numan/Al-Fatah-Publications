using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_HRAnnounceProvider:DataAccessObject
{
	public SqlLi_HRAnnounceProvider()
    {
    }


    public bool DeleteLi_HRAnnounce(int li_HRAnnounceID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_HRAnnounce", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AnnId", SqlDbType.Int).Value = li_HRAnnounceID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_HRAnnounce> GetAllLi_HRAnnounces()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_HRAnnounces", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_HRAnnouncesFromReader(reader);
        }
    }
    public List<Li_HRAnnounce> GetLi_HRAnnouncesFromReader(IDataReader reader)
    {
        List<Li_HRAnnounce> li_HRAnnounces = new List<Li_HRAnnounce>();

        while (reader.Read())
        {
            li_HRAnnounces.Add(GetLi_HRAnnounceFromReader(reader));
        }
        return li_HRAnnounces;
    }

    public Li_HRAnnounce GetLi_HRAnnounceFromReader(IDataReader reader)
    {
        try
        {
            Li_HRAnnounce li_HRAnnounce = new Li_HRAnnounce
                (
                     
                    (int)reader["AnnId"],
                    reader["AnnTitle"].ToString(),
                    reader["AnnDetail"].ToString(),
                    (DateTime)reader["PublishDate"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_HRAnnounce;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_HRAnnounce GetLi_HRAnnounceByID(int li_HRAnnounceID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_HRAnnounceByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AnnId", SqlDbType.Int).Value = li_HRAnnounceID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_HRAnnounceFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_HRAnnounce(Li_HRAnnounce li_HRAnnounce)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_HRAnnounce", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@AnnId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AnnTitle", SqlDbType.VarChar).Value = li_HRAnnounce.AnnTitle;
            cmd.Parameters.Add("@AnnDetail", SqlDbType.VarChar).Value = li_HRAnnounce.AnnDetail;
            cmd.Parameters.Add("@PublishDate", SqlDbType.DateTime).Value = li_HRAnnounce.PublishDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_HRAnnounce.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_HRAnnounce.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_HRAnnounce.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_HRAnnounce.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_HRAnnounce.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AnnId"].Value;
        }
    }

    public bool UpdateLi_HRAnnounce(Li_HRAnnounce li_HRAnnounce)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_HRAnnounce", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@AnnId", SqlDbType.Int).Value = li_HRAnnounce.AnnId;
            cmd.Parameters.Add("@AnnTitle", SqlDbType.VarChar).Value = li_HRAnnounce.AnnTitle;
            cmd.Parameters.Add("@AnnDetail", SqlDbType.VarChar).Value = li_HRAnnounce.AnnDetail;
            cmd.Parameters.Add("@PublishDate", SqlDbType.DateTime).Value = li_HRAnnounce.PublishDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_HRAnnounce.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_HRAnnounce.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_HRAnnounce.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_HRAnnounce.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_HRAnnounce.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
