using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Specimen_ReturnDetailProvider:DataAccessObject
{
	public SqlLi_Specimen_ReturnDetailProvider()
    {
    }


    public bool DeleteLi_Specimen_ReturnDetail(int li_Specimen_ReturnDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Specimen_ReturnDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Specimen_ReturnDetailID", SqlDbType.Int).Value = li_Specimen_ReturnDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Specimen_ReturnDetail> GetAllLi_Specimen_ReturnDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Specimen_ReturnDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Specimen_ReturnDetailsFromReader(reader);
        }
    }
    public List<Li_Specimen_ReturnDetail> GetLi_Specimen_ReturnDetailsFromReader(IDataReader reader)
    {
        List<Li_Specimen_ReturnDetail> li_Specimen_ReturnDetails = new List<Li_Specimen_ReturnDetail>();

        while (reader.Read())
        {
            li_Specimen_ReturnDetails.Add(GetLi_Specimen_ReturnDetailFromReader(reader));
        }
        return li_Specimen_ReturnDetails;
    }

    public Li_Specimen_ReturnDetail GetLi_Specimen_ReturnDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_Specimen_ReturnDetail li_Specimen_ReturnDetail = new Li_Specimen_ReturnDetail
                (
                     
                    reader["ReturnDetailsID"].ToString(),
                    reader["ReturnID"].ToString(),
                    reader["BookAcCode"].ToString(),
                    (int)reader["Qty"],
                    (int)reader["AdjustQty"],
                    (decimal)reader["UnitPrice"] 
                );
             return li_Specimen_ReturnDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Specimen_ReturnDetail GetLi_Specimen_ReturnDetailByID(int li_Specimen_ReturnDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Specimen_ReturnDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Specimen_ReturnDetailID", SqlDbType.Int).Value = li_Specimen_ReturnDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Specimen_ReturnDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Specimen_ReturnDetail(Li_Specimen_ReturnDetail li_Specimen_ReturnDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Specimen_ReturnDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ReturnDetailsID", SqlDbType.VarChar).Value = li_Specimen_ReturnDetail.ReturnDetailsID;
            cmd.Parameters.Add("@ReturnID", SqlDbType.VarChar).Value = li_Specimen_ReturnDetail.ReturnID;
            cmd.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = li_Specimen_ReturnDetail.BookAcCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_Specimen_ReturnDetail.Qty;
            cmd.Parameters.Add("@AdjustQty", SqlDbType.Int).Value = li_Specimen_ReturnDetail.AdjustQty;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = li_Specimen_ReturnDetail.UnitPrice;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_Specimen_ReturnDetail(Li_Specimen_ReturnDetail li_Specimen_ReturnDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Specimen_ReturnDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ReturnDetailsID", SqlDbType.VarChar).Value = li_Specimen_ReturnDetail.ReturnDetailsID;
            cmd.Parameters.Add("@ReturnID", SqlDbType.VarChar).Value = li_Specimen_ReturnDetail.ReturnID;
            cmd.Parameters.Add("@BookAcCode", SqlDbType.VarChar).Value = li_Specimen_ReturnDetail.BookAcCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_Specimen_ReturnDetail.Qty;
            cmd.Parameters.Add("@AdjustQty", SqlDbType.Int).Value = li_Specimen_ReturnDetail.AdjustQty;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = li_Specimen_ReturnDetail.UnitPrice;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
