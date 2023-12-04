using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_TraningFeedBackProvider:DataAccessObject
{
	public SqlLi_TraningFeedBackProvider()
    {
    }


    public bool DeleteLi_TraningFeedBack(int li_TraningFeedBackID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_TraningFeedBack", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TrainFId", SqlDbType.Int).Value = li_TraningFeedBackID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_TraningFeedBack> GetAllLi_TraningFeedBacks()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_TraningFeedBacks", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_TraningFeedBacksFromReader(reader);
        }
    }
    public List<Li_TraningFeedBack> GetLi_TraningFeedBacksFromReader(IDataReader reader)
    {
        List<Li_TraningFeedBack> li_TraningFeedBacks = new List<Li_TraningFeedBack>();

        while (reader.Read())
        {
            li_TraningFeedBacks.Add(GetLi_TraningFeedBackFromReader(reader));
        }
        return li_TraningFeedBacks;
    }

    public Li_TraningFeedBack GetLi_TraningFeedBackFromReader(IDataReader reader)
    {
        try
        {
            Li_TraningFeedBack li_TraningFeedBack = new Li_TraningFeedBack
                (
              
                    (int)reader["TrainFId"],
                    (int)reader["TrainFeedback"],
                    (int)reader["TrainAppId"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_TraningFeedBack;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_TraningFeedBack GetLi_TraningFeedBackByID(int li_TraningFeedBackID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_TraningFeedBackByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TrainFId", SqlDbType.Int).Value = li_TraningFeedBackID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_TraningFeedBackFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_TraningFeedBack(Li_TraningFeedBack li_TraningFeedBack)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_TraningFeedBack", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@TrainFId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TrainFeedback", SqlDbType.Int).Value = li_TraningFeedBack.TrainFeedback;
            cmd.Parameters.Add("@TrainAppId", SqlDbType.Int).Value = li_TraningFeedBack.TrainAppId;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_TraningFeedBack.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_TraningFeedBack.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TraningFeedBack.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_TraningFeedBack.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_TraningFeedBack.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_TraningFeedBack.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@TrainFId"].Value;
        }
    }

    public bool UpdateLi_TraningFeedBack(Li_TraningFeedBack li_TraningFeedBack)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_TraningFeedBack", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@TrainFId", SqlDbType.Int).Value = li_TraningFeedBack.TrainFId;
            cmd.Parameters.Add("@TrainFeedback", SqlDbType.Int).Value = li_TraningFeedBack.TrainFeedback;
            cmd.Parameters.Add("@TrainAppId", SqlDbType.Int).Value = li_TraningFeedBack.TrainAppId;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_TraningFeedBack.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_TraningFeedBack.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TraningFeedBack.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_TraningFeedBack.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_TraningFeedBack.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_TraningFeedBack.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
