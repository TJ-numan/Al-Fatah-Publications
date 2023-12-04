using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_GodownReceiveChoatProvider:DataAccessObject
{
	public SqlLi_GodownReceiveChoatProvider()
    {
    }


    public bool DeleteLi_GodownReceiveChoat(int li_GodownReceiveChoatID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_GodownReceiveChoat", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_GodownReceiveChoatID", SqlDbType.Int).Value = li_GodownReceiveChoatID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_GodownReceiveChoat> GetAllLi_GodownReceiveChoats()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_GodownReceiveChoats", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_GodownReceiveChoatsFromReader(reader);
        }
    }
    public List<Li_GodownReceiveChoat> GetLi_GodownReceiveChoatsFromReader(IDataReader reader)
    {
        List<Li_GodownReceiveChoat> li_GodownReceiveChoats = new List<Li_GodownReceiveChoat>();

        while (reader.Read())
        {
            li_GodownReceiveChoats.Add(GetLi_GodownReceiveChoatFromReader(reader));
        }
        return li_GodownReceiveChoats;
    }

    public Li_GodownReceiveChoat GetLi_GodownReceiveChoatFromReader(IDataReader reader)
    {
        try
        {
            Li_GodownReceiveChoat li_GodownReceiveChoat = new Li_GodownReceiveChoat
                (
                     
                    (int)reader["ReceiveID"],
                    (int)reader["PartyID"],
                    (DateTime)reader["ReceiveDate"],
                    (int)reader["ReceiveBy"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["Qty"] 
                    
                );
             return li_GodownReceiveChoat;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_GodownReceiveChoat GetLi_GodownReceiveChoatByID(int li_GodownReceiveChoatID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_GodownReceiveChoatByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_GodownReceiveChoatID", SqlDbType.Int).Value = li_GodownReceiveChoatID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_GodownReceiveChoatFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_GodownReceiveChoat(Li_GodownReceiveChoat li_GodownReceiveChoat)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_GodownReceiveChoat", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ReceiveID", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PartyID", SqlDbType.Int).Value = li_GodownReceiveChoat.PartyID;
            cmd.Parameters.Add("@ReceiveDate", SqlDbType.DateTime).Value = li_GodownReceiveChoat.ReceiveDate;
            cmd.Parameters.Add("@ReceiveBy", SqlDbType.Int).Value = li_GodownReceiveChoat.ReceiveBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_GodownReceiveChoat.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_GodownReceiveChoat.ModifiedDate;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_GodownReceiveChoat.Qty;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ReceiveID"].Value;
        }
    }

    public bool UpdateLi_GodownReceiveChoat(Li_GodownReceiveChoat li_GodownReceiveChoat)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_GodownReceiveChoat", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ReceiveID", SqlDbType.Int).Value = li_GodownReceiveChoat.ReceiveID;
            cmd.Parameters.Add("@PartyID", SqlDbType.Int).Value = li_GodownReceiveChoat.PartyID;
            cmd.Parameters.Add("@ReceiveDate", SqlDbType.DateTime).Value = li_GodownReceiveChoat.ReceiveDate;
            cmd.Parameters.Add("@ReceiveBy", SqlDbType.Int).Value = li_GodownReceiveChoat.ReceiveBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_GodownReceiveChoat.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_GodownReceiveChoat.ModifiedDate;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_GodownReceiveChoat.Qty;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
