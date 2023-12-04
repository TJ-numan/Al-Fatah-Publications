using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_ProductionBookDetailsProvider:DataAccessObject
{
	public SqlLi_ProductionBookDetailsProvider()
    {
    }


    public bool DeleteLi_ProductionBookDetails(int li_ProductionBookDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_ProductionBookDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_ProductionBookDetailsID", SqlDbType.Int).Value = li_ProductionBookDetailsID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_ProductionBookDetails> GetAllLi_ProductionBookDetailss()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_ProductionBookDetailss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ProductionBookDetailssFromReader(reader);
        }
    }
    public List<Li_ProductionBookDetails> GetLi_ProductionBookDetailssFromReader(IDataReader reader)
    {
        List<Li_ProductionBookDetails> li_ProductionBookDetailss = new List<Li_ProductionBookDetails>();

        while (reader.Read())
        {
            li_ProductionBookDetailss.Add(GetLi_ProductionBookDetailsFromReader(reader));
        }
        return li_ProductionBookDetailss;
    }

    public Li_ProductionBookDetails GetLi_ProductionBookDetailsFromReader(IDataReader reader)
    {
        try
        {
            Li_ProductionBookDetails li_ProductionBookDetails = new Li_ProductionBookDetails
                (
                     
                    reader["BookCode"].ToString(),
                    reader["BookID"].ToString(),
                    (int)reader["PrintQty"],
                    (decimal)reader["BookForma"],
                    reader["BookSize"].ToString(),
                    reader["Eddition"].ToString(),
                    (DateTime)reader["CreatedDate"],
                    (DateTime)reader["PrintDate"],
                    (int)reader["CreatedBy"],
                    reader["LeminationType"].ToString(),
                    reader["BindingType"].ToString(),
                    (bool)reader["IsCreasing"] 
                     
                );
             return li_ProductionBookDetails;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_ProductionBookDetails GetLi_ProductionBookDetailsByID(int li_ProductionBookDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_ProductionBookDetailsByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_ProductionBookDetailsID", SqlDbType.Int).Value = li_ProductionBookDetailsID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ProductionBookDetailsFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_ProductionBookDetails(Li_ProductionBookDetails li_ProductionBookDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_ProductionBookDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_ProductionBookDetails.BookCode;
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = li_ProductionBookDetails.BookID;
            cmd.Parameters.Add("@PrintQty", SqlDbType.Int).Value = li_ProductionBookDetails.PrintQty;
            cmd.Parameters.Add("@BookForma", SqlDbType.Decimal).Value = li_ProductionBookDetails.BookForma;
            cmd.Parameters.Add("@BookSize", SqlDbType.VarChar).Value = li_ProductionBookDetails.BookSize;
            cmd.Parameters.Add("@Eddition", SqlDbType.VarChar).Value = li_ProductionBookDetails.Eddition;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ProductionBookDetails.CreatedDate;
            cmd.Parameters.Add("@PrintDate", SqlDbType.DateTime).Value = li_ProductionBookDetails.PrintDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ProductionBookDetails.CreatedBy;
            cmd.Parameters.Add("@LeminationType", SqlDbType.VarChar).Value = li_ProductionBookDetails.LeminationType;
            cmd.Parameters.Add("@BindingType", SqlDbType.VarChar).Value = li_ProductionBookDetails.BindingType;
            cmd.Parameters.Add("@IsCreasing", SqlDbType.Bit).Value = li_ProductionBookDetails.IsCreasing;
             connection.Open();
            cmd.ExecuteNonQuery();
            return 1;
            
        }
    }

    public bool UpdateLi_ProductionBookDetails(Li_ProductionBookDetails li_ProductionBookDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_ProductionBookDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_ProductionBookDetails.BookCode;
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = li_ProductionBookDetails.BookID;
            cmd.Parameters.Add("@PrintQty", SqlDbType.Int).Value = li_ProductionBookDetails.PrintQty;
            cmd.Parameters.Add("@BookForma", SqlDbType.Decimal).Value = li_ProductionBookDetails.BookForma;
            cmd.Parameters.Add("@BookSize", SqlDbType.VarChar).Value = li_ProductionBookDetails.BookSize;
            cmd.Parameters.Add("@Eddition", SqlDbType.VarChar).Value = li_ProductionBookDetails.Eddition;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ProductionBookDetails.CreatedDate;
            cmd.Parameters.Add("@PrintDate", SqlDbType.DateTime).Value = li_ProductionBookDetails.PrintDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ProductionBookDetails.CreatedBy;
            cmd.Parameters.Add("@LeminationType", SqlDbType.VarChar).Value = li_ProductionBookDetails.LeminationType;
            cmd.Parameters.Add("@BindingType", SqlDbType.VarChar).Value = li_ProductionBookDetails.BindingType;
            cmd.Parameters.Add("@IsCreasing", SqlDbType.Bit).Value = li_ProductionBookDetails.IsCreasing;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
