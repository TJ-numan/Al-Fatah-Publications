using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PlateProcessDetailProvider:DataAccessObject
{
	public SqlLi_PlateProcessDetailProvider()
    {
    }


    public bool DeleteLi_PlateProcessDetail(int li_PlateProcessDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlateProcessDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PlateProcessDetailID", SqlDbType.Int).Value = li_PlateProcessDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PlateProcessDetail> GetAllLi_PlateProcessDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlateProcessDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PlateProcessDetailsFromReader(reader);
        }
    }
    public List<Li_PlateProcessDetail> GetLi_PlateProcessDetailsFromReader(IDataReader reader)
    {
        List<Li_PlateProcessDetail> li_PlateProcessDetails = new List<Li_PlateProcessDetail>();

        while (reader.Read())
        {
            li_PlateProcessDetails.Add(GetLi_PlateProcessDetailFromReader(reader));
        }
        return li_PlateProcessDetails;
    }

    public Li_PlateProcessDetail GetLi_PlateProcessDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_PlateProcessDetail li_PlateProcessDetail = new Li_PlateProcessDetail
                (
                    
                    (int)reader["SerialNo"],
                    reader["Pro_ID"].ToString(),
                    reader["BookCode"].ToString(),
                    reader["PressID"].ToString(),
                    (int)reader["Pur_Sl"],
                    (int)reader["Qty"] 
                );
             return li_PlateProcessDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PlateProcessDetail GetLi_PlateProcessDetailByID(int li_PlateProcessDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlateProcessDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PlateProcessDetailID", SqlDbType.Int).Value = li_PlateProcessDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PlateProcessDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PlateProcessDetail(Li_PlateProcessDetail li_PlateProcessDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PlateProcessDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Pro_ID", SqlDbType.VarChar).Value = li_PlateProcessDetail.Pro_ID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_PlateProcessDetail.BookCode;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_PlateProcessDetail.PressID;
            cmd.Parameters.Add("@Pur_Sl", SqlDbType.Int).Value = li_PlateProcessDetail.Pur_Sl;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_PlateProcessDetail.Qty;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  1;
        }
    }

    public bool UpdateLi_PlateProcessDetail(Li_PlateProcessDetail li_PlateProcessDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PlateProcessDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_PlateProcessDetail.SerialNo;
            cmd.Parameters.Add("@Pro_ID", SqlDbType.VarChar).Value = li_PlateProcessDetail.Pro_ID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_PlateProcessDetail.BookCode;
            cmd.Parameters.Add("@PressID", SqlDbType.VarChar).Value = li_PlateProcessDetail.PressID;
            cmd.Parameters.Add("@Pur_Sl", SqlDbType.Int).Value = li_PlateProcessDetail.Pur_Sl;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_PlateProcessDetail.Qty;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
