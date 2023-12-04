using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using Common.Marketing;
using DAL;

public class Sql_li_StockProvider:DataAccessObject
{
	public Sql_li_StockProvider()
    {
    }


    public List<li_Stock> GetAll_Stocks()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_Stocks", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_StocksFromReader(reader);
        }
    }

    public DataSet   GetAll_StocksWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_StocksWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


    public DataSet GetCurrentYearSalesStatus( string BookCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetCurrentYearSalesStatus", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;

            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }


  public DataSet GetLastYearSalesStatus( string BookCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetLastYearSalesStatus", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }


    public DataSet GetAllStocks(string BookGroup, string BookName, string Class, string Edition, string price)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("web_SMPM_li_GetAllStocks", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookGroup", SqlDbType.VarChar).Value = BookGroup ;
            command.Parameters.Add("@Bookname", SqlDbType.VarChar).Value = BookName;
            command.Parameters.Add("@Class", SqlDbType.VarChar).Value = Class;
            command.Parameters.Add("@Edition", SqlDbType.VarChar).Value = Edition;
            command.Parameters.Add("@Price", SqlDbType.VarChar).Value = price;


            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }


    public List<li_Stock> Get_StocksFromReader(IDataReader reader)
    {
        List<li_Stock> li_Stocks = new List<li_Stock>();

        while (reader.Read())
        {
            li_Stocks.Add(Get_StockFromReader(reader));
        }
        return li_Stocks;
    }

    public li_Stock Get_StockFromReader(IDataReader reader)
    {
        try
        {
            li_Stock li_Stock = new li_Stock
                (

                    reader["BookAcCode"].ToString(),
                    (decimal)reader["StockQuantity"],
                    (DateTime)reader["EntryDate"]
                );
             return li_Stock;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public li_Stock Get_StockByBookAcCode(string  bookAcCode)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_StockByBookAcCode", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = bookAcCode;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return Get_StockFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int Insert_Stock(li_Stock li_Stock)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Insert_Stock", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@StockQuantity", SqlDbType.Decimal).Value = li_Stock.StockQuantity;
            cmd.Parameters.Add("@EntryDate", SqlDbType.DateTime).Value = li_Stock.EntryDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BookAcCode"].Value;
        }
    }

    public bool Update_Stock(li_Stock li_Stock,bool IsCentralStore)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Update_Stock", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = li_Stock.BookAcCode;
            cmd.Parameters.Add("@StockQuantity", SqlDbType.Decimal).Value = li_Stock.StockQuantity;
            cmd.Parameters.Add("@IsCentralStore", SqlDbType. Bit ).Value = IsCentralStore ;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool Delete_Stock(int bookAcCode)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Delete_Stock", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = bookAcCode;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }


    public List<BookVersionInfo> GetAllStockInformations()
    {
        List<BookVersionInfo> informations= new List<BookVersionInfo>();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_Web_Get_AllBookVersionInfo", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                BookVersionInfo aBookVersionInfo = new BookVersionInfo();
                aBookVersionInfo.BookCode = (string) reader["BookCode"];
                aBookVersionInfo.BookName = (string) reader["BookName"];
                aBookVersionInfo.ClassName = (string) reader["Class Name"];
                aBookVersionInfo.BookType = (string) reader["Book Type"];
                aBookVersionInfo.Edition = (string) reader["Edition"];
                aBookVersionInfo.Price = (decimal) reader["Price"];
                aBookVersionInfo.StockQuantity = (decimal) reader["StockQuantity"];
                aBookVersionInfo.SerialNo = (int) reader["SerialNo"];
                informations.Add(aBookVersionInfo);
            }
        }
        return informations;
    }
}

