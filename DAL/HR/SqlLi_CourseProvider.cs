using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_CourseProvider:DataAccessObject
{
	public SqlLi_CourseProvider()
    {
    }


    public bool DeleteLi_Course(int li_CourseID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_Course", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CourseId", SqlDbType.Int).Value = li_CourseID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Course> GetAllLi_Courses()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_Courses", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_CoursesFromReader(reader);
        }
    }
    public List<Li_Course> GetLi_CoursesFromReader(IDataReader reader)
    {
        List<Li_Course> li_Courses = new List<Li_Course>();

        while (reader.Read())
        {
            li_Courses.Add(GetLi_CourseFromReader(reader));
        }
        return li_Courses;
    }

    public Li_Course GetLi_CourseFromReader(IDataReader reader)
    {
        try
        {
            Li_Course li_Course = new Li_Course
                (
                
                    (int)reader["CourseId"],
                    reader["CourseTitle"].ToString(),
                    reader["CourseDes"].ToString(),
                    reader["Comments"].ToString(),
                    (int)reader["DefaultDepId"],
                    reader["DefaultSes"].ToString(),
                    reader["DefaultDuration"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_Course;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Course GetLi_CourseByID(int li_CourseID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_CourseByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseId", SqlDbType.Int).Value = li_CourseID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_CourseFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Course(Li_Course li_Course)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_Course", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@CourseId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CourseTitle", SqlDbType.VarChar).Value = li_Course.CourseTitle;
            cmd.Parameters.Add("@CourseDes", SqlDbType.VarChar).Value = li_Course.CourseDes;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_Course.Comments;
            cmd.Parameters.Add("@DefaultDepId", SqlDbType.Int).Value = li_Course.DefaultDepId;
            cmd.Parameters.Add("@DefaultSes", SqlDbType.VarChar).Value = li_Course.DefaultSes;
            cmd.Parameters.Add("@DefaultDuration", SqlDbType.VarChar).Value = li_Course.DefaultDuration;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Course.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Course.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Course.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Course.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Course.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CourseId"].Value;
        }
    }

    public bool UpdateLi_Course(Li_Course li_Course)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_Course", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@CourseId", SqlDbType.Int).Value = li_Course.CourseId;
            cmd.Parameters.Add("@CourseTitle", SqlDbType.VarChar).Value = li_Course.CourseTitle;
            cmd.Parameters.Add("@CourseDes", SqlDbType.VarChar).Value = li_Course.CourseDes;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_Course.Comments;
            cmd.Parameters.Add("@DefaultDepId", SqlDbType.Int).Value = li_Course.DefaultDepId;
            cmd.Parameters.Add("@DefaultSes", SqlDbType.VarChar).Value = li_Course.DefaultSes;
            cmd.Parameters.Add("@DefaultDuration", SqlDbType.VarChar).Value = li_Course.DefaultDuration;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Course.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Course.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Course.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Course.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Course.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
