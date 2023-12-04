using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_CouResPersonProvider:DataAccessObject
{
	public SqlLi_CouResPersonProvider()
    {
    }


    public bool DeleteLi_CouResPerson(int li_CouResPersonID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_CouResPerson", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ResoPId", SqlDbType.Int).Value = li_CouResPersonID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_CouResPerson> GetAllLi_CouResPersons()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_CouResPersons", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_CouResPersonsFromReader(reader);
        }
    }
    public List<Li_CouResPerson> GetLi_CouResPersonsFromReader(IDataReader reader)
    {
        List<Li_CouResPerson> li_CouResPersons = new List<Li_CouResPerson>();

        while (reader.Read())
        {
            li_CouResPersons.Add(GetLi_CouResPersonFromReader(reader));
        }
        return li_CouResPersons;
    }

    public Li_CouResPerson GetLi_CouResPersonFromReader(IDataReader reader)
    {
        try
        {
            Li_CouResPerson li_CouResPerson = new Li_CouResPerson
                (
         
                    (int)reader["ResoPId"],
                    reader["ResPName"].ToString(),
                    reader["ProfTitle"].ToString(),
                    reader["InsAdd"].ToString(),
                    (int)reader["ResAdd"],
                    reader["Phone"].ToString(),
                    reader["ContactPerson"].ToString(),
                    reader["ContactPhone"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_CouResPerson;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_CouResPerson GetLi_CouResPersonByID(int li_CouResPersonID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_CouResPersonByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ResoPId", SqlDbType.Int).Value = li_CouResPersonID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_CouResPersonFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_CouResPerson(Li_CouResPerson li_CouResPerson)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_CouResPerson", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@ResoPId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ResPName", SqlDbType.VarChar).Value = li_CouResPerson.ResPName;
            cmd.Parameters.Add("@ProfTitle", SqlDbType.VarChar).Value = li_CouResPerson.ProfTitle;
            cmd.Parameters.Add("@InsAdd", SqlDbType.VarChar).Value = li_CouResPerson.InsAdd;
            cmd.Parameters.Add("@ResAdd", SqlDbType.Int).Value = li_CouResPerson.ResAdd;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_CouResPerson.Phone;
            cmd.Parameters.Add("@ContactPerson", SqlDbType.VarChar).Value = li_CouResPerson.ContactPerson;
            cmd.Parameters.Add("@ContactPhone", SqlDbType.VarChar).Value = li_CouResPerson.ContactPhone;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_CouResPerson.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_CouResPerson.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_CouResPerson.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_CouResPerson.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_CouResPerson.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();

            return (int)cmd.Parameters["@ResoPId"].Value;
        }
    }

    public bool UpdateLi_CouResPerson(Li_CouResPerson li_CouResPerson)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_CouResPerson", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@ResoPId", SqlDbType.Int).Value = li_CouResPerson.ResoPId;
            cmd.Parameters.Add("@ResPName", SqlDbType.VarChar).Value = li_CouResPerson.ResPName;
            cmd.Parameters.Add("@ProfTitle", SqlDbType.VarChar).Value = li_CouResPerson.ProfTitle;
            cmd.Parameters.Add("@InsAdd", SqlDbType.VarChar).Value = li_CouResPerson.InsAdd;
            cmd.Parameters.Add("@ResAdd", SqlDbType.Int).Value = li_CouResPerson.ResAdd;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_CouResPerson.Phone;
            cmd.Parameters.Add("@ContactPerson", SqlDbType.VarChar).Value = li_CouResPerson.ContactPerson;
            cmd.Parameters.Add("@ContactPhone", SqlDbType.VarChar).Value = li_CouResPerson.ContactPhone;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_CouResPerson.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_CouResPerson.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_CouResPerson.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_CouResPerson.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_CouResPerson.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
