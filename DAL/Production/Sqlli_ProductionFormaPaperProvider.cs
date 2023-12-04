using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_ProductionFormaPaperProvider:DataAccessObject
{
	public SqlLi_ProductionFormaPaperProvider()
    {
    }


    public bool DeleteLi_ProductionFormaPaper(int li_ProductionFormaPaperID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_ProductionFormaPaper", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_ProductionFormaPaperID", SqlDbType.Int).Value = li_ProductionFormaPaperID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_ProductionFormaPaper> GetAllLi_ProductionFormaPapers()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_ProductionFormaPapers", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ProductionFormaPapersFromReader(reader);
        }
    }
    public List<Li_ProductionFormaPaper> GetLi_ProductionFormaPapersFromReader(IDataReader reader)
    {
        List<Li_ProductionFormaPaper> li_ProductionFormaPapers = new List<Li_ProductionFormaPaper>();

        while (reader.Read())
        {
            li_ProductionFormaPapers.Add(GetLi_ProductionFormaPaperFromReader(reader));
        }
        return li_ProductionFormaPapers;
    }

    public Li_ProductionFormaPaper GetLi_ProductionFormaPaperFromReader(IDataReader reader)
    {
        try
        {
            Li_ProductionFormaPaper li_ProductionFormaPaper = new Li_ProductionFormaPaper
                (
                    
                    reader["BookCode"].ToString(),
                    reader["FormaPaper"].ToString(),
                    reader["FormaColor"].ToString(),
                    reader["FormaSize"].ToString(),
                    reader["FormaWeight"].ToString(),
                    reader["FormaBrand"].ToString() 
                    
                );
             return li_ProductionFormaPaper;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_ProductionFormaPaper GetLi_ProductionFormaPaperByID(int li_ProductionFormaPaperID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_ProductionFormaPaperByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_ProductionFormaPaperID", SqlDbType.Int).Value = li_ProductionFormaPaperID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ProductionFormaPaperFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_ProductionFormaPaper(Li_ProductionFormaPaper li_ProductionFormaPaper)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_ProductionFormaPaper", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_ProductionFormaPaper.BookCode;
            cmd.Parameters.Add("@FormaPaper", SqlDbType.VarChar).Value = li_ProductionFormaPaper.FormaPaper;
            cmd.Parameters.Add("@FormaColor", SqlDbType.VarChar).Value = li_ProductionFormaPaper.FormaColor;
            cmd.Parameters.Add("@FormaSize", SqlDbType.VarChar).Value = li_ProductionFormaPaper.FormaSize;
            cmd.Parameters.Add("@FormaWeight", SqlDbType.VarChar).Value = li_ProductionFormaPaper.FormaWeight;
            cmd.Parameters.Add("@FormaBrand", SqlDbType.VarChar).Value = li_ProductionFormaPaper.FormaBrand;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_ProductionFormaPaper(Li_ProductionFormaPaper li_ProductionFormaPaper)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_ProductionFormaPaper", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_ProductionFormaPaper.BookCode;
            cmd.Parameters.Add("@FormaPaper", SqlDbType.VarChar).Value = li_ProductionFormaPaper.FormaPaper;
            cmd.Parameters.Add("@FormaColor", SqlDbType.VarChar).Value = li_ProductionFormaPaper.FormaColor;
            cmd.Parameters.Add("@FormaSize", SqlDbType.VarChar).Value = li_ProductionFormaPaper.FormaSize;
            cmd.Parameters.Add("@FormaWeight", SqlDbType.VarChar).Value = li_ProductionFormaPaper.FormaWeight;
            cmd.Parameters.Add("@FormaBrand", SqlDbType.VarChar).Value = li_ProductionFormaPaper.FormaBrand;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
