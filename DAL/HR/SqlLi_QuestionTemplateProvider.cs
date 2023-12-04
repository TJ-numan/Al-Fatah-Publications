using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_QuestionTemplateProvider:DataAccessObject
{
	public SqlLi_QuestionTemplateProvider()
    {
    }


    public bool DeleteLi_QuestionTemplate(int li_QuestionTemplateID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_QuestionTemplate", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@QuesTemId", SqlDbType.Int).Value = li_QuestionTemplateID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_QuestionTemplate> GetAllLi_QuestionTemplates()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_QuestionTemplates", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_QuestionTemplatesFromReader(reader);
        }
    }
    public List<Li_QuestionTemplate> GetLi_QuestionTemplatesFromReader(IDataReader reader)
    {
        List<Li_QuestionTemplate> li_QuestionTemplates = new List<Li_QuestionTemplate>();

        while (reader.Read())
        {
            li_QuestionTemplates.Add(GetLi_QuestionTemplateFromReader(reader));
        }
        return li_QuestionTemplates;
    }

    public Li_QuestionTemplate GetLi_QuestionTemplateFromReader(IDataReader reader)
    {
        try
        {
            Li_QuestionTemplate li_QuestionTemplate = new Li_QuestionTemplate
                (
                    
                    (int)reader["QuesTemId"],
                    reader["QuesTemTitle"].ToString(),
                    (int)reader["DefPosId"],
                    (int)reader["InTypeId"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_QuestionTemplate;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_QuestionTemplate GetLi_QuestionTemplateByID(int li_QuestionTemplateID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_QuestionTemplateByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@QuesTemId", SqlDbType.Int).Value = li_QuestionTemplateID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_QuestionTemplateFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_QuestionTemplate(Li_QuestionTemplate li_QuestionTemplate)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_QuestionTemplate", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@QuesTemId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@QuesTemTitle", SqlDbType.VarChar).Value = li_QuestionTemplate.QuesTemTitle;
            cmd.Parameters.Add("@DefPosId", SqlDbType.Int).Value = li_QuestionTemplate.DefPosId;
            cmd.Parameters.Add("@InTypeId", SqlDbType.Int).Value = li_QuestionTemplate.InTypeId;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_QuestionTemplate.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_QuestionTemplate.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_QuestionTemplate.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_QuestionTemplate.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_QuestionTemplate.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_QuestionTemplate.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@QuesTemId"].Value;
        }
    }

    public bool UpdateLi_QuestionTemplate(Li_QuestionTemplate li_QuestionTemplate)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_QuestionTemplate", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@QuesTemId", SqlDbType.Int).Value = li_QuestionTemplate.QuesTemId;
            cmd.Parameters.Add("@QuesTemTitle", SqlDbType.VarChar).Value = li_QuestionTemplate.QuesTemTitle;
            cmd.Parameters.Add("@DefPosId", SqlDbType.Int).Value = li_QuestionTemplate.DefPosId;
            cmd.Parameters.Add("@InTypeId", SqlDbType.Int).Value = li_QuestionTemplate.InTypeId;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_QuestionTemplate.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_QuestionTemplate.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_QuestionTemplate.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_QuestionTemplate.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_QuestionTemplate.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_QuestionTemplate.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
