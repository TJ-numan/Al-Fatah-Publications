using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_JobTaskProvider:DataAccessObject
{
	public SqlLi_JobTaskProvider()
    {
    }


    public bool DeleteLi_JobTask(int li_JobTaskID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_JobTask", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobTaskId", SqlDbType.Int).Value = li_JobTaskID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_JobTask> GetAllLi_JobTasks()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_JobTasks", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_JobTasksFromReader(reader);
        }
    }
    public List<Li_JobTask> GetLi_JobTasksFromReader(IDataReader reader)
    {
        List<Li_JobTask> li_JobTasks = new List<Li_JobTask>();

        while (reader.Read())
        {
            li_JobTasks.Add(GetLi_JobTaskFromReader(reader));
        }
        return li_JobTasks;
    }

    public Li_JobTask GetLi_JobTaskFromReader(IDataReader reader)
    {
        try
        {
            Li_JobTask li_JobTask = new Li_JobTask
                (
                    
                    (int)reader["JobTaskId"],
                    reader["JobTask"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_JobTask;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_JobTask GetLi_JobTaskByID(int li_JobTaskID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_JobTaskByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@JobTaskId", SqlDbType.Int).Value = li_JobTaskID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_JobTaskFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_JobTask(Li_JobTask li_JobTask)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_JobTask", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@JobTaskId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@JobTask", SqlDbType.VarChar).Value = li_JobTask.JobTask;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_JobTask.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_JobTask.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobTask.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobTask.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobTask.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@JobTaskId"].Value;
        }
    }

    public bool UpdateLi_JobTask(Li_JobTask li_JobTask)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_JobTask", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@JobTaskId", SqlDbType.Int).Value = li_JobTask.JobTaskId;
            cmd.Parameters.Add("@JobTask", SqlDbType.VarChar).Value = li_JobTask.JobTask;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_JobTask.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_JobTask.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobTask.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobTask.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobTask.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
