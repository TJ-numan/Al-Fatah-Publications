using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_AssetBrandProvider:DataAccessObject
{
	public SqlLi_AssetBrandProvider()
    {
    }


    public bool DeleteLi_AssetBrand(int li_AssetBrandID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_AssetBrand", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BrandId", SqlDbType.Int).Value = li_AssetBrandID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_AssetBrand> GetAllLi_AssetBrands()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_AssetBrands", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_AssetBrandsFromReader(reader);
        }
    }
    public List<Li_AssetBrand> GetLi_AssetBrandsFromReader(IDataReader reader)
    {
        List<Li_AssetBrand> li_AssetBrands = new List<Li_AssetBrand>();

        while (reader.Read())
        {
            li_AssetBrands.Add(GetLi_AssetBrandFromReader(reader));
        }
        return li_AssetBrands;
    }

    public Li_AssetBrand GetLi_AssetBrandFromReader(IDataReader reader)
    {
        try
        {
            Li_AssetBrand li_AssetBrand = new Li_AssetBrand
                (
            
                    (int)reader["BrandId"],
                    reader["BrandName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_AssetBrand;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_AssetBrand GetLi_AssetBrandByID(int li_AssetBrandID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_AssetBrandByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_AssetBrandID", SqlDbType.Int).Value = li_AssetBrandID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_AssetBrandFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_AssetBrand(Li_AssetBrand li_AssetBrand)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_AssetBrand", connection);
            cmd.CommandType = CommandType.StoredProcedure;
      
            cmd.Parameters.Add("@BrandId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BrandName", SqlDbType.VarChar).Value = li_AssetBrand.BrandName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_AssetBrand.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_AssetBrand.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_AssetBrand.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_AssetBrand.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_AssetBrand.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BrandId"].Value;
        }
    }

    public bool UpdateLi_AssetBrand(Li_AssetBrand li_AssetBrand)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_AssetBrand", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@BrandId", SqlDbType.Int).Value = li_AssetBrand.BrandId;
            cmd.Parameters.Add("@BrandName", SqlDbType.VarChar).Value = li_AssetBrand.BrandName;
            //cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_AssetBrand.CreatedBy;
            //cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_AssetBrand.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_AssetBrand.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_AssetBrand.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_AssetBrand.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetAllLi_AssetBrandByID(int  BrandID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_AssetBrandByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BrandId", SqlDbType.Int).Value =  BrandID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
}
