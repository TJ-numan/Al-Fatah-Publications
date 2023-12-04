using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_ReceiveChoatProvider:DataAccessObject
{
	public SqlLi_ReceiveChoatProvider()
    {
    }


    public bool DeleteLi_ReceiveChoat(int li_ReceiveChoatID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_ReceiveChoat", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_ReceiveChoatID", SqlDbType.Int).Value = li_ReceiveChoatID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_ReceiveChoat> GetAllLi_ReceiveChoats()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_ReceiveChoats", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ReceiveChoatsFromReader(reader);
        }
    }
    public List<Li_ReceiveChoat> GetLi_ReceiveChoatsFromReader(IDataReader reader)
    {
        List<Li_ReceiveChoat> li_ReceiveChoats = new List<Li_ReceiveChoat>();

        while (reader.Read())
        {
            li_ReceiveChoats.Add(GetLi_ReceiveChoatFromReader(reader));
        }
        return li_ReceiveChoats;
    }

    public Li_ReceiveChoat GetLi_ReceiveChoatFromReader(IDataReader reader)
    {
        try
        {
            Li_ReceiveChoat li_ReceiveChoat = new Li_ReceiveChoat
                (
                     
                    (int)reader["ID"],
                    (int)reader["PartyID"],
                    (int)reader["Qty"],
                    (decimal)reader["UnitPrice"],
                    (decimal)reader["TotalPrice"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"] 
                );
             return li_ReceiveChoat;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_ReceiveChoat GetLi_ReceiveChoatByID(int li_ReceiveChoatID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_ReceiveChoatByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_ReceiveChoatID", SqlDbType.Int).Value = li_ReceiveChoatID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ReceiveChoatFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_ReceiveChoat(Li_ReceiveChoat li_ReceiveChoat)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_ReceiveChoat", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PartyID", SqlDbType.Int).Value = li_ReceiveChoat.PartyID;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_ReceiveChoat.Qty;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = li_ReceiveChoat.UnitPrice;
            cmd.Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = li_ReceiveChoat.TotalPrice;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ReceiveChoat.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ReceiveChoat.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ReceiveChoat.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ReceiveChoat.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ID"].Value;
        }
    }

    public bool UpdateLi_ReceiveChoat(Li_ReceiveChoat li_ReceiveChoat)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_ReceiveChoat", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = li_ReceiveChoat.ID;
            cmd.Parameters.Add("@PartyID", SqlDbType.Int).Value = li_ReceiveChoat.PartyID;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_ReceiveChoat.Qty;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = li_ReceiveChoat.UnitPrice;
            cmd.Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = li_ReceiveChoat.TotalPrice;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ReceiveChoat.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ReceiveChoat.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ReceiveChoat.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ReceiveChoat.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
