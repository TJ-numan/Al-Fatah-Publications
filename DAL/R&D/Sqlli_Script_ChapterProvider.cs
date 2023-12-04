using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Script_ChapterProvider:DataAccessObject
{
	public SqlLi_Script_ChapterProvider()
    {
    }


    public bool DeleteLi_Script_Chapter(int li_Script_ChapterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Script_Chapter", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Script_ChapterID", SqlDbType.Int).Value = li_Script_ChapterID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Script_Chapter> GetAllLi_Script_Chapters()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Script_Chapters", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Script_ChaptersFromReader(reader);
        }
    }
    public List<Li_Script_Chapter> GetLi_Script_ChaptersFromReader(IDataReader reader)
    {
        List<Li_Script_Chapter> li_Script_Chapters = new List<Li_Script_Chapter>();

        while (reader.Read())
        {
            li_Script_Chapters.Add(GetLi_Script_ChapterFromReader(reader));
        }
        return li_Script_Chapters;
    }

    public Li_Script_Chapter GetLi_Script_ChapterFromReader(IDataReader reader)
    {
        try
        {
            Li_Script_Chapter li_Script_Chapter = new Li_Script_Chapter
                (
                    (int)reader ["SerialNo"],
                    reader["BookCode"].ToString(),
                    reader["Edition"].ToString(),
                    (decimal)reader["Unit_No"],
                    reader["Unit_Heading"].ToString(),
                    reader["Auth_ID"].ToString(),
                    (bool)reader["InHouse"],
                    (DateTime)reader["LastDate"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (char)reader["Status_D"] 
                    
                );
             return li_Script_Chapter;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Script_Chapter GetLi_Script_ChapterByID(int li_Script_ChapterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Script_ChapterByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Script_ChapterID", SqlDbType.Int).Value = li_Script_ChapterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Script_ChapterFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Script_Chapter(Li_Script_Chapter li_Script_Chapter)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Script_Chapter", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_Script_Chapter.SerialNo;
 
            cmd.Parameters.Add("@Unit_No", SqlDbType.Decimal).Value = li_Script_Chapter.Unit_No;
            cmd.Parameters.Add("@Unit_Heading", SqlDbType.VarChar).Value = li_Script_Chapter.Unit_Heading;
            cmd.Parameters.Add("@Auth_ID", SqlDbType.VarChar).Value = li_Script_Chapter.Auth_ID;
            cmd.Parameters.Add("@InHouse", SqlDbType.Bit).Value = li_Script_Chapter.InHouse;
            cmd.Parameters.Add("@LastDate", SqlDbType.DateTime).Value = li_Script_Chapter.LastDate;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Script_Chapter.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Script_Chapter.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Script_Chapter.Status_D;
    
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@Li_Script_ChapterID"].Value;
        }
    }

    public bool UpdateLi_Script_Chapter(Li_Script_Chapter li_Script_Chapter)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Script_Chapter", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_Script_Chapter.BookCode;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_Script_Chapter.Edition;
            cmd.Parameters.Add("@Unit_No", SqlDbType.Decimal).Value = li_Script_Chapter.Unit_No;
            cmd.Parameters.Add("@Unit_Heading", SqlDbType.VarChar).Value = li_Script_Chapter.Unit_Heading;
            cmd.Parameters.Add("@Auth_ID", SqlDbType.VarChar).Value = li_Script_Chapter.Auth_ID;
            cmd.Parameters.Add("@InHouse", SqlDbType.Bit).Value = li_Script_Chapter.InHouse;
            cmd.Parameters.Add("@LastDate", SqlDbType.DateTime).Value = li_Script_Chapter.LastDate;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Script_Chapter.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Script_Chapter.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Script_Chapter.Status_D;
  
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
