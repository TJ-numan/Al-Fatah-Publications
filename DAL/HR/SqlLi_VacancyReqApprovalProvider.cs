using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_VacancyReqApprovalProvider:DataAccessObject
{
	public SqlLi_VacancyReqApprovalProvider()
    {
    }


    public bool DeleteLi_VacancyReqApproval(int li_VacancyReqApprovalID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_VacancyReqApproval", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AppId", SqlDbType.Int).Value = li_VacancyReqApprovalID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_VacancyReqApproval> GetAllLi_VacancyReqApprovals()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_VacancyReqApprovals", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_VacancyReqApprovalsFromReader(reader);
        }
    }
    public List<Li_VacancyReqApproval> GetLi_VacancyReqApprovalsFromReader(IDataReader reader)
    {
        List<Li_VacancyReqApproval> li_VacancyReqApprovals = new List<Li_VacancyReqApproval>();

        while (reader.Read())
        {
            li_VacancyReqApprovals.Add(GetLi_VacancyReqApprovalFromReader(reader));
        }
        return li_VacancyReqApprovals;
    }

    public Li_VacancyReqApproval GetLi_VacancyReqApprovalFromReader(IDataReader reader)
    {
        try
        {
            Li_VacancyReqApproval li_VacancyReqApproval = new Li_VacancyReqApproval
                (
                     
                    (int)reader["AppId"],
                    (int)reader["VacId"],
                    (int)reader["EmpSl"],
                    (bool)reader["IsApproved"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_VacancyReqApproval;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_VacancyReqApproval GetLi_VacancyReqApprovalByID(int li_VacancyReqApprovalID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_VacancyReqApprovalByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AppId", SqlDbType.Int).Value = li_VacancyReqApprovalID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_VacancyReqApprovalFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_VacancyReqApproval(Li_VacancyReqApproval li_VacancyReqApproval)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_VacancyReqApproval", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@AppId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@VacId", SqlDbType.Int).Value = li_VacancyReqApproval.VacId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_VacancyReqApproval.EmpSl;
            cmd.Parameters.Add("@IsApproved", SqlDbType.Bit).Value = li_VacancyReqApproval.IsApproved;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_VacancyReqApproval.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_VacancyReqApproval.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_VacancyReqApproval.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_VacancyReqApproval.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_VacancyReqApproval.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AppId"].Value;
        }
    }

    public bool UpdateLi_VacancyReqApproval(Li_VacancyReqApproval li_VacancyReqApproval)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_VacancyReqApproval", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@AppId", SqlDbType.Int).Value = li_VacancyReqApproval.AppId;
            cmd.Parameters.Add("@VacId", SqlDbType.Int).Value = li_VacancyReqApproval.VacId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_VacancyReqApproval.EmpSl;
            cmd.Parameters.Add("@IsApproved", SqlDbType.Bit).Value = li_VacancyReqApproval.IsApproved;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_VacancyReqApproval.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_VacancyReqApproval.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_VacancyReqApproval.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_VacancyReqApproval.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_VacancyReqApproval.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
