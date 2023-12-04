using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_LeaveApprovalProvider:DataAccessObject
{
	public SqlLi_LeaveApprovalProvider()
    {
    }


    public bool DeleteLi_LeaveApproval(int li_LeaveApprovalID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_LeaveApproval", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ApproSl", SqlDbType.Int).Value = li_LeaveApprovalID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_LeaveApproval> GetAllLi_LeaveApprovals()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_LeaveApprovals", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_LeaveApprovalsFromReader(reader);
        }
    }
    public List<Li_LeaveApproval> GetLi_LeaveApprovalsFromReader(IDataReader reader)
    {
        List<Li_LeaveApproval> li_LeaveApprovals = new List<Li_LeaveApproval>();

        while (reader.Read())
        {
            li_LeaveApprovals.Add(GetLi_LeaveApprovalFromReader(reader));
        }
        return li_LeaveApprovals;
    }

    public Li_LeaveApproval GetLi_LeaveApprovalFromReader(IDataReader reader)
    {
        try
        {
            Li_LeaveApproval li_LeaveApproval = new Li_LeaveApproval
                (
                  
                    (int)reader["ApproSl"],
                    (int)reader["LeavSl"],
                    (int)reader["EmpSl"],
                    (int)reader["ApproEmpSl"],
                    (int)reader["ResposibleEmpSl"],
                    (bool)reader["IsApproved"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_LeaveApproval;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_LeaveApproval GetLi_LeaveApprovalByID(int li_LeaveApprovalID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_LeaveApprovalByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ApproSl", SqlDbType.Int).Value = li_LeaveApprovalID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_LeaveApprovalFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_LeaveApproval(Li_LeaveApproval li_LeaveApproval)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_LeaveApproval", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@ApproSl", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@LeavSl", SqlDbType.Int).Value = li_LeaveApproval.LeavSl;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_LeaveApproval.EmpSl;
            cmd.Parameters.Add("@ApproEmpSl", SqlDbType.Int).Value = li_LeaveApproval.ApproEmpSl;
            cmd.Parameters.Add("@ResposibleEmpSl", SqlDbType.Int).Value = li_LeaveApproval.ResposibleEmpSl;
            cmd.Parameters.Add("@IsApproved", SqlDbType.Bit).Value = li_LeaveApproval.IsApproved;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_LeaveApproval.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LeaveApproval.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LeaveApproval.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_LeaveApproval.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_LeaveApproval.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_LeaveApproval.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ApproSl"].Value;
        }
    }

    public bool UpdateLi_LeaveApproval(Li_LeaveApproval li_LeaveApproval)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_LeaveApproval", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@ApproSl", SqlDbType.Int).Value = li_LeaveApproval.ApproSl;
            cmd.Parameters.Add("@LeavSl", SqlDbType.Int).Value = li_LeaveApproval.LeavSl;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_LeaveApproval.EmpSl;
            cmd.Parameters.Add("@ApproEmpSl", SqlDbType.Int).Value = li_LeaveApproval.ApproEmpSl;
            cmd.Parameters.Add("@ResposibleEmpSl", SqlDbType.Int).Value = li_LeaveApproval.ResposibleEmpSl;
            cmd.Parameters.Add("@IsApproved", SqlDbType.Bit).Value = li_LeaveApproval.IsApproved;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_LeaveApproval.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LeaveApproval.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LeaveApproval.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_LeaveApproval.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_LeaveApproval.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_LeaveApproval.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
