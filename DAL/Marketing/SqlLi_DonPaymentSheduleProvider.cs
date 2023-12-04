using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;

public class SqlLi_DonPaymentSheduleProvider:DataAccessObject
{
	public SqlLi_DonPaymentSheduleProvider()
    {
    }


    public bool DeleteLi_DonPaymentShedule(int li_DonPaymentSheduleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(" ", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ ", SqlDbType.Int).Value = li_DonPaymentSheduleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_DonPaymentShedule> GetAllLi_DonPaymentShedules()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand(" ", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_DonPaymentShedulesFromReader(reader);
        }
    }
    public List<Li_DonPaymentShedule> GetLi_DonPaymentShedulesFromReader(IDataReader reader)
    {
        List<Li_DonPaymentShedule> li_DonPaymentShedules = new List<Li_DonPaymentShedule>();

        while (reader.Read())
        {
            li_DonPaymentShedules.Add(GetLi_DonPaymentSheduleFromReader(reader));
        }
        return li_DonPaymentShedules;
    }

    public Li_DonPaymentShedule GetLi_DonPaymentSheduleFromReader(IDataReader reader)
    {
        try
        {
            Li_DonPaymentShedule li_DonPaymentShedule = new Li_DonPaymentShedule
                (
                   
                    (int)reader["PSId"],
                    (int)reader["SheId"],
                    (int)reader["DetId"],
                    (int)reader["DoDesId"],
                    (decimal)reader["Amount"],
                    reader["Status_d"].ToString(),
                    (DateTime )reader["StartingDate"],
                    (DateTime )reader["EndingDate"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"]
                );
             return li_DonPaymentShedule;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_DonPaymentShedule GetLi_DonPaymentSheduleByID(int li_DonPaymentSheduleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand(" ", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ ", SqlDbType.Int).Value = li_DonPaymentSheduleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_DonPaymentSheduleFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_DonPaymentShedule(Li_DonPaymentShedule li_DonPaymentShedule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AFPERP_InsertLi_DonPaymentSchedule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@PSId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SheId", SqlDbType.Int).Value = li_DonPaymentShedule.SheId;
            cmd.Parameters.Add("@DetId", SqlDbType.Int).Value = li_DonPaymentShedule.DetId;
            cmd.Parameters.Add("@DoDesId", SqlDbType.Int).Value = li_DonPaymentShedule.DoDesId;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_DonPaymentShedule.Amount;
            cmd.Parameters.Add("@Status_d", SqlDbType.VarChar).Value = li_DonPaymentShedule.Status_d;
            cmd.Parameters.Add("@StartingDate", SqlDbType.Date).Value = li_DonPaymentShedule.StartingDate;
            cmd.Parameters.Add("@EndingDate", SqlDbType.Date).Value = li_DonPaymentShedule.EndingDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DonPaymentShedule.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DonPaymentShedule.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PSId"].Value;
        }
    }

    public bool UpdateLi_DonPaymentShedule(Li_DonPaymentShedule li_DonPaymentShedule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("AFPERP_UpdateLi_DonPaymentSchedule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@PSId", SqlDbType.Int).Value = li_DonPaymentShedule.PSId;
            //cmd.Parameters.Add("@SheId", SqlDbType.Int).Value = li_DonPaymentShedule.SheId;
            //cmd.Parameters.Add("@DetId", SqlDbType.Int).Value = li_DonPaymentShedule.DetId;
            //cmd.Parameters.Add("@DoDesId", SqlDbType.Int).Value = li_DonPaymentShedule.DoDesId;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_DonPaymentShedule.Amount;
            //cmd.Parameters.Add("@Status_d", SqlDbType.VarChar).Value = li_DonPaymentShedule.Status_d;
            cmd.Parameters.Add("@StartingDate", SqlDbType.Date).Value = li_DonPaymentShedule.StartingDate;
            cmd.Parameters.Add("@EndingDate", SqlDbType.Date).Value = li_DonPaymentShedule.EndingDate;
            //cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DonPaymentShedule.CreatedBy;
            //cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DonPaymentShedule.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetAgreementAmount(string AgrNo, int DetId)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_GetDonationPaymentBy_AgrNo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AgrNo", SqlDbType.VarChar).Value = AgrNo;
            cmd.Parameters.Add("@DetId", SqlDbType.Int).Value = DetId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }
    public DataSet GetAgreementAmountR2(string AgrNo, int DetId, string AgrYear)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_GetDonationPaymentBy_AgrNoR2", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AgrNo", SqlDbType.VarChar).Value = AgrNo;
            cmd.Parameters.Add("@DetId", SqlDbType.Int).Value = DetId;
            cmd.Parameters.Add("@AgrYear", SqlDbType.VarChar ).Value = AgrYear;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }
    public DataSet GetAgreementAmountByMadSomiPerson(int DetId)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_GetDonationAmountBy_DonaFor", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DetId", SqlDbType.Int).Value = DetId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }
    public DataSet GetDonationName(string AgrNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_GetMadrashaSomiteePerson_NameBy_AgrNo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AgrNo", SqlDbType.VarChar).Value = AgrNo;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }
    public DataSet GetDonationNameR2(string AgrNo, string AgrYear)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_GetMadrashaSomiteePerson_NameBy_AgrNoR2", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AgrNo", SqlDbType.VarChar).Value = AgrNo;
            cmd.Parameters.Add("@AgrYear", SqlDbType.VarChar).Value = AgrYear;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }

    public DataSet GetDonationBasicAmntByAgreement(string AgrNo,int DetId)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Get_DonationBasicAmntByAgrNo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AgrNo", SqlDbType.VarChar).Value = AgrNo;
            cmd.Parameters.Add("@DetId", SqlDbType.VarChar).Value =DetId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }
    public DataSet GetDonationBasicAmntByAgreementR2(string AgrNo, int DetId, string AgrYear)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Get_DonationBasicAmntByAgrNoR2", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AgrNo", SqlDbType.VarChar).Value = AgrNo;
            cmd.Parameters.Add("@DetId", SqlDbType.VarChar).Value =DetId;
            cmd.Parameters.Add("@AgrYear", SqlDbType.VarChar).Value = AgrYear ;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }  
    
    public DataSet GetAmntSheduleBy_DonFor(int DetId)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Get_AmntSheduleBy_DonFor", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DetId", SqlDbType.Int).Value = DetId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }

    public decimal GetDonationPreviousPaid(int DetId, int DoDesID)
    {
      
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_GetDonationPreviousPaid", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal). Direction =  ParameterDirection .Output ;
            cmd.Parameters.Add("@DetId", SqlDbType.Int).Value = DetId;
            cmd.Parameters.Add("@DoDesID", SqlDbType.Int).Value = DoDesID;
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            return (decimal)cmd.Parameters["@Amount"].Value;
        }

    }
}
