using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_AssetVendorProvider:DataAccessObject
{
	public SqlLi_AssetVendorProvider()
    {
    }


    public bool DeleteLi_AssetVendor(int li_AssetVendorID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_AssetVendor", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AssetVenId", SqlDbType.Int).Value = li_AssetVendorID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_AssetVendor> GetAllLi_AssetVendors()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_AssetVendors", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_AssetVendorsFromReader(reader);
        }
    }
    public List<Li_AssetVendor> GetLi_AssetVendorsFromReader(IDataReader reader)
    {
        List<Li_AssetVendor> li_AssetVendors = new List<Li_AssetVendor>();

        while (reader.Read())
        {
            li_AssetVendors.Add(GetLi_AssetVendorFromReader(reader));
        }
        return li_AssetVendors;
    }

    public Li_AssetVendor GetLi_AssetVendorFromReader(IDataReader reader)
    {
        try
        {
            Li_AssetVendor li_AssetVendor = new Li_AssetVendor
                (
                     
                    (int)reader["AssetVenId"],
                    reader["VendorName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_AssetVendor;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_AssetVendor GetLi_AssetVendorByID(int li_AssetVendorID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_AssetVendorByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AssetVenId", SqlDbType.Int).Value = li_AssetVendorID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_AssetVendorFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_AssetVendor(Li_AssetVendor li_AssetVendor)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_AssetVendor", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@AssetVenId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@VendorName", SqlDbType.VarChar).Value = li_AssetVendor.VendorName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_AssetVendor.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_AssetVendor.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_AssetVendor.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_AssetVendor.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_AssetVendor.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AssetVenId"].Value;
        }
    }

    public bool UpdateLi_AssetVendor(Li_AssetVendor li_AssetVendor)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_AssetVendor", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@AssetVenId", SqlDbType.Int).Value = li_AssetVendor.AssetVenId;
            cmd.Parameters.Add("@VendorName", SqlDbType.VarChar).Value = li_AssetVendor.VendorName;
            //cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_AssetVendor.CreatedBy;
            //cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_AssetVendor.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_AssetVendor.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_AssetVendor.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_AssetVendor.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetAllLi_AssetVendorByID(int AssetVendorID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_AssetVendorByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AssetVenId", SqlDbType.Int).Value = AssetVendorID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
}
