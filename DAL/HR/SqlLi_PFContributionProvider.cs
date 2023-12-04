using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_PFContributionProvider:DataAccessObject
{
	public SqlLi_PFContributionProvider()
    {
    }


    public bool DeleteLi_PFContribution(int li_PFContributionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_PFContribution", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProjectId", SqlDbType.Int).Value = li_PFContributionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PFContribution> GetAllLi_PFContributions()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_PFContributions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PFContributionsFromReader(reader);
        }
    }
    public List<Li_PFContribution> GetLi_PFContributionsFromReader(IDataReader reader)
    {
        List<Li_PFContribution> li_PFContributions = new List<Li_PFContribution>();

        while (reader.Read())
        {
            li_PFContributions.Add(GetLi_PFContributionFromReader(reader));
        }
        return li_PFContributions;
    }

    public Li_PFContribution GetLi_PFContributionFromReader(IDataReader reader)
    {
        try
        {
            Li_PFContribution li_PFContribution = new Li_PFContribution
                (
                
                    (int)reader["ProjectId"],
                    reader["ProjectTitle"].ToString(),
                    (DateTime)reader["ProjectStDate"],
                    (DateTime)reader["ProjectEnDate"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_PFContribution;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PFContribution GetLi_PFContributionByID(int li_PFContributionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_PFContributionByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ProjectId", SqlDbType.Int).Value = li_PFContributionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PFContributionFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PFContribution(Li_PFContribution li_PFContribution)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_PFContribution", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@ProjectId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ProjectTitle", SqlDbType.VarChar).Value = li_PFContribution.ProjectTitle;
            cmd.Parameters.Add("@ProjectStDate", SqlDbType.DateTime).Value = li_PFContribution.ProjectStDate;
            cmd.Parameters.Add("@ProjectEnDate", SqlDbType.DateTime).Value = li_PFContribution.ProjectEnDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PFContribution.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PFContribution.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PFContribution.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PFContribution.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PFContribution.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ProjectId"].Value;
        }
    }

    public bool UpdateLi_PFContribution(Li_PFContribution li_PFContribution)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_PFContribution", connection);
            cmd.CommandType = CommandType.StoredProcedure;
   
            cmd.Parameters.Add("@ProjectId", SqlDbType.Int).Value = li_PFContribution.ProjectId;
            cmd.Parameters.Add("@ProjectTitle", SqlDbType.VarChar).Value = li_PFContribution.ProjectTitle;
            cmd.Parameters.Add("@ProjectStDate", SqlDbType.DateTime).Value = li_PFContribution.ProjectStDate;
            cmd.Parameters.Add("@ProjectEnDate", SqlDbType.DateTime).Value = li_PFContribution.ProjectEnDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PFContribution.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PFContribution.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PFContribution.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PFContribution.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PFContribution.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
