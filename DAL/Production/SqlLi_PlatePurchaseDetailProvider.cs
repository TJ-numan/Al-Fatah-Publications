using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PlatePurchaseDetailProvider:DataAccessObject
{
	public SqlLi_PlatePurchaseDetailProvider()
    {
    }


    public bool DeleteLi_PlatePurchaseDetail(int li_PlatePurchaseDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlatePurchaseDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PlatePurchaseDetailID", SqlDbType.Int).Value = li_PlatePurchaseDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PlatePurchaseDetail> GetAllLi_PlatePurchaseDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlatePurchaseDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PlatePurchaseDetailsFromReader(reader);
        }
    }
    public List<Li_PlatePurchaseDetail> GetLi_PlatePurchaseDetailsFromReader(IDataReader reader)
    {
        List<Li_PlatePurchaseDetail> li_PlatePurchaseDetails = new List<Li_PlatePurchaseDetail>();

        while (reader.Read())
        {
            li_PlatePurchaseDetails.Add(GetLi_PlatePurchaseDetailFromReader(reader));
        }
        return li_PlatePurchaseDetails;
    }

    public Li_PlatePurchaseDetail GetLi_PlatePurchaseDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_PlatePurchaseDetail li_PlatePurchaseDetail = new Li_PlatePurchaseDetail
                (
                   
                    (int)reader["Sl"],
                    reader["Pur_ID"].ToString(),
                    reader["BookCode"].ToString(),
                    reader["Edition"].ToString(),
                    reader["PlateTypeID"].ToString(),
                    reader["PlateSizeID"].ToString(),
                    (int)reader["Qty"],
                    (decimal)reader["BillRate"] ,
                    (int)reader["PlateFor"],
                    reader["Refno"].ToString() ,
                    (DateTime )reader["PurDate"] 
                );
             return li_PlatePurchaseDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PlatePurchaseDetail GetLi_PlatePurchaseDetailByID(int li_PlatePurchaseDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlatePurchaseDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PlatePurchaseDetailID", SqlDbType.Int).Value = li_PlatePurchaseDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PlatePurchaseDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PlatePurchaseDetail(Li_PlatePurchaseDetail li_PlatePurchaseDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PlatePurchaseDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@Pur_ID", SqlDbType.VarChar).Value = li_PlatePurchaseDetail.Pur_ID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_PlatePurchaseDetail.BookCode;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_PlatePurchaseDetail.Edition;
            cmd.Parameters.Add("@PlateTypeID", SqlDbType.VarChar).Value = li_PlatePurchaseDetail.PlateTypeID;
            cmd.Parameters.Add("@PlateSizeID", SqlDbType.VarChar).Value = li_PlatePurchaseDetail.PlateSizeID;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_PlatePurchaseDetail.Qty;
            cmd.Parameters.Add("@BillRate", SqlDbType.Decimal).Value = li_PlatePurchaseDetail.BillRate;
            cmd.Parameters.Add("@PlateFor", SqlDbType.Int).Value = li_PlatePurchaseDetail.PlateFor;
            cmd.Parameters.Add("@Refno", SqlDbType.VarChar).Value = li_PlatePurchaseDetail.Refno;
            cmd.Parameters.Add("@PurDate", SqlDbType.Date).Value = li_PlatePurchaseDetail.PurDate  ;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_PlatePurchaseDetail(Li_PlatePurchaseDetail li_PlatePurchaseDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PlatePurchaseDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@Sl", SqlDbType.Int).Value = li_PlatePurchaseDetail.Sl;
            cmd.Parameters.Add("@Pur_ID", SqlDbType.VarChar).Value = li_PlatePurchaseDetail.Pur_ID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_PlatePurchaseDetail.BookCode;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_PlatePurchaseDetail.Edition;
            cmd.Parameters.Add("@PlateTypeID", SqlDbType.VarChar).Value = li_PlatePurchaseDetail.PlateTypeID;
            cmd.Parameters.Add("@PlateSizeID", SqlDbType.VarChar).Value = li_PlatePurchaseDetail.PlateSizeID;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_PlatePurchaseDetail.Qty;
            cmd.Parameters.Add("@BillRate", SqlDbType.Decimal).Value = li_PlatePurchaseDetail.BillRate;
            cmd.Parameters.Add("@PlateFor", SqlDbType.Int).Value = li_PlatePurchaseDetail.PlateFor;  
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
