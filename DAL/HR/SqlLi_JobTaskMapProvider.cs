using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_JobTaskMapProvider:DataAccessObject
{
	public SqlLi_JobTaskMapProvider()
    {
    }


    public bool DeleteLi_JobTaskMap(int li_JobTaskMapID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_JobTaskMap", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DepId", SqlDbType.Int).Value = li_JobTaskMapID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_JobTaskMap> GetAllLi_JobTaskMaps()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_JobTaskMaps", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_JobTaskMapsFromReader(reader);
        }
    }
    public List<Li_JobTaskMap> GetLi_JobTaskMapsFromReader(IDataReader reader)
    {
        List<Li_JobTaskMap> li_JobTaskMaps = new List<Li_JobTaskMap>();

        while (reader.Read())
        {
            li_JobTaskMaps.Add(GetLi_JobTaskMapFromReader(reader));
        }
        return li_JobTaskMaps;
    }

    public Li_JobTaskMap GetLi_JobTaskMapFromReader(IDataReader reader)
    {
        try
        {
            Li_JobTaskMap li_JobTaskMap = new Li_JobTaskMap
                (
                  
                    (int)reader["DepId"],
                    (int)reader["JobTaskId"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_JobTaskMap;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_JobTaskMap GetLi_JobTaskMapByID(int li_JobTaskMapID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_JobTaskMapByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DepId", SqlDbType.Int).Value = li_JobTaskMapID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_JobTaskMapFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_JobTaskMap(Li_JobTaskMap li_JobTaskMap)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_JobTaskMap", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@DepId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@JobTaskId", SqlDbType.Int).Value = li_JobTaskMap.JobTaskId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_JobTaskMap.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_JobTaskMap.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobTaskMap.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobTaskMap.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobTaskMap.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DepId"].Value;
        }
    }

    public bool UpdateLi_JobTaskMap(Li_JobTaskMap li_JobTaskMap)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_JobTaskMap", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@DepId", SqlDbType.Int).Value = li_JobTaskMap.DepId;
            cmd.Parameters.Add("@JobTaskId", SqlDbType.Int).Value = li_JobTaskMap.JobTaskId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_JobTaskMap.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_JobTaskMap.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobTaskMap.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobTaskMap.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobTaskMap.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
