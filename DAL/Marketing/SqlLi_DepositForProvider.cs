using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; 
using System.Linq; 
public class SqlLi_DepositForProvider:DataAccessObject
{
	public SqlLi_DepositForProvider()
    {
    }


    public bool DeleteLi_DepositFor(int li_DepositForID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_DepositFor", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_DepositForID", SqlDbType.Int).Value = li_DepositForID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_DepositFor> GetAllLi_DepositFors()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_DepositFors", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_DepositForsFromReader(reader);
        }
    }
    public List<Li_DepositFor> GetLi_DepositForsFromReader(IDataReader reader)
    {
        List<Li_DepositFor> li_DepositFors = new List<Li_DepositFor>();

        while (reader.Read())
        {
            li_DepositFors.Add(GetLi_DepositForFromReader(reader));
        }
        return li_DepositFors;
    }

    public Li_DepositFor GetLi_DepositForFromReader(IDataReader reader)
    {
        try
        {
            Li_DepositFor li_DepositFor = new Li_DepositFor
                (
                    
                    (int)reader["DepForId"],
                    reader["DepForName"].ToString(),
                    (bool)reader["IsActive"],
                    reader["MrShortN"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"]
                );
             return li_DepositFor;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_DepositFor GetLi_DepositForByID(int li_DepositForID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_DepositForByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_DepositForID", SqlDbType.Int).Value = li_DepositForID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_DepositForFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_DepositFor(Li_DepositFor li_DepositFor)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_DepositFor", connection);
            cmd.CommandType = CommandType.StoredProcedure;    
            cmd.Parameters.Add("@DepForId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DepForName", SqlDbType.VarChar).Value = li_DepositFor.DepForName;
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = li_DepositFor.IsActive;
            cmd.Parameters.Add("@MrShortN", SqlDbType.VarChar).Value = li_DepositFor.MrShortN;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DepositFor.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DepositFor.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DepForId"].Value;
        }
    }

    public bool UpdateLi_DepositFor(Li_DepositFor li_DepositFor)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_DepositFor", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DepForId", SqlDbType.Int).Value = li_DepositFor.DepForId;
            cmd.Parameters.Add("@DepForName", SqlDbType.VarChar).Value = li_DepositFor.DepForName;
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = li_DepositFor.IsActive;
            cmd.Parameters.Add("@MrShortN", SqlDbType.VarChar).Value = li_DepositFor.MrShortN;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DepositFor.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DepositFor.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
