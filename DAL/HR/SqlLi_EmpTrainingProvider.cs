using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_EmpTrainingProvider:DataAccessObject
{
	public SqlLi_EmpTrainingProvider()
    {
    }


    public bool DeleteLi_EmpTraining(int li_EmpTrainingID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmpTraining", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TranId", SqlDbType.Int).Value = li_EmpTrainingID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmpTraining> GetAllLi_EmpTrainings()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmpTrainings", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmpTrainingsFromReader(reader);
        }
    }
    public List<Li_EmpTraining> GetLi_EmpTrainingsFromReader(IDataReader reader)
    {
        List<Li_EmpTraining> li_EmpTrainings = new List<Li_EmpTraining>();

        while (reader.Read())
        {
            li_EmpTrainings.Add(GetLi_EmpTrainingFromReader(reader));
        }
        return li_EmpTrainings;
    }

    public Li_EmpTraining GetLi_EmpTrainingFromReader(IDataReader reader)
    {
        try
        {
            Li_EmpTraining li_EmpTraining = new Li_EmpTraining
                (
                    
                    (int)reader["TranId"],
                    reader["TranTitle"].ToString(),
                    reader["TopicsCov"].ToString(),
                    reader["InstituteName"].ToString(),
                    reader["CertifPath"].ToString(),
                    reader["Location"].ToString(),
                    reader["Country"].ToString(),
                    reader["TranYr"].ToString(),
                    reader["Duration"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"],
                    (int)reader ["EmpSl"]
                );
             return li_EmpTraining;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmpTraining GetLi_EmpTrainingByID(int li_EmpTrainingID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmpTrainingByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TranId", SqlDbType.Int).Value = li_EmpTrainingID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmpTrainingFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmpTraining(Li_EmpTraining li_EmpTraining)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmpTraining", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@TranId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TranTitle", SqlDbType.VarChar).Value = li_EmpTraining.TranTitle;
            cmd.Parameters.Add("@TopicsCov", SqlDbType.VarChar).Value = li_EmpTraining.TopicsCov;
            cmd.Parameters.Add("@InstituteName", SqlDbType.VarChar).Value = li_EmpTraining.InstituteName;
            cmd.Parameters.Add("@CertifPath", SqlDbType.VarChar).Value = li_EmpTraining.CertifPath;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar).Value = li_EmpTraining.Location;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = li_EmpTraining.Country;
            cmd.Parameters.Add("@TranYr", SqlDbType.VarChar).Value = li_EmpTraining.TranYr;
            cmd.Parameters.Add("@Duration", SqlDbType.VarChar).Value = li_EmpTraining.Duration;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpTraining.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpTraining.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpTraining.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpTraining.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpTraining.InfStId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpTraining. EmpSl;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@TranId"].Value;
        }
    }

    public bool UpdateLi_EmpTraining(Li_EmpTraining li_EmpTraining)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmpTraining", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@TranId", SqlDbType.Int).Value = li_EmpTraining.TranId;
            cmd.Parameters.Add("@TranTitle", SqlDbType.VarChar).Value = li_EmpTraining.TranTitle;
            cmd.Parameters.Add("@TopicsCov", SqlDbType.VarChar).Value = li_EmpTraining.TopicsCov;
            cmd.Parameters.Add("@InstituteName", SqlDbType.VarChar).Value = li_EmpTraining.InstituteName;
            cmd.Parameters.Add("@CertifPath", SqlDbType.VarChar).Value = li_EmpTraining.CertifPath;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar).Value = li_EmpTraining.Location;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = li_EmpTraining.Country;
            cmd.Parameters.Add("@TranYr", SqlDbType.VarChar).Value = li_EmpTraining.TranYr;
            cmd.Parameters.Add("@Duration", SqlDbType.VarChar).Value = li_EmpTraining.Duration;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpTraining.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpTraining.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpTraining.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpTraining.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpTraining.InfStId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpTraining.EmpSl;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }




    public DataTable LoadGvEmployeeTraining()
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.LoadGvEmployeeTraning", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();

            return dt;
        }
    }
}
