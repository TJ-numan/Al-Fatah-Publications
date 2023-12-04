using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_TrainingApprovalProvider:DataAccessObject
{
	public SqlLi_TrainingApprovalProvider()
    {
    }


    public bool DeleteLi_TrainingApproval(int li_TrainingApprovalID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_TrainingApproval", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TrainAproveId", SqlDbType.Int).Value = li_TrainingApprovalID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_TrainingApproval> GetAllLi_TrainingApprovals()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_TrainingApprovals", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_TrainingApprovalsFromReader(reader);
        }
    }
    public List<Li_TrainingApproval> GetLi_TrainingApprovalsFromReader(IDataReader reader)
    {
        List<Li_TrainingApproval> li_TrainingApprovals = new List<Li_TrainingApproval>();

        while (reader.Read())
        {
            li_TrainingApprovals.Add(GetLi_TrainingApprovalFromReader(reader));
        }
        return li_TrainingApprovals;
    }

    public Li_TrainingApproval GetLi_TrainingApprovalFromReader(IDataReader reader)
    {
        try
        {
            Li_TrainingApproval li_TrainingApproval = new Li_TrainingApproval
                (
                 
                    (int)reader["TrainAproveId"],
                    (int)reader["TrainAppId"],
                    (int)reader["EmpSl"],
                    (bool)reader["IsApproved"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_TrainingApproval;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_TrainingApproval GetLi_TrainingApprovalByID(int li_TrainingApprovalID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_TrainingApprovalByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TrainAproveId", SqlDbType.Int).Value = li_TrainingApprovalID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_TrainingApprovalFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_TrainingApproval(Li_TrainingApproval li_TrainingApproval)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_TrainingApproval", connection);
            cmd.CommandType = CommandType.StoredProcedure;
  
            cmd.Parameters.Add("@TrainAproveId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TrainAppId", SqlDbType.Int).Value = li_TrainingApproval.TrainAppId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_TrainingApproval.EmpSl;
            cmd.Parameters.Add("@IsApproved", SqlDbType.Bit).Value = li_TrainingApproval.IsApproved;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_TrainingApproval.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_TrainingApproval.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TrainingApproval.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_TrainingApproval.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_TrainingApproval.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_TrainingApproval.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@TrainAproveId"].Value;
        }
    }

    public bool UpdateLi_TrainingApproval(Li_TrainingApproval li_TrainingApproval)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_TrainingApproval", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@TrainAproveId", SqlDbType.Int).Value = li_TrainingApproval.TrainAproveId;
            cmd.Parameters.Add("@TrainAppId", SqlDbType.Int).Value = li_TrainingApproval.TrainAppId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_TrainingApproval.EmpSl;
            cmd.Parameters.Add("@IsApproved", SqlDbType.Bit).Value = li_TrainingApproval.IsApproved;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_TrainingApproval.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_TrainingApproval.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TrainingApproval.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_TrainingApproval.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_TrainingApproval.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_TrainingApproval.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
