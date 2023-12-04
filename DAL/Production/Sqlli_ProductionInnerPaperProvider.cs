using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_ProductionInnerPaperProvider:DataAccessObject
{
	public SqlLi_ProductionInnerPaperProvider()
    {
    }


    public bool DeleteLi_ProductionInnerPaper(int li_ProductionInnerPaperID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_ProductionInnerPaper", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_ProductionInnerPaperID", SqlDbType.Int).Value = li_ProductionInnerPaperID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_ProductionInnerPaper> GetAllLi_ProductionInnerPapers()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_ProductionInnerPapers", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ProductionInnerPapersFromReader(reader);
        }
    }
    public List<Li_ProductionInnerPaper> GetLi_ProductionInnerPapersFromReader(IDataReader reader)
    {
        List<Li_ProductionInnerPaper> li_ProductionInnerPapers = new List<Li_ProductionInnerPaper>();

        while (reader.Read())
        {
            li_ProductionInnerPapers.Add(GetLi_ProductionInnerPaperFromReader(reader));
        }
        return li_ProductionInnerPapers;
    }

    public Li_ProductionInnerPaper GetLi_ProductionInnerPaperFromReader(IDataReader reader)
    {
        try
        {
            Li_ProductionInnerPaper li_ProductionInnerPaper = new Li_ProductionInnerPaper
                (
                     
                    reader["BookCode"].ToString(),
                    reader["InnerSize"].ToString(),
                    (int)reader["Art4Qty"],
                    reader["Art4QtyWeight"].ToString(),
                    reader["Art4QtyBrand"].ToString(),
                    (int)reader["Offset4Qty"],
                    reader["Offset4QtyWeight"].ToString(),
                    reader["Offset4QtyBrand"].ToString(),
                    (int)reader["Offset2Qty"],
                    reader["Offset2QtyWeight"].ToString(),
                    reader["Offset2QtyBrand"].ToString(),
                    (int)reader["NewsQty"],
                    reader["NewsQtyWeight"].ToString(),
                    reader["NewsQtyBrand"].ToString() 
                     
                );
             return li_ProductionInnerPaper;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_ProductionInnerPaper GetLi_ProductionInnerPaperByID(int li_ProductionInnerPaperID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_ProductionInnerPaperByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_ProductionInnerPaperID", SqlDbType.Int).Value = li_ProductionInnerPaperID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ProductionInnerPaperFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_ProductionInnerPaper(Li_ProductionInnerPaper li_ProductionInnerPaper)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_ProductionInnerPaper", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_ProductionInnerPaper.BookCode;
            cmd.Parameters.Add("@InnerSize", SqlDbType.VarChar).Value = li_ProductionInnerPaper.InnerSize;
            cmd.Parameters.Add("@Art4Qty", SqlDbType.Int).Value = li_ProductionInnerPaper.Art4Qty;
            cmd.Parameters.Add("@Art4QtyWeight", SqlDbType.VarChar).Value = li_ProductionInnerPaper.Art4QtyWeight;
            cmd.Parameters.Add("@Art4QtyBrand", SqlDbType.VarChar).Value = li_ProductionInnerPaper.Art4QtyBrand;
            cmd.Parameters.Add("@Offset4Qty", SqlDbType.Int).Value = li_ProductionInnerPaper.Offset4Qty;
            cmd.Parameters.Add("@Offset4QtyWeight", SqlDbType.VarChar).Value = li_ProductionInnerPaper.Offset4QtyWeight;
            cmd.Parameters.Add("@Offset4QtyBrand", SqlDbType.VarChar).Value = li_ProductionInnerPaper.Offset4QtyBrand;
            cmd.Parameters.Add("@Offset2Qty", SqlDbType.Int).Value = li_ProductionInnerPaper.Offset2Qty;
            cmd.Parameters.Add("@Offset2QtyWeight", SqlDbType.VarChar).Value = li_ProductionInnerPaper.Offset2QtyWeight;
            cmd.Parameters.Add("@Offset2QtyBrand", SqlDbType.VarChar).Value = li_ProductionInnerPaper.Offset2QtyBrand;
            cmd.Parameters.Add("@NewsQty", SqlDbType.Int).Value = li_ProductionInnerPaper.NewsQty;
            cmd.Parameters.Add("@NewsQtyWeight", SqlDbType.VarChar).Value = li_ProductionInnerPaper.NewsQtyWeight;
            cmd.Parameters.Add("@NewsQtyBrand", SqlDbType.VarChar).Value = li_ProductionInnerPaper.NewsQtyBrand;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_ProductionInnerPaper(Li_ProductionInnerPaper li_ProductionInnerPaper)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_ProductionInnerPaper", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_ProductionInnerPaper.BookCode;
            cmd.Parameters.Add("@InnerSize", SqlDbType.VarChar).Value = li_ProductionInnerPaper.InnerSize;
            cmd.Parameters.Add("@Art4Qty", SqlDbType.Int).Value = li_ProductionInnerPaper.Art4Qty;
            cmd.Parameters.Add("@Art4QtyWeight", SqlDbType.VarChar).Value = li_ProductionInnerPaper.Art4QtyWeight;
            cmd.Parameters.Add("@Art4QtyBrand", SqlDbType.VarChar).Value = li_ProductionInnerPaper.Art4QtyBrand;
            cmd.Parameters.Add("@Offset4Qty", SqlDbType.Int).Value = li_ProductionInnerPaper.Offset4Qty;
            cmd.Parameters.Add("@Offset4QtyWeight", SqlDbType.VarChar).Value = li_ProductionInnerPaper.Offset4QtyWeight;
            cmd.Parameters.Add("@Offset4QtyBrand", SqlDbType.VarChar).Value = li_ProductionInnerPaper.Offset4QtyBrand;
            cmd.Parameters.Add("@Offset2Qty", SqlDbType.Int).Value = li_ProductionInnerPaper.Offset2Qty;
            cmd.Parameters.Add("@Offset2QtyWeight", SqlDbType.VarChar).Value = li_ProductionInnerPaper.Offset2QtyWeight;
            cmd.Parameters.Add("@Offset2QtyBrand", SqlDbType.VarChar).Value = li_ProductionInnerPaper.Offset2QtyBrand;
            cmd.Parameters.Add("@NewsQty", SqlDbType.Int).Value = li_ProductionInnerPaper.NewsQty;
            cmd.Parameters.Add("@NewsQtyWeight", SqlDbType.VarChar).Value = li_ProductionInnerPaper.NewsQtyWeight;
            cmd.Parameters.Add("@NewsQtyBrand", SqlDbType.VarChar).Value = li_ProductionInnerPaper.NewsQtyBrand;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
