using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_JobLocationProvider:DataAccessObject
{
	public SqlLi_JobLocationProvider()
    {
    }


    public bool DeleteLi_JobLocation(int li_JobLocationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_JobLocation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LocId", SqlDbType.Int).Value = li_JobLocationID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_JobLocation> GetAllLi_JobLocations()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_JobLocations", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_JobLocationsFromReader(reader);
        }
    }
    public List<Li_JobLocation> GetLi_JobLocationsFromReader(IDataReader reader)
    {
        List<Li_JobLocation> li_JobLocations = new List<Li_JobLocation>();

        while (reader.Read())
        {
            li_JobLocations.Add(GetLi_JobLocationFromReader(reader));
        }
        return li_JobLocations;
    }

    public Li_JobLocation GetLi_JobLocationFromReader(IDataReader reader)
    {
        try
        {
            Li_JobLocation li_JobLocation = new Li_JobLocation
                (
                    
                    (int)reader["LocId"],
                    reader["LocName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_JobLocation;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_JobLocation GetLi_JobLocationByID(int li_JobLocationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_JobLocationByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LocId", SqlDbType.Int).Value = li_JobLocationID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_JobLocationFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_JobLocation(Li_JobLocation li_JobLocation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_JobLocation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@LocId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@LocName", SqlDbType.VarChar).Value = li_JobLocation.LocName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_JobLocation.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_JobLocation.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobLocation.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobLocation.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobLocation.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@LocId"].Value;
        }
    }

    public bool UpdateLi_JobLocation(Li_JobLocation li_JobLocation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_JobLocation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
   
            cmd.Parameters.Add("@LocId", SqlDbType.Int).Value = li_JobLocation.LocId;
            cmd.Parameters.Add("@LocName", SqlDbType.VarChar).Value = li_JobLocation.LocName; 
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobLocation.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobLocation.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobLocation.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
