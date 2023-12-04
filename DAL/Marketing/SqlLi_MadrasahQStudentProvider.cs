using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_MadrasahQStudentProvider:DataAccessObject
{
	public SqlLi_MadrasahQStudentProvider()
    {
    }


    public bool DeleteLi_MadrasahQStudent(int li_MadrasahQStudentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_MadrasahQStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_MadrasahQStudentID", SqlDbType.Int).Value = li_MadrasahQStudentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_MadrasahQStudent> GetAllLi_MadrasahQStudents()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_MadrasahQStudents", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_MadrasahQStudentsFromReader(reader);
        }
    }
    public List<Li_MadrasahQStudent> GetLi_MadrasahQStudentsFromReader(IDataReader reader)
    {
        List<Li_MadrasahQStudent> li_MadrasahQStudents = new List<Li_MadrasahQStudent>();

        while (reader.Read())
        {
            li_MadrasahQStudents.Add(GetLi_MadrasahQStudentFromReader(reader));
        }
        return li_MadrasahQStudents;
    }

    public Li_MadrasahQStudent GetLi_MadrasahQStudentFromReader(IDataReader reader)
    {
        try
        {
            Li_MadrasahQStudent li_MadrasahQStudent = new Li_MadrasahQStudent
                (
               
                    (int)reader["SerialNo"],
                    (int)reader["MadrasahID"],
                    (int)reader["ClassID"],
                    (int)reader["Students"] 
                );
             return li_MadrasahQStudent;
        }
        catch(Exception )
        {
            return null;
        }
    }

    public Li_MadrasahQStudent GetLi_MadrasahQStudentByID(int li_MadrasahQStudentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_MadrasahQStudentByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_MadrasahQStudentID", SqlDbType.Int).Value = li_MadrasahQStudentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_MadrasahQStudentFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_MadrasahQStudent(Li_MadrasahQStudent li_MadrasahQStudent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_MadrasahQStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@MadrasahID", SqlDbType.Int).Value = li_MadrasahQStudent.MadrasahID;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = li_MadrasahQStudent.ClassID;
            cmd.Parameters.Add("@Students", SqlDbType.Int).Value = li_MadrasahQStudent.Students;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  1;
        }
    }

    public bool UpdateLi_MadrasahQStudent(Li_MadrasahQStudent li_MadrasahQStudent)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_MadrasahQStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_MadrasahQStudent.SerialNo;
            cmd.Parameters.Add("@MadrasahID", SqlDbType.Int).Value = li_MadrasahQStudent.MadrasahID;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = li_MadrasahQStudent.ClassID;
            cmd.Parameters.Add("@Students", SqlDbType.Int).Value = li_MadrasahQStudent.Students;
  
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
