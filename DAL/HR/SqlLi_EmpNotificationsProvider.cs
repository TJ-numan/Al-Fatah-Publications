using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_EmpNotificationsProvider:DataAccessObject
{
	public SqlLi_EmpNotificationsProvider()
    {
    }


    public bool DeleteLi_EmpNotifications(int li_EmpNotificationsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmpNotifications", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NotId", SqlDbType.Int).Value = li_EmpNotificationsID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmpNotifications> GetAllLi_EmpNotificationss()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmpNotificationss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmpNotificationssFromReader(reader);
        }
    }
    public List<Li_EmpNotifications> GetLi_EmpNotificationssFromReader(IDataReader reader)
    {
        List<Li_EmpNotifications> li_EmpNotificationss = new List<Li_EmpNotifications>();

        while (reader.Read())
        {
            li_EmpNotificationss.Add(GetLi_EmpNotificationsFromReader(reader));
        }
        return li_EmpNotificationss;
    }

    public Li_EmpNotifications GetLi_EmpNotificationsFromReader(IDataReader reader)
    {
        try
        {
            Li_EmpNotifications li_EmpNotifications = new Li_EmpNotifications
                (
                   
                    (int)reader["NotId"],
                    reader["NotTitle"].ToString(),
                    reader["NotDes"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EmpNotifications;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmpNotifications GetLi_EmpNotificationsByID(int li_EmpNotificationsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmpNotificationsByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@NotId", SqlDbType.Int).Value = li_EmpNotificationsID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmpNotificationsFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmpNotifications(Li_EmpNotifications li_EmpNotifications)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmpNotifications", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@NotId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@NotTitle", SqlDbType.VarChar).Value = li_EmpNotifications.NotTitle;
            cmd.Parameters.Add("@NotDes", SqlDbType.VarChar).Value = li_EmpNotifications.NotDes;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpNotifications.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpNotifications.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpNotifications.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpNotifications.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpNotifications.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@NotId"].Value;
        }
    }

    public bool UpdateLi_EmpNotifications(Li_EmpNotifications li_EmpNotifications)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmpNotifications", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@NotId", SqlDbType.Int).Value = li_EmpNotifications.NotId;
            cmd.Parameters.Add("@NotTitle", SqlDbType.VarChar).Value = li_EmpNotifications.NotTitle;
            cmd.Parameters.Add("@NotDes", SqlDbType.VarChar).Value = li_EmpNotifications.NotDes;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpNotifications.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpNotifications.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpNotifications.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpNotifications.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpNotifications.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
