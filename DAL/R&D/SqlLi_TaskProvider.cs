using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_TaskProvider:DataAccessObject
{
	public SqlLi_TaskProvider()
    {
    }


    public bool DeleteLi_Task(int li_TaskID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Task", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_TaskID", SqlDbType.Int).Value = li_TaskID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Task> GetAllLi_Tasks()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Tasks", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_TasksFromReader(reader);
        }
    }
    public List<Li_Task> GetLi_TasksFromReader(IDataReader reader)
    {
        List<Li_Task> li_Tasks = new List<Li_Task>();

        while (reader.Read())
        {
            li_Tasks.Add(GetLi_TaskFromReader(reader));
        }
        return li_Tasks;
    }

    public Li_Task GetLi_TaskFromReader(IDataReader reader)
    {
        try
        {
            Li_Task li_Task = new Li_Task
                (
                     
                    (int)reader["TaskID"],
                    reader["TaskName"].ToString(),
                    reader["B_Name"].ToString() 
                );
             return li_Task;
        }
        catch(Exception)
        {
            return null;
        }
    }

    public Li_Task GetLi_TaskByID(int li_TaskID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_TaskByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_TaskID", SqlDbType.Int).Value = li_TaskID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_TaskFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Task(Li_Task li_Task)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Task", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@TaskID", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TaskName", SqlDbType.VarChar).Value = li_Task.TaskName;
            cmd.Parameters.Add("@B_Name", SqlDbType.Text).Value = li_Task.B_Name;
          
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Li_TaskID"].Value;
        }
    }

    public bool UpdateLi_Task(Li_Task li_Task)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Task", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@TaskID", SqlDbType.Int).Value = li_Task.TaskID;
            cmd.Parameters.Add("@TaskName", SqlDbType.VarChar).Value = li_Task.TaskName;
            cmd.Parameters.Add("@B_Name", SqlDbType.Text).Value = li_Task.B_Name;
        
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
    //--------------------------------------------rezaul Hossain------------------2021-06-01-----------
    public List<Li_Task> GetAllLi_TasksQawmi()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_TasksQawmi", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_TasksFromReader(reader);
        }
    }
    public List<Li_Task> GetAllLi_TasksGraphics()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Web_SMPM_GetAllLi_TasksGraphics", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_TasksFromReader(reader);
        }
    }
}
