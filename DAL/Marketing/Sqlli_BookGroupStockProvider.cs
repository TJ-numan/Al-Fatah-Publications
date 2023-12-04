using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BookGroupStockProvider:DataAccessObject
{
	public SqlLi_BookGroupStockProvider()
    {
    }


    public bool DeleteLi_BookGroupStock(int li_BookGroupStockID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BookGroupStock", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BookGroupStockID", SqlDbType.Int).Value = li_BookGroupStockID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BookGroupStock> GetAllLi_BookGroupStocks()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BookGroupStocks", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BookGroupStocksFromReader(reader);
        }
    }
    public List<Li_BookGroupStock> GetLi_BookGroupStocksFromReader(IDataReader reader)
    {
        List<Li_BookGroupStock> li_BookGroupStocks = new List<Li_BookGroupStock>();

        while (reader.Read())
        {
            li_BookGroupStocks.Add(GetLi_BookGroupStockFromReader(reader));
        }
        return li_BookGroupStocks;
    }

    public Li_BookGroupStock GetLi_BookGroupStockFromReader(IDataReader reader)
    {
        try
        {
            Li_BookGroupStock li_BookGroupStock = new Li_BookGroupStock
                (
                     
                    reader["ID"].ToString(),
                    reader["BookCode"].ToString(),
                    (decimal)reader["Qty"],
                    (DateTime)reader["TransDate"],
                    (int)reader["CreatedBy"] ,
                    (bool)reader["IsTransferToGroup"],
                    (bool ) reader ["IsCentralStore"]
                );
             return li_BookGroupStock;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_BookGroupStock GetLi_BookGroupStockByID(int li_BookGroupStockID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BookGroupStockByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_BookGroupStockID", SqlDbType.Int).Value = li_BookGroupStockID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BookGroupStockFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_BookGroupStock(Li_BookGroupStock li_BookGroupStock)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BookGroupStock", connection);
            cmd.CommandType = CommandType.StoredProcedure;            
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BookGroupStock.BookCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_BookGroupStock.Qty;             
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookGroupStock.CreatedBy;
            cmd.Parameters.Add("@IsGroupedTransaction", SqlDbType.Bit).Value = li_BookGroupStock.IsTransferToGroup;
            cmd.Parameters.Add("@IsCentralStore", SqlDbType.Bit).Value = li_BookGroupStock.IsCentralStore;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_BookGroupStock(Li_BookGroupStock li_BookGroupStock)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BookGroupStock", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_BookGroupStock.ID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BookGroupStock.BookCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_BookGroupStock.Qty;
            cmd.Parameters.Add("@TransDate", SqlDbType.DateTime).Value = li_BookGroupStock.TransDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookGroupStock.CreatedBy;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
