using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BookProductionDetailsProvider:DataAccessObject
{
	public SqlLi_BookProductionDetailsProvider()
    {
    }


    public bool DeleteLi_BookProductionDetails(int li_BookProductionDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BookProductionDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BookProductionDetailsID", SqlDbType.Int).Value = li_BookProductionDetailsID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BookProductionDetails> GetAllLi_BookProductionDetailss()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BookProductionDetailss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BookProductionDetailssFromReader(reader);
        }
    }
    public List<Li_BookProductionDetails> GetLi_BookProductionDetailssFromReader(IDataReader reader)
    {
        List<Li_BookProductionDetails> li_BookProductionDetailss = new List<Li_BookProductionDetails>();

        while (reader.Read())
        {
            li_BookProductionDetailss.Add(GetLi_BookProductionDetailsFromReader(reader));
        }
        return li_BookProductionDetailss;
    }

    public Li_BookProductionDetails GetLi_BookProductionDetailsFromReader(IDataReader reader)
    {
        try
        {
            Li_BookProductionDetails li_BookProductionDetails = new Li_BookProductionDetails
                (
                     reader["BookCode"].ToString(),
                    reader["BookID"].ToString(),
                    reader["Edition"].ToString(),
                    (int)reader["BookQty"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    reader["CoverColor"].ToString(),
                    reader["InnerColor"].ToString(),
                    reader["FormaColor"].ToString(),
                    reader["BookForma"].ToString(),
                    reader["BookSize"].ToString(),
                    reader["CoverPaperType"].ToString(),
                    reader["CoverPaperSize"].ToString(),
                    reader["CoverPaperWeight"].ToString(),
                    reader["CoverPaperManufacturer"].ToString(),
                    reader["InnerPaperType"].ToString(),
                    reader["InnerPaperSize"].ToString(),
                    reader["InnerPaperWeight"].ToString(),
                    reader["InnerPaperManufacturer"].ToString(),
                    reader["FormaPaperType"].ToString(),
                    reader["FormaPaperSize"].ToString(),
                    reader["FormaPaperWeight"].ToString(),
                    reader["FormaPaperManufacturer"].ToString(),
                    reader["LinationType"].ToString(),
                    reader["BindingType"].ToString(),
                    (bool)reader["IsCreasing"],
                     reader["InnerPageQty"].ToString ()
                );
             return li_BookProductionDetails;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_BookProductionDetails GetLi_BookProductionDetailsByID(int li_BookProductionDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BookProductionDetailsByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_BookProductionDetailsID", SqlDbType.Int).Value = li_BookProductionDetailsID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BookProductionDetailsFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_BookProductionDetails(Li_BookProductionDetails li_BookProductionDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BookProductionDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BookProductionDetailsID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BookProductionDetails.BookCode;
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = li_BookProductionDetails.BookID;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_BookProductionDetails.Edition;
            cmd.Parameters.Add("@BookQty", SqlDbType.Int).Value = li_BookProductionDetails.BookQty;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookProductionDetails.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookProductionDetails.CreatedBy;
            cmd.Parameters.Add("@CoverColor", SqlDbType.VarChar).Value = li_BookProductionDetails.CoverColor;
            cmd.Parameters.Add("@InnerColor", SqlDbType.VarChar).Value = li_BookProductionDetails.InnerColor;
            cmd.Parameters.Add("@FormaColor", SqlDbType.VarChar).Value = li_BookProductionDetails.FormaColor;
            cmd.Parameters.Add("@BookForma", SqlDbType.VarChar).Value = li_BookProductionDetails.BookForma;
            cmd.Parameters.Add("@BookSize", SqlDbType.VarChar).Value = li_BookProductionDetails.BookSize;
            cmd.Parameters.Add("@CoverPaperType", SqlDbType.VarChar).Value = li_BookProductionDetails.CoverPaperType;
            cmd.Parameters.Add("@CoverPaperSize", SqlDbType.VarChar).Value = li_BookProductionDetails.CoverPaperSize;
            cmd.Parameters.Add("@CoverPaperWeight", SqlDbType.VarChar).Value = li_BookProductionDetails.CoverPaperWeight;
            cmd.Parameters.Add("@CoverPaperManufacturer", SqlDbType.VarChar).Value = li_BookProductionDetails.CoverPaperManufacturer;
            cmd.Parameters.Add("@InnerPaperType", SqlDbType.VarChar).Value = li_BookProductionDetails.InnerPaperType;
            cmd.Parameters.Add("@InnerPaperSize", SqlDbType.VarChar).Value = li_BookProductionDetails.InnerPaperSize;
            cmd.Parameters.Add("@InnerPaperWeight", SqlDbType.VarChar).Value = li_BookProductionDetails.InnerPaperWeight;
            cmd.Parameters.Add("@InnerPaperManufacturer", SqlDbType.VarChar).Value = li_BookProductionDetails.InnerPaperManufacturer;
            cmd.Parameters.Add("@FormaPaperType", SqlDbType.VarChar).Value = li_BookProductionDetails.FormaPaperType;
            cmd.Parameters.Add("@FormaPaperSize", SqlDbType.VarChar).Value = li_BookProductionDetails.FormaPaperSize;
            cmd.Parameters.Add("@FormaPaperWeight", SqlDbType.VarChar).Value = li_BookProductionDetails.FormaPaperWeight;
            cmd.Parameters.Add("@FormaPaperManufacturer", SqlDbType.VarChar).Value = li_BookProductionDetails.FormaPaperManufacturer;
            cmd.Parameters.Add("@LinationType", SqlDbType.VarChar).Value = li_BookProductionDetails.LinationType;
            cmd.Parameters.Add("@BindingType", SqlDbType.VarChar).Value = li_BookProductionDetails.BindingType;
            cmd.Parameters.Add("@IsCreasing", SqlDbType.Bit).Value = li_BookProductionDetails.IsCreasing;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Li_BookProductionDetailsID"].Value;
        }
    }

    public bool UpdateLi_BookProductionDetails(Li_BookProductionDetails li_BookProductionDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BookProductionDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BookProductionDetails.BookCode;
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = li_BookProductionDetails.BookID;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_BookProductionDetails.Edition;
            cmd.Parameters.Add("@BookQty", SqlDbType.Int).Value = li_BookProductionDetails.BookQty;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookProductionDetails.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookProductionDetails.CreatedBy;
            cmd.Parameters.Add("@CoverColor", SqlDbType.VarChar).Value = li_BookProductionDetails.CoverColor;
            cmd.Parameters.Add("@InnerColor", SqlDbType.VarChar).Value = li_BookProductionDetails.InnerColor;
            cmd.Parameters.Add("@FormaColor", SqlDbType.VarChar).Value = li_BookProductionDetails.FormaColor;
            cmd.Parameters.Add("@BookForma", SqlDbType.VarChar).Value = li_BookProductionDetails.BookForma;
            cmd.Parameters.Add("@BookSize", SqlDbType.VarChar).Value = li_BookProductionDetails.BookSize;
            cmd.Parameters.Add("@CoverPaperType", SqlDbType.VarChar).Value = li_BookProductionDetails.CoverPaperType;
            cmd.Parameters.Add("@CoverPaperSize", SqlDbType.VarChar).Value = li_BookProductionDetails.CoverPaperSize;
            cmd.Parameters.Add("@CoverPaperWeight", SqlDbType.VarChar).Value = li_BookProductionDetails.CoverPaperWeight;
            cmd.Parameters.Add("@CoverPaperManufacturer", SqlDbType.VarChar).Value = li_BookProductionDetails.CoverPaperManufacturer;
            cmd.Parameters.Add("@InnerPaperType", SqlDbType.VarChar).Value = li_BookProductionDetails.InnerPaperType;
            cmd.Parameters.Add("@InnerPaperSize", SqlDbType.VarChar).Value = li_BookProductionDetails.InnerPaperSize;
            cmd.Parameters.Add("@InnerPaperWeight", SqlDbType.VarChar).Value = li_BookProductionDetails.InnerPaperWeight;
            cmd.Parameters.Add("@InnerPaperManufacturer", SqlDbType.VarChar).Value = li_BookProductionDetails.InnerPaperManufacturer;
            cmd.Parameters.Add("@FormaPaperType", SqlDbType.VarChar).Value = li_BookProductionDetails.FormaPaperType;
            cmd.Parameters.Add("@FormaPaperSize", SqlDbType.VarChar).Value = li_BookProductionDetails.FormaPaperSize;
            cmd.Parameters.Add("@FormaPaperWeight", SqlDbType.VarChar).Value = li_BookProductionDetails.FormaPaperWeight;
            cmd.Parameters.Add("@FormaPaperManufacturer", SqlDbType.VarChar).Value = li_BookProductionDetails.FormaPaperManufacturer;
            cmd.Parameters.Add("@LinationType", SqlDbType.VarChar).Value = li_BookProductionDetails.LinationType;
            cmd.Parameters.Add("@BindingType", SqlDbType.VarChar).Value = li_BookProductionDetails.BindingType;
            cmd.Parameters.Add("@IsCreasing", SqlDbType.Bit).Value = li_BookProductionDetails.IsCreasing;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetProductionDetailInfoByBookCode(string BookCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_ShowProductionBookInformations", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }




}
