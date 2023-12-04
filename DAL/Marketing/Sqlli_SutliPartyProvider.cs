using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_SutliPartyProvider:DataAccessObject
{
	public SqlLi_SutliPartyProvider()
    {
    }


    public bool DeleteLi_SutliParty(int li_SutliPartyID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_SutliParty", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_SutliPartyID", SqlDbType.Int).Value = li_SutliPartyID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_SutliParty> GetAllLi_SutliParties()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_SutliParties", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_SutliPartiesFromReader(reader);
        }
    }
    public List<Li_SutliParty> GetLi_SutliPartiesFromReader(IDataReader reader)
    {
        List<Li_SutliParty> li_SutliParties = new List<Li_SutliParty>();

        while (reader.Read())
        {
            li_SutliParties.Add(GetLi_SutliPartyFromReader(reader));
        }
        return li_SutliParties;
    }

    public Li_SutliParty GetLi_SutliPartyFromReader(IDataReader reader)
    {
        try
        {
            Li_SutliParty li_SutliParty = new Li_SutliParty
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
             return li_SutliParty;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_SutliParty GetLi_SutliPartyByID(int li_SutliPartyID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_SutliPartyByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_SutliPartyID", SqlDbType.Int).Value = li_SutliPartyID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_SutliPartyFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_SutliParty(Li_SutliParty li_SutliParty)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_SutliParty", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@ID", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_SutliParty.Name;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_SutliParty.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_SutliParty.Phone;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_SutliParty.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_SutliParty.CreatedDate;
             cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_SutliParty.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_SutliParty.ModifiedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ID"].Value;
        }
    }

    public bool UpdateLi_SutliParty(Li_SutliParty li_SutliParty)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_SutliParty", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.Int).Value = li_SutliParty.ID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_SutliParty.Name;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_SutliParty.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_SutliParty.Phone;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_SutliParty.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_SutliParty.CreatedDate;
             cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_SutliParty.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_SutliParty.ModifiedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
