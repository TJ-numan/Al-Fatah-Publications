using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_GoalDetailProvider:DataAccessObject
{
	public SqlLi_GoalDetailProvider()
    {
    }


    public bool DeleteLi_GoalDetail(int li_GoalDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_GoalDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@GoalDetId", SqlDbType.Int).Value = li_GoalDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_GoalDetail> GetAllLi_GoalDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_GoalDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_GoalDetailsFromReader(reader);
        }
    }
    public List<Li_GoalDetail> GetLi_GoalDetailsFromReader(IDataReader reader)
    {
        List<Li_GoalDetail> li_GoalDetails = new List<Li_GoalDetail>();

        while (reader.Read())
        {
            li_GoalDetails.Add(GetLi_GoalDetailFromReader(reader));
        }
        return li_GoalDetails;
    }

    public Li_GoalDetail GetLi_GoalDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_GoalDetail li_GoalDetail = new Li_GoalDetail
                (
                
                    reader["GoalDetId"].ToString(),
                    (int)reader["GoalId"],
                    (int)reader["EmpSl"],
                    reader["WorkDetail"].ToString(),
                    (bool)reader["IsTeamLead"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_GoalDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_GoalDetail GetLi_GoalDetailByID(int li_GoalDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_GoalDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@GoalDetId", SqlDbType.Int).Value = li_GoalDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_GoalDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_GoalDetail(Li_GoalDetail li_GoalDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_GoalDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@GoalDetId", SqlDbType.NChar). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@GoalId", SqlDbType.Int).Value = li_GoalDetail.GoalId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_GoalDetail.EmpSl;
            cmd.Parameters.Add("@WorkDetail", SqlDbType.VarChar).Value = li_GoalDetail.WorkDetail;
            cmd.Parameters.Add("@IsTeamLead", SqlDbType.Bit).Value = li_GoalDetail.IsTeamLead;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_GoalDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_GoalDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_GoalDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_GoalDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_GoalDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@GoalDetId"].Value;
        }
    }

    public bool UpdateLi_GoalDetail(Li_GoalDetail li_GoalDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_GoalDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@GoalDetId", SqlDbType.NChar).Value = li_GoalDetail.GoalDetId;
            cmd.Parameters.Add("@GoalId", SqlDbType.Int).Value = li_GoalDetail.GoalId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_GoalDetail.EmpSl;
            cmd.Parameters.Add("@WorkDetail", SqlDbType.VarChar).Value = li_GoalDetail.WorkDetail;
            cmd.Parameters.Add("@IsTeamLead", SqlDbType.Bit).Value = li_GoalDetail.IsTeamLead;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_GoalDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_GoalDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_GoalDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_GoalDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_GoalDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
