using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BinderBillDetailProvider:DataAccessObject
{
	public SqlLi_BinderBillDetailProvider()
    {
    }


    public bool DeleteLi_BinderBillDetail(int li_BinderBillDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BinderBillDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BinderBillDetailID", SqlDbType.Int).Value = li_BinderBillDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BinderBillDetail> GetAllLi_BinderBillDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BinderBillDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BinderBillDetailsFromReader(reader);
        }
    }
    public List<Li_BinderBillDetail> GetLi_BinderBillDetailsFromReader(IDataReader reader)
    {
        List<Li_BinderBillDetail> li_BinderBillDetails = new List<Li_BinderBillDetail>();

        while (reader.Read())
        {
            li_BinderBillDetails.Add(GetLi_BinderBillDetailFromReader(reader));
        }
        return li_BinderBillDetails;
    }

    public Li_BinderBillDetail GetLi_BinderBillDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_BinderBillDetail li_BinderBillDetail = new Li_BinderBillDetail
                (
                    
                    reader["BillNo"].ToString(),
                    (decimal)reader["Qty"],
                    reader["ReceiveID"].ToString() 
                );
             return li_BinderBillDetail;
        }
        catch(Exception)
        {
            return null;
        }
    }

    public Li_BinderBillDetail GetLi_BinderBillDetailByID(int li_BinderBillDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BinderBillDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_BinderBillDetailID", SqlDbType.Int).Value = li_BinderBillDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BinderBillDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_BinderBillDetail(Li_BinderBillDetail li_BinderBillDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BinderBillDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = li_BinderBillDetail.BillNo;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_BinderBillDetail.Qty;
            cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar).Value = li_BinderBillDetail.ReceiveID;
      
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;//(int)cmd.Parameters["@Li_BinderBillDetailID"].Value;
        }
    }

    public bool UpdateLi_BinderBillDetail(Li_BinderBillDetail li_BinderBillDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BinderBillDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = li_BinderBillDetail.BillNo;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_BinderBillDetail.Qty;
            cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar).Value = li_BinderBillDetail.ReceiveID;
         
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
