using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;
using DAL;


public class SqlLi_PlateDamageDetailProvider:DataAccessObject
{
    public SqlLi_PlateDamageDetailProvider()
    {

    }

    public bool DeleteLi_PlateDamageDetail(int li_PlateDamageDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlateDamageDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PlateDamageDetailID", SqlDbType.Int).Value = li_PlateDamageDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PlateDamageDetail> GetAllLi_PlateDamageDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlateDamageDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetAllLi_PlateDamageDetailsFromReader(reader);
        }
    }
    public List<Li_PlateDamageDetail> GetAllLi_PlateDamageDetailsFromReader(IDataReader reader)
    {
        List<Li_PlateDamageDetail> li_PlateDamageDetails = new List<Li_PlateDamageDetail>();

        while (reader.Read())
        {
            li_PlateDamageDetails.Add(GetAllLi_PlateDamageDetailFromReader(reader));
        }
        return li_PlateDamageDetails;
    }

    public Li_PlateDamageDetail GetAllLi_PlateDamageDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_PlateDamageDetail li_PlatePurchaseDetail = new Li_PlateDamageDetail
                (
                   
                    (int)reader["Sl"],
                    reader["PDM_ID"].ToString(),
                    reader["PlateTypeID"].ToString(),
                    reader["PlateSizeID"].ToString(),
                    (int)reader["Qty"],
                    (decimal)reader["BillRate"],
                    reader["Refno"].ToString()
                );
             return li_PlatePurchaseDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PlateDamageDetail GetLi_PlateDamageDetailByID(int li_PlateDamageDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlateDamageDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@li_PlateDamageDetailID", SqlDbType.Int).Value = li_PlateDamageDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetAllLi_PlateDamageDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PlateDamageDetail(Li_PlateDamageDetail li_PlateDamageDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PlateDamageDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PDM_ID", SqlDbType.VarChar).Value = li_PlateDamageDetail.PDM_ID;
            cmd.Parameters.Add("@PlateTypeID", SqlDbType.VarChar).Value = li_PlateDamageDetail.PlateTypeID;
            cmd.Parameters.Add("@PlateSizeID", SqlDbType.VarChar).Value = li_PlateDamageDetail.PlateSizeID;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_PlateDamageDetail.Qty;
            cmd.Parameters.Add("@BillRate", SqlDbType.Decimal).Value = li_PlateDamageDetail.BillRate;
            cmd.Parameters.Add("@Refno", SqlDbType.VarChar).Value = li_PlateDamageDetail.Refno;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_PlateDamageDetail(Li_PlateDamageDetail li_PlateDamageDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PlateDamageDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Sl", SqlDbType.Int).Value = li_PlateDamageDetail.Sl;
            cmd.Parameters.Add("@PDM_ID", SqlDbType.VarChar).Value = li_PlateDamageDetail.PDM_ID;
            cmd.Parameters.Add("@PlateTypeID", SqlDbType.VarChar).Value = li_PlateDamageDetail.PlateTypeID;
            cmd.Parameters.Add("@PlateSizeID", SqlDbType.VarChar).Value = li_PlateDamageDetail.PlateSizeID;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_PlateDamageDetail.Qty;
            cmd.Parameters.Add("@BillRate", SqlDbType.Decimal).Value = li_PlateDamageDetail.BillRate; 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
    public int InsertLi_PlateDamageStockDetail(Li_PlateDamageDetail li_PlateDamageDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PlateDamageStockDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@PDS_ID", SqlDbType.VarChar).Value = li_PlateDamageDetail.PDM_ID;
            cmd.Parameters.Add("@PlateTypeID", SqlDbType.VarChar).Value = li_PlateDamageDetail.PlateTypeID;
            cmd.Parameters.Add("@PlateSizeID", SqlDbType.VarChar).Value = li_PlateDamageDetail.PlateSizeID;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_PlateDamageDetail.Qty;         
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }
}
