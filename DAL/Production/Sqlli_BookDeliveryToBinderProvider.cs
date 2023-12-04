using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BookDeliveryToBinderProvider:DataAccessObject
{
	public SqlLi_BookDeliveryToBinderProvider()
    {
    }


    public bool DeleteLi_BookDeliveryToBinder(int li_BookDeliveryToBinderID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BookDeliveryToBinder", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BookDeliveryToBinderID", SqlDbType.Int).Value = li_BookDeliveryToBinderID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BookDeliveryToBinder> GetAllLi_BookDeliveryToBinders()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BookDeliveryToBinders", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BookDeliveryToBindersFromReader(reader);
        }
    }
    public List<Li_BookDeliveryToBinder> GetLi_BookDeliveryToBindersFromReader(IDataReader reader)
    {
        List<Li_BookDeliveryToBinder> li_BookDeliveryToBinders = new List<Li_BookDeliveryToBinder>();

        while (reader.Read())
        {
            li_BookDeliveryToBinders.Add(GetLi_BookDeliveryToBinderFromReader(reader));
        }
        return li_BookDeliveryToBinders;
    }

    public Li_BookDeliveryToBinder GetLi_BookDeliveryToBinderFromReader(IDataReader reader)
    {
        try
        {
            Li_BookDeliveryToBinder li_BookDeliveryToBinder = new Li_BookDeliveryToBinder
                (
                     
                    (int)reader["DeID"],
                    reader["BookCode"].ToString(),
                    reader["Edition"].ToString(),
                    (int)reader["PrintNo"],
                    (decimal)reader["PrintQty"],
                    (DateTime)reader["DeliveryDate"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (char)reader["Status_D"],
                    (bool)reader ["IsForma"]
                     
                );
             return li_BookDeliveryToBinder;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_BookDeliveryToBinder GetLi_BookDeliveryToBinderByID(int li_BookDeliveryToBinderID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BookDeliveryToBinderByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_BookDeliveryToBinderID", SqlDbType.Int).Value = li_BookDeliveryToBinderID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BookDeliveryToBinderFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_BookDeliveryToBinder(Li_BookDeliveryToBinder li_BookDeliveryToBinder)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BookDeliveryToBinder", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@DeID", SqlDbType.Int)  .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BookDeliveryToBinder.BookCode;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_BookDeliveryToBinder.Edition;
            cmd.Parameters.Add("@PrintNo", SqlDbType.Int).Value = li_BookDeliveryToBinder.PrintNo;
            cmd.Parameters.Add("@PrintQty", SqlDbType.Decimal).Value = li_BookDeliveryToBinder.PrintQty;
            cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = li_BookDeliveryToBinder.DeliveryDate;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookDeliveryToBinder.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookDeliveryToBinder.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_BookDeliveryToBinder.Status_D;
            cmd.Parameters.Add("@IsForma", SqlDbType.VarChar).Value = li_BookDeliveryToBinder.IsForma;          
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DeID"].Value;
        }
    }

    public bool UpdateLi_BookDeliveryToBinder(Li_BookDeliveryToBinder li_BookDeliveryToBinder)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BookDeliveryToBinder", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@DeID", SqlDbType.Int).Value = li_BookDeliveryToBinder.DeID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BookDeliveryToBinder.BookCode;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_BookDeliveryToBinder.Edition;
            cmd.Parameters.Add("@PrintNo", SqlDbType.Int).Value = li_BookDeliveryToBinder.PrintNo;
            cmd.Parameters.Add("@PrintQty", SqlDbType.Decimal).Value = li_BookDeliveryToBinder.PrintQty;
            cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = li_BookDeliveryToBinder.DeliveryDate;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookDeliveryToBinder.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookDeliveryToBinder.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_BookDeliveryToBinder.Status_D;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
