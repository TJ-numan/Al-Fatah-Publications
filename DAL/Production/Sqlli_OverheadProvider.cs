using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_OverheadProvider:DataAccessObject
{
	public SqlLi_OverheadProvider()
    {
    }


    public bool DeleteLi_Overhead(int li_OverheadID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Overhead", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_OverheadID", SqlDbType.Int).Value = li_OverheadID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Overhead> GetAllLi_Overheads()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Overheads", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_OverheadsFromReader(reader);
        }
    }
    public List<Li_Overhead> GetLi_OverheadsFromReader(IDataReader reader)
    {
        List<Li_Overhead> li_Overheads = new List<Li_Overhead>();

        while (reader.Read())
        {
            li_Overheads.Add(GetLi_OverheadFromReader(reader));
        }
        return li_Overheads;
    }

    public Li_Overhead GetLi_OverheadFromReader(IDataReader reader)
    {
        try
        {
            Li_Overhead li_Overhead = new Li_Overhead
                (

                    reader["BookCode"].ToString(),
                    (decimal)reader["ManufacturingOverhead"],
                    (decimal)reader["AdministrativeOverhead"],
                    (decimal)reader["MKTOverhead"],
                    (decimal)reader["Wastage"],
                    (decimal)reader["Commission"],
                    (decimal)reader["MarkUp"],
                    (decimal)reader["Bonus"]

                );
            return li_Overhead;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Li_Overhead GetLi_OverheadByID(string  li_OverheadID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_OverheadByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookCode", SqlDbType.VarChar ).Value = li_OverheadID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            if (reader.Read())
            {
                return GetLi_OverheadFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Overhead(Li_Overhead li_Overhead)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Overhead", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_Overhead.BookCode;
            cmd.Parameters.Add("@ManufacturingOverhead", SqlDbType.Decimal).Value = li_Overhead.ManufacturingOverhead;
            cmd.Parameters.Add("@AdministrativeOverhead", SqlDbType.Decimal).Value = li_Overhead.AdministrativeOverhead;
            cmd.Parameters.Add("@MKTOverhead", SqlDbType.Decimal).Value = li_Overhead.MKTOverhead;
            cmd.Parameters.Add("@Wastage", SqlDbType.Decimal).Value = li_Overhead.Wastage;
            cmd.Parameters.Add("@Commission", SqlDbType.Decimal).Value = li_Overhead.Commission;
            cmd.Parameters.Add("@MarkUp", SqlDbType.Decimal).Value = li_Overhead.MarkUp;
            cmd.Parameters.Add("@Bonus", SqlDbType.Decimal).Value = li_Overhead.Bonus;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_Overhead(Li_Overhead li_Overhead)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Overhead", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_Overhead.BookCode;
            cmd.Parameters.Add("@ManufacturingOverhead", SqlDbType.Decimal).Value = li_Overhead.ManufacturingOverhead;
            cmd.Parameters.Add("@AdministrativeOverhead", SqlDbType.Decimal).Value = li_Overhead.AdministrativeOverhead;
            cmd.Parameters.Add("@MKTOverhead", SqlDbType.Decimal).Value = li_Overhead.MKTOverhead;
            cmd.Parameters.Add("@Wastage", SqlDbType.Decimal).Value = li_Overhead.Wastage;
            cmd.Parameters.Add("@Commission", SqlDbType.Decimal).Value = li_Overhead.Commission;
            cmd.Parameters.Add("@MarkUp", SqlDbType.Decimal).Value = li_Overhead.MarkUp;
            cmd.Parameters.Add("@Bonus", SqlDbType.Decimal).Value = li_Overhead.Bonus;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
