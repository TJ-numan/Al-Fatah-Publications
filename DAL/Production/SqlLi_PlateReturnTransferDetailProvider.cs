using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;

using System.Xml.Linq;
using DAL;

public class SqlLi_PlateReturnTransferDetailProvider:DataAccessObject
{
	public SqlLi_PlateReturnTransferDetailProvider()
    {
    }


    public bool DeleteLi_PlateReturnTransferDetail(int li_PlateReturnTransferDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlateReturnTransferDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PlateReturnTransferDetailID", SqlDbType.Int).Value = li_PlateReturnTransferDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PlateReturnTransferDetail> GetAllLi_PlateReturnTransferDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlateReturnTransferDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PlateReturnTransferDetailsFromReader(reader);
        }
    }
    public List<Li_PlateReturnTransferDetail> GetLi_PlateReturnTransferDetailsFromReader(IDataReader reader)
    {
        List<Li_PlateReturnTransferDetail> li_PlateReturnTransferDetails = new List<Li_PlateReturnTransferDetail>();

        while (reader.Read())
        {
            li_PlateReturnTransferDetails.Add(GetLi_PlateReturnTransferDetailFromReader(reader));
        }
        return li_PlateReturnTransferDetails;
    }

    public Li_PlateReturnTransferDetail GetLi_PlateReturnTransferDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_PlateReturnTransferDetail li_PlateReturnTransferDetail = new Li_PlateReturnTransferDetail
                (

                    (int)reader["SerialNo"],
                    reader["PlateRecID"].ToString(),
                    reader["BookCode"].ToString(),
                    (int)reader["PlateFor"],
                    (int)reader["Qty"],
                    reader["PlateTypeID"].ToString(),
                    reader["PlateSizeID"].ToString(),
                    reader["PlateUseType"].ToString()
                );
             return li_PlateReturnTransferDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PlateReturnTransferDetail GetLi_PlateReturnTransferDetailByID(int li_PlateReturnTransferDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlateReturnTransferDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PlateReturnTransferDetailID", SqlDbType.Int).Value = li_PlateReturnTransferDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PlateReturnTransferDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PlateReturnTransferDetail(Li_PlateReturnTransferDetail li_PlateReturnTransferDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PlateReturnTransferDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@PlateRecID", SqlDbType.VarChar).Value = li_PlateReturnTransferDetail.PlateRecID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_PlateReturnTransferDetail.BookCode;
            cmd.Parameters.Add("@PlateFor", SqlDbType.Int).Value = li_PlateReturnTransferDetail.PlateFor;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_PlateReturnTransferDetail.Qty;
            cmd.Parameters.Add("@PlateTypeID", SqlDbType.VarChar).Value = li_PlateReturnTransferDetail.PlateTypeID;
            cmd.Parameters.Add("@PlateSizeID", SqlDbType.VarChar).Value = li_PlateReturnTransferDetail.PlateSizeID;
            cmd.Parameters.Add("@PlateUseType", SqlDbType.VarChar).Value = li_PlateReturnTransferDetail.PlateUseType;


            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_PlateReturnTransferDetail(Li_PlateReturnTransferDetail li_PlateReturnTransferDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PlateReturnTransferDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_PlateReturnTransferDetail.SerialNo;
            cmd.Parameters.Add("@PlateRecID", SqlDbType.VarChar).Value = li_PlateReturnTransferDetail.PlateRecID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_PlateReturnTransferDetail.BookCode;
            cmd.Parameters.Add("@PlateFor", SqlDbType.Int).Value = li_PlateReturnTransferDetail.PlateFor;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_PlateReturnTransferDetail.Qty;


            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
