using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_VacancyForProvider:DataAccessObject
{
	public SqlLi_VacancyForProvider()
    {
    }


    public bool DeleteLi_VacancyFor(int li_VacancyForID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_VacancyFor", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VacForId", SqlDbType.Int).Value = li_VacancyForID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_VacancyFor> GetAllLi_VacancyFors()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_VacancyFors", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_VacancyForsFromReader(reader);
        }
    }
    public List<Li_VacancyFor> GetLi_VacancyForsFromReader(IDataReader reader)
    {
        List<Li_VacancyFor> li_VacancyFors = new List<Li_VacancyFor>();

        while (reader.Read())
        {
            li_VacancyFors.Add(GetLi_VacancyForFromReader(reader));
        }
        return li_VacancyFors;
    }

    public Li_VacancyFor GetLi_VacancyForFromReader(IDataReader reader)
    {
        try
        {
            Li_VacancyFor li_VacancyFor = new Li_VacancyFor
                (
                    
                    (int)reader["VacForId"],
                    reader["VacForName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_VacancyFor;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_VacancyFor GetLi_VacancyForByID(int li_VacancyForID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_VacancyForByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@VacForId", SqlDbType.Int).Value = li_VacancyForID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_VacancyForFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_VacancyFor(Li_VacancyFor li_VacancyFor)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_VacancyFor", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@VacForId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@VacForName", SqlDbType.VarChar).Value = li_VacancyFor.VacForName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_VacancyFor.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_VacancyFor.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_VacancyFor.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_VacancyFor.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_VacancyFor.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@VacForId"].Value;
        }
    }

    public bool UpdateLi_VacancyFor(Li_VacancyFor li_VacancyFor)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_VacancyFor", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@VacForId", SqlDbType.Int).Value = li_VacancyFor.VacForId;
            cmd.Parameters.Add("@VacForName", SqlDbType.VarChar).Value = li_VacancyFor.VacForName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_VacancyFor.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_VacancyFor.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_VacancyFor.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_VacancyFor.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_VacancyFor.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
