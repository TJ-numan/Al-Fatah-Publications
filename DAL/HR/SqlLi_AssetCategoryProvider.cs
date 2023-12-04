using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_AssetCategoryProvider:DataAccessObject
{
	public SqlLi_AssetCategoryProvider()
    {
    }


    public bool DeleteLi_AssetCategory(int li_AssetCategoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_AssetCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AssetCatId", SqlDbType.Int).Value = li_AssetCategoryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_AssetCategory> GetAllLi_AssetCategories()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_AssetCategories", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_AssetCategoriesFromReader(reader);
        }
    }
    public List<Li_AssetCategory> GetLi_AssetCategoriesFromReader(IDataReader reader)
    {
        List<Li_AssetCategory> li_AssetCategories = new List<Li_AssetCategory>();

        while (reader.Read())
        {
            li_AssetCategories.Add(GetLi_AssetCategoryFromReader(reader));
        }
        return li_AssetCategories;
    }

    public Li_AssetCategory GetLi_AssetCategoryFromReader(IDataReader reader)
    {
        try
        {
            Li_AssetCategory li_AssetCategory = new Li_AssetCategory
                (
                    
                    (int)reader["AssetCatId"],
                    reader["Category"].ToString(),
                    reader["CatePrefix"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_AssetCategory;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_AssetCategory GetLi_AssetCategoryByID(int li_AssetCategoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_AssetCategoryByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AssetCatId", SqlDbType.Int).Value = li_AssetCategoryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_AssetCategoryFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_AssetCategory(Li_AssetCategory li_AssetCategory)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_AssetCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@AssetCatId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = li_AssetCategory.Category;
            cmd.Parameters.Add("@CatePrefix", SqlDbType.VarChar).Value = li_AssetCategory.CatePrefix;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_AssetCategory.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_AssetCategory.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_AssetCategory.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_AssetCategory.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_AssetCategory.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AssetCatId"].Value;
        }
    }

    public bool UpdateLi_AssetCategory(Li_AssetCategory li_AssetCategory)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_AssetCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            cmd.Parameters.Add("@AssetCatId", SqlDbType.Int).Value = li_AssetCategory.AssetCatId;
            cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = li_AssetCategory.Category;
            cmd.Parameters.Add("@CatePrefix", SqlDbType.VarChar).Value = li_AssetCategory.CatePrefix;
            //cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_AssetCategory.CreatedBy;
            //cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_AssetCategory.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_AssetCategory.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_AssetCategory.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_AssetCategory.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public DataSet GetAllLi_AssetCategoryByID(int AssetCatID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_AssetCategoryByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AssetCatId", SqlDbType.Int).Value = AssetCatID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
}
