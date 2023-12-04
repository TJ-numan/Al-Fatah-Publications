using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_ResourcePerSkillProvider:DataAccessObject
{
	public SqlLi_ResourcePerSkillProvider()
    {
    }


    public bool DeleteLi_ResourcePerSkill(int li_ResourcePerSkillID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_ResourcePerSkill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ResoProfId", SqlDbType.Int).Value = li_ResourcePerSkillID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_ResourcePerSkill> GetAllLi_ResourcePerSkills()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_ResourcePerSkills", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ResourcePerSkillsFromReader(reader);
        }
    }
    public List<Li_ResourcePerSkill> GetLi_ResourcePerSkillsFromReader(IDataReader reader)
    {
        List<Li_ResourcePerSkill> li_ResourcePerSkills = new List<Li_ResourcePerSkill>();

        while (reader.Read())
        {
            li_ResourcePerSkills.Add(GetLi_ResourcePerSkillFromReader(reader));
        }
        return li_ResourcePerSkills;
    }

    public Li_ResourcePerSkill GetLi_ResourcePerSkillFromReader(IDataReader reader)
    {
        try
        {
            Li_ResourcePerSkill li_ResourcePerSkill = new Li_ResourcePerSkill
                (
               
                    (int)reader["ResoProfId"],
                    (int)reader["ResoPId"],
                    reader["ResoSkill"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_ResourcePerSkill;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_ResourcePerSkill GetLi_ResourcePerSkillByID(int li_ResourcePerSkillID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_ResourcePerSkillByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ResoProfId", SqlDbType.Int).Value = li_ResourcePerSkillID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ResourcePerSkillFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_ResourcePerSkill(Li_ResourcePerSkill li_ResourcePerSkill)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_ResourcePerSkill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@ResoProfId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ResoPId", SqlDbType.Int).Value = li_ResourcePerSkill.ResoPId;
            cmd.Parameters.Add("@ResoSkill", SqlDbType.VarChar).Value = li_ResourcePerSkill.ResoSkill;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ResourcePerSkill.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ResourcePerSkill.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ResourcePerSkill.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ResourcePerSkill.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_ResourcePerSkill.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ResoProfId"].Value;
        }
    }

    public bool UpdateLi_ResourcePerSkill(Li_ResourcePerSkill li_ResourcePerSkill)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM_UpdateLi_ResourcePerSkill", connection);
            cmd.CommandType = CommandType.StoredProcedure;
    
            cmd.Parameters.Add("@ResoProfId", SqlDbType.Int).Value = li_ResourcePerSkill.ResoProfId;
            cmd.Parameters.Add("@ResoPId", SqlDbType.Int).Value = li_ResourcePerSkill.ResoPId;
            cmd.Parameters.Add("@ResoSkill", SqlDbType.VarChar).Value = li_ResourcePerSkill.ResoSkill;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ResourcePerSkill.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ResourcePerSkill.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ResourcePerSkill.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ResourcePerSkill.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_ResourcePerSkill.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
