using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using DAL;

public class SqlLi_PlateProcessPartyProvider:DataAccessObject
{
	public SqlLi_PlateProcessPartyProvider()
    {
    }


    public bool DeleteLi_PlateProcessParty(int li_PlateProcessPartyID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlateProcessParty", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PlateProcessPartyID", SqlDbType.Int).Value = li_PlateProcessPartyID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PlateProcessParty> GetAllLi_PlateProcessParties()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlateProcessParties", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PlateProcessPartiesFromReader(reader);
        }
    }
    public List<Li_PlateProcessParty> GetLi_PlateProcessPartiesFromReader(IDataReader reader)
    {
        List<Li_PlateProcessParty> li_PlateProcessParties = new List<Li_PlateProcessParty>();

        while (reader.Read())
        {
            li_PlateProcessParties.Add(GetLi_PlateProcessPartyFromReader(reader));
        }
        return li_PlateProcessParties;
    }

    public Li_PlateProcessParty GetLi_PlateProcessPartyFromReader(IDataReader reader)
    {
        try
        {
            Li_PlateProcessParty li_PlateProcessParty = new Li_PlateProcessParty
                (
                    
                    reader["ID"].ToString(),
                    reader["Name"].ToString(),
                    reader["Address"].ToString(),
                    reader["Phone"].ToString(),
                    (decimal)reader["O_Balance"],
                   
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"] ,

                    reader["B_Name"].ToString(),
                    reader["B_Add"].ToString()
                   
                );
             return li_PlateProcessParty;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PlateProcessParty GetLi_PlateProcessPartyByID(int li_PlateProcessPartyID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlateProcessPartyByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PlateProcessPartyID", SqlDbType.Int).Value = li_PlateProcessPartyID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PlateProcessPartyFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_PlateProcessParty(Li_PlateProcessParty li_PlateProcessParty)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("web_SMPM_InsertLi_PlateProcessParty", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ID", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_PlateProcessParty.Name;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_PlateProcessParty.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_PlateProcessParty.Phone;
            cmd.Parameters.Add("@O_Balance", SqlDbType.Decimal).Value = li_PlateProcessParty.O_Balance;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateProcessParty.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateProcessParty.CreatedDate;
            cmd.Parameters.Add("@B_Name", SqlDbType.VarChar).Value = li_PlateProcessParty.B_Name;
            cmd.Parameters.Add("@B_Add", SqlDbType.VarChar).Value = li_PlateProcessParty.B_Add;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@ID"].Value.ToString();
        }
    }

    public bool UpdateLi_PlateProcessParty(Li_PlateProcessParty li_PlateProcessParty)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("web_SMPM_UpdateLi_PlateProcessParty", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_PlateProcessParty.ID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_PlateProcessParty.Name;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = li_PlateProcessParty.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = li_PlateProcessParty.Phone;
            cmd.Parameters.Add("@O_Balance", SqlDbType.Decimal).Value = li_PlateProcessParty.O_Balance;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateProcessParty.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateProcessParty.CreatedDate;
            cmd.Parameters.Add("@B_Name", SqlDbType.VarChar).Value = li_PlateProcessParty.B_Name;
            cmd.Parameters.Add("@B_Add", SqlDbType.VarChar).Value = li_PlateProcessParty.B_Add;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetLi_PlateBuyerInfoByID(string PartyID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("web_SMPM_GetLi_Li_PlateBuyerInfoById", connection);
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

    public DataSet GetLi_PlateProcessPartiesByID(string PartyID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("web_SMPM_GetAllLi_PlateProcessPartiesById", connection);
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
