using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_ExamTitleProvider:DataAccessObject
{
	public SqlLi_ExamTitleProvider()
    {
    }


    public bool DeleteLi_ExamTitle(int li_ExamTitleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_ExamTitle", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamId", SqlDbType.Int).Value = li_ExamTitleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_ExamTitle> GetAllLi_ExamTitles()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_ExamTitles", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ExamTitlesFromReader(reader);
        }
    }
    public List<Li_ExamTitle> GetLi_ExamTitlesFromReader(IDataReader reader)
    {
        List<Li_ExamTitle> li_ExamTitles = new List<Li_ExamTitle>();

        while (reader.Read())
        {
            li_ExamTitles.Add(GetLi_ExamTitleFromReader(reader));
        }
        return li_ExamTitles;
    }

    public Li_ExamTitle GetLi_ExamTitleFromReader(IDataReader reader)
    {
        try
        {
            Li_ExamTitle li_ExamTitle = new Li_ExamTitle
                (
                   
                    (int)reader["ExamId"],
                    reader["ExamName"].ToString(),
                    (int)reader["EduLId"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_ExamTitle;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_ExamTitle GetLi_ExamTitleByID(int li_ExamTitleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_ExamTitleByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamId", SqlDbType.Int).Value = li_ExamTitleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ExamTitleFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_ExamTitle(Li_ExamTitle li_ExamTitle)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_ExamTitle", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@ExamId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ExamName", SqlDbType.VarChar).Value = li_ExamTitle.ExamName;
            cmd.Parameters.Add("@EduLId", SqlDbType.Int).Value = li_ExamTitle.EduLId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ExamTitle.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ExamTitle.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ExamTitle.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ExamTitle.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_ExamTitle.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ExamId"].Value;
        }
    }

    public bool UpdateLi_ExamTitle(Li_ExamTitle li_ExamTitle)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_ExamTitle", connection);
            cmd.CommandType = CommandType.StoredProcedure;
   
            cmd.Parameters.Add("@ExamId", SqlDbType.Int).Value = li_ExamTitle.ExamId;
            cmd.Parameters.Add("@ExamName", SqlDbType.VarChar).Value = li_ExamTitle.ExamName;
            cmd.Parameters.Add("@EduLId", SqlDbType.Int).Value = li_ExamTitle.EduLId;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ExamTitle.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ExamTitle.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_ExamTitle.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
