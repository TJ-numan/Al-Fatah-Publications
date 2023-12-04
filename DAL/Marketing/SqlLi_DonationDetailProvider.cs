using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlLi_DonationDetailProvider : DataAccessObject
{
    public SqlLi_DonationDetailProvider()
    {

    }

    public bool DeleteLi_DonationDetail(int li_DonationDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@", SqlDbType.Int).Value = li_DonationDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_DonationDetail> GetAllLi_DonationDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_DonationDetailsFromReader(reader);
        }
    }

    public List<Li_DonationDetail> GetLi_DonationDetailsFromReader(IDataReader reader)
    {
        List<Li_DonationDetail> li_DonationDetails = new List<Li_DonationDetail>();

        while (reader.Read())
        {
            li_DonationDetails.Add(GetLi_DonationDetailFromReader(reader));
        }
        return li_DonationDetails;
    }

    public Li_DonationDetail GetLi_DonationDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_DonationDetail li_DonationDetail = new Li_DonationDetail
                (

                    (int)reader["DetId"],
                    (int)reader["Dold"],
                    (int)reader["DoFId"],
                    reader["DoName"].ToString(),
                    reader["VillRoBaz"].ToString(),
                    reader["PostOff"].ToString(),
                    (int)reader["ThanaId"],
                    reader["ContactNo"].ToString(),
                    reader["Chair_Prin"].ToString(),
                    reader["Chair_PrinCont"].ToString(),
                    reader["Sec_ViceP"].ToString(),
                    reader["Sec_VicePCont"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"]
                );
            return li_DonationDetail;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Li_DonationDetail GetLi_DonationDetailByID(int li_DonationDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@", SqlDbType.Int).Value = li_DonationDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_DonationDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_DonationDetail(Li_DonationDetail li_DonationDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Donation_Detail", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@DetId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Dold", SqlDbType.Int).Value = li_DonationDetail.Dold;
            cmd.Parameters.Add("@DoFId", SqlDbType.Int).Value = li_DonationDetail.DoFId;
            cmd.Parameters.Add("@DoName", SqlDbType.VarChar).Value = li_DonationDetail.DoName;
            cmd.Parameters.Add("@VillRoBaz", SqlDbType.VarChar).Value = li_DonationDetail.VillRoBaz;
            cmd.Parameters.Add("@PostOff", SqlDbType.VarChar).Value = li_DonationDetail.PostOff;
            cmd.Parameters.Add("@ThanaId", SqlDbType.Int).Value = li_DonationDetail.ThanaId;
            cmd.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = li_DonationDetail.ContactNo;
            cmd.Parameters.Add("@Chair_Prin", SqlDbType.VarChar).Value = li_DonationDetail.Chair_Prin;
            cmd.Parameters.Add("@Chair_PrinCont", SqlDbType.VarChar).Value = li_DonationDetail.Chair_PrinCont;
            cmd.Parameters.Add("@Sec_ViceP", SqlDbType.VarChar).Value = li_DonationDetail.Sec_ViceP;
            cmd.Parameters.Add("@Sec_VicePCont", SqlDbType.VarChar).Value = li_DonationDetail.Sec_VicePCont;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DonationDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DonationDetail.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DetId"].Value;
        }
    }

    public bool UpdateLi_DonationDetail(Li_DonationDetail li_DonationDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Update_DonationDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@DetId", SqlDbType.Int).Value = li_DonationDetail.DetId;
            //cmd.Parameters.Add("@Dold", SqlDbType.Int).Value = li_DonationDetail.Dold;
            cmd.Parameters.Add("@DoFId", SqlDbType.Int).Value = li_DonationDetail.DoFId;
            cmd.Parameters.Add("@DoName", SqlDbType.VarChar).Value = li_DonationDetail.DoName;
            cmd.Parameters.Add("@VillRoBaz", SqlDbType.VarChar).Value = li_DonationDetail.VillRoBaz;
            cmd.Parameters.Add("@PostOff", SqlDbType.VarChar).Value = li_DonationDetail.PostOff;
            cmd.Parameters.Add("@ThanaId", SqlDbType.Int).Value = li_DonationDetail.ThanaId;
            cmd.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = li_DonationDetail.ContactNo;
            cmd.Parameters.Add("@Chair_Prin", SqlDbType.VarChar).Value = li_DonationDetail.Chair_Prin;
            cmd.Parameters.Add("@Chair_PrinCont", SqlDbType.VarChar).Value = li_DonationDetail.Chair_PrinCont;
            cmd.Parameters.Add("@Sec_ViceP", SqlDbType.VarChar).Value = li_DonationDetail.Sec_ViceP;
            cmd.Parameters.Add("@Sec_VicePCont", SqlDbType.VarChar).Value = li_DonationDetail.Sec_VicePCont;
            //cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DonationDetail.CreatedBy;
            //cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DonationDetail.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetTeritoryWiseBudgetAmt(int ThanaId, int DoDesId, string agrYear)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Get_DonationTeritoryWiseBudget", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ThanaID", SqlDbType.Int).Value = ThanaId;
            cmd.Parameters.Add("@DoDesID", SqlDbType.Int).Value = DoDesId;
            cmd.Parameters.Add("@AgrYear", SqlDbType.VarChar).Value = agrYear;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }

    public DataSet GetTeritoryWiseBudgetAmtPaid(int ThanaId, int DoDesId, string agrYear)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Get_DonationTeritoryWisePaidBudget", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ThanaID", SqlDbType.Int).Value = ThanaId;
            cmd.Parameters.Add("@DoDesID", SqlDbType.Int).Value = DoDesId;
            cmd.Parameters.Add("@AgrYear", SqlDbType.VarChar).Value = agrYear;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }
    public DataSet GetTeritoryWiseBudgetAndPaid(int ThanaId)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Get_DonationTeritoryWiseBudgetAndPaid", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ThanaID", SqlDbType.Int).Value = ThanaId;

            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }
    public DataSet GetTeritoryWiseBudgetAndPaidR2(string agrYear, string TerritoryCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Get_DonationTeritoryWiseBudgetAndPaidR2", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@agrYear", SqlDbType.VarChar).Value = agrYear;
            cmd.Parameters.Add("@TerritoryCode", SqlDbType.VarChar).Value = TerritoryCode;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }

    }
}
