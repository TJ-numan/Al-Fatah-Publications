using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlLi_DonationForProvider:DataAccessObject
{
	public SqlLi_DonationForProvider()
    {
    }


    public bool DeleteLi_DonationFor(int li_DonationForID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@", SqlDbType.Int).Value = li_DonationForID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_DonationFor> GetAllLi_DonationFors()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllLi_DonationFors", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_DonationForsFromReader(reader);
        }
    }
    public List<Li_DonationFor> GetLi_DonationForsFromReader(IDataReader reader)
    {
        List<Li_DonationFor> li_DonationFors = new List<Li_DonationFor>();

        while (reader.Read())
        {
            li_DonationFors.Add(GetLi_DonationForFromReader(reader));
        }
        return li_DonationFors;
    }

    public Li_DonationFor GetLi_DonationForFromReader(IDataReader reader)
    {
        try
        {
            Li_DonationFor li_DonationFor = new Li_DonationFor
                (
                
                    (int)reader["DoFId"],
                    reader["DonationFor"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"]
                );
             return li_DonationFor;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_DonationFor GetLi_DonationForByID(int li_DonationForID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@", SqlDbType.Int).Value = li_DonationForID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_DonationForFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_DonationFor(Li_DonationFor li_DonationFor)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("", connection);
            cmd.CommandType = CommandType.StoredProcedure;
    
            cmd.Parameters.Add("@DoFId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DonationFor", SqlDbType.VarChar).Value = li_DonationFor.DonationFor;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DonationFor.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DonationFor.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DoFId"].Value;
        }
    }

    public bool UpdateLi_DonationFor(Li_DonationFor li_DonationFor)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AFPERP_UpdateLi_DonationFor", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@DoFId", SqlDbType.Int).Value = li_DonationFor.DoFId;
            cmd.Parameters.Add("@DonationFor", SqlDbType.VarChar).Value = li_DonationFor.DonationFor;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DonationFor.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DonationFor.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
