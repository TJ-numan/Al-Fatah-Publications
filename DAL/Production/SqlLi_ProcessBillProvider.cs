using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_ProcessBillProvider:DataAccessObject
{
	public SqlLi_ProcessBillProvider()
    {
    }


    public bool DeleteLi_ProcessBill(int li_ProcessBillID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_ProcessBill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_ProcessBillID", SqlDbType.Int).Value = li_ProcessBillID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_ProcessBill> GetAllLi_ProcessBills()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_ProcessBills", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ProcessBillsFromReader(reader);
        }
    }
    public List<Li_ProcessBill> GetLi_ProcessBillsFromReader(IDataReader reader)
    {
        List<Li_ProcessBill> li_ProcessBills = new List<Li_ProcessBill>();

        while (reader.Read())
        {
            li_ProcessBills.Add(GetLi_ProcessBillFromReader(reader));
        }
        return li_ProcessBills;
    }

    public Li_ProcessBill GetLi_ProcessBillFromReader(IDataReader reader)
    {
        try
        {
            Li_ProcessBill li_ProcessBill = new Li_ProcessBill
                (
                     
                    (int)reader["BillSerial"],
                    reader["BillNo"].ToString(),
                    reader["ProcessID"].ToString(),
                    (decimal)reader["Amount"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (char)reader["Status_D"] 
                );
             return li_ProcessBill;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_ProcessBill GetLi_ProcessBillByID(int li_ProcessBillID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_ProcessBillByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_ProcessBillID", SqlDbType.Int).Value = li_ProcessBillID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ProcessBillFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_ProcessBill(Li_ProcessBill li_ProcessBill)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_ProcessBill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@BillSerial", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = li_ProcessBill.BillNo;
            cmd.Parameters.Add("@ProcessID", SqlDbType.VarChar).Value = li_ProcessBill.ProcessID;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_ProcessBill.Amount;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ProcessBill.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ProcessBill.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_ProcessBill.Status_D;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BillSerial"].Value;
        }
    }

    public bool UpdateLi_ProcessBill(Li_ProcessBill li_ProcessBill)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_ProcessBill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@BillSerial", SqlDbType.Int).Value = li_ProcessBill.BillSerial;
            cmd.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = li_ProcessBill.BillNo;
            cmd.Parameters.Add("@ProcessID", SqlDbType.VarChar).Value = li_ProcessBill.ProcessID;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_ProcessBill.Amount;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ProcessBill.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ProcessBill.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_ProcessBill.Status_D;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetPlateProcessDetail(string ProcessID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_GetPlateProcessDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProcessID", SqlDbType.VarChar).Value = ProcessID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }

}
