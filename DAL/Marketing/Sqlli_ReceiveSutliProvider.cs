using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_ReceiveSutliProvider:DataAccessObject
{
	public SqlLi_ReceiveSutliProvider()
    {
    }


    public bool DeleteLi_ReceiveSutli(int li_ReceiveSutliID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_ReceiveSutli", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_ReceiveSutliID", SqlDbType.Int).Value = li_ReceiveSutliID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_ReceiveSutli> GetAllLi_ReceiveSutlis()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_ReceiveSutlis", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ReceiveSutlisFromReader(reader);
        }
    }
    public List<Li_ReceiveSutli> GetLi_ReceiveSutlisFromReader(IDataReader reader)
    {
        List<Li_ReceiveSutli> li_ReceiveSutlis = new List<Li_ReceiveSutli>();

        while (reader.Read())
        {
            li_ReceiveSutlis.Add(GetLi_ReceiveSutliFromReader(reader));
        }
        return li_ReceiveSutlis;
    }

    public Li_ReceiveSutli GetLi_ReceiveSutliFromReader(IDataReader reader)
    {
        try
        {
            Li_ReceiveSutli li_ReceiveSutli = new Li_ReceiveSutli
                (
                     
                    (int)reader["ID"],
                     (int)reader["PartyID"],
                  (decimal)  reader["Qty"]  ,
                    (decimal)reader["UnitPrice"],
                    (decimal)reader["TotalPrice"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"] 
                );
             return li_ReceiveSutli;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_ReceiveSutli GetLi_ReceiveSutliByID(int li_ReceiveSutliID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_ReceiveSutliByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_ReceiveSutliID", SqlDbType.Int).Value = li_ReceiveSutliID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ReceiveSutliFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_ReceiveSutli(Li_ReceiveSutli li_ReceiveSutli)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_ReceiveSutli", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PartyID", SqlDbType.Int ).Value = li_ReceiveSutli.PartyID;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal ).Value = li_ReceiveSutli.Qty;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = li_ReceiveSutli.UnitPrice;
            cmd.Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = li_ReceiveSutli.TotalPrice;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ReceiveSutli.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ReceiveSutli.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ReceiveSutli.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ReceiveSutli.ModifiedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ID"].Value;
        }
    }

    public bool UpdateLi_ReceiveSutli(Li_ReceiveSutli li_ReceiveSutli)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_ReceiveSutli", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.Int).Value = li_ReceiveSutli.ID;
            cmd.Parameters.Add("@PartyID", SqlDbType.Decimal).Value = li_ReceiveSutli.PartyID;
            cmd.Parameters.Add("@Qty", SqlDbType.VarChar).Value = li_ReceiveSutli.Qty;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = li_ReceiveSutli.UnitPrice;
            cmd.Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = li_ReceiveSutli.TotalPrice;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ReceiveSutli.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ReceiveSutli.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ReceiveSutli.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ReceiveSutli.ModifiedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
