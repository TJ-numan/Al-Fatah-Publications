using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_SendForRebindDetailProvider:DataAccessObject
{
	public SqlLi_SendForRebindDetailProvider()
    {
    }


    public bool DeleteLi_SendForRebindDetail(int li_SendForRebindDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_SendForRebindDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_SendForRebindDetailID", SqlDbType.Int).Value = li_SendForRebindDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_SendForRebindDetail> GetAllLi_SendForRebindDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_SendForRebindDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_SendForRebindDetailsFromReader(reader);
        }
    }
    public List<Li_SendForRebindDetail> GetLi_SendForRebindDetailsFromReader(IDataReader reader)
    {
        List<Li_SendForRebindDetail> li_SendForRebindDetails = new List<Li_SendForRebindDetail>();

        while (reader.Read())
        {
            li_SendForRebindDetails.Add(GetLi_SendForRebindDetailFromReader(reader));
        }
        return li_SendForRebindDetails;
    }

    public Li_SendForRebindDetail GetLi_SendForRebindDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_SendForRebindDetail li_SendForRebindDetail = new Li_SendForRebindDetail
                (

                reader["ReceiveID"].ToString(),
                reader["BookCode"].ToString(),
                (int)reader["Qty"],
                (decimal)reader["Price"],
                (char)reader["Status_D"],
                reader["Edition"].ToString(),
                (bool)reader["FromCentral"]

                );
             return li_SendForRebindDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_SendForRebindDetail GetLi_SendForRebindDetailByID(int li_SendForRebindDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_SendForRebindDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_SendForRebindDetailID", SqlDbType.Int).Value = li_SendForRebindDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_SendForRebindDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_SendForRebindDetail(Li_SendForRebindDetail li_SendForRebindDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_SendForRebindDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar).Value =  li_SendForRebindDetail.ReceiveID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value =  li_SendForRebindDetail.BookCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value =  li_SendForRebindDetail.Qty;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value =  li_SendForRebindDetail.Price;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value =  li_SendForRebindDetail.Status_D;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value =  li_SendForRebindDetail.Edition;
            cmd.Parameters.Add("@FromCentral", SqlDbType.Bit).Value =  li_SendForRebindDetail.FromCentral;  

             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@Li_SendForRebindDetailID"].Value;
        }
    }

    public bool UpdateLi_SendForRebindDetail(Li_SendForRebindDetail li_SendForRebindDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_SendForRebindDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar).Value = li_SendForRebindDetail.ReceiveID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_SendForRebindDetail.BookCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_SendForRebindDetail.Qty;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = li_SendForRebindDetail.Price;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_SendForRebindDetail.Status_D;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_SendForRebindDetail.Edition;
            cmd.Parameters.Add("@FromCentral", SqlDbType.Bit).Value = li_SendForRebindDetail.FromCentral; 

             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
