using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BookReplacementDetailProvider:DataAccessObject
{
	public SqlLi_BookReplacementDetailProvider()
    {
    }


    public bool DeleteLi_BookReplacementDetail(int li_BookReplacementDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BookReplacementDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BookReplacementDetailID", SqlDbType.Int).Value = li_BookReplacementDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BookReplacementDetail> GetAllLi_BookReplacementDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BookReplacementDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BookReplacementDetailsFromReader(reader);
        }
    }
    public List<Li_BookReplacementDetail> GetLi_BookReplacementDetailsFromReader(IDataReader reader)
    {
        List<Li_BookReplacementDetail> li_BookReplacementDetails = new List<Li_BookReplacementDetail>();

        while (reader.Read())
        {
            li_BookReplacementDetails.Add(GetLi_BookReplacementDetailFromReader(reader));
        }
        return li_BookReplacementDetails;
    }

    public Li_BookReplacementDetail GetLi_BookReplacementDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_BookReplacementDetail li_BookReplacementDetail = new Li_BookReplacementDetail
                (
                     
                    reader["ReceiveID"].ToString(),
                    reader["BookCode"].ToString(),
                    (int)reader["Qty"],
                    (decimal)reader["Price"],
                    (char)reader["Status_D"],
                    reader ["Edition"].ToString ()
                );
             return li_BookReplacementDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_BookReplacementDetail GetLi_BookReplacementDetailByID(int li_BookReplacementDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BookReplacementDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_BookReplacementDetailID", SqlDbType.Int).Value = li_BookReplacementDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BookReplacementDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_BookReplacementDetail(Li_BookReplacementDetail li_BookReplacementDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BookReplacementDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReplaceID", SqlDbType.VarChar).Value = li_BookReplacementDetail.ReceiveID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BookReplacementDetail.BookCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_BookReplacementDetail.Qty;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = li_BookReplacementDetail.Price;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_BookReplacementDetail.Status_D;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_BookReplacementDetail.Edition ;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@Li_BookReplacementDetailID"].Value;
        }
    }

    public bool UpdateLi_BookReplacementDetail(Li_BookReplacementDetail li_BookReplacementDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BookReplacementDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar).Value = li_BookReplacementDetail.ReceiveID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BookReplacementDetail.BookCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_BookReplacementDetail.Qty;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = li_BookReplacementDetail.Price;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_BookReplacementDetail.Status_D;
           
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
