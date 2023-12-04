using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;

public class SqlLi_DonationAmtProvider:DataAccessObject
{
	public SqlLi_DonationAmtProvider()
    {
    }


    public bool DeleteLi_DonationAmt(int li_DonationAmtID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_DonationAmtID", SqlDbType.Int).Value = li_DonationAmtID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_DonationAmt> GetAllLi_DonationAmts()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_DonationAmtsFromReader(reader);
        }
    }
    public List<Li_DonationAmt> GetLi_DonationAmtsFromReader(IDataReader reader)
    {
        List<Li_DonationAmt> li_DonationAmts = new List<Li_DonationAmt>();

        while (reader.Read())
        {
            li_DonationAmts.Add(GetLi_DonationAmtFromReader(reader));
        }
        return li_DonationAmts;
    }

    public Li_DonationAmt GetLi_DonationAmtFromReader(IDataReader reader)
    {
        try
        {
            Li_DonationAmt li_DonationAmt = new Li_DonationAmt
                (
                     
                    (int)reader["SlNo"],
                    (int)reader["DetId"],
                    (int)reader["DoDesId"],
                    (decimal)reader["Amount"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"]
                );
             return li_DonationAmt;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_DonationAmt GetLi_DonationAmtByID(int li_DonationAmtID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_DonationAmtID", SqlDbType.Int).Value = li_DonationAmtID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_DonationAmtFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_DonationAmt(Li_DonationAmt li_DonationAmt)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_DonationAmt", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@SlNo", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DetId", SqlDbType.Int).Value = li_DonationAmt.DetId;
            cmd.Parameters.Add("@DoDesId", SqlDbType.Int).Value = li_DonationAmt.DoDesId;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_DonationAmt.Amount;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DonationAmt.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DonationAmt.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SlNo"].Value;
        }
    }

    public bool UpdateLi_DonationAmt(Li_DonationAmt li_DonationAmt)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_UpdateDonationAmount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            //cmd.Parameters.Add("@SlNo", SqlDbType.Int).Value = li_DonationAmt.SlNo;
            cmd.Parameters.Add("@DetId", SqlDbType.Int).Value = li_DonationAmt.DetId;
            cmd.Parameters.Add("@DoDesId", SqlDbType.Int).Value = li_DonationAmt.DoDesId;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_DonationAmt.Amount;
            //cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DonationAmt.CreatedBy;
            //cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DonationAmt.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
