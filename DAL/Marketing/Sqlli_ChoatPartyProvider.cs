using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_ChoatPartyProvider:DataAccessObject
{
	public SqlLi_ChoatPartyProvider()
    {
    }


    public bool DeleteLi_ChoatParty(int li_ChoatPartyID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_ChoatParty", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_ChoatPartyID", SqlDbType.Int).Value = li_ChoatPartyID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_ChoatParty> GetAllLi_ChoatParties()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_ChoatParties", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ChoatPartiesFromReader(reader);
        }
    }
    public List<Li_ChoatParty> GetLi_ChoatPartiesFromReader(IDataReader reader)
    {
        List<Li_ChoatParty> li_ChoatParties = new List<Li_ChoatParty>();

        while (reader.Read())
        {
            li_ChoatParties.Add(GetLi_ChoatPartyFromReader(reader));
        }
        return li_ChoatParties;
    }

    public Li_ChoatParty GetLi_ChoatPartyFromReader(IDataReader reader)
    {
        try
        {
            Li_ChoatParty li_ChoatParty = new Li_ChoatParty
                (
                     
                    (int)reader["ID"],
                    reader["Name"].ToString(),
                    reader["Address"].ToString(),
                    reader["Phone"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                     
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"]  
                );
             return li_ChoatParty;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_ChoatParty GetLi_ChoatPartyByID(int li_ChoatPartyID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_ChoatPartyByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_ChoatPartyID", SqlDbType.Int).Value = li_ChoatPartyID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ChoatPartyFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_ChoatParty(Li_ChoatParty li_ChoatParty)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_ChoatParty", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_ChoatParty.Name;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_ChoatParty.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_ChoatParty.Phone;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ChoatParty.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ChoatParty.CreatedDate;
 
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ChoatParty.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ChoatParty.ModifiedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ID"].Value;
        }
    }

    public bool UpdateLi_ChoatParty(Li_ChoatParty li_ChoatParty)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_ChoatParty", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.Int).Value = li_ChoatParty.ID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_ChoatParty.Name;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_ChoatParty.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_ChoatParty.Phone;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ChoatParty.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ChoatParty.CreatedDate;
             cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ChoatParty.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ChoatParty.ModifiedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
