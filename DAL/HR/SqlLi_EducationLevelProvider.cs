using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_EducationLevelProvider:DataAccessObject
{
	public SqlLi_EducationLevelProvider()
    {
    }


    public bool DeleteLi_EducationLevel(int li_EducationLevelID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EducationLevel", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EduLId", SqlDbType.Int).Value = li_EducationLevelID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EducationLevel> GetAllLi_EducationLevels()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EducationLevels", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EducationLevelsFromReader(reader);
        }
    }
    public List<Li_EducationLevel> GetLi_EducationLevelsFromReader(IDataReader reader)
    {
        List<Li_EducationLevel> li_EducationLevels = new List<Li_EducationLevel>();

        while (reader.Read())
        {
            li_EducationLevels.Add(GetLi_EducationLevelFromReader(reader));
        }
        return li_EducationLevels;
    }

    public Li_EducationLevel GetLi_EducationLevelFromReader(IDataReader reader)
    {
        try
        {
            Li_EducationLevel li_EducationLevel = new Li_EducationLevel
                (
                   
                    (int)reader["EduLId"],
                    reader["EduLevelName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EducationLevel;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EducationLevel GetLi_EducationLevelByID(int li_EducationLevelID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EducationLevelByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EduLId", SqlDbType.Int).Value = li_EducationLevelID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EducationLevelFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EducationLevel(Li_EducationLevel li_EducationLevel)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EducationLevel", connection);
            cmd.CommandType = CommandType.StoredProcedure;
    
            cmd.Parameters.Add("@EduLId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EduLevelName", SqlDbType.VarChar).Value = li_EducationLevel.EduLevelName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EducationLevel.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EducationLevel.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EducationLevel.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EducationLevel.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EducationLevel.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EduLId"].Value;
        }
    }

    public bool UpdateLi_EducationLevel(Li_EducationLevel li_EducationLevel)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EducationLevel", connection);
            cmd.CommandType = CommandType.StoredProcedure;
      
            cmd.Parameters.Add("@EduLId", SqlDbType.Int).Value = li_EducationLevel.EduLId;
            cmd.Parameters.Add("@EduLevelName", SqlDbType.VarChar).Value = li_EducationLevel.EduLevelName; 
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EducationLevel.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EducationLevel.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EducationLevel.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
