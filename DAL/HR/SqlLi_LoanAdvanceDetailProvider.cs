using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_LoanAdvanceDetailProvider:DataAccessObject
{
	public SqlLi_LoanAdvanceDetailProvider()
    {
    }


    public bool DeleteLi_LoanAdvanceDetail(int li_LoanAdvanceDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_LoanAdvanceDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LoAdDetId", SqlDbType.Int).Value = li_LoanAdvanceDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_LoanAdvanceDetail> GetAllLi_LoanAdvanceDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_LoanAdvanceDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_LoanAdvanceDetailsFromReader(reader);
        }
    }
    public List<Li_LoanAdvanceDetail> GetLi_LoanAdvanceDetailsFromReader(IDataReader reader)
    {
        List<Li_LoanAdvanceDetail> li_LoanAdvanceDetails = new List<Li_LoanAdvanceDetail>();

        while (reader.Read())
        {
            li_LoanAdvanceDetails.Add(GetLi_LoanAdvanceDetailFromReader(reader));
        }
        return li_LoanAdvanceDetails;
    }

    public Li_LoanAdvanceDetail GetLi_LoanAdvanceDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_LoanAdvanceDetail li_LoanAdvanceDetail = new Li_LoanAdvanceDetail
                (
                    
                    (int)reader["LoAdDetId"],
                    (int)reader["LoAdId"],
                    (DateTime)reader["TranDate"],
                    (decimal)reader["TakenAmt"],
                    (decimal)reader["AdjAmt"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_LoanAdvanceDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_LoanAdvanceDetail GetLi_LoanAdvanceDetailByID(int li_LoanAdvanceDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_LoanAdvanceDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LoAdDetId", SqlDbType.Int).Value = li_LoanAdvanceDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_LoanAdvanceDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_LoanAdvanceDetail(Li_LoanAdvanceDetail li_LoanAdvanceDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_LoanAdvanceDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@LoAdDetId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@LoAdId", SqlDbType.Int).Value = li_LoanAdvanceDetail.LoAdId;
            cmd.Parameters.Add("@TranDate", SqlDbType.DateTime).Value = li_LoanAdvanceDetail.TranDate;
            cmd.Parameters.Add("@TakenAmt", SqlDbType.Decimal).Value = li_LoanAdvanceDetail.TakenAmt;
            cmd.Parameters.Add("@AdjAmt", SqlDbType.Decimal).Value = li_LoanAdvanceDetail.AdjAmt;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LoanAdvanceDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LoanAdvanceDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_LoanAdvanceDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_LoanAdvanceDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_LoanAdvanceDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@LoAdDetId"].Value;
        }
    }

    public bool UpdateLi_LoanAdvanceDetail(Li_LoanAdvanceDetail li_LoanAdvanceDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_LoanAdvanceDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@LoAdDetId", SqlDbType.Int).Value = li_LoanAdvanceDetail.LoAdDetId;
            cmd.Parameters.Add("@LoAdId", SqlDbType.Int).Value = li_LoanAdvanceDetail.LoAdId;
            cmd.Parameters.Add("@TranDate", SqlDbType.DateTime).Value = li_LoanAdvanceDetail.TranDate;
            cmd.Parameters.Add("@TakenAmt", SqlDbType.Decimal).Value = li_LoanAdvanceDetail.TakenAmt;
            cmd.Parameters.Add("@AdjAmt", SqlDbType.Decimal).Value = li_LoanAdvanceDetail.AdjAmt;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LoanAdvanceDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LoanAdvanceDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_LoanAdvanceDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_LoanAdvanceDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_LoanAdvanceDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
