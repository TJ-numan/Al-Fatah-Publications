using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BookInfo_SectionProvider:DataAccessObject
{
	public SqlLi_BookInfo_SectionProvider()
    {
    }


    public bool DeleteLi_BookInfo_Section(int li_BookInfo_SectionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BookInfo_Section", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BookInfo_SectionID", SqlDbType.Int).Value = li_BookInfo_SectionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BookInfo_Section> GetAllLi_BookInfo_Sections()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BookInfo_Sections", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BookInfo_SectionsFromReader(reader);
        }
    }
    public List<Li_BookInfo_Section> GetLi_BookInfo_SectionsFromReader(IDataReader reader)
    {
        List<Li_BookInfo_Section> li_BookInfo_Sections = new List<Li_BookInfo_Section>();

        while (reader.Read())
        {
            li_BookInfo_Sections.Add(GetLi_BookInfo_SectionFromReader(reader));
        }
        return li_BookInfo_Sections;
    }

    public Li_BookInfo_Section GetLi_BookInfo_SectionFromReader(IDataReader reader)
    {
        try
        {
            Li_BookInfo_Section li_BookInfo_Section = new Li_BookInfo_Section
                (
                   
                    (int)reader["SerialNo"],
                    reader["BookID"].ToString(),
                    (int)reader["SectionID"],
                    (bool)reader["IsSelect"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"] 
                );
             return li_BookInfo_Section;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_BookInfo_Section GetLi_BookInfo_SectionByID(int li_BookInfo_SectionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BookInfo_SectionByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_BookInfo_SectionID", SqlDbType.Int).Value = li_BookInfo_SectionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BookInfo_SectionFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_BookInfo_Section(Li_BookInfo_Section li_BookInfo_Section)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BookInfo_Section", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = li_BookInfo_Section.BookID;
            cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = li_BookInfo_Section.SectionID;
            cmd.Parameters.Add("@IsSelect", SqlDbType.Bit).Value = li_BookInfo_Section.IsSelect;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookInfo_Section.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookInfo_Section.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value =  DBNull .Value ;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = DBNull.Value;
         
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;//(int)cmd.Parameters["@Li_BookInfo_SectionID"].Value;
        }
    }

    public bool UpdateLi_BookInfo_Section(Li_BookInfo_Section li_BookInfo_Section)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BookInfo_Section", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
      
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = li_BookInfo_Section.BookID;
            cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = li_BookInfo_Section.SectionID;
            cmd.Parameters.Add("@IsSelect", SqlDbType.Bit).Value = li_BookInfo_Section.IsSelect;
       
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_BookInfo_Section.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_BookInfo_Section.ModifiedDate;
    
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
