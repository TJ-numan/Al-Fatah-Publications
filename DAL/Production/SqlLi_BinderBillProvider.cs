using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BinderBillProvider:DataAccessObject
{
	public SqlLi_BinderBillProvider()
    {
    }


    public bool DeleteLi_BinderBill(int li_BinderBillID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BinderBill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BinderBillID", SqlDbType.Int).Value = li_BinderBillID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BinderBill> GetAllLi_BinderBills()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BinderBills", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BinderBillsFromReader(reader);
        }
    }
    public List<Li_BinderBill> GetLi_BinderBillsFromReader(IDataReader reader)
    {
        List<Li_BinderBill> li_BinderBills = new List<Li_BinderBill>();

        while (reader.Read())
        {
            li_BinderBills.Add(GetLi_BinderBillFromReader(reader));
        }
        return li_BinderBills;
    }

    public Li_BinderBill GetLi_BinderBillFromReader(IDataReader reader)
    {
        try
        {
            Li_BinderBill li_BinderBill = new Li_BinderBill
                (                  
                    reader["BillID"].ToString(),
                    (DateTime)reader["BillDate"],
                    reader["BillNo"].ToString(),
                    reader["BinderID"].ToString(),
                    reader["BookCode"].ToString(),
                    (bool)reader["IsRebind"],
                    (decimal)reader["TotalQty"],
                    (decimal)reader["Ac_Forma"],
                    (decimal)reader["Pay_Forma"],
                    (decimal)reader["MiniRate"],
                    (decimal)reader["BillRate"],
                    (decimal)reader["TotalBill"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreateBy"],
                    (char)reader["Status_D"],
                    (DateTime)reader["DelDate"],
                    reader["CauseOfDel"].ToString(),
                    (int)reader["DeleBy"] ,
                    (int) reader ["RateBy"], 
                    (decimal ) reader ["LabourBill"],
                     (decimal)reader["OtherCost"]
                );
             return li_BinderBill;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_BinderBill GetLi_BinderBillByID(int li_BinderBillID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BinderBillByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_BinderBillID", SqlDbType.Int).Value = li_BinderBillID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BinderBillFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_BinderBill(Li_BinderBill li_BinderBill)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BinderBill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
  
            cmd.Parameters.Add("@BillID", SqlDbType.VarChar,50).Direction = ParameterDirection .Output ;
            cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = li_BinderBill.BillDate;
            cmd.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = li_BinderBill.BillNo;
            cmd.Parameters.Add("@BinderID", SqlDbType.VarChar).Value = li_BinderBill.BinderID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BinderBill.BookCode;
            cmd.Parameters.Add("@IsRebind", SqlDbType.Bit).Value = li_BinderBill.IsRebind;
            cmd.Parameters.Add("@TotalQty", SqlDbType.Decimal).Value = li_BinderBill.TotalQty;
            cmd.Parameters.Add("@Ac_Forma", SqlDbType.Decimal).Value = li_BinderBill.Ac_Forma;
            cmd.Parameters.Add("@Pay_Forma", SqlDbType.Decimal).Value = li_BinderBill.Pay_Forma;
            cmd.Parameters.Add("@MiniRate", SqlDbType.Decimal).Value = li_BinderBill.MiniRate;
            cmd.Parameters.Add("@BillRate", SqlDbType.Decimal).Value = li_BinderBill.BillRate;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_BinderBill.TotalBill;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BinderBill.CreatedDate;
            cmd.Parameters.Add("@CreateBy", SqlDbType.Int).Value = li_BinderBill.CreateBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_BinderBill.Status_D;
            cmd.Parameters.Add("@DelDate", SqlDbType.DateTime).Value = DBNull .Value ;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value =  DBNull .Value ;
            cmd.Parameters.Add("@DeleBy", SqlDbType.Int).Value = DBNull .Value ;

            cmd.Parameters.Add("@RateBy", SqlDbType.Int).Value = li_BinderBill.RateBy;
            cmd.Parameters.Add("@LabourBill", SqlDbType.Decimal).Value = li_BinderBill.LabourBill;
            cmd.Parameters.Add("@OtherCost", SqlDbType. Decimal).Value = li_BinderBill.OtherCost ;      

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@BillID"].Value.ToString ();
        }
    }

    public bool UpdateLi_BinderBill(Li_BinderBill li_BinderBill)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BinderBill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
  
            cmd.Parameters.Add("@BillID", SqlDbType.VarChar).Value = li_BinderBill.BillID;
            cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = li_BinderBill.BillDate;
            cmd.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = li_BinderBill.BillNo;
            cmd.Parameters.Add("@BinderID", SqlDbType.VarChar).Value = li_BinderBill.BinderID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BinderBill.BookCode;
            cmd.Parameters.Add("@IsRebind", SqlDbType.Bit).Value = li_BinderBill.IsRebind;
            cmd.Parameters.Add("@TotalQty", SqlDbType.Decimal).Value = li_BinderBill.TotalQty;
            cmd.Parameters.Add("@Ac_Forma", SqlDbType.Decimal).Value = li_BinderBill.Ac_Forma;
            cmd.Parameters.Add("@Pay_Forma", SqlDbType.Decimal).Value = li_BinderBill.Pay_Forma;
            cmd.Parameters.Add("@MiniRate", SqlDbType.Decimal).Value = li_BinderBill.MiniRate;
            cmd.Parameters.Add("@BillRate", SqlDbType.Decimal).Value = li_BinderBill.BillRate;
            cmd.Parameters.Add("@TotalBill", SqlDbType.Decimal).Value = li_BinderBill.TotalBill;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BinderBill.CreatedDate;
            cmd.Parameters.Add("@CreateBy", SqlDbType.Int).Value = li_BinderBill.CreateBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_BinderBill.Status_D;
            cmd.Parameters.Add("@DelDate", SqlDbType.DateTime).Value = li_BinderBill.DelDate;
            cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_BinderBill.CauseOfDel;
            cmd.Parameters.Add("@DeleBy", SqlDbType.Int).Value = li_BinderBill.DeleBy;

            cmd.Parameters.Add("@RateBy", SqlDbType.Int).Value = li_BinderBill.RateBy;
            cmd.Parameters.Add("@DeleBy", SqlDbType.Int).Value = li_BinderBill.LabourBill;  
     
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
