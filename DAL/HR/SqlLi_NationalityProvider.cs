using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_NationalityProvider:DataAccessObject
{
	public SqlLi_NationalityProvider()
    {
    }


    public bool DeleteLi_Nationality(int li_NationalityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_Nationality", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NatiId", SqlDbType.Int).Value = li_NationalityID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Nationality> GetAllLi_Nationalities()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_Nationalities", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_NationalitiesFromReader(reader);
        }
    }
    public List<Li_Nationality> GetLi_NationalitiesFromReader(IDataReader reader)
    {
        List<Li_Nationality> li_Nationalities = new List<Li_Nationality>();

        while (reader.Read())
        {
            li_Nationalities.Add(GetLi_NationalityFromReader(reader));
        }
        return li_Nationalities;
    }

    public Li_Nationality GetLi_NationalityFromReader(IDataReader reader)
    {
        try
        {
            Li_Nationality li_Nationality = new Li_Nationality
                (
                   
                    (int)reader["NatiId"],
                    reader["NatiName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_Nationality;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Nationality GetLi_NationalityByID(int li_NationalityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_NationalityByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@NatiId", SqlDbType.Int).Value = li_NationalityID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_NationalityFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Nationality(Li_Nationality li_Nationality)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_Nationality", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@NatiId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@NatiName", SqlDbType.VarChar).Value = li_Nationality.NatiName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Nationality.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Nationality.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Nationality.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Nationality.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Nationality.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@NatiId"].Value;
        }
    }

    public bool UpdateLi_Nationality(Li_Nationality li_Nationality)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_Nationality", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@NatiId", SqlDbType.Int).Value = li_Nationality.NatiId;
            cmd.Parameters.Add("@NatiName", SqlDbType.VarChar).Value = li_Nationality.NatiName; 
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Nationality.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Nationality.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Nationality.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
