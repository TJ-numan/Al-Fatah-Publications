using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_InnerFormaPrintingProvider:DataAccessObject
{
	public SqlLi_InnerFormaPrintingProvider()
    {
    }


    public bool DeleteLi_InnerFormaPrinting(int li_InnerFormaPrintingID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_InnerFormaPrinting", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_InnerFormaPrintingID", SqlDbType.Int).Value = li_InnerFormaPrintingID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_InnerFormaPrinting> GetAllLi_InnerFormaPrintings()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_InnerFormaPrintings", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_InnerFormaPrintingsFromReader(reader);
        }
    }
    public List<Li_InnerFormaPrinting> GetLi_InnerFormaPrintingsFromReader(IDataReader reader)
    {
        List<Li_InnerFormaPrinting> li_InnerFormaPrintings = new List<Li_InnerFormaPrinting>();

        while (reader.Read())
        {
            li_InnerFormaPrintings.Add(GetLi_InnerFormaPrintingFromReader(reader));
        }
        return li_InnerFormaPrintings;
    }

    public Li_InnerFormaPrinting GetLi_InnerFormaPrintingFromReader(IDataReader reader)
    {
        try
        {
            Li_InnerFormaPrinting li_InnerFormaPrinting = new Li_InnerFormaPrinting
                (
                     
                    reader["OrderNo"].ToString(),
                    reader["PressID"].ToString(),
                    reader["BookCode"].ToString(),
                    reader["BookSize"].ToString(),
                    reader["FormaDetail"].ToString(),
                    (decimal)reader["FormaNo"],
                    reader["FormaColour"].ToString(),
                    reader["PaperSizeID"].ToString(),
                    reader["PaperTypeID"].ToString(),
                    reader["PaperBrandID"].ToString(),
                    reader["PaperGSMID"].ToString(),
                    (bool)reader["Is1stPrint"],
                    (bool)reader["Is2ndPrint"],
                    (bool)reader["Is3rdPrint"],
                    (bool)reader["Is4thPrint"],
                    (bool)reader["Is5thPrint"],
                    (decimal)reader["PrintQty"],
                    reader["PaperType"].ToString(),
                    (decimal)reader["PaperQty"],
                    (decimal)reader["PrintUnitPrice"],
                    (decimal)reader["PrintTotalPrice"],
                    reader["PaperMUnit"].ToString(),
                    (DateTime)reader["OrderDate"],
                    reader["Remark"].ToString(),
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["ModifiedBy"],
                    (bool)reader["IsForma"] 
                     
                );
             return li_InnerFormaPrinting;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_InnerFormaPrinting GetLi_InnerFormaPrintingByID(int li_InnerFormaPrintingID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_InnerFormaPrintingByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_InnerFormaPrintingID", SqlDbType.Int).Value = li_InnerFormaPrintingID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_InnerFormaPrintingFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_InnerFormaPrinting(Li_InnerFormaPrinting li_InnerFormaPrinting)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_InnerFormaPrinting", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar,50) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_InnerFormaPrinting.PressID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_InnerFormaPrinting.BookCode;
            cmd.Parameters.Add("@BookSize", SqlDbType.VarChar).Value = li_InnerFormaPrinting.BookSize;
            cmd.Parameters.Add("@FormaDetail", SqlDbType.VarChar).Value = li_InnerFormaPrinting.FormaDetail;
            cmd.Parameters.Add("@FormaNo", SqlDbType.Decimal).Value = li_InnerFormaPrinting.FormaNo;
            cmd.Parameters.Add("@FormaColour", SqlDbType.VarChar).Value = li_InnerFormaPrinting.FormaColour;
            cmd.Parameters.Add("@PaperSizeID", SqlDbType.VarChar).Value = li_InnerFormaPrinting.PaperSizeID;
            cmd.Parameters.Add("@PaperTypeID", SqlDbType.VarChar).Value = li_InnerFormaPrinting.PaperTypeID;
            cmd.Parameters.Add("@PaperBrandID", SqlDbType.VarChar).Value = li_InnerFormaPrinting.PaperBrandID;
            cmd.Parameters.Add("@PaperGSMID", SqlDbType.VarChar).Value = li_InnerFormaPrinting.PaperGSMID;
            cmd.Parameters.Add("@Is1stPrint", SqlDbType.Bit).Value = li_InnerFormaPrinting.Is1stPrint;
            cmd.Parameters.Add("@Is2ndPrint", SqlDbType.Bit).Value = li_InnerFormaPrinting.Is2ndPrint;
            cmd.Parameters.Add("@Is3rdPrint", SqlDbType.Bit).Value = li_InnerFormaPrinting.Is3rdPrint;
            cmd.Parameters.Add("@Is4thPrint", SqlDbType.Bit).Value = li_InnerFormaPrinting.Is4thPrint;
            cmd.Parameters.Add("@Is5thPrint", SqlDbType.Bit).Value = li_InnerFormaPrinting.Is5thPrint;
            cmd.Parameters.Add("@PrintQty", SqlDbType.Decimal).Value = li_InnerFormaPrinting.PrintQty;
            cmd.Parameters.Add("@PaperType", SqlDbType.VarChar).Value = li_InnerFormaPrinting.PaperType;
            cmd.Parameters.Add("@PaperQty", SqlDbType.Decimal).Value = li_InnerFormaPrinting.PaperQty;
            cmd.Parameters.Add("@PrintUnitPrice", SqlDbType.Decimal).Value = li_InnerFormaPrinting.PrintUnitPrice;
            cmd.Parameters.Add("@PrintTotalPrice", SqlDbType.Decimal).Value = li_InnerFormaPrinting.PrintTotalPrice;
            cmd.Parameters.Add("@PaperMUnit", SqlDbType.VarChar).Value = li_InnerFormaPrinting.PaperMUnit;
            cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = li_InnerFormaPrinting.OrderDate;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_InnerFormaPrinting.Remark;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_InnerFormaPrinting.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_InnerFormaPrinting.CreatedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_InnerFormaPrinting.ModifiedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_InnerFormaPrinting.ModifiedBy;
            cmd.Parameters.Add("@IsForma", SqlDbType.Bit).Value = li_InnerFormaPrinting.IsForma;
           
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@OrderNo"].Value.ToString ();
        }
    }

    public bool UpdateLi_InnerFormaPrinting(Li_InnerFormaPrinting li_InnerFormaPrinting)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_InnerFormaPrinting", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = li_InnerFormaPrinting.OrderNo;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_InnerFormaPrinting.PressID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_InnerFormaPrinting.BookCode;
            cmd.Parameters.Add("@BookSize", SqlDbType.VarChar).Value = li_InnerFormaPrinting.BookSize;
            cmd.Parameters.Add("@FormaDetail", SqlDbType.VarChar).Value = li_InnerFormaPrinting.FormaDetail;
            cmd.Parameters.Add("@FormaNo", SqlDbType.Decimal).Value = li_InnerFormaPrinting.FormaNo;
            cmd.Parameters.Add("@FormaColour", SqlDbType.VarChar).Value = li_InnerFormaPrinting.FormaColour;
            cmd.Parameters.Add("@PaperSizeID", SqlDbType.VarChar).Value = li_InnerFormaPrinting.PaperSizeID;
            cmd.Parameters.Add("@PaperTypeID", SqlDbType.VarChar).Value = li_InnerFormaPrinting.PaperTypeID;
            cmd.Parameters.Add("@PaperBrandID", SqlDbType.VarChar).Value = li_InnerFormaPrinting.PaperBrandID;
            cmd.Parameters.Add("@PaperGSMID", SqlDbType.VarChar).Value = li_InnerFormaPrinting.PaperGSMID;
            cmd.Parameters.Add("@Is1stPrint", SqlDbType.Bit).Value = li_InnerFormaPrinting.Is1stPrint;
            cmd.Parameters.Add("@Is2ndPrint", SqlDbType.Bit).Value = li_InnerFormaPrinting.Is2ndPrint;
            cmd.Parameters.Add("@Is3rdPrint", SqlDbType.Bit).Value = li_InnerFormaPrinting.Is3rdPrint;
            cmd.Parameters.Add("@Is4thPrint", SqlDbType.Bit).Value = li_InnerFormaPrinting.Is4thPrint;
            cmd.Parameters.Add("@Is5thPrint", SqlDbType.Bit).Value = li_InnerFormaPrinting.Is5thPrint;
            cmd.Parameters.Add("@PrintQty", SqlDbType.Decimal).Value = li_InnerFormaPrinting.PrintQty;
            cmd.Parameters.Add("@PaperType", SqlDbType.VarChar).Value = li_InnerFormaPrinting.PaperType;
            cmd.Parameters.Add("@PaperQty", SqlDbType.Decimal).Value = li_InnerFormaPrinting.PaperQty;
            cmd.Parameters.Add("@PrintUnitPrice", SqlDbType.Decimal).Value = li_InnerFormaPrinting.PrintUnitPrice;
            cmd.Parameters.Add("@PrintTotalPrice", SqlDbType.Decimal).Value = li_InnerFormaPrinting.PrintTotalPrice;
            cmd.Parameters.Add("@PaperMUnit", SqlDbType.VarChar).Value = li_InnerFormaPrinting.PaperMUnit;
            cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = li_InnerFormaPrinting.OrderDate;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_InnerFormaPrinting.Remark;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_InnerFormaPrinting.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_InnerFormaPrinting.CreatedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_InnerFormaPrinting.ModifiedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_InnerFormaPrinting.ModifiedBy;
            cmd.Parameters.Add("@IsForma", SqlDbType.Bit).Value = li_InnerFormaPrinting.IsForma;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
