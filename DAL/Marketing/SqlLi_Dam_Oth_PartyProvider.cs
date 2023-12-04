using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Dam_Oth_PartyProvider:DataAccessObject
{
	public SqlLi_Dam_Oth_PartyProvider()
    {
    }


    public bool DeleteLi_Dam_Oth_Party(int li_Dam_Oth_PartyID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Dam_Oth_Party", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Dam_Oth_PartyID", SqlDbType.Int).Value = li_Dam_Oth_PartyID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Dam_Oth_Party> GetAllLi_Dam_Oth_Parties()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Dam_Oth_Parties", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Dam_Oth_PartiesFromReader(reader);
        }
    }
    public List<Li_Dam_Oth_Party> GetLi_Dam_Oth_PartiesFromReader(IDataReader reader)
    {
        List<Li_Dam_Oth_Party> li_Dam_Oth_Parties = new List<Li_Dam_Oth_Party>();

        while (reader.Read())
        {
            li_Dam_Oth_Parties.Add(GetLi_Dam_Oth_PartyFromReader(reader));
        }
        return li_Dam_Oth_Parties;
    }

    public Li_Dam_Oth_Party GetLi_Dam_Oth_PartyFromReader(IDataReader reader)
    {
        try
        {
            Li_Dam_Oth_Party li_Dam_Oth_Party = new Li_Dam_Oth_Party
                (
                    
                    reader["PartyID"].ToString(),
                    reader["PartName"].ToString(),
                    reader["P_Add"].ToString(),
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    reader["OwnerName"].ToString(),
                    reader["ContactPer"].ToString(),
                    reader["Phone"].ToString() 
                );
             return li_Dam_Oth_Party;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Dam_Oth_Party GetLi_Dam_Oth_PartyByID(int li_Dam_Oth_PartyID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Dam_Oth_PartyByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Dam_Oth_PartyID", SqlDbType.Int).Value = li_Dam_Oth_PartyID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Dam_Oth_PartyFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Dam_Oth_Party(Li_Dam_Oth_Party li_Dam_Oth_Party)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Dam_Oth_Party", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@PartyID", SqlDbType.VarChar).Value = li_Dam_Oth_Party.PartyID;
            cmd.Parameters.Add("@PartName", SqlDbType.VarChar).Value = li_Dam_Oth_Party.PartName;
            cmd.Parameters.Add("@P_Add", SqlDbType.VarChar).Value = li_Dam_Oth_Party.P_Add;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Dam_Oth_Party.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Dam_Oth_Party.CreatedBy;
            cmd.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = li_Dam_Oth_Party.OwnerName;
            cmd.Parameters.Add("@ContactPer", SqlDbType.VarChar).Value = li_Dam_Oth_Party.ContactPer;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_Dam_Oth_Party.Phone;
 
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Li_Dam_Oth_PartyID"].Value;
        }
    }

    public bool UpdateLi_Dam_Oth_Party(Li_Dam_Oth_Party li_Dam_Oth_Party)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Dam_Oth_Party", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@PartyID", SqlDbType.VarChar).Value = li_Dam_Oth_Party.PartyID;
            cmd.Parameters.Add("@PartName", SqlDbType.VarChar).Value = li_Dam_Oth_Party.PartName;
            cmd.Parameters.Add("@P_Add", SqlDbType.VarChar).Value = li_Dam_Oth_Party.P_Add;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Dam_Oth_Party.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Dam_Oth_Party.CreatedBy;
            cmd.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = li_Dam_Oth_Party.OwnerName;
            cmd.Parameters.Add("@ContactPer", SqlDbType.VarChar).Value = li_Dam_Oth_Party.ContactPer;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_Dam_Oth_Party.Phone;
 
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
