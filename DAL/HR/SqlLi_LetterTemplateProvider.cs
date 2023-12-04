using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_LetterTemplateProvider:DataAccessObject
{
	public SqlLi_LetterTemplateProvider()
    {
    }


    public bool DeleteLi_LetterTemplate(int li_LetterTemplateID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_LetterTemplate", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TempId", SqlDbType.Int).Value = li_LetterTemplateID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_LetterTemplate> GetAllLi_LetterTemplates()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_LetterTemplates", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_LetterTemplatesFromReader(reader);
        }
    }
    public List<Li_LetterTemplate> GetLi_LetterTemplatesFromReader(IDataReader reader)
    {
        List<Li_LetterTemplate> li_LetterTemplates = new List<Li_LetterTemplate>();

        while (reader.Read())
        {
            li_LetterTemplates.Add(GetLi_LetterTemplateFromReader(reader));
        }
        return li_LetterTemplates;
    }

    public Li_LetterTemplate GetLi_LetterTemplateFromReader(IDataReader reader)
    {
        try
        {
            Li_LetterTemplate li_LetterTemplate = new Li_LetterTemplate
                (
                
                    (int)reader["TempId"],
                    reader["TempName"].ToString(),
                    reader["TempPath"].ToString(),
                    reader["TempDes"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_LetterTemplate;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_LetterTemplate GetLi_LetterTemplateByID(int li_LetterTemplateID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_LetterTemplateByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TempId", SqlDbType.Int).Value = li_LetterTemplateID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_LetterTemplateFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_LetterTemplate(Li_LetterTemplate li_LetterTemplate)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_LetterTemplate", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@TempId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TempName", SqlDbType.VarChar).Value = li_LetterTemplate.TempName;
            cmd.Parameters.Add("@TempPath", SqlDbType.VarChar).Value = li_LetterTemplate.TempPath;
            cmd.Parameters.Add("@TempDes", SqlDbType.VarChar).Value = li_LetterTemplate.TempDes;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LetterTemplate.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LetterTemplate.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_LetterTemplate.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_LetterTemplate.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_LetterTemplate.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@TempId"].Value;
        }
    }

    public bool UpdateLi_LetterTemplate(Li_LetterTemplate li_LetterTemplate)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_LetterTemplate", connection);
            cmd.CommandType = CommandType.StoredProcedure;
  
            cmd.Parameters.Add("@TempId", SqlDbType.Int).Value = li_LetterTemplate.TempId;
            cmd.Parameters.Add("@TempName", SqlDbType.VarChar).Value = li_LetterTemplate.TempName;
            cmd.Parameters.Add("@TempPath", SqlDbType.VarChar).Value = li_LetterTemplate.TempPath;
            cmd.Parameters.Add("@TempDes", SqlDbType.VarChar).Value = li_LetterTemplate.TempDes;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_LetterTemplate.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_LetterTemplate.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_LetterTemplate.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
