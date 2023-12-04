using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlLi_DonationDesProvider:DataAccessObject
{
	public SqlLi_DonationDesProvider()
    {
    }


    public bool DeleteLi_DonationDes(int li_DonationDesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@", SqlDbType.Int).Value = li_DonationDesID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_DonationDes> GetAllLi_DonationDess()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_LI_GetAllLi_DonationDess", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_DonationDessFromReader(reader);
        }
    }

    public List<Li_DonationDes> GetAllLi_DonationDessWithBudget()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_LI_GetAllLi_DonationDessWithBudget", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_DonationDessFromReader(reader);
        }
    }
    public List<Li_DonationDes> GetLi_DonationDessFromReader(IDataReader reader)
    {
        List<Li_DonationDes> li_DonationDess = new List<Li_DonationDes>();

        while (reader.Read())
        {
            li_DonationDess.Add(GetLi_DonationDesFromReader(reader));
        }
        return li_DonationDess;
    }

    public Li_DonationDes GetLi_DonationDesFromReader(IDataReader reader)
    {
        try
        {
            Li_DonationDes li_DonationDes = new Li_DonationDes
                (
                
                    (int)reader["DoDesId"],
                    reader["DoDescription"].ToString(),
                    (bool)reader["IsBdgIncluse"]
                );
             return li_DonationDes;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_DonationDes GetLi_DonationDesByID(int li_DonationDesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@", SqlDbType.Int).Value = li_DonationDesID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_DonationDesFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_DonationDes(Li_DonationDes li_DonationDes)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@DoDesId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DoDescription", SqlDbType.VarChar).Value = li_DonationDes.DoDescription;
            cmd.Parameters.Add("@IsBdgIncluse", SqlDbType.Bit).Value = li_DonationDes.IsBdgIncluse;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DoDesId"].Value;
        }
    }

    public bool UpdateLi_DonationDes(Li_DonationDes li_DonationDes)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@DoDesId", SqlDbType.Int).Value = li_DonationDes.DoDesId;
            cmd.Parameters.Add("@DoDescription", SqlDbType.VarChar).Value = li_DonationDes.DoDescription;
            cmd.Parameters.Add("@IsBdgIncluse", SqlDbType.Bit).Value = li_DonationDes.IsBdgIncluse;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
