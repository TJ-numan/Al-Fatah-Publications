using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_JobCategoryProvider:DataAccessObject
{
	public SqlLi_JobCategoryProvider()
    {
    }


    public bool DeleteLi_JobCategory(int li_JobCategoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_JobCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobCatId", SqlDbType.Int).Value = li_JobCategoryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_JobCategory> GetAllLi_JobCategories()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_JobCategories", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_JobCategoriesFromReader(reader);
        }
    }
    public List<Li_JobCategory> GetLi_JobCategoriesFromReader(IDataReader reader)
    {
        List<Li_JobCategory> li_JobCategories = new List<Li_JobCategory>();

        while (reader.Read())
        {
            li_JobCategories.Add(GetLi_JobCategoryFromReader(reader));
        }
        return li_JobCategories;
    }

    public Li_JobCategory GetLi_JobCategoryFromReader(IDataReader reader)
    {
        try
        {
            Li_JobCategory li_JobCategory = new Li_JobCategory
                (
                     
                    (int)reader["JobCatId"],
                    reader["JobCatName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_JobCategory;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_JobCategory GetLi_JobCategoryByID(int li_JobCategoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_JobCategoryByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@JobCatId", SqlDbType.Int).Value = li_JobCategoryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_JobCategoryFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_JobCategory(Li_JobCategory li_JobCategory)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_JobCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@JobCatId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@JobCatName", SqlDbType.VarChar).Value = li_JobCategory.JobCatName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_JobCategory.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_JobCategory.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobCategory.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobCategory.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobCategory.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@JobCatId"].Value;
        }
    }

    public bool UpdateLi_JobCategory(Li_JobCategory li_JobCategory)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_JobCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@JobCatId", SqlDbType.Int).Value = li_JobCategory.JobCatId;
            cmd.Parameters.Add("@JobCatName", SqlDbType.VarChar).Value = li_JobCategory.JobCatName; 
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobCategory.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobCategory.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobCategory.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataTable LoadJobCategoryFromEmpInfos(int DepId,  int SecId )
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.LoadJobCategoryFromEmpInfos" ,connection);
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
