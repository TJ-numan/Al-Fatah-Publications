using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BookRecFrBinderProvider:DataAccessObject
{
	public SqlLi_BookRecFrBinderProvider()
    {
    }


    public bool DeleteLi_BookRecFrBinder(int li_BookRecFrBinderID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BookRecFrBinder", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BookRecFrBinderID", SqlDbType.Int).Value = li_BookRecFrBinderID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BookRecFrBinder> GetAllLi_BookRecFrBinders()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BookRecFrBinders", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BookRecFrBindersFromReader(reader);
        }
    }
    public List<Li_BookRecFrBinder> GetLi_BookRecFrBindersFromReader(IDataReader reader)
    {
        List<Li_BookRecFrBinder> li_BookRecFrBinders = new List<Li_BookRecFrBinder>();

        while (reader.Read())
        {
            li_BookRecFrBinders.Add(GetLi_BookRecFrBinderFromReader(reader));
        }
        return li_BookRecFrBinders;
    }

    public Li_BookRecFrBinder GetLi_BookRecFrBinderFromReader(IDataReader reader)
    {
        try
        {
            Li_BookRecFrBinder li_BookRecFrBinder = new Li_BookRecFrBinder
                (
                    
                    (int)reader["SerialNo"],
                    reader["BookCode"].ToString(),
                    reader["BinderID"].ToString(),
                    (int)reader["Qty"],
                    (DateTime)reader["CollectionDate"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"] 
                );
             return li_BookRecFrBinder;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_BookRecFrBinder GetLi_BookRecFrBinderByID(int li_BookRecFrBinderID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BookRecFrBinderByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_BookRecFrBinderID", SqlDbType.Int).Value = li_BookRecFrBinderID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BookRecFrBinderFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_BookRecFrBinder(Li_BookRecFrBinder li_BookRecFrBinder)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BookRecFrBinder", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int) .Direction = ParameterDirection.Output;
         
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BookRecFrBinder.BookCode;
            cmd.Parameters.Add("@BinderID", SqlDbType.VarChar).Value = li_BookRecFrBinder.BinderID;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_BookRecFrBinder.Qty;
            cmd.Parameters.Add("@CollectionDate", SqlDbType.DateTime).Value = li_BookRecFrBinder.CollectionDate;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookRecFrBinder.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookRecFrBinder.CreatedBy;
          
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_BookRecFrBinder(Li_BookRecFrBinder li_BookRecFrBinder)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BookRecFrBinder", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_BookRecFrBinder.SerialNo;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BookRecFrBinder.BookCode;
            cmd.Parameters.Add("@BinderID", SqlDbType.VarChar).Value = li_BookRecFrBinder.BinderID;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_BookRecFrBinder.Qty;
            cmd.Parameters.Add("@CollectionDate", SqlDbType.DateTime).Value = li_BookRecFrBinder.CollectionDate;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookRecFrBinder.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookRecFrBinder.CreatedBy;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
