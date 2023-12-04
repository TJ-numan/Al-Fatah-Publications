using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using DAL;

public class SqlLi_CoverBillProvider:DataAccessObject
{
	public SqlLi_CoverBillProvider()
    {
    }


    public bool DeleteLi_CoverBill(int li_CoverBillID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_CoverBill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_CoverBillID", SqlDbType.Int).Value = li_CoverBillID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_CoverBill> GetAllLi_CoverBills()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_CoverBills", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_CoverBillsFromReader(reader);
        }
    }
    public List<Li_CoverBill> GetLi_CoverBillsFromReader(IDataReader reader)
    {
        List<Li_CoverBill> li_CoverBills = new List<Li_CoverBill>();

        while (reader.Read())
        {
            li_CoverBills.Add(GetLi_CoverBillFromReader(reader));
        }
        return li_CoverBills;
    }

    public Li_CoverBill GetLi_CoverBillFromReader(IDataReader reader)
    {
        try
        {
            Li_CoverBill li_CoverBill = new Li_CoverBill
                (
                  
                    reader["BillID"].ToString(),
                    (DateTime)reader["BillDate"],
                    reader["BillNo"].ToString(),
                    reader["SupplierID"].ToString(),
                    reader["BookCode"].ToString(),
                    (bool)reader["IsRebind"],
                    (decimal)reader["TotalQty"],
                    (decimal)reader["BillRate"],
                    (decimal)reader["TotalBill"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreateBy"],
                    (char)reader["Status_D"],
                    (DateTime)reader["DelDate"],
                    reader["CauseOfDel"].ToString(),
                    (int)reader["DeleBy"]
                );
             return li_CoverBill;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_CoverBill GetLi_CoverBillByID(int li_CoverBillID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_CoverBillByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_CoverBillID", SqlDbType.Int).Value = li_CoverBillID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_CoverBillFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_CoverBill(Li_CoverBill li_CoverBill)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_CoverBill", connection);
            cmd.CommandType = CommandType.StoredProcedure;

        
            cmd.Parameters.Add("@BillID", SqlDbType.VarChar,50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = li_CoverBill.BillDate;
            cmd.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = li_CoverBill.BillNo;
            cmd.Parameters.Add("@SupplierID", SqlDbType.VarChar).Value = li_CoverBill.SupplierID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_CoverBill.BookCode;
            cmd.Parameters.Add("@IsRebind", SqlDbType.Bit).Value = li_CoverBill.IsRebind;
            cmd.Parameters.Add("@TotalQty", SqlDbType.Decimal).Value = li_CoverBill.TotalQty;
            cmd.Parameters.Add("@BillRate", SqlDbType.Decimal).Value = li_CoverBill.BillRate;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_CoverBill.TotalBill;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_CoverBill.CreatedDate;
            cmd.Parameters.Add("@CreateBy", SqlDbType.Int).Value = li_CoverBill.CreateBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_CoverBill.Status_D;
            cmd.Parameters.Add("@DelDate", SqlDbType.DateTime).Value = li_CoverBill.DelDate;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_CoverBill.CauseOfDel;
            cmd.Parameters.Add("@DeleBy", SqlDbType.Int).Value = li_CoverBill.DeleBy;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@BillID"].Value.ToString ();
        }
    }

    public bool UpdateLi_CoverBill(Li_CoverBill li_CoverBill)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_CoverBill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@BillID", SqlDbType.VarChar).Value = li_CoverBill.BillID;
            cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = li_CoverBill.BillDate;
            cmd.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = li_CoverBill.BillNo;
            cmd.Parameters.Add("@SupplierID", SqlDbType.VarChar).Value = li_CoverBill.SupplierID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_CoverBill.BookCode;
            cmd.Parameters.Add("@IsRebind", SqlDbType.Bit).Value = li_CoverBill.IsRebind;
            cmd.Parameters.Add("@TotalQty", SqlDbType.Decimal).Value = li_CoverBill.TotalQty;
            cmd.Parameters.Add("@BillRate", SqlDbType.Decimal).Value = li_CoverBill.BillRate;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_CoverBill.TotalBill;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_CoverBill.CreatedDate;
            cmd.Parameters.Add("@CreateBy", SqlDbType.Int).Value = li_CoverBill.CreateBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_CoverBill.Status_D;
            cmd.Parameters.Add("@DelDate", SqlDbType.DateTime).Value = li_CoverBill.DelDate;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_CoverBill.CauseOfDel;
            cmd.Parameters.Add("@DeleBy", SqlDbType.Int).Value = li_CoverBill.DeleBy;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
