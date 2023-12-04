using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PaperSizeBasicProvider:DataAccessObject
{
	public SqlLi_PaperSizeBasicProvider()
    {
    }


    public bool DeleteLi_PaperSizeBasic(int li_PaperSizeBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PaperSizeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PaperSizeBasicID", SqlDbType.Int).Value = li_PaperSizeBasicID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PaperSizeBasic> GetAllLi_PaperSizeBasics()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PaperSizeBasics", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PaperSizeBasicsFromReader(reader);
        }
    }
    public List<Li_PaperSizeBasic> GetLi_PaperSizeBasicsFromReader(IDataReader reader)
    {
        List<Li_PaperSizeBasic> li_PaperSizeBasics = new List<Li_PaperSizeBasic>();

        while (reader.Read())
        {
            li_PaperSizeBasics.Add(GetLi_PaperSizeBasicFromReader(reader));
        }
        return li_PaperSizeBasics;
    }

    public Li_PaperSizeBasic GetLi_PaperSizeBasicFromReader(IDataReader reader)
    {
        try
        {
            Li_PaperSizeBasic li_PaperSizeBasic = new Li_PaperSizeBasic
                (
                   
                    reader["SizeID"].ToString(),
                    reader["Size"].ToString(),
                     reader["PaperType"].ToString(),
                     
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"] 
                     
                );
             return li_PaperSizeBasic;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public List<Li_PaperSizeBasic> GetLi_PaperSizeBasicByID(string  li_PaperTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PaperSizeBasicByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PaperType", SqlDbType.VarChar).Value = li_PaperTypeID;
            connection.Open();

            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PaperSizeBasicsFromReader(reader);
        }
    }

    public string  InsertLi_PaperSizeBasic(Li_PaperSizeBasic li_PaperSizeBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PaperSizeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@SizeID", SqlDbType.VarChar,50) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Size", SqlDbType.VarChar).Value = li_PaperSizeBasic.Size;
            cmd.Parameters.Add("@PaperType", SqlDbType.VarChar ).Value = li_PaperSizeBasic.PaperType;
        
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PaperSizeBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PaperSizeBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@SizeID"].Value.ToString ();
        }
    }

    public bool UpdateLi_PaperSizeBasic(Li_PaperSizeBasic li_PaperSizeBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PaperSizeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@SizeID", SqlDbType.VarChar).Value = li_PaperSizeBasic.SizeID;
            cmd.Parameters.Add("@Size", SqlDbType.VarChar).Value = li_PaperSizeBasic.Size;
             cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PaperSizeBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PaperSizeBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }    
    }
}
