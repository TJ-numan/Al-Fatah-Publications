using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BookDeliveryDetailProvider:DataAccessObject
{
	public SqlLi_BookDeliveryDetailProvider()
    {
    }


    public bool DeleteLi_BookDeliveryDetail(int li_BookDeliveryDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BookDeliveryDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BookDeliveryDetailID", SqlDbType.Int).Value = li_BookDeliveryDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BookDeliveryDetail> GetAllLi_BookDeliveryDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BookDeliveryDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BookDeliveryDetailsFromReader(reader);
        }
    }
    public List<Li_BookDeliveryDetail> GetLi_BookDeliveryDetailsFromReader(IDataReader reader)
    {
        List<Li_BookDeliveryDetail> li_BookDeliveryDetails = new List<Li_BookDeliveryDetail>();

        while (reader.Read())
        {
            li_BookDeliveryDetails.Add(GetLi_BookDeliveryDetailFromReader(reader));
        }
        return li_BookDeliveryDetails;
    }

    public Li_BookDeliveryDetail GetLi_BookDeliveryDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_BookDeliveryDetail li_BookDeliveryDetail = new Li_BookDeliveryDetail
                (
                     
                    (bool)reader["IsForma"],
                    reader["BinderId"].ToString(),
                    (decimal)reader["Qty"],
                    (char)reader["Status_D"],
                    (int)reader["DeID"] ,
                    reader ["StartingNo"].ToString (),
                    reader["EndingNo"].ToString()
                );
             return li_BookDeliveryDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_BookDeliveryDetail GetLi_BookDeliveryDetailByID(int li_BookDeliveryDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BookDeliveryDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_BookDeliveryDetailID", SqlDbType.Int).Value = li_BookDeliveryDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BookDeliveryDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_BookDeliveryDetail(Li_BookDeliveryDetail li_BookDeliveryDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BookDeliveryDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@IsForma", SqlDbType.Bit).Value = li_BookDeliveryDetail.IsForma;
            cmd.Parameters.Add("@BinderId", SqlDbType.VarChar).Value = li_BookDeliveryDetail.BinderId;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_BookDeliveryDetail.Qty;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_BookDeliveryDetail.Status_D;
            cmd.Parameters.Add("@DeID", SqlDbType.Int).Value = li_BookDeliveryDetail.DeID;
            cmd.Parameters.Add("@CovS", SqlDbType.VarChar).Value = li_BookDeliveryDetail.StartingNo;
            cmd.Parameters.Add("@CovE", SqlDbType.VarChar).Value = li_BookDeliveryDetail.EndingNo;  
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@Li_BookDeliveryDetailID"].Value;
        }
    }

    public bool UpdateLi_BookDeliveryDetail(Li_BookDeliveryDetail li_BookDeliveryDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BookDeliveryDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@IsForma", SqlDbType.Bit).Value = li_BookDeliveryDetail.IsForma;
            cmd.Parameters.Add("@BinderId", SqlDbType.VarChar).Value = li_BookDeliveryDetail.BinderId;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_BookDeliveryDetail.Qty;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_BookDeliveryDetail.Status_D;
            cmd.Parameters.Add("@DeID", SqlDbType.Int).Value = li_BookDeliveryDetail.DeID;
            cmd.Parameters.Add("@MSerialNo", SqlDbType.VarChar).Value = li_BookDeliveryDetail.StartingNo;  
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
