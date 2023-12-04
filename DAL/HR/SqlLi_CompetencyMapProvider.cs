using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_CompetencyMapProvider:DataAccessObject
{
	public SqlLi_CompetencyMapProvider()
    {
    }


    public bool DeleteLi_CompetencyMap(int li_CompetencyMapID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_CompetencyMap", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CoMapId", SqlDbType.Int).Value = li_CompetencyMapID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_CompetencyMap> GetAllLi_CompetencyMaps()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_CompetencyMaps", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_CompetencyMapsFromReader(reader);
        }
    }
    public List<Li_CompetencyMap> GetLi_CompetencyMapsFromReader(IDataReader reader)
    {
        List<Li_CompetencyMap> li_CompetencyMaps = new List<Li_CompetencyMap>();

        while (reader.Read())
        {
            li_CompetencyMaps.Add(GetLi_CompetencyMapFromReader(reader));
        }
        return li_CompetencyMaps;
    }

    public Li_CompetencyMap GetLi_CompetencyMapFromReader(IDataReader reader)
    {
        try
        {
            Li_CompetencyMap li_CompetencyMap = new Li_CompetencyMap
                (
     
                    (int)reader["CoMapId"],
                    (int)reader["CompeId"],
                    (int)reader["EmpSl"],
                    (decimal)reader["Weight"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_CompetencyMap;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_CompetencyMap GetLi_CompetencyMapByID(int li_CompetencyMapID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_CompetencyMapByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CoMapId", SqlDbType.Int).Value = li_CompetencyMapID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_CompetencyMapFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_CompetencyMap(Li_CompetencyMap li_CompetencyMap)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_CompetencyMap", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@CoMapId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CompeId", SqlDbType.Int).Value = li_CompetencyMap.CompeId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_CompetencyMap.EmpSl;
            cmd.Parameters.Add("@Weight", SqlDbType.Decimal).Value = li_CompetencyMap.Weight;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_CompetencyMap.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_CompetencyMap.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_CompetencyMap.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_CompetencyMap.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_CompetencyMap.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CoMapId"].Value;
        }
    }

    public bool UpdateLi_CompetencyMap(Li_CompetencyMap li_CompetencyMap)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_CompetencyMap", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@CoMapId", SqlDbType.Int).Value = li_CompetencyMap.CoMapId;
            cmd.Parameters.Add("@CompeId", SqlDbType.Int).Value = li_CompetencyMap.CompeId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_CompetencyMap.EmpSl;
            cmd.Parameters.Add("@Weight", SqlDbType.Decimal).Value = li_CompetencyMap.Weight;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_CompetencyMap.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_CompetencyMap.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_CompetencyMap.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_CompetencyMap.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_CompetencyMap.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
