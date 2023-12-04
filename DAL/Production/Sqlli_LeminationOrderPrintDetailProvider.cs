using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using DAL;

public class SqlLi_LeminationOrderPrintDetailProvider:DataAccessObject
{
	public SqlLi_LeminationOrderPrintDetailProvider()
    {
    }


    public bool DeleteLi_LeminationOrderPrintDetail(int li_LeminationOrderPrintDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_LeminationOrderPrintDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_LeminationOrderPrintDetailID", SqlDbType.Int).Value = li_LeminationOrderPrintDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_LeminationOrderPrintDetail> GetAllLi_LeminationOrderPrintDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_LeminationOrderPrintDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_LeminationOrderPrintDetailsFromReader(reader);
        }
    }
    public List<Li_LeminationOrderPrintDetail> GetLi_LeminationOrderPrintDetailsFromReader(IDataReader reader)
    {
        List<Li_LeminationOrderPrintDetail> li_LeminationOrderPrintDetails = new List<Li_LeminationOrderPrintDetail>();

        while (reader.Read())
        {
            li_LeminationOrderPrintDetails.Add(GetLi_LeminationOrderPrintDetailFromReader(reader));
        }
        return li_LeminationOrderPrintDetails;
    }

    public Li_LeminationOrderPrintDetail GetLi_LeminationOrderPrintDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_LeminationOrderPrintDetail li_LeminationOrderPrintDetail = new Li_LeminationOrderPrintDetail
                (
                     
                    (int)reader["SerialNo"],
                    reader["OrderID"].ToString(),
                   (int)  reader["LemiSerial"] 
                );
             return li_LeminationOrderPrintDetail;
        }
        catch(Exception)
        {
            return null;
        }
    }

    public Li_LeminationOrderPrintDetail GetLi_LeminationOrderPrintDetailByID(int li_LeminationOrderPrintDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_LeminationOrderPrintDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_LeminationOrderPrintDetailID", SqlDbType.Int).Value = li_LeminationOrderPrintDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_LeminationOrderPrintDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_LeminationOrderPrintDetail(Li_LeminationOrderPrintDetail li_LeminationOrderPrintDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_LeminationOrderPrintDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@LemiSerial", SqlDbType.Int).Value = li_LeminationOrderPrintDetail.LemiSerial;
            cmd.Parameters.Add("@OrderID", SqlDbType.VarChar).Value = li_LeminationOrderPrintDetail.OrderID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_LeminationOrderPrintDetail(Li_LeminationOrderPrintDetail li_LeminationOrderPrintDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_LeminationOrderPrintDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_LeminationOrderPrintDetail.SerialNo;

            cmd.Parameters.Add("@LemiSerial", SqlDbType.VarChar).Value = li_LeminationOrderPrintDetail.LemiSerial;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
