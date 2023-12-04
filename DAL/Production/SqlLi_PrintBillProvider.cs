using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PrintBillProvider:DataAccessObject
{
	public SqlLi_PrintBillProvider()
    {
    }


    public bool DeleteLi_PrintBill(int li_PrintBillID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PrintBill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PrintBillID", SqlDbType.Int).Value = li_PrintBillID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PrintBill> GetAllLi_PrintBills()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PrintBills", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PrintBillsFromReader(reader);
        }
    }
    public List<Li_PrintBill> GetLi_PrintBillsFromReader(IDataReader reader)
    {
        List<Li_PrintBill> li_PrintBills = new List<Li_PrintBill>();

        while (reader.Read())
        {
            li_PrintBills.Add(GetLi_PrintBillFromReader(reader));
        }
        return li_PrintBills;
    }

    public Li_PrintBill GetLi_PrintBillFromReader(IDataReader reader)
    {
        try
        {
            Li_PrintBill li_PrintBill = new Li_PrintBill
                (
                     
                    (int)reader["BillSerial"],
                    reader["BillNo"].ToString(),
                    (DateTime)reader["BillDate"],
                    reader["OrderNo"].ToString(),
                    reader["BookCode"].ToString(),
                   
                    (decimal)reader["PrintBill"],
                    (decimal)reader["PlateBill"],
                    (decimal)reader["ProcessBill"],
                    (decimal)reader["TotalBill"],
                    reader["Remark"].ToString(),
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (char)reader["Status_D"],
                    reader["CauseOfDel"].ToString(),
                    (DateTime)reader["DelDate"],
                    (int)reader["DelBy"] ,
                    reader ["PressID"].ToString () ,
                    (decimal)reader["PrintQty"],
                    (bool)reader ["Extra"]
                );
             return li_PrintBill;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PrintBill GetLi_PrintBillByID(int li_PrintBillID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PrintBillByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PrintBillID", SqlDbType.Int).Value = li_PrintBillID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PrintBillFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PrintBill(Li_PrintBill li_PrintBill)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PrintBill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@BillSerial", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = li_PrintBill.BillNo;
            cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = li_PrintBill.BillDate;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = li_PrintBill.OrderNo;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_PrintBill.BookCode;
            cmd.Parameters.Add("@PrintBill", SqlDbType.Decimal).Value = li_PrintBill.PrintBill;
            cmd.Parameters.Add("@PlateBill", SqlDbType.Decimal).Value = li_PrintBill.PlateBill;
            cmd.Parameters.Add("@ProcessBill", SqlDbType.Decimal).Value = li_PrintBill.ProcessBill;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_PrintBill.TotalBill;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_PrintBill.Remark;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PrintBill.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PrintBill.CreatedBy;
          
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_PrintBill.CauseOfDel;
            cmd.Parameters.Add("@DelDate", SqlDbType.DateTime).Value = li_PrintBill.DelDate;
            cmd.Parameters.Add("@DelBy", SqlDbType.Int).Value = li_PrintBill.DelBy;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_PrintBill.PressID;
            cmd.Parameters.Add("@PrintQty", SqlDbType.VarChar).Value = li_PrintBill.PrintQty;
            cmd.Parameters.Add("@Extra", SqlDbType.Bit).Value = li_PrintBill. Extra ;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BillSerial"].Value;
        }
    }

    public bool UpdateLi_PrintBill(Li_PrintBill li_PrintBill)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PrintBill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@BillSerial", SqlDbType.Int).Value = li_PrintBill.BillSerial;
            cmd.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = li_PrintBill.BillNo;
            cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = li_PrintBill.BillDate;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = li_PrintBill.OrderNo;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_PrintBill.BookCode;
            cmd.Parameters.Add("@PrintBill", SqlDbType.Decimal).Value = li_PrintBill.PrintBill;
            cmd.Parameters.Add("@PlateBill", SqlDbType.Decimal).Value = li_PrintBill.PlateBill;
            cmd.Parameters.Add("@ProcessBill", SqlDbType.Decimal).Value = li_PrintBill.ProcessBill;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_PrintBill.TotalBill;
            cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = li_PrintBill.Remark;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PrintBill.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PrintBill.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_PrintBill.Status_D;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_PrintBill.CauseOfDel;
            cmd.Parameters.Add("@DelDate", SqlDbType.DateTime).Value = li_PrintBill.DelDate;
            cmd.Parameters.Add("@DelBy", SqlDbType.Int).Value = li_PrintBill.DelBy;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_PrintBill.PressID;
            cmd.Parameters.Add("@PrintQty", SqlDbType.VarChar).Value = li_PrintBill.PrintQty;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
