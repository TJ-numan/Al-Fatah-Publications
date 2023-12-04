using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using DAL;

public class SqlLi_PolithinPartyProvider:DataAccessObject
{
	public SqlLi_PolithinPartyProvider()
    {
    }


    public bool DeleteLi_PolithinParty(int li_PolithinPartyID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PolithinParty", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PolithinPartyID", SqlDbType.Int).Value = li_PolithinPartyID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PolithinParty> GetAllLi_PolithinParties()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PolithinParties", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PolithinPartiesFromReader(reader);
        }
    }
    public List<Li_PolithinParty> GetLi_PolithinPartiesFromReader(IDataReader reader)
    {
        List<Li_PolithinParty> li_PolithinParties = new List<Li_PolithinParty>();

        while (reader.Read())
        {
            li_PolithinParties.Add(GetLi_PolithinPartyFromReader(reader));
        }
        return li_PolithinParties;
    }

    public Li_PolithinParty GetLi_PolithinPartyFromReader(IDataReader reader)
    {
        try
        {
            Li_PolithinParty li_PolithinParty = new Li_PolithinParty
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
             return li_PolithinParty;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PolithinParty GetLi_PolithinPartyByID(int li_PolithinPartyID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PolithinPartyByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PolithinPartyID", SqlDbType.Int).Value = li_PolithinPartyID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PolithinPartyFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PolithinParty(Li_PolithinParty li_PolithinParty)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PolithinParty", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_PolithinParty.Name;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_PolithinParty.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_PolithinParty.Phone;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PolithinParty.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PolithinParty.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PolithinParty.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PolithinParty.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ID"].Value;
        }
    }

    public bool UpdateLi_PolithinParty(Li_PolithinParty li_PolithinParty)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PolithinParty", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = li_PolithinParty.ID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_PolithinParty.Name;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_PolithinParty.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_PolithinParty.Phone;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PolithinParty.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PolithinParty.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PolithinParty.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PolithinParty.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
