using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_ReligionProvider:DataAccessObject
{
	public SqlLi_ReligionProvider()
    {
    }


    public bool DeleteLi_Religion(int li_ReligionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_Religion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RegId", SqlDbType.Int).Value = li_ReligionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Religion> GetAllLi_Religions()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_Religions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ReligionsFromReader(reader);
        }
    }
    public List<Li_Religion> GetLi_ReligionsFromReader(IDataReader reader)
    {
        List<Li_Religion> li_Religions = new List<Li_Religion>();

        while (reader.Read())
        {
            li_Religions.Add(GetLi_ReligionFromReader(reader));
        }
        return li_Religions;
    }

    public Li_Religion GetLi_ReligionFromReader(IDataReader reader)
    {
        try
        {
            Li_Religion li_Religion = new Li_Religion
                (
                   
                    (int)reader["RegId"],
                    reader["RegName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_Religion;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Religion GetLi_ReligionByID(int li_ReligionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_ReligionByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RegId", SqlDbType.Int).Value = li_ReligionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ReligionFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Religion(Li_Religion li_Religion)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_Religion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@RegId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@RegName", SqlDbType.VarChar).Value = li_Religion.RegName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Religion.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Religion.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Religion.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Religion.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Religion.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@RegId"].Value;
        }
    }

    public bool UpdateLi_Religion(Li_Religion li_Religion)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_Religion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
      
            cmd.Parameters.Add("@RegId", SqlDbType.Int).Value = li_Religion.RegId;
            cmd.Parameters.Add("@RegName", SqlDbType.VarChar).Value = li_Religion.RegName; 
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Religion.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Religion.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Religion.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
