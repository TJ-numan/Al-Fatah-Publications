using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_CoverBillDetailProvider:DataAccessObject
{
	public SqlLi_CoverBillDetailProvider()
    {
    }


    public bool DeleteLi_CoverBillDetail(int li_CoverBillDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_CoverBillDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_CoverBillDetailID", SqlDbType.Int).Value = li_CoverBillDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_CoverBillDetail> GetAllLi_CoverBillDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_CoverBillDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_CoverBillDetailsFromReader(reader);
        }
    }
    public List<Li_CoverBillDetail> GetLi_CoverBillDetailsFromReader(IDataReader reader)
    {
        List<Li_CoverBillDetail> li_CoverBillDetails = new List<Li_CoverBillDetail>();

        while (reader.Read())
        {
            li_CoverBillDetails.Add(GetLi_CoverBillDetailFromReader(reader));
        }
        return li_CoverBillDetails;
    }

    public Li_CoverBillDetail GetLi_CoverBillDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_CoverBillDetail li_CoverBillDetail = new Li_CoverBillDetail
                (
                    
                    reader["BillNo"].ToString(),
                    (decimal)reader["Qty"],
                    reader["ReceiveID"].ToString() 
                );
             return li_CoverBillDetail;
        }
        catch(Exception )
        {
            return null;
        }
    }

    public Li_CoverBillDetail GetLi_CoverBillDetailByID(int li_CoverBillDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_CoverBillDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_CoverBillDetailID", SqlDbType.Int).Value = li_CoverBillDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_CoverBillDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_CoverBillDetail(Li_CoverBillDetail li_CoverBillDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_CoverBillDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = li_CoverBillDetail.BillNo;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_CoverBillDetail.Qty;
            cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar).Value = li_CoverBillDetail.ReceiveID;
    
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1 ;
        }
    }

    public bool UpdateLi_CoverBillDetail(Li_CoverBillDetail li_CoverBillDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_CoverBillDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = li_CoverBillDetail.BillNo;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_CoverBillDetail.Qty;
            cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar).Value = li_CoverBillDetail.ReceiveID;
      
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
