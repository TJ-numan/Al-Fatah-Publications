using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_ProductionCoverPaperProvider:DataAccessObject
{
	public SqlLi_ProductionCoverPaperProvider()
    {
    }


    public bool DeleteLi_ProductionCoverPaper(int li_ProductionCoverPaperID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_ProductionCoverPaper", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_ProductionCoverPaperID", SqlDbType.Int).Value = li_ProductionCoverPaperID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_ProductionCoverPaper> GetAllLi_ProductionCoverPapers()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_ProductionCoverPapers", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ProductionCoverPapersFromReader(reader);
        }
    }
    public List<Li_ProductionCoverPaper> GetLi_ProductionCoverPapersFromReader(IDataReader reader)
    {
        List<Li_ProductionCoverPaper> li_ProductionCoverPapers = new List<Li_ProductionCoverPaper>();

        while (reader.Read())
        {
            li_ProductionCoverPapers.Add(GetLi_ProductionCoverPaperFromReader(reader));
        }
        return li_ProductionCoverPapers;
    }

    public Li_ProductionCoverPaper GetLi_ProductionCoverPaperFromReader(IDataReader reader)
    {
        try
        {
            Li_ProductionCoverPaper li_ProductionCoverPaper = new Li_ProductionCoverPaper
                (
                   
                    reader["BookCode"].ToString(),
                    reader["CoverPaper"].ToString(),
                    reader["CoverColor"].ToString(),
                    reader["CoverSize"].ToString(),
                    reader["CoverWeight"].ToString(),
                    reader["CoverBrand"].ToString() 
                    
                );
             return li_ProductionCoverPaper;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_ProductionCoverPaper GetLi_ProductionCoverPaperByID(int li_ProductionCoverPaperID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_ProductionCoverPaperByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_ProductionCoverPaperID", SqlDbType.Int).Value = li_ProductionCoverPaperID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ProductionCoverPaperFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_ProductionCoverPaper(Li_ProductionCoverPaper li_ProductionCoverPaper)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_ProductionCoverPaper", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_ProductionCoverPaper.BookCode;
            cmd.Parameters.Add("@CoverPaper", SqlDbType.VarChar).Value = li_ProductionCoverPaper.CoverPaper;
            cmd.Parameters.Add("@CoverColor", SqlDbType.VarChar).Value = li_ProductionCoverPaper.CoverColor;
            cmd.Parameters.Add("@CoverSize", SqlDbType.VarChar).Value = li_ProductionCoverPaper.CoverSize;
            cmd.Parameters.Add("@CoverWeight", SqlDbType.VarChar).Value = li_ProductionCoverPaper.CoverWeight;
            cmd.Parameters.Add("@CoverBrand", SqlDbType.VarChar).Value = li_ProductionCoverPaper.CoverBrand;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_ProductionCoverPaper(Li_ProductionCoverPaper li_ProductionCoverPaper)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_ProductionCoverPaper", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_ProductionCoverPaper.BookCode;
            cmd.Parameters.Add("@CoverPaper", SqlDbType.VarChar).Value = li_ProductionCoverPaper.CoverPaper;
            cmd.Parameters.Add("@CoverColor", SqlDbType.VarChar).Value = li_ProductionCoverPaper.CoverColor;
            cmd.Parameters.Add("@CoverSize", SqlDbType.VarChar).Value = li_ProductionCoverPaper.CoverSize;
            cmd.Parameters.Add("@CoverWeight", SqlDbType.VarChar).Value = li_ProductionCoverPaper.CoverWeight;
            cmd.Parameters.Add("@CoverBrand", SqlDbType.VarChar).Value = li_ProductionCoverPaper.CoverBrand;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
