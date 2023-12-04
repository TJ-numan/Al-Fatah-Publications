using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_CvBankProvider:DataAccessObject
{
	public SqlLi_CvBankProvider()
    {
    }


    public bool DeleteLi_CvBank(int li_CvBankID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_CvBank", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CvId", SqlDbType.Int).Value = li_CvBankID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_CvBank> GetAllLi_CvBanks()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_CvBanks", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_CvBanksFromReader(reader);
        }
    }
    public List<Li_CvBank> GetLi_CvBanksFromReader(IDataReader reader)
    {
        List<Li_CvBank> li_CvBanks = new List<Li_CvBank>();

        while (reader.Read())
        {
            li_CvBanks.Add(GetLi_CvBankFromReader(reader));
        }
        return li_CvBanks;
    }

    public Li_CvBank GetLi_CvBankFromReader(IDataReader reader)
    {
        try
        {
            Li_CvBank li_CvBank = new Li_CvBank
                ( 
                    (int)reader["CvId"],
                    (int)reader["VacAnId"],
                    reader["CvPath"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_CvBank;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_CvBank GetLi_CvBankByID(int li_CvBankID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_CvBankByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CvId", SqlDbType.Int).Value = li_CvBankID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_CvBankFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_CvBank(Li_CvBank li_CvBank)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_CvBank", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@CvId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@VacAnId", SqlDbType.Int).Value = li_CvBank.VacAnId;
            cmd.Parameters.Add("@CvPath", SqlDbType.VarChar).Value = li_CvBank.CvPath;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_CvBank.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_CvBank.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_CvBank.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_CvBank.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_CvBank.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CvId"].Value;
        }
    }

    public bool UpdateLi_CvBank(Li_CvBank li_CvBank)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_CvBank", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@CvId", SqlDbType.Int).Value = li_CvBank.CvId;
            cmd.Parameters.Add("@VacAnId", SqlDbType.Int).Value = li_CvBank.VacAnId;
            cmd.Parameters.Add("@CvPath", SqlDbType.VarChar).Value = li_CvBank.CvPath;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_CvBank.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_CvBank.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_CvBank.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_CvBank.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_CvBank.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
