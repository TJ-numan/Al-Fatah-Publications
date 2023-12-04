using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_OrganogramProvider:DataAccessObject
{
	public SqlLi_OrganogramProvider()
    {
    }


    public bool DeleteLi_Organogram(int li_OrganogramID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_Organogram", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PosId", SqlDbType.Int).Value = li_OrganogramID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Organogram> GetAllLi_Organograms()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_Organograms", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_OrganogramsFromReader(reader);
        }
    }
    public List<Li_Organogram> GetLi_OrganogramsFromReader(IDataReader reader)
    {
        List<Li_Organogram> li_Organograms = new List<Li_Organogram>();

        while (reader.Read())
        {
            li_Organograms.Add(GetLi_OrganogramFromReader(reader));
        }
        return li_Organograms;
    }

    public Li_Organogram GetLi_OrganogramFromReader(IDataReader reader)
    {
        try
        {
            Li_Organogram li_Organogram = new Li_Organogram
                (
                   
                    (int)reader["PosId"],
                    reader["PosTitle"].ToString(),
                    (int)reader["DepId"],
                    (int)reader["DesId"],
                    (int)reader["JobNaId"],
                    (bool)reader["IsDefault"],
                    (int)reader["ReportToPosId"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_Organogram;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Organogram GetLi_OrganogramByID(int li_OrganogramID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_OrganogramByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PosId", SqlDbType.Int).Value = li_OrganogramID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_OrganogramFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Organogram(Li_Organogram li_Organogram)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_Organogram", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@PosId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PosTitle", SqlDbType.VarChar).Value = li_Organogram.PosTitle;
            cmd.Parameters.Add("@DepId", SqlDbType.Int).Value = li_Organogram.DepId;
            cmd.Parameters.Add("@DesId", SqlDbType.Int).Value = li_Organogram.DesId;
            cmd.Parameters.Add("@JobNaId", SqlDbType.Int).Value = li_Organogram.JobNaId;
            cmd.Parameters.Add("@IsDefault", SqlDbType.Bit).Value = li_Organogram.IsDefault;
            cmd.Parameters.Add("@ReportToPosId", SqlDbType.Int).Value = li_Organogram.ReportToPosId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Organogram.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Organogram.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Organogram.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Organogram.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Organogram.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PosId"].Value;
        }
    }

    public bool UpdateLi_Organogram(Li_Organogram li_Organogram)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_Organogram", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@PosId", SqlDbType.Int).Value = li_Organogram.PosId;
            cmd.Parameters.Add("@PosTitle", SqlDbType.VarChar).Value = li_Organogram.PosTitle;
            cmd.Parameters.Add("@DepId", SqlDbType.Int).Value = li_Organogram.DepId;
            cmd.Parameters.Add("@DesId", SqlDbType.Int).Value = li_Organogram.DesId;
            cmd.Parameters.Add("@JobNaId", SqlDbType.Int).Value = li_Organogram.JobNaId;
            cmd.Parameters.Add("@IsDefault", SqlDbType.Bit).Value = li_Organogram.IsDefault;
            cmd.Parameters.Add("@ReportToPosId", SqlDbType.Int).Value = li_Organogram.ReportToPosId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Organogram.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Organogram.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Organogram.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Organogram.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Organogram.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
