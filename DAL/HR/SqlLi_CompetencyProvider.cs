using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_CompetencyProvider:DataAccessObject
{
	public SqlLi_CompetencyProvider()
    {
    }


    public bool DeleteLi_Competency(int li_CompetencyID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_Competency", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CompeId", SqlDbType.Int).Value = li_CompetencyID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Competency> GetAllLi_Competencies()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_Competencies", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_CompetenciesFromReader(reader);
        }
    }
    public List<Li_Competency> GetLi_CompetenciesFromReader(IDataReader reader)
    {
        List<Li_Competency> li_Competencies = new List<Li_Competency>();

        while (reader.Read())
        {
            li_Competencies.Add(GetLi_CompetencyFromReader(reader));
        }
        return li_Competencies;
    }

    public Li_Competency GetLi_CompetencyFromReader(IDataReader reader)
    {
        try
        {
            Li_Competency li_Competency = new Li_Competency
                (
                   
                    (int)reader["CompeId"],
                    reader["Competency"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_Competency;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Competency GetLi_CompetencyByID(int li_CompetencyID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_CompetencyByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CompeId", SqlDbType.Int).Value = li_CompetencyID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_CompetencyFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Competency(Li_Competency li_Competency)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_Competency", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@CompeId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Competency", SqlDbType.VarChar).Value = li_Competency.Competency;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Competency.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Competency.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Competency.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Competency.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Competency.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Li_CompetencyID"].Value;
        }
    }

    public bool UpdateLi_Competency(Li_Competency li_Competency)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_Competency", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@CompeId", SqlDbType.Int).Value = li_Competency.CompeId;
            cmd.Parameters.Add("@Competency", SqlDbType.VarChar).Value = li_Competency.Competency;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Competency.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Competency.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Competency.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Competency.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Competency.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
