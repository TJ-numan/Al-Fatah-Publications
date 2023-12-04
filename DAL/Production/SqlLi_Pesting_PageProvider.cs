using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Pesting_PageProvider:DataAccessObject
{
	public SqlLi_Pesting_PageProvider()
    {
    }


    public bool DeleteLi_Pesting_Page(int li_Pesting_PageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Pesting_Page", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Pesting_PageID", SqlDbType.Int).Value = li_Pesting_PageID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Pesting_Page> GetAllLi_Pesting_Pages()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Pesting_Pages", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Pesting_PagesFromReader(reader);
        }
    }
    public List<Li_Pesting_Page> GetLi_Pesting_PagesFromReader(IDataReader reader)
    {
        List<Li_Pesting_Page> li_Pesting_Pages = new List<Li_Pesting_Page>();

        while (reader.Read())
        {
            li_Pesting_Pages.Add(GetLi_Pesting_PageFromReader(reader));
        }
        return li_Pesting_Pages;
    }

    public Li_Pesting_Page GetLi_Pesting_PageFromReader(IDataReader reader)
    {
        try
        {
            Li_Pesting_Page li_Pesting_Page = new Li_Pesting_Page
                (
                    
                    (int)reader["SerialNo"],
                    reader["OrderNo"].ToString(),
                    (int)reader["Inner_P"],
                    (int)reader["Suggestion_P"],
                    (int)reader["Index_P"],
                    (int)reader["Main_P"],
                    (int)reader["Last_P"],
                    (int)reader["Total_P"],
                    (char)reader["Status_D"] 
                );
             return li_Pesting_Page;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Pesting_Page GetLi_Pesting_PageByID(int li_Pesting_PageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Pesting_PageByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Pesting_PageID", SqlDbType.Int).Value = li_Pesting_PageID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Pesting_PageFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Pesting_Page(Li_Pesting_Page li_Pesting_Page)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("web_SMPM_InsertLi_Pesting_Page", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
          //  cmd.Parameters.Add("@SerialNo", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = li_Pesting_Page.OrderNo;
            cmd.Parameters.Add("@Inner_P", SqlDbType.Int).Value = li_Pesting_Page.Inner_P;
            cmd.Parameters.Add("@Suggestion_P", SqlDbType.Int).Value = li_Pesting_Page.Suggestion_P;
            cmd.Parameters.Add("@Index_P", SqlDbType.Int).Value = li_Pesting_Page.Index_P;
            cmd.Parameters.Add("@Main_P", SqlDbType.Int).Value = li_Pesting_Page.Main_P;
            cmd.Parameters.Add("@Last_P", SqlDbType.Int).Value = li_Pesting_Page.Last_P;
            cmd.Parameters.Add("@Total_P", SqlDbType.Int).Value = li_Pesting_Page.Total_P;
            //cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Pesting_Page.Status_D;
          
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  1;
        }
    }

    public bool UpdateLi_Pesting_Page(Li_Pesting_Page li_Pesting_Page)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Pesting_Page", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_Pesting_Page.SerialNo;
            cmd.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = li_Pesting_Page.OrderNo;
            cmd.Parameters.Add("@Inner_P", SqlDbType.Int).Value = li_Pesting_Page.Inner_P;
            cmd.Parameters.Add("@Suggestion_P", SqlDbType.Int).Value = li_Pesting_Page.Suggestion_P;
            cmd.Parameters.Add("@Index_P", SqlDbType.Int).Value = li_Pesting_Page.Index_P;
            cmd.Parameters.Add("@Main_P", SqlDbType.Int).Value = li_Pesting_Page.Main_P;
            cmd.Parameters.Add("@Last_P", SqlDbType.Int).Value = li_Pesting_Page.Last_P;
            cmd.Parameters.Add("@Total_P", SqlDbType.Int).Value = li_Pesting_Page.Total_P;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Pesting_Page.Status_D;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
