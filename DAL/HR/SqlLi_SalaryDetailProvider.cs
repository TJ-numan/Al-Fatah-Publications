using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_SalaryDetailProvider:DataAccessObject
{
	public SqlLi_SalaryDetailProvider()
    {
    }


    public bool DeleteLi_SalaryDetail(int li_SalaryDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_SalaryDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalDetId", SqlDbType.Int).Value = li_SalaryDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_SalaryDetail> GetAllLi_SalaryDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_SalaryDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_SalaryDetailsFromReader(reader);
        }
    }
    public List<Li_SalaryDetail> GetLi_SalaryDetailsFromReader(IDataReader reader)
    {
        List<Li_SalaryDetail> li_SalaryDetails = new List<Li_SalaryDetail>();

        while (reader.Read())
        {
            li_SalaryDetails.Add(GetLi_SalaryDetailFromReader(reader));
        }
        return li_SalaryDetails;
    }

    public Li_SalaryDetail GetLi_SalaryDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_SalaryDetail li_SalaryDetail = new Li_SalaryDetail
                (
                   
                    (int)reader["SalDetId"],
                    (int)reader["SalaryId"],
                    (decimal)reader["PaidAmt"],
                    (decimal)reader["ReturnAmt"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_SalaryDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_SalaryDetail GetLi_SalaryDetailByID(int li_SalaryDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_SalaryDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalDetId", SqlDbType.Int).Value = li_SalaryDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_SalaryDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_SalaryDetail(Li_SalaryDetail li_SalaryDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_SalaryDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@SalDetId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SalaryId", SqlDbType.Int).Value = li_SalaryDetail.SalaryId;
            cmd.Parameters.Add("@PaidAmt", SqlDbType.Decimal).Value = li_SalaryDetail.PaidAmt;
            cmd.Parameters.Add("@ReturnAmt", SqlDbType.Decimal).Value = li_SalaryDetail.ReturnAmt;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_SalaryDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_SalaryDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_SalaryDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_SalaryDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_SalaryDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SalDetId"].Value;
        }
    }

    public bool UpdateLi_SalaryDetail(Li_SalaryDetail li_SalaryDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_SalaryDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@SalDetId", SqlDbType.Int).Value = li_SalaryDetail.SalDetId;
            cmd.Parameters.Add("@SalaryId", SqlDbType.Int).Value = li_SalaryDetail.SalaryId;
            cmd.Parameters.Add("@PaidAmt", SqlDbType.Decimal).Value = li_SalaryDetail.PaidAmt;
            cmd.Parameters.Add("@ReturnAmt", SqlDbType.Decimal).Value = li_SalaryDetail.ReturnAmt;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_SalaryDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_SalaryDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_SalaryDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_SalaryDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_SalaryDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
