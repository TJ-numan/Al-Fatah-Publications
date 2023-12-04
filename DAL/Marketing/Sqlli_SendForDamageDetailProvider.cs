using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_SendForDamageDetailProvider:DataAccessObject
{
	public SqlLi_SendForDamageDetailProvider()
    {
    }


    public bool DeleteLi_SendForDamageDetail(int li_SendForDamageDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_SendForDamageDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_SendForDamageDetailID", SqlDbType.Int).Value = li_SendForDamageDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_SendForDamageDetail> GetAllLi_SendForDamageDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_SendForDamageDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_SendForDamageDetailsFromReader(reader);
        }
    }
    public List<Li_SendForDamageDetail> GetLi_SendForDamageDetailsFromReader(IDataReader reader)
    {
        List<Li_SendForDamageDetail> li_SendForDamageDetails = new List<Li_SendForDamageDetail>();

        while (reader.Read())
        {
            li_SendForDamageDetails.Add(GetLi_SendForDamageDetailFromReader(reader));
        }
        return li_SendForDamageDetails;
    }

    public Li_SendForDamageDetail GetLi_SendForDamageDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_SendForDamageDetail li_SendForDamageDetail = new Li_SendForDamageDetail
                (

                reader["ReceiveID"].ToString(),
                reader["BookCode"].ToString(),
                (int)reader["Qty"],
                (decimal)reader["Price"],
                (char)reader["Status_D"],
                reader["Edition"].ToString(),
                (bool) reader ["FromCentral"]
                );
             return li_SendForDamageDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_SendForDamageDetail GetLi_SendForDamageDetailByID(int li_SendForDamageDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_SendForDamageDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_SendForDamageDetailID", SqlDbType.Int).Value = li_SendForDamageDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_SendForDamageDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_SendForDamageDetail(Li_SendForDamageDetail li_SendForDamageDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_SendForDamageDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar).Value = li_SendForDamageDetail.ReceiveID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_SendForDamageDetail.BookCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_SendForDamageDetail.Qty;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = li_SendForDamageDetail.Price;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_SendForDamageDetail.Status_D;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_SendForDamageDetail .Edition;
            cmd.Parameters.Add("@FromCentral", SqlDbType.Bit).Value = li_SendForDamageDetail.FromCentral;  
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@Li_SendForDamageDetailID"].Value;
        }
    }

    public bool UpdateLi_SendForDamageDetail(Li_SendForDamageDetail li_SendForDamageDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_SendForDamageDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar).Value = li_SendForDamageDetail.ReceiveID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_SendForDamageDetail.BookCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_SendForDamageDetail.Qty;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = li_SendForDamageDetail.Price;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_SendForDamageDetail.Status_D;
            cmd.Parameters.Add("@FromCentral", SqlDbType.Bit).Value = li_SendForDamageDetail.FromCentral;  
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
