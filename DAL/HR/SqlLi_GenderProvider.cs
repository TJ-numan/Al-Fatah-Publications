using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_GenderProvider:DataAccessObject
{
	public SqlLi_GenderProvider()
    {
    }


    public bool DeleteLi_Gender(int li_GenderID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_Gender", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@GenId", SqlDbType.Int).Value = li_GenderID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Gender> GetAllLi_Genders()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_Genders", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_GendersFromReader(reader);
        }
    }
    public List<Li_Gender> GetLi_GendersFromReader(IDataReader reader)
    {
        List<Li_Gender> li_Genders = new List<Li_Gender>();

        while (reader.Read())
        {
            li_Genders.Add(GetLi_GenderFromReader(reader));
        }
        return li_Genders;
    }

    public Li_Gender GetLi_GenderFromReader(IDataReader reader)
    {
        try
        {
            Li_Gender li_Gender = new Li_Gender
                (
                     
                    (int)reader["GenId"],
                    reader["GenGp"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_Gender;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Gender GetLi_GenderByID(int li_GenderID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_GenderByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@GenId", SqlDbType.Int).Value = li_GenderID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_GenderFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Gender(Li_Gender li_Gender)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_Gender", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@GenId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@GenGp", SqlDbType.VarChar).Value = li_Gender.GenGp;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Gender.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Gender.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Gender.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Gender.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Gender.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@GenId"].Value;
        }
    }

    public bool UpdateLi_Gender(Li_Gender li_Gender)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_Gender", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@GenId", SqlDbType.Int).Value = li_Gender.GenId;
            cmd.Parameters.Add("@GenGp", SqlDbType.VarChar).Value = li_Gender.GenGp; 
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Gender.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Gender.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Gender.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
