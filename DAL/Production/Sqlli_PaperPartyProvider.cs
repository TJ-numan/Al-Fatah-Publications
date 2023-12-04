using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PaperPartyProvider:DataAccessObject
{
	public SqlLi_PaperPartyProvider()
    {
    }


    public bool DeleteLi_PaperParty(int li_PaperPartyID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PaperParty", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PaperPartyID", SqlDbType.Int).Value = li_PaperPartyID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PaperParty> GetAllLi_PaperParties()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PaperParties", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PaperPartiesFromReader(reader);
        }
    }
    public List<Li_PaperParty> GetLi_PaperPartiesFromReader(IDataReader reader)
    {
        List<Li_PaperParty> li_PaperParties = new List<Li_PaperParty>();

        while (reader.Read())
        {
            li_PaperParties.Add(GetLi_PaperPartyFromReader(reader));
        }
        return li_PaperParties;
    }

    public Li_PaperParty GetLi_PaperPartyFromReader(IDataReader reader)
    {
        try
        {
            Li_PaperParty li_PaperParty = new Li_PaperParty
                (
                    
                    reader["ID"].ToString(),
                    reader["Name"].ToString(),
                    reader["Name_Bn"].ToString(),
                    reader["Address"].ToString(),
                    reader["Address_Bn"].ToString(),
                    reader["Phone"].ToString(),
                    (decimal)reader["O_Balance"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"] 
                     
                );
             return li_PaperParty;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PaperParty GetLi_PaperPartyByID(int li_PaperPartyID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PaperPartyByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PaperPartyID", SqlDbType.Int).Value = li_PaperPartyID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PaperPartyFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_PaperParty(Li_PaperParty li_PaperParty)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PaperParty", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@ID", SqlDbType.VarChar,50). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_PaperParty.Name;
            cmd.Parameters.Add("@Name_Bn", SqlDbType.VarChar).Value = li_PaperParty.Name_Bn;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_PaperParty.Address;
            cmd.Parameters.Add("@Address_Bn", SqlDbType.VarChar).Value = li_PaperParty.Address_Bn;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_PaperParty.Phone;
            cmd.Parameters.Add("@O_Balance", SqlDbType.Decimal).Value = li_PaperParty.O_Balance;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PaperParty.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PaperParty.CreatedDate;
              connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@ID"].Value .ToString ();
        }
    }

    public bool UpdateLi_PaperParty(Li_PaperParty li_PaperParty)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PaperParty", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_PaperParty.ID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_PaperParty.Name;
            cmd.Parameters.Add("@Name_Bn", SqlDbType.VarChar).Value = li_PaperParty.Name_Bn;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_PaperParty.Address;
            cmd.Parameters.Add("@Address_Bn", SqlDbType.VarChar).Value = li_PaperParty.Address_Bn;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_PaperParty.Phone;
            cmd.Parameters.Add("@O_Balance", SqlDbType.Decimal).Value = li_PaperParty.O_Balance;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PaperParty.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PaperParty.CreatedDate;
              connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetAllLi_PaperPartyByID(string PartyID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PaperPartyByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = PartyID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

}
