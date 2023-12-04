using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PlateBillProvider:DataAccessObject
{
	public SqlLi_PlateBillProvider()
    {
    }


    public bool DeleteLi_PlateBill(int li_PlateBillID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlateBill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PlateBillID", SqlDbType.Int).Value = li_PlateBillID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PlateBill> GetAllLi_PlateBills()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlateBills", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PlateBillsFromReader(reader);
        }
    }
    public List<Li_PlateBill> GetLi_PlateBillsFromReader(IDataReader reader)
    {
        List<Li_PlateBill> li_PlateBills = new List<Li_PlateBill>();

        while (reader.Read())
        {
            li_PlateBills.Add(GetLi_PlateBillFromReader(reader));
        }
        return li_PlateBills;
    }

    public Li_PlateBill GetLi_PlateBillFromReader(IDataReader reader)
    {
        try
        {
            Li_PlateBill li_PlateBill = new Li_PlateBill
                (
                  
                    (int)reader["BillSerial"],
                    reader["BillNo"].ToString(),
                    reader["SupplierID"].ToString(),
                    (decimal)reader["Amount"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (char)reader["Status_D"] 
                );
             return li_PlateBill;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PlateBill GetLi_PlateBillByID(int li_PlateBillID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlateBillByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PlateBillID", SqlDbType.Int).Value = li_PlateBillID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PlateBillFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PlateBill(Li_PlateBill li_PlateBill)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PlateBill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@BillSerial", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = li_PlateBill.BillNo;
            cmd.Parameters.Add("@SupplierID", SqlDbType.VarChar).Value = li_PlateBill.SupplierID;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_PlateBill.Amount;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateBill.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateBill.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_PlateBill.Status_D;
       
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BillSerial"].Value;
        }
    }

    public bool UpdateLi_PlateBill(Li_PlateBill li_PlateBill)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PlateBill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@BillSerial", SqlDbType.Int).Value = li_PlateBill.BillSerial;
            cmd.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = li_PlateBill.BillNo;
            cmd.Parameters.Add("@SupplierID", SqlDbType.VarChar).Value = li_PlateBill.SupplierID;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_PlateBill.Amount;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateBill.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateBill.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_PlateBill.Status_D;
             
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataSet GetPlatePurchaseDetail(string SupplierID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_GetPlatePurchaseDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SupplierID", SqlDbType.VarChar).Value = SupplierID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter( cmd );
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    
    }


}
