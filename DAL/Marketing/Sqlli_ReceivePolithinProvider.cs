using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using DAL;

public class SqlLi_ReceivePolithinProvider:DataAccessObject
{
	public SqlLi_ReceivePolithinProvider()
    {
    }


    public bool DeleteLi_ReceivePolithin(int li_ReceivePolithinID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_ReceivePolithin", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_ReceivePolithinID", SqlDbType.Int).Value = li_ReceivePolithinID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_ReceivePolithin> GetAllLi_ReceivePolithins()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_ReceivePolithins", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ReceivePolithinsFromReader(reader);
        }
    }
    public List<Li_ReceivePolithin> GetLi_ReceivePolithinsFromReader(IDataReader reader)
    {
        List<Li_ReceivePolithin> li_ReceivePolithins = new List<Li_ReceivePolithin>();

        while (reader.Read())
        {
            li_ReceivePolithins.Add(GetLi_ReceivePolithinFromReader(reader));
        }
        return li_ReceivePolithins;
    }

    public Li_ReceivePolithin GetLi_ReceivePolithinFromReader(IDataReader reader)
    {
        try
        {
            Li_ReceivePolithin li_ReceivePolithin = new Li_ReceivePolithin
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
             return li_ReceivePolithin;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_ReceivePolithin GetLi_ReceivePolithinByID(int li_ReceivePolithinID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_ReceivePolithinByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_ReceivePolithinID", SqlDbType.Int).Value = li_ReceivePolithinID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ReceivePolithinFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_ReceivePolithin(Li_ReceivePolithin li_ReceivePolithin)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_ReceivePolithin", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PartyID", SqlDbType.Int).Value = li_ReceivePolithin.PartyID;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_ReceivePolithin.Qty;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = li_ReceivePolithin.UnitPrice;
            cmd.Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = li_ReceivePolithin.TotalPrice;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ReceivePolithin.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ReceivePolithin.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ReceivePolithin.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ReceivePolithin.ModifiedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ID"].Value;
        }
    }

    public bool UpdateLi_ReceivePolithin(Li_ReceivePolithin li_ReceivePolithin)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_ReceivePolithin", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.Int).Value = li_ReceivePolithin.ID;
            cmd.Parameters.Add("@PartyID", SqlDbType.Int).Value = li_ReceivePolithin.PartyID;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_ReceivePolithin.Qty;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = li_ReceivePolithin.UnitPrice;
            cmd.Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = li_ReceivePolithin.TotalPrice;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ReceivePolithin.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ReceivePolithin.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ReceivePolithin.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ReceivePolithin.ModifiedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
