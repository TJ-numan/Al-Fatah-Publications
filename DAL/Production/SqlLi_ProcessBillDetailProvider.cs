using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_ProcessBillDetailProvider:DataAccessObject
{
	public SqlLi_ProcessBillDetailProvider()
    {
    }


    public bool DeleteLi_ProcessBillDetail(int li_ProcessBillDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_ProcessBillDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_ProcessBillDetailID", SqlDbType.Int).Value = li_ProcessBillDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_ProcessBillDetail> GetAllLi_ProcessBillDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_ProcessBillDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ProcessBillDetailsFromReader(reader);
        }
    }
    public List<Li_ProcessBillDetail> GetLi_ProcessBillDetailsFromReader(IDataReader reader)
    {
        List<Li_ProcessBillDetail> li_ProcessBillDetails = new List<Li_ProcessBillDetail>();

        while (reader.Read())
        {
            li_ProcessBillDetails.Add(GetLi_ProcessBillDetailFromReader(reader));
        }
        return li_ProcessBillDetails;
    }

    public Li_ProcessBillDetail GetLi_ProcessBillDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_ProcessBillDetail li_ProcessBillDetail = new Li_ProcessBillDetail
                (
              
                    (int)reader["SerialNo"],
                    (int)reader["BillSerial"],
                    reader["Pro_Order"].ToString(),
                    (decimal)reader["Bill"],
                    reader["PressID"].ToString()
                );
             return li_ProcessBillDetail;
        }
        catch(Exception )
        {
            return null;
        }
    }

    public Li_ProcessBillDetail GetLi_ProcessBillDetailByID(int li_ProcessBillDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_ProcessBillDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_ProcessBillDetailID", SqlDbType.Int).Value = li_ProcessBillDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ProcessBillDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_ProcessBillDetail(Li_ProcessBillDetail li_ProcessBillDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_ProcessBillDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BillSerial", SqlDbType.Int).Value = li_ProcessBillDetail.BillSerial;
            cmd.Parameters.Add("@Pro_Order", SqlDbType.VarChar).Value = li_ProcessBillDetail.Pro_Order;
            cmd.Parameters.Add("@Bill", SqlDbType.Decimal).Value = li_ProcessBillDetail.Bill;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_ProcessBillDetail.PressID;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@SerialNo"].Value;
        }
    }

    public bool UpdateLi_ProcessBillDetail(Li_ProcessBillDetail li_ProcessBillDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_ProcessBillDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_ProcessBillDetail.SerialNo;
            cmd.Parameters.Add("@BillSerial", SqlDbType.Int).Value = li_ProcessBillDetail.BillSerial;
            cmd.Parameters.Add("@Pro_Order", SqlDbType.VarChar).Value = li_ProcessBillDetail.Pro_Order;
            cmd.Parameters.Add("@Bill", SqlDbType.Decimal).Value = li_ProcessBillDetail.Bill;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
