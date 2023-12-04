using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_EmpLanguageProvider:DataAccessObject
{
	public SqlLi_EmpLanguageProvider()
    {
    }


    public bool DeleteLi_EmpLanguage(int li_EmpLanguageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmpLanguage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LanId", SqlDbType.Int).Value = li_EmpLanguageID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmpLanguage> GetAllLi_EmpLanguages()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmpLanguages", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmpLanguagesFromReader(reader);
        }
    }
    public List<Li_EmpLanguage> GetLi_EmpLanguagesFromReader(IDataReader reader)
    {
        List<Li_EmpLanguage> li_EmpLanguages = new List<Li_EmpLanguage>();

        while (reader.Read())
        {
            li_EmpLanguages.Add(GetLi_EmpLanguageFromReader(reader));
        }
        return li_EmpLanguages;
    }

    public Li_EmpLanguage GetLi_EmpLanguageFromReader(IDataReader reader)
    {
        try
        {
            Li_EmpLanguage li_EmpLanguage = new Li_EmpLanguage
                (
                     
                    (int)reader["LanId"],
                    (int)reader["EmpSl"],
                    reader["Language"].ToString(),
                    reader["Reading"].ToString(),
                    reader["Writing"].ToString(),
                    reader["Speaking"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EmpLanguage;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmpLanguage GetLi_EmpLanguageByID(int li_EmpLanguageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmpLanguageByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LanId", SqlDbType.Int).Value = li_EmpLanguageID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmpLanguageFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmpLanguage(Li_EmpLanguage li_EmpLanguage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmpLanguage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@LanId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpLanguage.EmpSl;
            cmd.Parameters.Add("@Language", SqlDbType.VarChar).Value = li_EmpLanguage.Language;
            cmd.Parameters.Add("@Reading", SqlDbType.VarChar).Value = li_EmpLanguage.Reading;
            cmd.Parameters.Add("@Writing", SqlDbType.VarChar).Value = li_EmpLanguage.Writing;
            cmd.Parameters.Add("@Speaking", SqlDbType.VarChar).Value = li_EmpLanguage.Speaking;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpLanguage.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpLanguage.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpLanguage.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpLanguage.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpLanguage.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@LanId"].Value;
        }
    }

    public bool UpdateLi_EmpLanguage(Li_EmpLanguage li_EmpLanguage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmpLanguage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@LanId", SqlDbType.Int).Value = li_EmpLanguage.LanId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpLanguage.EmpSl;
            cmd.Parameters.Add("@Language", SqlDbType.VarChar).Value = li_EmpLanguage.Language;
            cmd.Parameters.Add("@Reading", SqlDbType.VarChar).Value = li_EmpLanguage.Reading;
            cmd.Parameters.Add("@Writing", SqlDbType.VarChar).Value = li_EmpLanguage.Writing;
            cmd.Parameters.Add("@Speaking", SqlDbType.VarChar).Value = li_EmpLanguage.Speaking;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpLanguage.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpLanguage.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpLanguage.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpLanguage.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpLanguage.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataTable LoadGvEmployeeInfo()
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.LoadGvEmployee", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();

            return dt;
        }
    }
    public DataTable LoadGvEmployeeLanguage()
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.LoadEmpLanguage", connection);
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
