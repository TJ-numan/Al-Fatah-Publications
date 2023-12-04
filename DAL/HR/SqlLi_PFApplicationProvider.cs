using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_PFApplicationProvider:DataAccessObject
{
	public SqlLi_PFApplicationProvider()
    {
    }


    public bool DeleteLi_PFApplication(int li_PFApplicationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_PFApplication", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PFAppId", SqlDbType.Int).Value = li_PFApplicationID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PFApplication> GetAllLi_PFApplications()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_PFApplications", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PFApplicationsFromReader(reader);
        }
    }
    public List<Li_PFApplication> GetLi_PFApplicationsFromReader(IDataReader reader)
    {
        List<Li_PFApplication> li_PFApplications = new List<Li_PFApplication>();

        while (reader.Read())
        {
            li_PFApplications.Add(GetLi_PFApplicationFromReader(reader));
        }
        return li_PFApplications;
    }

    public Li_PFApplication GetLi_PFApplicationFromReader(IDataReader reader)
    {
        try
        {
            Li_PFApplication li_PFApplication = new Li_PFApplication
                (
                     
                    (int)reader["PFAppId"],
                    reader["PFAcNo"].ToString(),
                    (int)reader["EmpSl"],
                    (DateTime)reader["EffectiveDate"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_PFApplication;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PFApplication GetLi_PFApplicationByID(int li_PFApplicationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_PFApplicationByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PFAppId", SqlDbType.Int).Value = li_PFApplicationID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PFApplicationFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PFApplication(Li_PFApplication li_PFApplication)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_PFApplication", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@PFAppId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PFAcNo", SqlDbType.VarChar).Value = li_PFApplication.PFAcNo;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_PFApplication.EmpSl;
            cmd.Parameters.Add("@EffectiveDate", SqlDbType.DateTime).Value = li_PFApplication.EffectiveDate;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_PFApplication.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PFApplication.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PFApplication.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PFApplication.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PFApplication.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PFApplication.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PFAppId"].Value;
        }
    }

    public bool UpdateLi_PFApplication(Li_PFApplication li_PFApplication)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_PFApplication", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            cmd.Parameters.Add("@PFAppId", SqlDbType.Int).Value = li_PFApplication.PFAppId;
            cmd.Parameters.Add("@PFAcNo", SqlDbType.VarChar).Value = li_PFApplication.PFAcNo;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_PFApplication.EmpSl;
            cmd.Parameters.Add("@EffectiveDate", SqlDbType.DateTime).Value = li_PFApplication.EffectiveDate;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_PFApplication.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PFApplication.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PFApplication.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PFApplication.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PFApplication.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PFApplication.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
