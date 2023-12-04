using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_TrainApplicationProvider:DataAccessObject
{
	public SqlLi_TrainApplicationProvider()
    {
    }


    public bool DeleteLi_TrainApplication(int li_TrainApplicationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_TrainApplication", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TrainAppId", SqlDbType.Int).Value = li_TrainApplicationID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_TrainApplication> GetAllLi_TrainApplications()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_TrainApplications", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_TrainApplicationsFromReader(reader);
        }
    }
    public List<Li_TrainApplication> GetLi_TrainApplicationsFromReader(IDataReader reader)
    {
        List<Li_TrainApplication> li_TrainApplications = new List<Li_TrainApplication>();

        while (reader.Read())
        {
            li_TrainApplications.Add(GetLi_TrainApplicationFromReader(reader));
        }
        return li_TrainApplications;
    }

    public Li_TrainApplication GetLi_TrainApplicationFromReader(IDataReader reader)
    {
        try
        {
            Li_TrainApplication li_TrainApplication = new Li_TrainApplication
                (
                     
                    (int)reader["TrainAppId"],
                    (int)reader["EmpSl"],
                    (int)reader["CourseId"],
                    (int)reader["InsId"],
                    (int)reader["ResoPId"],
                    reader["CouSession"].ToString(),
                    reader["CouHour"].ToString(),
                    (decimal)reader["CouCost"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_TrainApplication;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_TrainApplication GetLi_TrainApplicationByID(int li_TrainApplicationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_TrainApplicationByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TrainAppId", SqlDbType.Int).Value = li_TrainApplicationID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_TrainApplicationFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_TrainApplication(Li_TrainApplication li_TrainApplication)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_TrainApplication", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@TrainAppId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_TrainApplication.EmpSl;
            cmd.Parameters.Add("@CourseId", SqlDbType.Int).Value = li_TrainApplication.CourseId;
            cmd.Parameters.Add("@InsId", SqlDbType.Int).Value = li_TrainApplication.InsId;
            cmd.Parameters.Add("@ResoPId", SqlDbType.Int).Value = li_TrainApplication.ResoPId;
            cmd.Parameters.Add("@CouSession", SqlDbType.VarChar).Value = li_TrainApplication.CouSession;
            cmd.Parameters.Add("@CouHour", SqlDbType.VarChar).Value = li_TrainApplication.CouHour;
            cmd.Parameters.Add("@CouCost", SqlDbType.Decimal).Value = li_TrainApplication.CouCost;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_TrainApplication.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_TrainApplication.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TrainApplication.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_TrainApplication.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_TrainApplication.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_TrainApplication.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@TrainAppId"].Value;
        }
    }

    public bool UpdateLi_TrainApplication(Li_TrainApplication li_TrainApplication)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_TrainApplication", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@TrainAppId", SqlDbType.Int).Value = li_TrainApplication.TrainAppId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_TrainApplication.EmpSl;
            cmd.Parameters.Add("@CourseId", SqlDbType.Int).Value = li_TrainApplication.CourseId;
            cmd.Parameters.Add("@InsId", SqlDbType.Int).Value = li_TrainApplication.InsId;
            cmd.Parameters.Add("@ResoPId", SqlDbType.Int).Value = li_TrainApplication.ResoPId;
            cmd.Parameters.Add("@CouSession", SqlDbType.VarChar).Value = li_TrainApplication.CouSession;
            cmd.Parameters.Add("@CouHour", SqlDbType.VarChar).Value = li_TrainApplication.CouHour;
            cmd.Parameters.Add("@CouCost", SqlDbType.Decimal).Value = li_TrainApplication.CouCost;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_TrainApplication.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_TrainApplication.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TrainApplication.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_TrainApplication.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_TrainApplication.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_TrainApplication.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
