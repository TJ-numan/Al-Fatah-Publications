using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;

public class SqlLi_DonPaymentProvider:DataAccessObject
{
	public SqlLi_DonPaymentProvider()
    {
    }


    public bool DeleteLi_DonPayment(int li_DonPaymentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@", SqlDbType.Int).Value = li_DonPaymentID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_DonPayment> GetAllLi_DonPayments()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_DonPaymentsFromReader(reader);
        }
    }
    public List<Li_DonPayment> GetLi_DonPaymentsFromReader(IDataReader reader)
    {
        List<Li_DonPayment> li_DonPayments = new List<Li_DonPayment>();

        while (reader.Read())
        {
            li_DonPayments.Add(GetLi_DonPaymentFromReader(reader));
        }
        return li_DonPayments;
    }

    public Li_DonPayment GetLi_DonPaymentFromReader(IDataReader reader)
    {
        try
        {
            Li_DonPayment li_DonPayment = new Li_DonPayment
                (
                    
                    (int)reader["PayId"],
                    (int)reader["PSId"],
                    reader["AcName"].ToString(),
                    reader["AcName_bn"].ToString(),
                    reader["AcMemNo"].ToString(),
                    reader["BankCof"].ToString(),
                    reader["AcAddress"].ToString(),
                    (int)reader["ThanaId"],
                    reader["ContactNo"].ToString(),
                    (bool)reader["IsBankPay"],
                    (int)reader["AccTypId"],
                    (int)reader["PayTypId"],
                    reader["TransportID"].ToString(),
                    (bool)reader["IsRecAckNo"],
                    reader["AckNo"].ToString(),
                    reader["Remarks"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"]
                );
             return li_DonPayment;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_DonPayment GetLi_DonPaymentByID(int PSId)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@", SqlDbType.Int).Value = PSId;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_DonPaymentFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_DonPayment(Li_DonPayment li_DonPayment)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AFPERP_InsertLi_DonPayment", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@PayId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PSId", SqlDbType.Int).Value = li_DonPayment.PSId;
            cmd.Parameters.Add("@AcName", SqlDbType.VarChar).Value = li_DonPayment.AcName;
            cmd.Parameters.Add("@AcName_bn", SqlDbType.VarChar).Value = li_DonPayment.AcName_bn;
            cmd.Parameters.Add("@AcMemNo", SqlDbType.VarChar).Value = li_DonPayment.AcMemNo;
            cmd.Parameters.Add("@BankCof", SqlDbType.VarChar).Value = li_DonPayment.BankCof;
            cmd.Parameters.Add("@AcAddress", SqlDbType.VarChar).Value = li_DonPayment.AcAddress;
            cmd.Parameters.Add("@ThanaId", SqlDbType.Int).Value = li_DonPayment.ThanaId;
            cmd.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = li_DonPayment.ContactNo;
            cmd.Parameters.Add("@IsBankPay", SqlDbType.Bit).Value = li_DonPayment.IsBankPay;
            cmd.Parameters.Add("@AccTypId", SqlDbType.Int).Value = li_DonPayment.AccTypId;
            cmd.Parameters.Add("@PayTypId", SqlDbType.Int).Value = li_DonPayment.PayTypId;
            cmd.Parameters.Add("@TransportID", SqlDbType.VarChar).Value = li_DonPayment.TransportID;
            cmd.Parameters.Add("@IsRecAckNo", SqlDbType.Bit).Value = li_DonPayment.IsRecAckNo;
            cmd.Parameters.Add("@AckNo", SqlDbType.VarChar).Value = li_DonPayment.AckNo;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = li_DonPayment.Remarks;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DonPayment.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DonPayment.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PayId"].Value;
        }
    }

    public bool UpdateLi_DonPayment(Li_DonPayment li_DonPayment)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AFPERP_UpdateLi_DonPayment", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            //cmd.Parameters.Add("@PayId", SqlDbType.Int).Value = li_DonPayment.PayId;
            cmd.Parameters.Add("@PSId", SqlDbType.Int).Value = li_DonPayment.PSId;
            cmd.Parameters.Add("@AcName", SqlDbType.VarChar).Value = li_DonPayment.AcName;
            cmd.Parameters.Add("@AcName_bn", SqlDbType.VarChar).Value = li_DonPayment.AcName_bn;
            cmd.Parameters.Add("@AcMemNo", SqlDbType.VarChar).Value = li_DonPayment.AcMemNo;
            cmd.Parameters.Add("@BankCof", SqlDbType.VarChar).Value = li_DonPayment.BankCof;
            cmd.Parameters.Add("@AcAddress", SqlDbType.VarChar).Value = li_DonPayment.AcAddress;
            cmd.Parameters.Add("@ThanaId", SqlDbType.Int).Value = li_DonPayment.ThanaId;
            cmd.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = li_DonPayment.ContactNo;
            cmd.Parameters.Add("@IsBankPay", SqlDbType.Bit).Value = li_DonPayment.IsBankPay;
            cmd.Parameters.Add("@AccTypId", SqlDbType.Int).Value = li_DonPayment.AccTypId;
            cmd.Parameters.Add("@PayTypId", SqlDbType.Int).Value = li_DonPayment.PayTypId;
            cmd.Parameters.Add("@TransportID", SqlDbType.VarChar).Value = li_DonPayment.TransportID;
            cmd.Parameters.Add("@IsRecAckNo", SqlDbType.Bit).Value = li_DonPayment.IsRecAckNo;
            cmd.Parameters.Add("@AckNo", SqlDbType.VarChar).Value = li_DonPayment.AckNo;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = li_DonPayment.Remarks;
            //cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DonPayment.CreatedBy;
            //cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DonPayment.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    } 
    public DataSet GetLi_DonPaymentBySheID(int PSId)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SMPM_li_GetPaymentInfoByShedId", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PSId", SqlDbType.Int).Value = PSId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }

    public DataSet GetLi_DonOneShedTotalAmtSheID(int PSId)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("SMPM_li_GetTotalOneShedAmt", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PSId", SqlDbType.Int).Value = PSId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public DataSet GetLi_DonLetterInfoByLetterNO(string LetterNo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("Get_DonationLetterInfo_ForPaymentBy_LetterNo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LetterNo", SqlDbType.VarChar).Value = LetterNo;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
}
