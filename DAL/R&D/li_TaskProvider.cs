using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using DAL;


public class li_TaskProvider : DataAccessObject
    {

       public li_TaskProvider()
        {


        }


       public string Insert_TaskInformation(Li_AddTask Li_AddTask)
       {
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               SqlCommand cmd = new SqlCommand("SMPM_li_Insert_TaskInformation", connection);
               cmd.CommandType = CommandType.StoredProcedure;

              // cmd.Parameters.Add("@TaskID", SqlDbType.Int).Value = Li_AddTask.TaskID;
               cmd.Parameters.Add("@TaskName", SqlDbType.VarChar).Value = Li_AddTask.TaskName;
               cmd.Parameters.Add("@IsHourly", SqlDbType.Int).Value = Li_AddTask.IsHourly;

               connection.Open();

               cmd.ExecuteNonQuery();

               return null;
           }
       }

       public DataSet GetALLTaskInformation()
       {

           DataSet ds = new DataSet();
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {

               SqlCommand command = new SqlCommand("SMPM_li_ALLTaskInformation", connection);
               command.CommandType = CommandType.StoredProcedure;
               connection.Open();
               SqlDataAdapter myadapter = new SqlDataAdapter(command);
               myadapter.Fill(ds);
               myadapter.Dispose();
               connection.Close();

               return ds;
           }
       }

       public bool DeleteTaskFromDatabase(int TaskID)
       {
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               SqlCommand cmd = new SqlCommand("SMPM_li_Delete_TaskFromLibrary", connection);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@TaskID", SqlDbType.VarChar).Value = TaskID;
              
               connection.Open();
               cmd.ExecuteNonQuery();
               return true;
           }
       }

       public DataSet GetTaskInformationByTaskID(int TaskID)
       {
           DataSet ds = new DataSet();
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               SqlCommand command = new SqlCommand("SMPM_li_GetTaskInformationByID", connection);
               command.CommandType = CommandType.StoredProcedure;
               command.Parameters.Add("@TaskID", SqlDbType.VarChar).Value = TaskID;
               connection.Open();
               SqlDataAdapter myadapter = new SqlDataAdapter(command);
               myadapter.Fill(ds);
               myadapter.Dispose();
               connection.Close();

               return ds;
           }
       }


       public bool Update_TaskInformation(Li_AddTask addtask)
       {
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               SqlCommand cmd = new SqlCommand("SMPM_li_Update_TaskInformation", connection);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@TaskID", SqlDbType.Int).Value = addtask.TaskID;
               cmd.Parameters.Add("@TaskName", SqlDbType.VarChar).Value = addtask.TaskName;
               cmd.Parameters.Add("@IsHourly", SqlDbType.Int).Value = addtask.IsHourly;
              
               connection.Open();

               int result = cmd.ExecuteNonQuery();
               return result == 1;
           }
       }









    }

