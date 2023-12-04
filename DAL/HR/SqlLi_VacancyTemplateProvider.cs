using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_VacancyTemplateProvider:DataAccessObject
{
	public SqlLi_VacancyTemplateProvider()
    {
    }


    public bool DeleteLi_VacancyTemplate(int li_VacancyTemplateID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_VacancyTemplate", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VacTemId", SqlDbType.Int).Value = li_VacancyTemplateID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_VacancyTemplate> GetAllLi_VacancyTemplates()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_VacancyTemplates", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_VacancyTemplatesFromReader(reader);
        }
    }
    public List<Li_VacancyTemplate> GetLi_VacancyTemplatesFromReader(IDataReader reader)
    {
        List<Li_VacancyTemplate> li_VacancyTemplates = new List<Li_VacancyTemplate>();

        while (reader.Read())
        {
            li_VacancyTemplates.Add(GetLi_VacancyTemplateFromReader(reader));
        }
        return li_VacancyTemplates;
    }

    public Li_VacancyTemplate GetLi_VacancyTemplateFromReader(IDataReader reader)
    {
        try
        {
            Li_VacancyTemplate li_VacancyTemplate = new Li_VacancyTemplate
                (
                    
                    (int)reader["VacTemId"],
                    (int)reader["PosId"],
                    reader["TemPath"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_VacancyTemplate;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_VacancyTemplate GetLi_VacancyTemplateByID(int li_VacancyTemplateID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_VacancyTemplateByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@VacTemId", SqlDbType.Int).Value = li_VacancyTemplateID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_VacancyTemplateFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_VacancyTemplate(Li_VacancyTemplate li_VacancyTemplate)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_VacancyTemplate", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@VacTemId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PosId", SqlDbType.Int).Value = li_VacancyTemplate.PosId;
            cmd.Parameters.Add("@TemPath", SqlDbType.VarChar).Value = li_VacancyTemplate.TemPath;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_VacancyTemplate.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_VacancyTemplate.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_VacancyTemplate.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_VacancyTemplate.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_VacancyTemplate.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@VacTemId"].Value;
        }
    }

    public bool UpdateLi_VacancyTemplate(Li_VacancyTemplate li_VacancyTemplate)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_VacancyTemplate", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@VacTemId", SqlDbType.Int).Value = li_VacancyTemplate.VacTemId;
            cmd.Parameters.Add("@PosId", SqlDbType.Int).Value = li_VacancyTemplate.PosId;
            cmd.Parameters.Add("@TemPath", SqlDbType.VarChar).Value = li_VacancyTemplate.TemPath;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_VacancyTemplate.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_VacancyTemplate.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_VacancyTemplate.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_VacancyTemplate.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_VacancyTemplate.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
