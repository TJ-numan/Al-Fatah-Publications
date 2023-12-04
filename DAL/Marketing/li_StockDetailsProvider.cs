using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using DAL;

public class SqlStockDetailsProvider:DataAccessObject
{
	public SqlStockDetailsProvider()
    {
    }


    public List<li_StockDetails> GetAllStockDetailss()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAllStockDetailss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetStockDetailssFromReader(reader);
        }
    }
    public List<li_StockDetails> GetStockDetailssFromReader(IDataReader reader)
    {
        List<li_StockDetails> StockDetailss = new List<li_StockDetails>();

        while (reader.Read())
        {
            StockDetailss.Add(GetStockDetailsFromReader(reader));
        }
        return StockDetailss;
    }

    public li_StockDetails GetStockDetailsFromReader(IDataReader reader)
    {
        try
        {
            li_StockDetails li_StockDetails = new li_StockDetails
                (

                    reader["StockID"].ToString(),
                    reader["BookAcCode"].ToString(),
                    (int)reader["Quantity"],
                    (decimal)reader["CurrentStock"],
                    (DateTime)reader["StockEntryDate"]
                );
             return li_StockDetails;
        }
        catch(Exception )
        {
            return null;
        }
    }

    public li_StockDetails GetStockDetailsByStockID(string   stockID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetStockDetailsByStockID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StockID", SqlDbType.VarChar).Value = stockID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetStockDetailsFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public void  InsertStockDetails(li_StockDetails StockDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_InsertStockDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = StockDetails.BookAcCode;
            cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = StockDetails.Quantity;
          
            cmd.Parameters.Add("@StockEntryDate", SqlDbType.DateTime).Value = StockDetails.StockEntryDate;
            connection.Open();

            cmd.ExecuteNonQuery();
           
        }
    }

    public bool UpdateStockDetails(li_StockDetails StockDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_UpdateStockDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StockID", SqlDbType.VarChar).Value = StockDetails.StockID;
            cmd.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = StockDetails.BookAcCode;
            cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = StockDetails.Quantity;
            cmd.Parameters.Add("@CurrentStock", SqlDbType.Decimal).Value = StockDetails.CurrentStock;
            cmd.Parameters.Add("@StockEntryDate", SqlDbType.DateTime).Value = StockDetails.StockEntryDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteStockDetails(int stockID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_DeleteStockDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StockID", SqlDbType.VarChar).Value = stockID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

