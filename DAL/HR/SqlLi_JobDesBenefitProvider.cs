using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_JobDesBenefitProvider:DataAccessObject
{
	public SqlLi_JobDesBenefitProvider()
    {
    }


    public bool DeleteLi_JobDesBenefit(int li_JobDesBenefitID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_JobDesBenefit", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobBenId", SqlDbType.Int).Value = li_JobDesBenefitID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_JobDesBenefit> GetAllLi_JobDesBenefits()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_JobDesBenefits", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_JobDesBenefitsFromReader(reader);
        }
    }
    public List<Li_JobDesBenefit> GetLi_JobDesBenefitsFromReader(IDataReader reader)
    {
        List<Li_JobDesBenefit> li_JobDesBenefits = new List<Li_JobDesBenefit>();

        while (reader.Read())
        {
            li_JobDesBenefits.Add(GetLi_JobDesBenefitFromReader(reader));
        }
        return li_JobDesBenefits;
    }

    public Li_JobDesBenefit GetLi_JobDesBenefitFromReader(IDataReader reader)
    {
        try
        {
            Li_JobDesBenefit li_JobDesBenefit = new Li_JobDesBenefit
                (
                    
                    (int)reader["JobBenId"],
                    reader["JobBenefit"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_JobDesBenefit;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_JobDesBenefit GetLi_JobDesBenefitByID(int li_JobDesBenefitID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_JobDesBenefitByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@JobBenId", SqlDbType.Int).Value = li_JobDesBenefitID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_JobDesBenefitFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_JobDesBenefit(Li_JobDesBenefit li_JobDesBenefit)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_JobDesBenefit", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@JobBenId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@JobBenefit", SqlDbType.VarChar).Value = li_JobDesBenefit.JobBenefit;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_JobDesBenefit.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_JobDesBenefit.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobDesBenefit.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobDesBenefit.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobDesBenefit.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@JobBenId"].Value;
        }
    }

    public bool UpdateLi_JobDesBenefit(Li_JobDesBenefit li_JobDesBenefit)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_JobDesBenefit", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@JobBenId", SqlDbType.Int).Value = li_JobDesBenefit.JobBenId;
            cmd.Parameters.Add("@JobBenefit", SqlDbType.VarChar).Value = li_JobDesBenefit.JobBenefit;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_JobDesBenefit.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_JobDesBenefit.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobDesBenefit.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobDesBenefit.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobDesBenefit.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
