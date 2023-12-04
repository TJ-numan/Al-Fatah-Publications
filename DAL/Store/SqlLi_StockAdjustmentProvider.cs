using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_StockAdjustmentProvider:DataAccessObject
{
	public SqlLi_StockAdjustmentProvider()
    {
    }


    public bool DeleteLi_StockAdjustment(int li_StockAdjustmentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_StockAdjustment", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_StockAdjustmentID", SqlDbType.Int).Value = li_StockAdjustmentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_StockAdjustment> GetAllLi_StockAdjustments()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_StockAdjustments", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_StockAdjustmentsFromReader(reader);
        }
    }
    public List<Li_StockAdjustment> GetLi_StockAdjustmentsFromReader(IDataReader reader)
    {
        List<Li_StockAdjustment> li_StockAdjustments = new List<Li_StockAdjustment>();

        while (reader.Read())
        {
            li_StockAdjustments.Add(GetLi_StockAdjustmentFromReader(reader));
        }
        return li_StockAdjustments;
    }

    public Li_StockAdjustment GetLi_StockAdjustmentFromReader(IDataReader reader)
    {
        try
        {
            Li_StockAdjustment li_StockAdjustment = new Li_StockAdjustment
                (
                  
                    (int)reader["ID"],
                    reader["BookCode"].ToString(),
                    (decimal)reader["CurStock"],
                    (decimal)reader["PhysicalStock"],
                    (decimal)reader["AdjustStock"],
                    (bool)reader["IsCentral"],
                    (DateTime)reader["AdjustDate"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    reader["VerifiedBy"].ToString() 
                );
             return li_StockAdjustment;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_StockAdjustment GetLi_StockAdjustmentByID(int li_StockAdjustmentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_StockAdjustmentByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_StockAdjustmentID", SqlDbType.Int).Value = li_StockAdjustmentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_StockAdjustmentFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_StockAdjustment(Li_StockAdjustment li_StockAdjustment)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_StockAdjustment", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@ID", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_StockAdjustment.BookCode;
            cmd.Parameters.Add("@CurStock", SqlDbType.Decimal).Value = li_StockAdjustment.CurStock;
            cmd.Parameters.Add("@PhysicalStock", SqlDbType.Decimal).Value = li_StockAdjustment.PhysicalStock;
            cmd.Parameters.Add("@AdjustStock", SqlDbType.Decimal).Value = li_StockAdjustment.AdjustStock;
            cmd.Parameters.Add("@IsCentral", SqlDbType.Bit).Value = li_StockAdjustment.IsCentral;
            cmd.Parameters.Add("@AdjustDate", SqlDbType.DateTime).Value = li_StockAdjustment.AdjustDate;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_StockAdjustment.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_StockAdjustment.CreatedBy;
            cmd.Parameters.Add("@VerifiedBy", SqlDbType.VarChar).Value = li_StockAdjustment.VerifiedBy;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@ID"].Value;
        }
    }

    public bool UpdateLi_StockAdjustment(Li_StockAdjustment li_StockAdjustment)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_StockAdjustment", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = li_StockAdjustment.ID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_StockAdjustment.BookCode;
            cmd.Parameters.Add("@CurStock", SqlDbType.Decimal).Value = li_StockAdjustment.CurStock;
            cmd.Parameters.Add("@PhysicalStock", SqlDbType.Decimal).Value = li_StockAdjustment.PhysicalStock;
            cmd.Parameters.Add("@AdjustStock", SqlDbType.Decimal).Value = li_StockAdjustment.AdjustStock;
            cmd.Parameters.Add("@IsCentral", SqlDbType.Bit).Value = li_StockAdjustment.IsCentral;
            cmd.Parameters.Add("@AdjustDate", SqlDbType.DateTime).Value = li_StockAdjustment.AdjustDate;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_StockAdjustment.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_StockAdjustment.CreatedBy;
            cmd.Parameters.Add("@VerifiedBy", SqlDbType.VarChar).Value = li_StockAdjustment.VerifiedBy;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
