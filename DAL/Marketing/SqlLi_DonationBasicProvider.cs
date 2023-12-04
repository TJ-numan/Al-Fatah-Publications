using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlLi_DonationBasicProvider:DataAccessObject
{
	public SqlLi_DonationBasicProvider()
    {
    }


    public bool DeleteLi_DonationBasic(int li_DonationBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@", SqlDbType.Int).Value = li_DonationBasicID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_DonationBasic> GetAllLi_DonationBasics()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_DonationBasicsFromReader(reader);
        }
    }
    public List<Li_DonationBasic> GetLi_DonationBasicsFromReader(IDataReader reader)
    {
        List<Li_DonationBasic> li_DonationBasics = new List<Li_DonationBasic>();

        while (reader.Read())
        {
            li_DonationBasics.Add(GetLi_DonationBasicFromReader(reader));
        }
        return li_DonationBasics;
    }

    public Li_DonationBasic GetLi_DonationBasicFromReader(IDataReader reader)
    {
        try
        {
            Li_DonationBasic li_DonationBasic = new Li_DonationBasic
                (
                   
                    (int)reader["DoId"],
                    reader["AgrNo"].ToString(),
                    reader["AgrYNo"].ToString(),
                    reader["AgrYear"].ToString(),
                    (int)reader["ThanaId"],
                    (int)reader["TerritorySl"],
                    (decimal)reader["DonAmt"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"]
                );
             return li_DonationBasic;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_DonationBasic GetLi_DonationBasicByID(int li_DonationBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@", SqlDbType.Int).Value = li_DonationBasicID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_DonationBasicFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_DonationBasic(Li_DonationBasic li_DonationBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_DonationBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@DoId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AgrNo", SqlDbType.VarChar).Value = li_DonationBasic.AgrNo;
            cmd.Parameters.Add("@AgrYNo", SqlDbType.VarChar).Value = li_DonationBasic.AgrYNo;
            cmd.Parameters.Add("@AgrYear", SqlDbType.VarChar).Value = li_DonationBasic.AgrYear;
            cmd.Parameters.Add("@ThanaId", SqlDbType.Int).Value = li_DonationBasic.ThanaId;
            cmd.Parameters.Add("@TerritorySl", SqlDbType.Int).Value = li_DonationBasic.TerritorySl;
            cmd.Parameters.Add("@DonAmt", SqlDbType.Decimal).Value = li_DonationBasic.DonAmt;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DonationBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DonationBasic.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DoId"].Value;
        }
    }

    public bool UpdateLi_DonationBasic(Li_DonationBasic li_DonationBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@DoId", SqlDbType.Int).Value = li_DonationBasic.DoId;
            cmd.Parameters.Add("@AgrNo", SqlDbType.VarChar).Value = li_DonationBasic.AgrNo;
            cmd.Parameters.Add("@AgrYNo", SqlDbType.VarChar).Value = li_DonationBasic.AgrYNo;
            cmd.Parameters.Add("@AgrYear", SqlDbType.VarChar).Value = li_DonationBasic.AgrYear;
            cmd.Parameters.Add("@ThanaId", SqlDbType.Int).Value = li_DonationBasic.ThanaId;
            cmd.Parameters.Add("@TerritorySl", SqlDbType.Int).Value = li_DonationBasic.TerritorySl;
            cmd.Parameters.Add("@DonAmt", SqlDbType.Decimal).Value = li_DonationBasic.DonAmt;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DonationBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DonationBasic.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetDonationExistingAgreement(string AgrNo, int DoFId  )
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Get_li_DonAgreementExist", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AgrNo", SqlDbType.VarChar).Value = AgrNo;
            cmd.Parameters.Add("@DoFId", SqlDbType.Int).Value = DoFId;
          
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }
    public DataSet GetDonationExistingAgreementR2(string AgrNo, int DoFId, string AgYear)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Get_li_DonAgreementExistR2", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AgrNo", SqlDbType.VarChar).Value = AgrNo;
            cmd.Parameters.Add("@DoFId", SqlDbType.Int).Value = DoFId;
            cmd.Parameters.Add("@AgYear", SqlDbType.VarChar).Value = AgYear;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }
    public DataSet GetMadrashaSomiteePersonInfo_ForEdit(string AgrNo, int DoFId, string AgrYear)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_GetMadrashaSomiteePersonInfo_ForEdit", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AgrNo", SqlDbType.VarChar).Value = AgrNo;
            cmd.Parameters.Add("@DoFId", SqlDbType.Int).Value = DoFId;
            cmd.Parameters.Add("@AgrYear", SqlDbType.VarChar).Value = AgrYear;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }

    public DataSet GetMadrashaSomiteePersonInfo_ForEditAmount(string AgrNo, int DoFId, string AgrYear)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_GetMadrashaSomiteePersonInfo_ForEditAmount", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AgrNo", SqlDbType.VarChar).Value = AgrNo;
            cmd.Parameters.Add("@DoFId", SqlDbType.Int).Value = DoFId;
            cmd.Parameters.Add("@AgrYear", SqlDbType.VarChar).Value = AgrYear;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }
    public DataSet GetScheduleAmountForDonationType(int DetId, int DoDesId)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_GetScheduleAmountForDonationType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DetId", SqlDbType.Int).Value = DetId;
            cmd.Parameters.Add("@DoDesId", SqlDbType.Int).Value = DoDesId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }
}
