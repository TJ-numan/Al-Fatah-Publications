using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_AttnPolicyProvider:DataAccessObject
{
	public SqlLi_AttnPolicyProvider()
    {
    }


    public bool DeleteLi_AttnPolicy(int li_AttnPolicyID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_AttnPolicy", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PoliId", SqlDbType.Int).Value = li_AttnPolicyID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_AttnPolicy> GetAllLi_AttnPolicies()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_AttnPolicies", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_AttnPoliciesFromReader(reader);
        }
    }
    public List<Li_AttnPolicy> GetLi_AttnPoliciesFromReader(IDataReader reader)
    {
        List<Li_AttnPolicy> li_AttnPolicies = new List<Li_AttnPolicy>();

        while (reader.Read())
        {
            li_AttnPolicies.Add(GetLi_AttnPolicyFromReader(reader));
        }
        return li_AttnPolicies;
    }

    public Li_AttnPolicy GetLi_AttnPolicyFromReader(IDataReader reader)
    {
        try
        {
            Li_AttnPolicy li_AttnPolicy = new Li_AttnPolicy
                (
            
                    (int)reader["PoliId"],
                    reader["PoliName"].ToString(),
                    reader["PoliDes"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_AttnPolicy;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_AttnPolicy GetLi_AttnPolicyByID(int li_AttnPolicyID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_AttnPolicyByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PoliId", SqlDbType.Int).Value = li_AttnPolicyID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_AttnPolicyFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_AttnPolicy(Li_AttnPolicy li_AttnPolicy)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_AttnPolicy", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@PoliId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PoliName", SqlDbType.VarChar).Value = li_AttnPolicy.PoliName;
            cmd.Parameters.Add("@PoliDes", SqlDbType.VarChar).Value = li_AttnPolicy.PoliDes;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_AttnPolicy.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_AttnPolicy.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_AttnPolicy.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_AttnPolicy.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_AttnPolicy.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PoliId"].Value;
        }
    }

    public bool UpdateLi_AttnPolicy(Li_AttnPolicy li_AttnPolicy)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_AttnPolicy", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@PoliId", SqlDbType.Int).Value = li_AttnPolicy.PoliId;
            cmd.Parameters.Add("@PoliName", SqlDbType.VarChar).Value = li_AttnPolicy.PoliName;
            cmd.Parameters.Add("@PoliDes", SqlDbType.VarChar).Value = li_AttnPolicy.PoliDes;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_AttnPolicy.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_AttnPolicy.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_AttnPolicy.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_AttnPolicy.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_AttnPolicy.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
