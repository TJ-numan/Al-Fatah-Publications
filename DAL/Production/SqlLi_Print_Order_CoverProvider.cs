using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Print_Order_CoverProvider:DataAccessObject
{
	public SqlLi_Print_Order_CoverProvider()
    {
    }


    public bool DeleteLi_Print_Order_Cover(int li_Print_Order_CoverID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Print_Order_Cover", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Print_Order_CoverID", SqlDbType.Int).Value = li_Print_Order_CoverID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Print_Order_Cover> GetAllLi_Print_Order_Covers()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Print_Order_Covers", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Print_Order_CoversFromReader(reader);
        }
    }
    public List<Li_Print_Order_Cover> GetLi_Print_Order_CoversFromReader(IDataReader reader)
    {
        List<Li_Print_Order_Cover> li_Print_Order_Covers = new List<Li_Print_Order_Cover>();

        while (reader.Read())
        {
            li_Print_Order_Covers.Add(GetLi_Print_Order_CoverFromReader(reader));
        }
        return li_Print_Order_Covers;
    }

    public Li_Print_Order_Cover GetLi_Print_Order_CoverFromReader(IDataReader reader)
    {
        try
        {
            Li_Print_Order_Cover li_Print_Order_Cover = new Li_Print_Order_Cover
                (
                     
                    reader["Print_OrderNo"].ToString(),
                    (DateTime)reader["OrderDate"],
                    reader["BookCode"].ToString(),
                    reader["PressID"].ToString(),
                    (int)reader["PrintQty"],
                    (int)reader["PrintSl"],
                    (decimal)reader["FormaTotal"],
                     reader["PaperType"].ToString(), 
                     reader["PaperSize"].ToString(),  
                     reader["PaperGsm"].ToString(),  
                     reader["BrandID"].ToString(),
                    (int)reader["Sett_Sheet"],
                    (decimal)reader["App_Paper"],
                    (decimal )reader["Pcs_Sheet"],
                    (decimal )reader["TotalPcs"],
                    (int)reader["Total_Impress"],
                    (int)reader["Total_Cover"],
                    (decimal)reader["TotalBill"],
                    reader["Remark"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["DeleBy"],
                    (DateTime)reader["DeleDate"],
                    reader["CauseOfDel"].ToString(),
                    (bool)reader["ShortForma"],
                    (bool)reader["OtherPrint"] ,
                    reader ["Edition"].ToString ()
                );
             return li_Print_Order_Cover;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Print_Order_Cover GetLi_Print_Order_CoverByID(int li_Print_Order_CoverID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Print_Order_CoverByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Print_Order_CoverID", SqlDbType.Int).Value = li_Print_Order_CoverID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Print_Order_CoverFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_Print_Order_Cover(Li_Print_Order_Cover li_Print_Order_Cover)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Print_Order_Cover", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@Print_OrderNo", SqlDbType.VarChar,50). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = li_Print_Order_Cover.OrderDate;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_Print_Order_Cover.BookCode;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_Print_Order_Cover.PressID;
            cmd.Parameters.Add("@PrintQty", SqlDbType.Int).Value = li_Print_Order_Cover.PrintQty;
            cmd.Parameters.Add("@PrintSl", SqlDbType.Int).Value = li_Print_Order_Cover.PrintSl;
            cmd.Parameters.Add("@FormaTotal", SqlDbType.Decimal).Value = li_Print_Order_Cover.FormaTotal;
            cmd.Parameters.Add("@PaperType", SqlDbType.VarChar).Value = li_Print_Order_Cover.PaperType;
            cmd.Parameters.Add("@PaperSize", SqlDbType.VarChar).Value = li_Print_Order_Cover.PaperSize;
            cmd.Parameters.Add("@PaperGsm", SqlDbType.VarChar).Value = li_Print_Order_Cover.PaperGsm;
            cmd.Parameters.Add("@BrandID", SqlDbType.VarChar).Value = li_Print_Order_Cover.BrandID;
            cmd.Parameters.Add("@Sett_Sheet", SqlDbType.Int).Value = li_Print_Order_Cover.Sett_Sheet;
            cmd.Parameters.Add("@App_Paper", SqlDbType.Decimal).Value = li_Print_Order_Cover.App_Paper;
            cmd.Parameters.Add("@Pcs_Sheet", SqlDbType.Decimal).Value = li_Print_Order_Cover.Pcs_Sheet;
            cmd.Parameters.Add("@TotalPcs", SqlDbType.Decimal).Value = li_Print_Order_Cover.TotalPcs;
            cmd.Parameters.Add("@Total_Impress", SqlDbType.Int).Value = li_Print_Order_Cover.Total_Impress;
            cmd.Parameters.Add("@Total_Cover", SqlDbType.Int).Value = li_Print_Order_Cover.Total_Cover;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_Print_Order_Cover.TotalBill;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_Print_Order_Cover.Remark;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Print_Order_Cover.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Print_Order_Cover.CreatedDate;
            cmd.Parameters.Add("@DeleBy", SqlDbType.Int).Value = li_Print_Order_Cover.DeleBy;
            cmd.Parameters.Add("@DeleDate", SqlDbType.DateTime).Value = DBNull .Value ;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_Print_Order_Cover.CauseOfDel;
            cmd.Parameters.Add("@ShortForma", SqlDbType.Bit).Value = li_Print_Order_Cover.ShortForma;
            cmd.Parameters.Add("@OtherPrint", SqlDbType.Bit).Value = li_Print_Order_Cover.OtherPrint;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar ).Value = li_Print_Order_Cover.Edition; 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@Print_OrderNo"].Value.ToString ();
        }
    }

    public bool UpdateLi_Print_Order_Cover(Li_Print_Order_Cover li_Print_Order_Cover)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Print_Order_Cover", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@Print_OrderNo", SqlDbType.VarChar).Value = li_Print_Order_Cover.Print_OrderNo;
            cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = li_Print_Order_Cover.OrderDate;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_Print_Order_Cover.BookCode;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_Print_Order_Cover.PressID;
            cmd.Parameters.Add("@PrintQty", SqlDbType.Int).Value = li_Print_Order_Cover.PrintQty;
            cmd.Parameters.Add("@PrintSl", SqlDbType.Int).Value = li_Print_Order_Cover.PrintSl;
            cmd.Parameters.Add("@FormaTotal", SqlDbType.Decimal).Value = li_Print_Order_Cover.FormaTotal;
            cmd.Parameters.Add("@PaperType", SqlDbType.VarChar).Value = li_Print_Order_Cover.PaperType;
            cmd.Parameters.Add("@PaperSize", SqlDbType.VarChar).Value = li_Print_Order_Cover.PaperSize;
            cmd.Parameters.Add("@PaperGsm", SqlDbType.VarChar).Value = li_Print_Order_Cover.PaperGsm;
            cmd.Parameters.Add("@BrandID", SqlDbType.VarChar).Value = li_Print_Order_Cover.BrandID;
            cmd.Parameters.Add("@Sett_Sheet", SqlDbType.Int).Value = li_Print_Order_Cover.Sett_Sheet;
            cmd.Parameters.Add("@App_Paper", SqlDbType.Decimal).Value = li_Print_Order_Cover.App_Paper;
            cmd.Parameters.Add("@Pcs_Sheet", SqlDbType.Int).Value = li_Print_Order_Cover.Pcs_Sheet;
            cmd.Parameters.Add("@TotalPcs", SqlDbType.Int).Value = li_Print_Order_Cover.TotalPcs;
            cmd.Parameters.Add("@Total_Impress", SqlDbType.Int).Value = li_Print_Order_Cover.Total_Impress;
            cmd.Parameters.Add("@Total_Cover", SqlDbType.Int).Value = li_Print_Order_Cover.Total_Cover;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_Print_Order_Cover.TotalBill;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_Print_Order_Cover.Remark;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Print_Order_Cover.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Print_Order_Cover.CreatedDate;
            cmd.Parameters.Add("@DeleBy", SqlDbType.Int).Value = li_Print_Order_Cover.DeleBy;
            cmd.Parameters.Add("@DeleDate", SqlDbType.DateTime).Value = li_Print_Order_Cover.DeleDate;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_Print_Order_Cover.CauseOfDel;
            cmd.Parameters.Add("@ShortForma", SqlDbType.Bit).Value = li_Print_Order_Cover.ShortForma;
            cmd.Parameters.Add("@OtherPrint", SqlDbType.Bit).Value = li_Print_Order_Cover.OtherPrint;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
