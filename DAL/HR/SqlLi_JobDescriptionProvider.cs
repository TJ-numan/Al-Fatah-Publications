using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_JobDescriptionProvider:DataAccessObject
{
	public SqlLi_JobDescriptionProvider()
    {
    }


    public bool DeleteLi_JobDescription(int li_JobDescriptionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_JobDescription", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JDId", SqlDbType.Int).Value = li_JobDescriptionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_JobDescription> GetAllLi_JobDescriptions()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_JobDescriptions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_JobDescriptionsFromReader(reader);
        }
    }
    public List<Li_JobDescription> GetLi_JobDescriptionsFromReader(IDataReader reader)
    {
        List<Li_JobDescription> li_JobDescriptions = new List<Li_JobDescription>();

        while (reader.Read())
        {
            li_JobDescriptions.Add(GetLi_JobDescriptionFromReader(reader));
        }
        return li_JobDescriptions;
    }

    public Li_JobDescription GetLi_JobDescriptionFromReader(IDataReader reader)
    {
        try
        {
            Li_JobDescription li_JobDescription = new Li_JobDescription
                (
                  
                    (int)reader["JDId"],
                    (int)reader["PosId"],
                    (int)reader["JobResId"],
                    (int)reader["EduReqId"],
                    (int)reader["ExpReqId"],
                    (int)reader["JobReqId"],
                    (int)reader["JobBenId"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_JobDescription;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_JobDescription GetLi_JobDescriptionByID(int li_JobDescriptionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_JobDescriptionByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@JDId", SqlDbType.Int).Value = li_JobDescriptionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_JobDescriptionFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_JobDescription(Li_JobDescription li_JobDescription)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_JobDescription", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@JDId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PosId", SqlDbType.Int).Value = li_JobDescription.PosId;
            cmd.Parameters.Add("@JobResId", SqlDbType.Int).Value = li_JobDescription.JobResId;
            cmd.Parameters.Add("@EduReqId", SqlDbType.Int).Value = li_JobDescription.EduReqId;
            cmd.Parameters.Add("@ExpReqId", SqlDbType.Int).Value = li_JobDescription.ExpReqId;
            cmd.Parameters.Add("@JobReqId", SqlDbType.Int).Value = li_JobDescription.JobReqId;
            cmd.Parameters.Add("@JobBenId", SqlDbType.Int).Value = li_JobDescription.JobBenId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_JobDescription.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_JobDescription.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobDescription.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobDescription.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobDescription.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@JDId"].Value;
        }
    }

    public bool UpdateLi_JobDescription(Li_JobDescription li_JobDescription)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_JobDescription", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@JDId", SqlDbType.Int).Value = li_JobDescription.JDId;
            cmd.Parameters.Add("@PosId", SqlDbType.Int).Value = li_JobDescription.PosId;
            cmd.Parameters.Add("@JobResId", SqlDbType.Int).Value = li_JobDescription.JobResId;
            cmd.Parameters.Add("@EduReqId", SqlDbType.Int).Value = li_JobDescription.EduReqId;
            cmd.Parameters.Add("@ExpReqId", SqlDbType.Int).Value = li_JobDescription.ExpReqId;
            cmd.Parameters.Add("@JobReqId", SqlDbType.Int).Value = li_JobDescription.JobReqId;
            cmd.Parameters.Add("@JobBenId", SqlDbType.Int).Value = li_JobDescription.JobBenId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_JobDescription.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_JobDescription.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobDescription.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobDescription.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobDescription.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
