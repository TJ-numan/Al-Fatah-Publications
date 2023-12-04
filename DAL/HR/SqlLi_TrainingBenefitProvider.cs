using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_TrainingBenefitProvider:DataAccessObject
{
	public SqlLi_TrainingBenefitProvider()
    {
    }


    public bool DeleteLi_TrainingBenefit(int li_TrainingBenefitID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_TrainingBenefit", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TrainBeId", SqlDbType.Int).Value = li_TrainingBenefitID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_TrainingBenefit> GetAllLi_TrainingBenefits()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_TrainingBenefits", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_TrainingBenefitsFromReader(reader);
        }
    }
    public List<Li_TrainingBenefit> GetLi_TrainingBenefitsFromReader(IDataReader reader)
    {
        List<Li_TrainingBenefit> li_TrainingBenefits = new List<Li_TrainingBenefit>();

        while (reader.Read())
        {
            li_TrainingBenefits.Add(GetLi_TrainingBenefitFromReader(reader));
        }
        return li_TrainingBenefits;
    }

    public Li_TrainingBenefit GetLi_TrainingBenefitFromReader(IDataReader reader)
    {
        try
        {
            Li_TrainingBenefit li_TrainingBenefit = new Li_TrainingBenefit
                (
                  
                    (int)reader["TrainBeId"],
                    (int)reader["TrainAppId"],
                    reader["TrainBenefit"].ToString(),
                    (bool)reader["IsPersonal"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_TrainingBenefit;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_TrainingBenefit GetLi_TrainingBenefitByID(int li_TrainingBenefitID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_TrainingBenefitByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TrainBeId", SqlDbType.Int).Value = li_TrainingBenefitID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_TrainingBenefitFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_TrainingBenefit(Li_TrainingBenefit li_TrainingBenefit)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_TrainingBenefit", connection);
            cmd.CommandType = CommandType.StoredProcedure;
   
            cmd.Parameters.Add("@TrainBeId", SqlDbType.Int).Value = li_TrainingBenefit.TrainBeId;
            cmd.Parameters.Add("@TrainAppId", SqlDbType.Int).Value = li_TrainingBenefit.TrainAppId;
            cmd.Parameters.Add("@TrainBenefit", SqlDbType.VarChar).Value = li_TrainingBenefit.TrainBenefit;
            cmd.Parameters.Add("@IsPersonal", SqlDbType.Bit).Value = li_TrainingBenefit.IsPersonal;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_TrainingBenefit.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TrainingBenefit.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_TrainingBenefit.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_TrainingBenefit.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_TrainingBenefit.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@TrainBeId"].Value;
        }
    }

    public bool UpdateLi_TrainingBenefit(Li_TrainingBenefit li_TrainingBenefit)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_TrainingBenefit", connection);
            cmd.CommandType = CommandType.StoredProcedure;
    
            cmd.Parameters.Add("@TrainBeId", SqlDbType.Int).Value = li_TrainingBenefit.TrainBeId;
            cmd.Parameters.Add("@TrainAppId", SqlDbType.Int).Value = li_TrainingBenefit.TrainAppId;
            cmd.Parameters.Add("@TrainBenefit", SqlDbType.VarChar).Value = li_TrainingBenefit.TrainBenefit;
            cmd.Parameters.Add("@IsPersonal", SqlDbType.Bit).Value = li_TrainingBenefit.IsPersonal;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_TrainingBenefit.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TrainingBenefit.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_TrainingBenefit.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_TrainingBenefit.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_TrainingBenefit.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
