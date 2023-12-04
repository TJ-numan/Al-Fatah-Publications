using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_RND_PlanProvider:DataAccessObject
{
	public SqlLi_RND_PlanProvider()
    {
    }


    public bool DeleteLi_RND_Plan(int li_RND_PlanID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_RND_Plan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_RND_PlanID", SqlDbType.Int).Value = li_RND_PlanID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_RND_Plan> GetAllLi_RND_Plans()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_RND_Plans", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_RND_PlansFromReader(reader);
        }
    }
    public List<Li_RND_Plan> GetLi_RND_PlansFromReader(IDataReader reader)
    {
        List<Li_RND_Plan> li_RND_Plans = new List<Li_RND_Plan>();

        while (reader.Read())
        {
            li_RND_Plans.Add(GetLi_RND_PlanFromReader(reader));
        }
        return li_RND_Plans;
    }

    public Li_RND_Plan GetLi_RND_PlanFromReader(IDataReader reader)
    {
        try
        {
            Li_RND_Plan li_RND_Plan = new Li_RND_Plan
                (
                    
                    (int)reader["PlanID"],
                    reader["BookCode"].ToString(),
                    reader["Edition"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["FirstAppBy"],
                    (DateTime)reader["FirstAppDate"],
                    (int)reader["SecoundAppBy"],
                    (DateTime)reader["SecoundAppDate"],
                    (int)reader["ThirdAppBy"],
                    (DateTime)reader["ThirdAppDate"],
                    (int)reader["FourthAppBy"],
                    (DateTime)reader["FourthAppDate"],
                    reader["Note"].ToString(),
                    (char)reader["Status_D"] 
                );
             return li_RND_Plan;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_RND_Plan GetLi_RND_PlanByID(int li_RND_PlanID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_RND_PlanByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_RND_PlanID", SqlDbType.Int).Value = li_RND_PlanID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_RND_PlanFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_RND_Plan(Li_RND_Plan li_RND_Plan)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_RND_Plan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@PlanID", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_RND_Plan.BookCode;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_RND_Plan.Edition;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_RND_Plan.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_RND_Plan.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = DBNull .Value ;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = DBNull.Value;
            cmd.Parameters.Add("@FirstAppBy", SqlDbType.Int).Value = DBNull.Value;
            cmd.Parameters.Add("@FirstAppDate", SqlDbType.DateTime).Value = DBNull.Value;
            cmd.Parameters.Add("@SecoundAppBy", SqlDbType.Int).Value = DBNull.Value;
            cmd.Parameters.Add("@SecoundAppDate", SqlDbType.DateTime).Value = DBNull.Value;
            cmd.Parameters.Add("@ThirdAppBy", SqlDbType.Int).Value = DBNull.Value;
            cmd.Parameters.Add("@ThirdAppDate", SqlDbType.DateTime).Value = DBNull.Value;
            cmd.Parameters.Add("@FourthAppBy", SqlDbType.Int).Value = DBNull.Value;
            cmd.Parameters.Add("@FourthAppDate", SqlDbType.DateTime).Value = DBNull.Value;
            cmd.Parameters.Add("@Note", SqlDbType.VarChar).Value = li_RND_Plan.Note;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_RND_Plan.Status_D;
           
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PlanID"].Value;
        }
    }

    public bool UpdateLi_RND_Plan(Li_RND_Plan li_RND_Plan)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_RND_Plan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@PlanID", SqlDbType.Int).Value = li_RND_Plan.PlanID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_RND_Plan.BookCode;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_RND_Plan.Edition;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_RND_Plan.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_RND_Plan.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_RND_Plan.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_RND_Plan.ModifiedDate;
            cmd.Parameters.Add("@FirstAppBy", SqlDbType.Int).Value = li_RND_Plan.FirstAppBy;
            cmd.Parameters.Add("@FirstAppDate", SqlDbType.DateTime).Value = li_RND_Plan.FirstAppDate;
            cmd.Parameters.Add("@SecoundAppBy", SqlDbType.Int).Value = li_RND_Plan.SecoundAppBy;
            cmd.Parameters.Add("@SecoundAppDate", SqlDbType.DateTime).Value = li_RND_Plan.SecoundAppDate;
            cmd.Parameters.Add("@ThirdAppBy", SqlDbType.Int).Value = li_RND_Plan.ThirdAppBy;
            cmd.Parameters.Add("@ThirdAppDate", SqlDbType.DateTime).Value = li_RND_Plan.ThirdAppDate;
            cmd.Parameters.Add("@FourthAppBy", SqlDbType.Int).Value = li_RND_Plan.FourthAppBy;
            cmd.Parameters.Add("@FourthAppDate", SqlDbType.DateTime).Value = li_RND_Plan.FourthAppDate;
            cmd.Parameters.Add("@Note", SqlDbType.VarChar).Value = li_RND_Plan.Note;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_RND_Plan.Status_D;
     
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataSet GetPlanApproveStatus(string  BookCode ,string Edition)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetRNDPlanApproval", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;
            command.Parameters.Add("@Edition", SqlDbType.VarChar).Value =Edition  ;  
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }

    }

    public DataSet GetPlanSections(string BookCode, string Edition, int IsStart)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetPalnSection", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;
            command.Parameters.Add("@Edition", SqlDbType.VarChar).Value =  Edition ;
            command.Parameters.Add("@IsStart", SqlDbType.Int).Value = IsStart ;          
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }

    }

    public DataSet GetPlanTask(string BookCode, string Edition)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetPalnTask", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;   
            command.Parameters.Add("@Edition", SqlDbType.VarChar).Value =  Edition ;           
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }

    }

    public DataSet UpdateRNDPlanApprove(int AppSerial, int AppBy, string BookCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_UpdateApproveRNDPlan", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AppSerial", SqlDbType.Int).Value = BookCode; 
            command.Parameters.Add("@AppBy", SqlDbType.VarChar).Value = BookCode; 
            command.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = BookCode;           
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }

    }

  
   
}
