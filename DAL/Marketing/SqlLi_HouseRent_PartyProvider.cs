using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_HouseRent_PartyProvider:DataAccessObject
{
	public SqlLi_HouseRent_PartyProvider()
    {
    }


    public bool DeleteLi_HouseRent_Party(int li_HouseRent_PartyID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_HouseRent_Party", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_HouseRent_PartyID", SqlDbType.Int).Value = li_HouseRent_PartyID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_HouseRent_Party> GetAllLi_HouseRent_Parties()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_HouseRent_Parties", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_HouseRent_PartiesFromReader(reader);
        }
    }
    public List<Li_HouseRent_Party> GetLi_HouseRent_PartiesFromReader(IDataReader reader)
    {
        List<Li_HouseRent_Party> li_HouseRent_Parties = new List<Li_HouseRent_Party>();

        while (reader.Read())
        {
            li_HouseRent_Parties.Add(GetLi_HouseRent_PartyFromReader(reader));
        }
        return li_HouseRent_Parties;
    }

    public Li_HouseRent_Party GetLi_HouseRent_PartyFromReader(IDataReader reader)
    {
        try
        {
            Li_HouseRent_Party li_HouseRent_Party = new Li_HouseRent_Party
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
             return li_HouseRent_Party;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_HouseRent_Party GetLi_HouseRent_PartyByID(int li_HouseRent_PartyID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_HouseRent_PartyByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_HouseRent_PartyID", SqlDbType.Int).Value = li_HouseRent_PartyID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_HouseRent_PartyFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string InsertLi_HouseRent_Party(Li_HouseRent_Party li_HouseRent_Party)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_HouseRent_Party", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PartyID", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PartName", SqlDbType.VarChar).Value = li_HouseRent_Party.PartName;
            cmd.Parameters.Add("@P_Add", SqlDbType.VarChar).Value = li_HouseRent_Party.P_Add;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_HouseRent_Party.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_HouseRent_Party.CreatedBy;
            cmd.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = li_HouseRent_Party.OwnerName;
            cmd.Parameters.Add("@ContactPer", SqlDbType.VarChar).Value = li_HouseRent_Party.ContactPer;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_HouseRent_Party.Phone;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@PartyID"].Value.ToString();
        }
    }

    public bool UpdateLi_HouseRent_Party(Li_HouseRent_Party li_HouseRent_Party)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_HouseRent_Party", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@PartyID", SqlDbType.VarChar).Value = li_HouseRent_Party.PartyID;
            cmd.Parameters.Add("@PartName", SqlDbType.VarChar).Value = li_HouseRent_Party.PartName;
            cmd.Parameters.Add("@P_Add", SqlDbType.VarChar).Value = li_HouseRent_Party.P_Add;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_HouseRent_Party.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_HouseRent_Party.CreatedBy;
            cmd.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = li_HouseRent_Party.OwnerName;
            cmd.Parameters.Add("@ContactPer", SqlDbType.VarChar).Value = li_HouseRent_Party.ContactPer;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_HouseRent_Party.Phone;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetAllLi_HouseRentPartyByID(string PartyID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_HouseRent_PartyByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PartyID", SqlDbType.VarChar).Value = PartyID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
}
