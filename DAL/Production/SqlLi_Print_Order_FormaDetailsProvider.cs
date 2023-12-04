using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Print_Order_FormaDetailsProvider:DataAccessObject
{
	public SqlLi_Print_Order_FormaDetailsProvider()
    {
    }


    public bool DeleteLi_Print_Order_FormaDetails(int li_Print_Order_FormaDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Print_Order_FormaDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Print_Order_FormaDetailsID", SqlDbType.Int).Value = li_Print_Order_FormaDetailsID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Print_Order_FormaDetails> GetAllLi_Print_Order_FormaDetailss()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Print_Order_FormaDetailss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Print_Order_FormaDetailssFromReader(reader);
        }
    }
    public List<Li_Print_Order_FormaDetails> GetLi_Print_Order_FormaDetailssFromReader(IDataReader reader)
    {
        List<Li_Print_Order_FormaDetails> li_Print_Order_FormaDetailss = new List<Li_Print_Order_FormaDetails>();

        while (reader.Read())
        {
            li_Print_Order_FormaDetailss.Add(GetLi_Print_Order_FormaDetailsFromReader(reader));
        }
        return li_Print_Order_FormaDetailss;
    }

    public Li_Print_Order_FormaDetails GetLi_Print_Order_FormaDetailsFromReader(IDataReader reader)
    {
        try
        {
            Li_Print_Order_FormaDetails li_Print_Order_FormaDetails = new Li_Print_Order_FormaDetails
                (
                    
                    
                    reader["Print_OrderNo"].ToString(),
                    reader["BookPart"].ToString(),
                    reader["PressID"].ToString(),
                    reader["P_TypeID"].ToString(),
                    reader["P_SizeID"].ToString(),
                    reader["P_GSMID"].ToString(),
                    reader["P_BrandID"].ToString(),                   
                    (int)reader["ColorNo"],
                    (decimal)reader["FormaQty"],
                    (decimal)reader["BillRate"],
                    (decimal)reader["App_Paper"] ,
                    reader["FormaDis"].ToString() ,
                    (decimal)reader["TotalBill"],
                    reader["PapNote"].ToString(),
                    (int) reader ["PressPrintQty"],
                    (bool)reader ["Side"]
                );
             return li_Print_Order_FormaDetails;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Print_Order_FormaDetails GetLi_Print_Order_FormaDetailsByID(int li_Print_Order_FormaDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Print_Order_FormaDetailsByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Print_Order_FormaDetailsID", SqlDbType.Int).Value = li_Print_Order_FormaDetailsID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Print_Order_FormaDetailsFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Print_Order_FormaDetails(Li_Print_Order_FormaDetails li_Print_Order_FormaDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("web_SMPM_InsertLi_Print_Order_FormaDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@Print_OrderNo", SqlDbType.VarChar).Value = li_Print_Order_FormaDetails.Print_OrderNo;
            cmd.Parameters.Add("@BookPart", SqlDbType.NChar).Value = li_Print_Order_FormaDetails.BookPart;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_Print_Order_FormaDetails.PressID;
            cmd.Parameters.Add("@P_TypeID", SqlDbType.VarChar).Value = li_Print_Order_FormaDetails.P_TypeID;
            cmd.Parameters.Add("@P_SizeID", SqlDbType.VarChar).Value = li_Print_Order_FormaDetails.P_SizeID;
            cmd.Parameters.Add("@P_GSMID", SqlDbType.VarChar).Value = li_Print_Order_FormaDetails.P_GSMID;
            cmd.Parameters.Add("@P_BrandID", SqlDbType.VarChar).Value = li_Print_Order_FormaDetails.P_BrandID;            
            cmd.Parameters.Add("@ColorNo", SqlDbType.Int).Value = li_Print_Order_FormaDetails.ColorNo;
            cmd.Parameters.Add("@FormaQty", SqlDbType.Decimal).Value = li_Print_Order_FormaDetails.FormaQty;
            cmd.Parameters.Add("@BillRate", SqlDbType.Decimal).Value = li_Print_Order_FormaDetails.BillRate;
            cmd.Parameters.Add("@App_Paper", SqlDbType.Decimal).Value = li_Print_Order_FormaDetails.App_Paper;
            cmd.Parameters.Add("@FormaDis", SqlDbType.VarChar ).Value = li_Print_Order_FormaDetails.FormaDis ;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal ).Value = li_Print_Order_FormaDetails. TotalBill ;            
            cmd.Parameters.Add("@PapNote", SqlDbType.Text).Value = li_Print_Order_FormaDetails. PaperNote;
            cmd.Parameters.Add("@PressPrintQty", SqlDbType.Int).Value = li_Print_Order_FormaDetails. PressPrintQty;
            cmd.Parameters.Add("@Side", SqlDbType.Int).Value = li_Print_Order_FormaDetails.Side;  

             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@Li_Print_Order_FormaDetailsID"].Value;
        }
    }

    public bool UpdateLi_Print_Order_FormaDetails(Li_Print_Order_FormaDetails li_Print_Order_FormaDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Print_Order_FormaDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@Print_OrderNo", SqlDbType.VarChar).Value = li_Print_Order_FormaDetails.Print_OrderNo;
            cmd.Parameters.Add("@BookPart", SqlDbType.NChar).Value = li_Print_Order_FormaDetails.BookPart;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_Print_Order_FormaDetails.PressID;
            cmd.Parameters.Add("@P_TypeID", SqlDbType.VarChar).Value = li_Print_Order_FormaDetails.P_TypeID;
            cmd.Parameters.Add("@P_SizeID", SqlDbType.VarChar).Value = li_Print_Order_FormaDetails.P_SizeID;
            cmd.Parameters.Add("@P_GSMID", SqlDbType.VarChar).Value = li_Print_Order_FormaDetails.P_GSMID;
            cmd.Parameters.Add("@P_BrandID", SqlDbType.VarChar).Value = li_Print_Order_FormaDetails.P_BrandID;         
            cmd.Parameters.Add("@ColorNo", SqlDbType.Int).Value = li_Print_Order_FormaDetails.ColorNo;
            cmd.Parameters.Add("@FormaQty", SqlDbType.Decimal).Value = li_Print_Order_FormaDetails.FormaQty;
            cmd.Parameters.Add("@BillRate", SqlDbType.Decimal).Value = li_Print_Order_FormaDetails.BillRate;
            cmd.Parameters.Add("@App_Paper", SqlDbType.Decimal).Value = li_Print_Order_FormaDetails.App_Paper;
            cmd.Parameters.Add("@App_Paper", SqlDbType.Decimal).Value = li_Print_Order_FormaDetails.App_Paper;
            cmd.Parameters.Add("@FormaDis", SqlDbType.VarChar).Value = li_Print_Order_FormaDetails.FormaDis;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal ).Value = li_Print_Order_FormaDetails. TotalBill ;     
            cmd.Parameters.Add("@PapNote", SqlDbType.Text).Value = li_Print_Order_FormaDetails. PaperNote;  

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
