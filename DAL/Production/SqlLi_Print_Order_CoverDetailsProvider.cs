using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Print_Order_CoverDetailsProvider:DataAccessObject
{
	public SqlLi_Print_Order_CoverDetailsProvider()
    {
    }


    public bool DeleteLi_Print_Order_CoverDetails(int li_Print_Order_CoverDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Print_Order_CoverDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Print_Order_CoverDetailsID", SqlDbType.Int).Value = li_Print_Order_CoverDetailsID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Print_Order_CoverDetails> GetAllLi_Print_Order_CoverDetailss()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Print_Order_CoverDetailss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Print_Order_CoverDetailssFromReader(reader);
        }
    }
    public List<Li_Print_Order_CoverDetails> GetLi_Print_Order_CoverDetailssFromReader(IDataReader reader)
    {
        List<Li_Print_Order_CoverDetails> li_Print_Order_CoverDetailss = new List<Li_Print_Order_CoverDetails>();

        while (reader.Read())
        {
            li_Print_Order_CoverDetailss.Add(GetLi_Print_Order_CoverDetailsFromReader(reader));
        }
        return li_Print_Order_CoverDetailss;
    }

    public Li_Print_Order_CoverDetails GetLi_Print_Order_CoverDetailsFromReader(IDataReader reader)
    {
        try
        {
            Li_Print_Order_CoverDetails li_Print_Order_CoverDetails = new Li_Print_Order_CoverDetails
                (
                 
                    (int)reader["SerialNo"],
                    reader["Print_OrderNo"].ToString(),
                    (int)reader["Ups"],
                    (int)reader["Impression"],
                    (int)reader["ColorNo"],
                    (decimal)reader["BillRate"],
                    (decimal)reader["TotalBill"],
                    (int)reader["CoverQty"],
                    reader["ExPrintNote"].ToString() 
                );
             return li_Print_Order_CoverDetails;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Print_Order_CoverDetails GetLi_Print_Order_CoverDetailsByID(int li_Print_Order_CoverDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Print_Order_CoverDetailsByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Print_Order_CoverDetailsID", SqlDbType.Int).Value = li_Print_Order_CoverDetailsID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Print_Order_CoverDetailsFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Print_Order_CoverDetails(Li_Print_Order_CoverDetails li_Print_Order_CoverDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Print_Order_CoverDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Print_OrderNo", SqlDbType.VarChar).Value = li_Print_Order_CoverDetails.Print_OrderNo;
            cmd.Parameters.Add("@Ups", SqlDbType.Int).Value = li_Print_Order_CoverDetails.Ups;
            cmd.Parameters.Add("@Impression", SqlDbType.Int).Value = li_Print_Order_CoverDetails.Impression;
            cmd.Parameters.Add("@ColorNo", SqlDbType.Int).Value = li_Print_Order_CoverDetails.ColorNo;
            cmd.Parameters.Add("@BillRate", SqlDbType.Decimal).Value = li_Print_Order_CoverDetails.BillRate;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_Print_Order_CoverDetails.TotalBill;
            cmd.Parameters.Add("@CoverQty", SqlDbType.Int).Value = li_Print_Order_CoverDetails.CoverQty;
            cmd.Parameters.Add("@ExPrintNote", SqlDbType.Text).Value = li_Print_Order_CoverDetails.ExPrintNote;
       
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  1;
        }
    }

    public bool UpdateLi_Print_Order_CoverDetails(Li_Print_Order_CoverDetails li_Print_Order_CoverDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Print_Order_CoverDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_Print_Order_CoverDetails.SerialNo;
            cmd.Parameters.Add("@Print_OrderNo", SqlDbType.VarChar).Value = li_Print_Order_CoverDetails.Print_OrderNo;
            cmd.Parameters.Add("@Ups", SqlDbType.Int).Value = li_Print_Order_CoverDetails.Ups;
            cmd.Parameters.Add("@Impression", SqlDbType.Int).Value = li_Print_Order_CoverDetails.Impression;
            cmd.Parameters.Add("@ColorNo", SqlDbType.Int).Value = li_Print_Order_CoverDetails.ColorNo;
            cmd.Parameters.Add("@BillRate", SqlDbType.Decimal).Value = li_Print_Order_CoverDetails.BillRate;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_Print_Order_CoverDetails.TotalBill;
            cmd.Parameters.Add("@CoverQty", SqlDbType.Int).Value = li_Print_Order_CoverDetails.CoverQty;
            cmd.Parameters.Add("@ExPrintNote", SqlDbType.Text).Value = li_Print_Order_CoverDetails.ExPrintNote;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
