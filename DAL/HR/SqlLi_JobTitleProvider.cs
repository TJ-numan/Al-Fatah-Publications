using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_JobTitleProvider:DataAccessObject
{
	public SqlLi_JobTitleProvider()
    {
    }


    public bool DeleteLi_JobTitle(int li_JobTitleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_JobTitle", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobTiId", SqlDbType.Int).Value = li_JobTitleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_JobTitle> GetAllLi_JobTitles()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_JobTitles", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_JobTitlesFromReader(reader);
        }
    }
    public List<Li_JobTitle> GetLi_JobTitlesFromReader(IDataReader reader)
    {
        List<Li_JobTitle> li_JobTitles = new List<Li_JobTitle>();

        while (reader.Read())
        {
            li_JobTitles.Add(GetLi_JobTitleFromReader(reader));
        }
        return li_JobTitles;
    }

    public Li_JobTitle GetLi_JobTitleFromReader(IDataReader reader)
    {
        try
        {
            Li_JobTitle li_JobTitle = new Li_JobTitle
                (
                  
                    (int)reader["JobTiId"],
                    reader["JobTiName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_JobTitle;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_JobTitle GetLi_JobTitleByID(int li_JobTitleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_JobTitleByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@JobTiId", SqlDbType.Int).Value = li_JobTitleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_JobTitleFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_JobTitle(Li_JobTitle li_JobTitle)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_JobTitle", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@JobTiId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@JobTiName", SqlDbType.VarChar).Value = li_JobTitle.JobTiName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_JobTitle.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_JobTitle.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobTitle.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobTitle.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobTitle.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@JobTiId"].Value;
        }
    }

    public bool UpdateLi_JobTitle(Li_JobTitle li_JobTitle)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_JobTitle", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@JobTiId", SqlDbType.Int).Value = li_JobTitle.JobTiId;
            cmd.Parameters.Add("@JobTiName", SqlDbType.VarChar).Value = li_JobTitle.JobTiName; 
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobTitle.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobTitle.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobTitle.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataTable LoadJobTitleFromEmpInfos(int DepId, int SecId )
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.loadJobTitleFromEmpInfos",connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DepId", SqlDbType.Int).Value = DepId;
            cmd.Parameters.Add("@SecId", SqlDbType.Int).Value = SecId ;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(dt);
            myadapter.Dispose();
            connection.Close();
            return dt;
        }
    }
}
