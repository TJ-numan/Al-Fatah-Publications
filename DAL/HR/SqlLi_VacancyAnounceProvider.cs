using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_VacancyAnounceProvider:DataAccessObject
{
	public SqlLi_VacancyAnounceProvider()
    {
    }


    public bool DeleteLi_VacancyAnounce(int li_VacancyAnounceID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_VacancyAnounce", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VacAnId", SqlDbType.Int).Value = li_VacancyAnounceID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_VacancyAnounce> GetAllLi_VacancyAnounces()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_VacancyAnounces", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_VacancyAnouncesFromReader(reader);
        }
    }
    public List<Li_VacancyAnounce> GetLi_VacancyAnouncesFromReader(IDataReader reader)
    {
        List<Li_VacancyAnounce> li_VacancyAnounces = new List<Li_VacancyAnounce>();

        while (reader.Read())
        {
            li_VacancyAnounces.Add(GetLi_VacancyAnounceFromReader(reader));
        }
        return li_VacancyAnounces;
    }

    public Li_VacancyAnounce GetLi_VacancyAnounceFromReader(IDataReader reader)
    {
        try
        {
            Li_VacancyAnounce li_VacancyAnounce = new Li_VacancyAnounce
                (
                   
                    (int)reader["VacAnId"],
                    (int)reader["VacId"],
                    (int)reader["VacTemId"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_VacancyAnounce;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_VacancyAnounce GetLi_VacancyAnounceByID(int li_VacancyAnounceID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_VacancyAnounceByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@VacAnId", SqlDbType.Int).Value = li_VacancyAnounceID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_VacancyAnounceFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_VacancyAnounce(Li_VacancyAnounce li_VacancyAnounce)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_VacancyAnounce", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@VacAnId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@VacId", SqlDbType.Int).Value = li_VacancyAnounce.VacId;
            cmd.Parameters.Add("@VacTemId", SqlDbType.Int).Value = li_VacancyAnounce.VacTemId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_VacancyAnounce.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_VacancyAnounce.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_VacancyAnounce.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_VacancyAnounce.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_VacancyAnounce.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@VacAnId"].Value;
        }
    }

    public bool UpdateLi_VacancyAnounce(Li_VacancyAnounce li_VacancyAnounce)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_VacancyAnounce", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@VacAnId", SqlDbType.Int).Value = li_VacancyAnounce.VacAnId;
            cmd.Parameters.Add("@VacId", SqlDbType.Int).Value = li_VacancyAnounce.VacId;
            cmd.Parameters.Add("@VacTemId", SqlDbType.Int).Value = li_VacancyAnounce.VacTemId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_VacancyAnounce.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_VacancyAnounce.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_VacancyAnounce.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_VacancyAnounce.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_VacancyAnounce.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
