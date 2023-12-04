using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;

public class SqlLi_DonPayTypeProvider:DataAccessObject
{
	public SqlLi_DonPayTypeProvider()
    {
    }


    public bool DeleteLi_DonPayType(int li_DonPayTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(" ", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ ", SqlDbType.Int).Value = li_DonPayTypeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_DonPayType> GetAllLi_DonPayTypes()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllLi_DonPayType", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_DonPayTypesFromReader(reader);
        }
    }
    public List<Li_DonPayType> GetLi_DonPayTypesFromReader(IDataReader reader)
    {
        List<Li_DonPayType> li_DonPayTypes = new List<Li_DonPayType>();

        while (reader.Read())
        {
            li_DonPayTypes.Add(GetLi_DonPayTypeFromReader(reader));
        }
        return li_DonPayTypes;
    }

    public Li_DonPayType GetLi_DonPayTypeFromReader(IDataReader reader)
    {
        try
        {
            Li_DonPayType li_DonPayType = new Li_DonPayType
                (
                    
                    (int)reader["PayTypId"],
                    reader["PayTypName"].ToString(),
                    (bool)reader["IsBank"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"]
                );
             return li_DonPayType;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_DonPayType GetLi_DonPayTypeByID(int li_DonPayTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand(" ", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ ", SqlDbType.Int).Value = li_DonPayTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_DonPayTypeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_DonPayType(Li_DonPayType li_DonPayType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(" ", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@PayTypId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PayTypName", SqlDbType.VarChar).Value = li_DonPayType.PayTypName;
            cmd.Parameters.Add("@IsBank", SqlDbType.Bit).Value = li_DonPayType.IsBank;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DonPayType.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DonPayType.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PayTypId"].Value;
        }
    }

    public bool UpdateLi_DonPayType(Li_DonPayType li_DonPayType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(" ", connection);
            cmd.CommandType = CommandType.StoredProcedure;
              
            cmd.Parameters.Add("@PayTypId", SqlDbType.Int).Value = li_DonPayType.PayTypId;
            cmd.Parameters.Add("@PayTypName", SqlDbType.VarChar).Value = li_DonPayType.PayTypName;
            cmd.Parameters.Add("@IsBank", SqlDbType.Bit).Value = li_DonPayType.IsBank;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DonPayType.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DonPayType.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetAllLi_DonAcountTypes()
    {
        DataSet ds = new DataSet();

        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("GetAllAccountType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            sda.Dispose();

            return ds;
        }
    }
}
