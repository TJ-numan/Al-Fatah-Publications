using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PlateSupply_FormaDetailProvider:DataAccessObject
{
	public SqlLi_PlateSupply_FormaDetailProvider()
    {
    }


    public bool DeleteLi_PlateSupply_FormaDetail(int li_PlateSupply_FormaDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlateSupply_FormaDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PlateSupply_FormaDetailID", SqlDbType.Int).Value = li_PlateSupply_FormaDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PlateSupply_FormaDetail> GetAllLi_PlateSupply_FormaDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlateSupply_FormaDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PlateSupply_FormaDetailsFromReader(reader);
        }
    }
    public List<Li_PlateSupply_FormaDetail> GetLi_PlateSupply_FormaDetailsFromReader(IDataReader reader)
    {
        List<Li_PlateSupply_FormaDetail> li_PlateSupply_FormaDetails = new List<Li_PlateSupply_FormaDetail>();

        while (reader.Read())
        {
            li_PlateSupply_FormaDetails.Add(GetLi_PlateSupply_FormaDetailFromReader(reader));
        }
        return li_PlateSupply_FormaDetails;
    }

    public Li_PlateSupply_FormaDetail GetLi_PlateSupply_FormaDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_PlateSupply_FormaDetail li_PlateSupply_FormaDetail = new Li_PlateSupply_FormaDetail
                (
                     
                    (int)reader["SlNo"],
                    reader["Plate_SID"].ToString(),
                    reader["PresID"].ToString(),
                    reader["PlateTypeID"].ToString(),
                    reader["PlateSizeID"].ToString(),
                    (decimal)reader["PlateQty"],
                    (int)reader["PlateGivenType"],
                    (decimal)reader["PlateBillRate"],
                    (int)reader["ProcessGivenType"],
                    (decimal)reader["ProcessBillRate"],
                     (decimal)reader["TotalAmount"]  
                );
             return li_PlateSupply_FormaDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PlateSupply_FormaDetail GetLi_PlateSupply_FormaDetailByID(int li_PlateSupply_FormaDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlateSupply_FormaDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PlateSupply_FormaDetailID", SqlDbType.Int).Value = li_PlateSupply_FormaDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PlateSupply_FormaDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PlateSupply_FormaDetail(Li_PlateSupply_FormaDetail li_PlateSupply_FormaDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("web_SMPM_InsertLi_PlateSupply_FormaDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
           // cmd.Parameters.Add("@SlNo", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Plate_SID", SqlDbType.VarChar).Value = li_PlateSupply_FormaDetail.Plate_SID;
            cmd.Parameters.Add("@PresID", SqlDbType.VarChar).Value = li_PlateSupply_FormaDetail.PresID;
            cmd.Parameters.Add("@PlateTypeID", SqlDbType.VarChar).Value = li_PlateSupply_FormaDetail.PlateTypeID;
            cmd.Parameters.Add("@PlateSizeID", SqlDbType.VarChar).Value = li_PlateSupply_FormaDetail.PlateSizeID;
            cmd.Parameters.Add("@PlateQty", SqlDbType.Decimal).Value = li_PlateSupply_FormaDetail.PlateQty;
            cmd.Parameters.Add("@PlateGivenType", SqlDbType.Int).Value = li_PlateSupply_FormaDetail.PlateGivenType;
            cmd.Parameters.Add("@PlateBillRate", SqlDbType.Decimal).Value = li_PlateSupply_FormaDetail.PlateBillRate;
            cmd.Parameters.Add("@ProcessGivenType", SqlDbType.Int).Value = li_PlateSupply_FormaDetail.ProcessGivenType;
            cmd.Parameters.Add("@ProcessBillRate", SqlDbType.Decimal).Value = li_PlateSupply_FormaDetail.ProcessBillRate;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.NChar).Value = li_PlateSupply_FormaDetail.TotalAmount;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_PlateSupply_FormaDetail(Li_PlateSupply_FormaDetail li_PlateSupply_FormaDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PlateSupply_FormaDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@SlNo", SqlDbType.Int).Value = li_PlateSupply_FormaDetail.SlNo;
            cmd.Parameters.Add("@Plate_SID", SqlDbType.VarChar).Value = li_PlateSupply_FormaDetail.Plate_SID;
            cmd.Parameters.Add("@PresID", SqlDbType.VarChar).Value = li_PlateSupply_FormaDetail.PresID;
            cmd.Parameters.Add("@PlateTypeID", SqlDbType.VarChar).Value = li_PlateSupply_FormaDetail.PlateTypeID;
            cmd.Parameters.Add("@PlateSizeID", SqlDbType.VarChar).Value = li_PlateSupply_FormaDetail.PlateSizeID;
            cmd.Parameters.Add("@PlateQty", SqlDbType.Decimal).Value = li_PlateSupply_FormaDetail.PlateQty;
            cmd.Parameters.Add("@PlateGivenType", SqlDbType.Int).Value = li_PlateSupply_FormaDetail.PlateGivenType;
            cmd.Parameters.Add("@PlateBillRate", SqlDbType.Decimal).Value = li_PlateSupply_FormaDetail.PlateBillRate;
            cmd.Parameters.Add("@ProcessGivenType", SqlDbType.Int).Value = li_PlateSupply_FormaDetail.ProcessGivenType;
            cmd.Parameters.Add("@ProcessBillRate", SqlDbType.Decimal).Value = li_PlateSupply_FormaDetail.ProcessBillRate;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.NChar).Value = li_PlateSupply_FormaDetail.TotalAmount;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
