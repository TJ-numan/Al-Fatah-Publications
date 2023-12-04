using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_BloodGroupProvider:DataAccessObject
{
	public SqlLi_BloodGroupProvider()
    {
    }


    public bool DeleteLi_BloodGroup(int li_BloodGroupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_BloodGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BGId", SqlDbType.Int).Value = li_BloodGroupID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BloodGroup> GetAllLi_BloodGroups()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_BloodGroups", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BloodGroupsFromReader(reader);
        }
    }
    public List<Li_BloodGroup> GetLi_BloodGroupsFromReader(IDataReader reader)
    {
        List<Li_BloodGroup> li_BloodGroups = new List<Li_BloodGroup>();

        while (reader.Read())
        {
            li_BloodGroups.Add(GetLi_BloodGroupFromReader(reader));
        }
        return li_BloodGroups;
    }

    public Li_BloodGroup GetLi_BloodGroupFromReader(IDataReader reader)
    {
        try
        {
            Li_BloodGroup li_BloodGroup = new Li_BloodGroup
                (
                  
                    (int)reader["BGId"],
                    reader["BGName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_BloodGroup;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_BloodGroup GetLi_BloodGroupByID(int li_BloodGroupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_BloodGroupByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BGId", SqlDbType.Int).Value = li_BloodGroupID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BloodGroupFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_BloodGroup(Li_BloodGroup li_BloodGroup)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_BloodGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
    
            cmd.Parameters.Add("@BGId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BGName", SqlDbType.VarChar).Value = li_BloodGroup.BGName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BloodGroup.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BloodGroup.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_BloodGroup.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_BloodGroup.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_BloodGroup.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BGId"].Value;
        }
    }

    public bool UpdateLi_BloodGroup(Li_BloodGroup li_BloodGroup)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_BloodGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@BGId", SqlDbType.Int).Value = li_BloodGroup.BGId;
            cmd.Parameters.Add("@BGName", SqlDbType.VarChar).Value = li_BloodGroup.BGName; 
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_BloodGroup.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_BloodGroup.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_BloodGroup.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
