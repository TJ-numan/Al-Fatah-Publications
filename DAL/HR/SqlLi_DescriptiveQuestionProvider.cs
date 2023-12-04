using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_DescriptiveQuestionProvider:DataAccessObject
{
	public SqlLi_DescriptiveQuestionProvider()
    {
    }


    public bool DeleteLi_DescriptiveQuestion(int li_DescriptiveQuestionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_DescriptiveQuestion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DesQuesId", SqlDbType.Int).Value = li_DescriptiveQuestionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_DescriptiveQuestion> GetAllLi_DescriptiveQuestions()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_DescriptiveQuestions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_DescriptiveQuestionsFromReader(reader);
        }
    }
    public List<Li_DescriptiveQuestion> GetLi_DescriptiveQuestionsFromReader(IDataReader reader)
    {
        List<Li_DescriptiveQuestion> li_DescriptiveQuestions = new List<Li_DescriptiveQuestion>();

        while (reader.Read())
        {
            li_DescriptiveQuestions.Add(GetLi_DescriptiveQuestionFromReader(reader));
        }
        return li_DescriptiveQuestions;
    }

    public Li_DescriptiveQuestion GetLi_DescriptiveQuestionFromReader(IDataReader reader)
    {
        try
        {
            Li_DescriptiveQuestion li_DescriptiveQuestion = new Li_DescriptiveQuestion
                (
                     
                    (int)reader["DesQuesId"],
                    (int)reader["QuesTemId"],
                    reader["DesQues"].ToString(),
                    reader["DesAns"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_DescriptiveQuestion;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_DescriptiveQuestion GetLi_DescriptiveQuestionByID(int li_DescriptiveQuestionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_DescriptiveQuestionByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DesQuesId", SqlDbType.Int).Value = li_DescriptiveQuestionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_DescriptiveQuestionFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_DescriptiveQuestion(Li_DescriptiveQuestion li_DescriptiveQuestion)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_DescriptiveQuestion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@DesQuesId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@QuesTemId", SqlDbType.Int).Value = li_DescriptiveQuestion.QuesTemId;
            cmd.Parameters.Add("@DesQues", SqlDbType.VarChar).Value = li_DescriptiveQuestion.DesQues;
            cmd.Parameters.Add("@DesAns", SqlDbType.VarChar).Value = li_DescriptiveQuestion.DesAns;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DescriptiveQuestion.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DescriptiveQuestion.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_DescriptiveQuestion.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_DescriptiveQuestion.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_DescriptiveQuestion.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DesQuesId"].Value;
        }
    }

    public bool UpdateLi_DescriptiveQuestion(Li_DescriptiveQuestion li_DescriptiveQuestion)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_DescriptiveQuestion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@DesQuesId", SqlDbType.Int).Value = li_DescriptiveQuestion.DesQuesId;
            cmd.Parameters.Add("@QuesTemId", SqlDbType.Int).Value = li_DescriptiveQuestion.QuesTemId;
            cmd.Parameters.Add("@DesQues", SqlDbType.VarChar).Value = li_DescriptiveQuestion.DesQues;
            cmd.Parameters.Add("@DesAns", SqlDbType.VarChar).Value = li_DescriptiveQuestion.DesAns;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DescriptiveQuestion.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DescriptiveQuestion.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_DescriptiveQuestion.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_DescriptiveQuestion.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_DescriptiveQuestion.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
