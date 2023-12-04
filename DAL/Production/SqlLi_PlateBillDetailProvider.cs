using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PlateBillDetailProvider:DataAccessObject
{
	public SqlLi_PlateBillDetailProvider()
    {
    }


    public bool DeleteLi_PlateBillDetail(int li_PlateBillDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlateBillDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PlateBillDetailID", SqlDbType.Int).Value = li_PlateBillDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PlateBillDetail> GetAllLi_PlateBillDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlateBillDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PlateBillDetailsFromReader(reader);
        }
    }
    public List<Li_PlateBillDetail> GetLi_PlateBillDetailsFromReader(IDataReader reader)
    {
        List<Li_PlateBillDetail> li_PlateBillDetails = new List<Li_PlateBillDetail>();

        while (reader.Read())
        {
            li_PlateBillDetails.Add(GetLi_PlateBillDetailFromReader(reader));
        }
        return li_PlateBillDetails;
    }

    public Li_PlateBillDetail GetLi_PlateBillDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_PlateBillDetail li_PlateBillDetail = new Li_PlateBillDetail
                (
                    
                    (int)reader["SerialNo"],
                    reader["Pur_Order"].ToString(),
                    (decimal)reader["OrderAmount"] 
                );
             return li_PlateBillDetail;
        }
        catch(Exception)
        {
            return null;
        }
    }

    public Li_PlateBillDetail GetLi_PlateBillDetailByID(int li_PlateBillDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlateBillDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PlateBillDetailID", SqlDbType.Int).Value = li_PlateBillDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PlateBillDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PlateBillDetail(Li_PlateBillDetail li_PlateBillDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PlateBillDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value   =li_PlateBillDetail.SerialNo   ;
            cmd.Parameters.Add("@Pur_Order", SqlDbType.VarChar).Value = li_PlateBillDetail.Pur_Order;
            cmd.Parameters.Add("@OrderAmount", SqlDbType.Decimal).Value = li_PlateBillDetail.OrderAmount;
        
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@Li_PlateBillDetailID"].Value;
        }
    }

    public bool UpdateLi_PlateBillDetail(Li_PlateBillDetail li_PlateBillDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PlateBillDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_PlateBillDetail.SerialNo;
            cmd.Parameters.Add("@Pur_Order", SqlDbType.VarChar).Value = li_PlateBillDetail.Pur_Order;
            cmd.Parameters.Add("@OrderAmount", SqlDbType.Decimal).Value = li_PlateBillDetail.OrderAmount;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
