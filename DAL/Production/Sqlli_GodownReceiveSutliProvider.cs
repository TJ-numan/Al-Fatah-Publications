using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_GodownReceiveSutliProvider:DataAccessObject
{
	public SqlLi_GodownReceiveSutliProvider()
    {
    }


    public bool DeleteLi_GodownReceiveSutli(int li_GodownReceiveSutliID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_GodownReceiveSutli", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_GodownReceiveSutliID", SqlDbType.Int).Value = li_GodownReceiveSutliID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_GodownReceiveSutli> GetAllLi_GodownReceiveSutlis()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_GodownReceiveSutlis", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_GodownReceiveSutlisFromReader(reader);
        }
    }
    public List<Li_GodownReceiveSutli> GetLi_GodownReceiveSutlisFromReader(IDataReader reader)
    {
        List<Li_GodownReceiveSutli> li_GodownReceiveSutlis = new List<Li_GodownReceiveSutli>();

        while (reader.Read())
        {
            li_GodownReceiveSutlis.Add(GetLi_GodownReceiveSutliFromReader(reader));
        }
        return li_GodownReceiveSutlis;
    }

    public Li_GodownReceiveSutli GetLi_GodownReceiveSutliFromReader(IDataReader reader)
    {
        try
        {
            Li_GodownReceiveSutli li_GodownReceiveSutli = new Li_GodownReceiveSutli
                (
                     
                    (int)reader["ReceiveID"],
                    (int)reader["PartyID"],
                    (DateTime)reader["ReceiveDate"],
                    (int)reader["ReceiveBy"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["Qty"] 
                     
                );
             return li_GodownReceiveSutli;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_GodownReceiveSutli GetLi_GodownReceiveSutliByID(int li_GodownReceiveSutliID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_GodownReceiveSutliByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_GodownReceiveSutliID", SqlDbType.Int).Value = li_GodownReceiveSutliID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_GodownReceiveSutliFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_GodownReceiveSutli(Li_GodownReceiveSutli li_GodownReceiveSutli)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_GodownReceiveSutli", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@ReceiveID", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PartyID", SqlDbType.Int).Value = li_GodownReceiveSutli.PartyID;
            cmd.Parameters.Add("@ReceiveDate", SqlDbType.DateTime).Value = li_GodownReceiveSutli.ReceiveDate;
            cmd.Parameters.Add("@ReceiveBy", SqlDbType.Int).Value = li_GodownReceiveSutli.ReceiveBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_GodownReceiveSutli.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_GodownReceiveSutli.ModifiedDate;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_GodownReceiveSutli.Qty;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ReceiveID"].Value;
        }
    }

    public bool UpdateLi_GodownReceiveSutli(Li_GodownReceiveSutli li_GodownReceiveSutli)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_GodownReceiveSutli", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ReceiveID", SqlDbType.Int).Value = li_GodownReceiveSutli.ReceiveID;
            cmd.Parameters.Add("@PartyID", SqlDbType.Int).Value = li_GodownReceiveSutli.PartyID;
            cmd.Parameters.Add("@ReceiveDate", SqlDbType.DateTime).Value = li_GodownReceiveSutli.ReceiveDate;
            cmd.Parameters.Add("@ReceiveBy", SqlDbType.Int).Value = li_GodownReceiveSutli.ReceiveBy;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_GodownReceiveSutli.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_GodownReceiveSutli.ModifiedDate;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_GodownReceiveSutli.Qty;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
