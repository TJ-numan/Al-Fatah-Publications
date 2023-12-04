using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PrintBillDetailProvider:DataAccessObject
{
	public SqlLi_PrintBillDetailProvider()
    {
    }


    public bool DeleteLi_PrintBillDetail(int li_PrintBillDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PrintBillDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PrintBillDetailID", SqlDbType.Int).Value = li_PrintBillDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PrintBillDetail> GetAllLi_PrintBillDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PrintBillDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PrintBillDetailsFromReader(reader);
        }
    }
    public List<Li_PrintBillDetail> GetLi_PrintBillDetailsFromReader(IDataReader reader)
    {
        List<Li_PrintBillDetail> li_PrintBillDetails = new List<Li_PrintBillDetail>();

        while (reader.Read())
        {
            li_PrintBillDetails.Add(GetLi_PrintBillDetailFromReader(reader));
        }
        return li_PrintBillDetails;
    }

    public Li_PrintBillDetail GetLi_PrintBillDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_PrintBillDetail li_PrintBillDetail = new Li_PrintBillDetail
                (
                   
                    (int)reader["SerialNo"],
                    (int)reader["BillSerial"],
                    (int)reader["PintDSerial"],
                    (decimal)reader["Rate"],
                    (decimal)reader["Bill"] 
                );
             return li_PrintBillDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PrintBillDetail GetLi_PrintBillDetailByID(int li_PrintBillDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PrintBillDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PrintBillDetailID", SqlDbType.Int).Value = li_PrintBillDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PrintBillDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PrintBillDetail(Li_PrintBillDetail li_PrintBillDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PrintBillDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BillSerial", SqlDbType.Int).Value = li_PrintBillDetail.BillSerial;
            cmd.Parameters.Add("@PintDSerial", SqlDbType.Int).Value = li_PrintBillDetail.PintDSerial;
            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = li_PrintBillDetail.Rate;
            cmd.Parameters.Add("@Bill", SqlDbType.Decimal).Value = li_PrintBillDetail.Bill;
           
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@Li_PrintBillDetailID"].Value;
        }
    }

    public bool UpdateLi_PrintBillDetail(Li_PrintBillDetail li_PrintBillDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PrintBillDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_PrintBillDetail.SerialNo;
            cmd.Parameters.Add("@BillSerial", SqlDbType.Int).Value = li_PrintBillDetail.BillSerial;
            cmd.Parameters.Add("@PintDSerial", SqlDbType.Int).Value = li_PrintBillDetail.PintDSerial;
            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = li_PrintBillDetail.Rate;
            cmd.Parameters.Add("@Bill", SqlDbType.Decimal).Value = li_PrintBillDetail.Bill;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
