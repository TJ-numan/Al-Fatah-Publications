using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_EmpSkillsProvider:DataAccessObject
{
	public SqlLi_EmpSkillsProvider()
    {
    }


    public bool DeleteLi_EmpSkills(int li_EmpSkillsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmpSkills", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SkilId", SqlDbType.Int).Value = li_EmpSkillsID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmpSkills> GetAllLi_EmpSkillss()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmpSkillss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmpSkillssFromReader(reader);
        }
    }
    public List<Li_EmpSkills> GetLi_EmpSkillssFromReader(IDataReader reader)
    {
        List<Li_EmpSkills> li_EmpSkillss = new List<Li_EmpSkills>();

        while (reader.Read())
        {
            li_EmpSkillss.Add(GetLi_EmpSkillsFromReader(reader));
        }
        return li_EmpSkillss;
    }

    public Li_EmpSkills GetLi_EmpSkillsFromReader(IDataReader reader)
    {
        try
        {
            Li_EmpSkills li_EmpSkills = new Li_EmpSkills
                (
                    
                    (int)reader["SkilId"],
                    (int)reader["EmpSl"],
                    reader["Skills"].ToString(),
                    reader["SkilDes"].ToString(),
                    reader["ExtraActivities"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EmpSkills;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmpSkills GetLi_EmpSkillsByID(int li_EmpSkillsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmpSkillsByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SkilId", SqlDbType.Int).Value = li_EmpSkillsID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmpSkillsFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmpSkills(Li_EmpSkills li_EmpSkills)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmpSkills", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@SkilId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpSkills.EmpSl;
            cmd.Parameters.Add("@Skills", SqlDbType.VarChar).Value = li_EmpSkills.Skills;
            cmd.Parameters.Add("@SkilDes", SqlDbType.VarChar).Value = li_EmpSkills.SkilDes;
            cmd.Parameters.Add("@ExtraActivities", SqlDbType.VarChar).Value = li_EmpSkills.ExtraActivities;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpSkills.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpSkills.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpSkills.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpSkills.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpSkills.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SkilId"].Value;
        }
    }

    public bool UpdateLi_EmpSkills(Li_EmpSkills li_EmpSkills)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmpSkills", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@SkilId", SqlDbType.Int).Value = li_EmpSkills.SkilId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpSkills.EmpSl;
            cmd.Parameters.Add("@Skills", SqlDbType.VarChar).Value = li_EmpSkills.Skills;
            cmd.Parameters.Add("@SkilDes", SqlDbType.VarChar).Value = li_EmpSkills.SkilDes;
            cmd.Parameters.Add("@ExtraActivities", SqlDbType.VarChar).Value = li_EmpSkills.ExtraActivities;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpSkills.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpSkills.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpSkills.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpSkills.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpSkills.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataTable LoadGvEmpSkill()
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.LoadGvEmployeeSkill", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();

            return dt;
        }
    }
}
