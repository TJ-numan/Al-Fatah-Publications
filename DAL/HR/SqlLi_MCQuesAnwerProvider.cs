using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_MCQuesAnwerProvider:DataAccessObject
{
	public SqlLi_MCQuesAnwerProvider()
    {
    }


    public bool DeleteLi_MCQuesAnwer(int li_MCQuesAnwerID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_MCQuesAnwer", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@McqAnsId", SqlDbType.Int).Value = li_MCQuesAnwerID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_MCQuesAnwer> GetAllLi_MCQuesAnwers()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_MCQuesAnwers", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_MCQuesAnwersFromReader(reader);
        }
    }
    public List<Li_MCQuesAnwer> GetLi_MCQuesAnwersFromReader(IDataReader reader)
    {
        List<Li_MCQuesAnwer> li_MCQuesAnwers = new List<Li_MCQuesAnwer>();

        while (reader.Read())
        {
            li_MCQuesAnwers.Add(GetLi_MCQuesAnwerFromReader(reader));
        }
        return li_MCQuesAnwers;
    }

    public Li_MCQuesAnwer GetLi_MCQuesAnwerFromReader(IDataReader reader)
    {
        try
        {
            Li_MCQuesAnwer li_MCQuesAnwer = new Li_MCQuesAnwer
                (
                  
                    (int)reader["McqAnsId"],
                    (int)reader["MCQuesId"],
                    (int)reader["QuesSl"],
                    reader["McqAns"].ToString(),
                    (bool)reader["IsCorrect"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_MCQuesAnwer;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_MCQuesAnwer GetLi_MCQuesAnwerByID(int li_MCQuesAnwerID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_MCQuesAnwerByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@McqAnsId", SqlDbType.Int).Value = li_MCQuesAnwerID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_MCQuesAnwerFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_MCQuesAnwer(Li_MCQuesAnwer li_MCQuesAnwer)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_MCQuesAnwer", connection);
            cmd.CommandType = CommandType.StoredProcedure;
  
            cmd.Parameters.Add("@McqAnsId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MCQuesId", SqlDbType.Int).Value = li_MCQuesAnwer.MCQuesId;
            cmd.Parameters.Add("@QuesSl", SqlDbType.Int).Value = li_MCQuesAnwer.QuesSl;
            cmd.Parameters.Add("@McqAns", SqlDbType.VarChar).Value = li_MCQuesAnwer.McqAns;
            cmd.Parameters.Add("@IsCorrect", SqlDbType.Bit).Value = li_MCQuesAnwer.IsCorrect;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_MCQuesAnwer.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_MCQuesAnwer.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_MCQuesAnwer.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_MCQuesAnwer.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_MCQuesAnwer.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@McqAnsId"].Value;
        }
    }

    public bool UpdateLi_MCQuesAnwer(Li_MCQuesAnwer li_MCQuesAnwer)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_MCQuesAnwer", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@McqAnsId", SqlDbType.Int).Value = li_MCQuesAnwer.McqAnsId;
            cmd.Parameters.Add("@MCQuesId", SqlDbType.Int).Value = li_MCQuesAnwer.MCQuesId;
            cmd.Parameters.Add("@QuesSl", SqlDbType.Int).Value = li_MCQuesAnwer.QuesSl;
            cmd.Parameters.Add("@McqAns", SqlDbType.VarChar).Value = li_MCQuesAnwer.McqAns;
            cmd.Parameters.Add("@IsCorrect", SqlDbType.Bit).Value = li_MCQuesAnwer.IsCorrect;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_MCQuesAnwer.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_MCQuesAnwer.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_MCQuesAnwer.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_MCQuesAnwer.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_MCQuesAnwer.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
