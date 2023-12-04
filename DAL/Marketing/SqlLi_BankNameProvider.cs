using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using Common;
using DAL;

public class SqlLi_BankNameProvider:DataAccessObject
{
	public SqlLi_BankNameProvider()
    {
    }


    public bool DeleteLi_BankName(int li_BankNameID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BankName", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BankNameID", SqlDbType.Int).Value = li_BankNameID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BankName> GetAllLi_BankNames()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BankNames", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BankNamesFromReader(reader);
        }
    }
    public List<Li_BankName> GetLi_BankNamesFromReader(IDataReader reader)
    {
        List<Li_BankName> li_BankNames = new List<Li_BankName>();

        while (reader.Read())
        {
            li_BankNames.Add(GetLi_BankNameFromReader(reader));
        }
        return li_BankNames;
    }

    public Li_BankName GetLi_BankNameFromReader(IDataReader reader)
    {
        try
        {
            Li_BankName li_BankName = new Li_BankName
                (
                    
                    (int)reader["ID"],
                    reader["BankCode"].ToString(),
                    reader["BankName"].ToString(),
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CeatedBy"] 
                    
                );
             return li_BankName;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_BankName GetLi_BankNameByID(int li_BankNameID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BankNameByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_BankNameID", SqlDbType.Int).Value = li_BankNameID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BankNameFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_BankName(Li_BankName li_BankName)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BankName", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = li_BankName.ID;
            cmd.Parameters.Add("@BankCode", SqlDbType.VarChar).Value = li_BankName.BankCode;
            cmd.Parameters.Add("@BankName", SqlDbType.VarChar).Value = li_BankName.BankName;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BankName.CreatedDate;
            cmd.Parameters.Add("@CeatedBy", SqlDbType.Int).Value = li_BankName.CeatedBy;
          
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1; // (int)cmd.Parameters["@Li_BankNameID"].Value;
        }
    }

    public bool UpdateLi_BankName(Li_BankName li_BankName)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BankName", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = li_BankName.ID;
            cmd.Parameters.Add("@BankCode", SqlDbType.VarChar).Value = li_BankName.BankCode;
            cmd.Parameters.Add("@BankName", SqlDbType.VarChar).Value = li_BankName.BankName;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BankName.CreatedDate;
            cmd.Parameters.Add("@CeatedBy", SqlDbType.Int).Value = li_BankName.CeatedBy;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetAllLi_Payfor()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PayFors", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    
}
