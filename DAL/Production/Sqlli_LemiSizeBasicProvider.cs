using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_LemiSizeBasicProvider:DataAccessObject
{
	public SqlLi_LemiSizeBasicProvider()
    {
    }


    public bool DeleteLi_LemiSizeBasic(int li_LemiSizeBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_LemiSizeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_LemiSizeBasicID", SqlDbType.Int).Value = li_LemiSizeBasicID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_LemiSizeBasic> GetAllLi_LemiSizeBasics()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_LemiSizeBasics", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_LemiSizeBasicsFromReader(reader);
        }
    }
    public List<Li_LemiSizeBasic> GetLi_LemiSizeBasicsFromReader(IDataReader reader)
    {
        List<Li_LemiSizeBasic> li_LemiSizeBasics = new List<Li_LemiSizeBasic>();

        while (reader.Read())
        {
            li_LemiSizeBasics.Add(GetLi_LemiSizeBasicFromReader(reader));
        }
        return li_LemiSizeBasics;
    }

    public Li_LemiSizeBasic GetLi_LemiSizeBasicFromReader(IDataReader reader)
    {
        try
        {
            Li_LemiSizeBasic li_LemiSizeBasic = new Li_LemiSizeBasic
                (
                    
                    reader["LemiSizeID"].ToString(),
                    reader["LemiSize"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"]
                );
             return li_LemiSizeBasic;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_LemiSizeBasic GetLi_LemiSizeBasicByID(int li_LemiSizeBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_LemiSizeBasicByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_LemiSizeBasicID", SqlDbType.Int).Value = li_LemiSizeBasicID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_LemiSizeBasicFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_LemiSizeBasic(Li_LemiSizeBasic li_LemiSizeBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertLi_LemiSizeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@LemiSizeID", SqlDbType.VarChar,50). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@LemiSize", SqlDbType.VarChar).Value = li_LemiSizeBasic.LemiSize;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LemiSizeBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LemiSizeBasic.CreatedDate;
            connection.Open();

            int  result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@LemiSizeID"].Value.ToString ();
        }
    }

    public bool UpdateLi_LemiSizeBasic(Li_LemiSizeBasic li_LemiSizeBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_LemiSizeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
      
            cmd.Parameters.Add("@LemiSizeID", SqlDbType.VarChar).Value = li_LemiSizeBasic.LemiSizeID;
            cmd.Parameters.Add("@LemiSize", SqlDbType.VarChar).Value = li_LemiSizeBasic.LemiSize;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LemiSizeBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LemiSizeBasic.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
