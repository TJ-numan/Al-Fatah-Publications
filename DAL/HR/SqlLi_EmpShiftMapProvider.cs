using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_EmpShiftMapProvider:DataAccessObject
{
	public SqlLi_EmpShiftMapProvider()
    {
    }


    public bool DeleteLi_EmpShiftMap(int li_EmpShiftMapID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmpShiftMap", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmpMapId", SqlDbType.Int).Value = li_EmpShiftMapID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmpShiftMap> GetAllLi_EmpShiftMaps()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmpShiftMaps", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmpShiftMapsFromReader(reader);
        }
    }
    public List<Li_EmpShiftMap> GetLi_EmpShiftMapsFromReader(IDataReader reader)
    {
        List<Li_EmpShiftMap> li_EmpShiftMaps = new List<Li_EmpShiftMap>();

        while (reader.Read())
        {
            li_EmpShiftMaps.Add(GetLi_EmpShiftMapFromReader(reader));
        }
        return li_EmpShiftMaps;
    }

    public Li_EmpShiftMap GetLi_EmpShiftMapFromReader(IDataReader reader)
    {
        try
        {
            Li_EmpShiftMap li_EmpShiftMap = new Li_EmpShiftMap
                (
            
                    (int)reader["EmpMapId"],
                    (int)reader["EmpSl"],
                    (int)reader["ShiftId"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EmpShiftMap;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmpShiftMap GetLi_EmpShiftMapByID(int li_EmpShiftMapID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmpShiftMapByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmpMapId", SqlDbType.Int).Value = li_EmpShiftMapID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmpShiftMapFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmpShiftMap(Li_EmpShiftMap li_EmpShiftMap)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmpShiftMap", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@EmpMapId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpShiftMap.EmpSl;
            cmd.Parameters.Add("@ShiftId", SqlDbType.Int).Value = li_EmpShiftMap.ShiftId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpShiftMap.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpShiftMap.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpShiftMap.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpShiftMap.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpShiftMap.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EmpMapId"].Value;
        }
    }

    public bool UpdateLi_EmpShiftMap(Li_EmpShiftMap li_EmpShiftMap)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmpShiftMap", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@EmpMapId", SqlDbType.Int).Value = li_EmpShiftMap.EmpMapId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpShiftMap.EmpSl;
            cmd.Parameters.Add("@ShiftId", SqlDbType.Int).Value = li_EmpShiftMap.ShiftId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpShiftMap.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpShiftMap.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpShiftMap.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpShiftMap.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpShiftMap.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
