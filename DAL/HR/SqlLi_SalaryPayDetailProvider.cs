using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_SalaryPayDetailProvider:DataAccessObject
{
	public SqlLi_SalaryPayDetailProvider()
    {
    }


    public bool DeleteLi_SalaryPayDetail(int li_SalaryPayDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_SalaryPayDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalPayId", SqlDbType.Int).Value = li_SalaryPayDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_SalaryPayDetail> GetAllLi_SalaryPayDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_SalaryPayDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_SalaryPayDetailsFromReader(reader);
        }
    }
    public List<Li_SalaryPayDetail> GetLi_SalaryPayDetailsFromReader(IDataReader reader)
    {
        List<Li_SalaryPayDetail> li_SalaryPayDetails = new List<Li_SalaryPayDetail>();

        while (reader.Read())
        {
            li_SalaryPayDetails.Add(GetLi_SalaryPayDetailFromReader(reader));
        }
        return li_SalaryPayDetails;
    }

    public Li_SalaryPayDetail GetLi_SalaryPayDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_SalaryPayDetail li_SalaryPayDetail = new Li_SalaryPayDetail
                (
                   
                    (int)reader["SalPayId"],
                    (int)reader["SalaryId"],
                    (int)reader["EmpSl"],
                    (int)reader["PDayDetId"],
                    (int)reader["PaHId"],
                    (decimal)reader["FixedAmt"],
                    (decimal)reader["PaidAmt"],
                    (decimal)reader["DeductAmt"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_SalaryPayDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_SalaryPayDetail GetLi_SalaryPayDetailByID(int li_SalaryPayDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_SalaryPayDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalPayId", SqlDbType.Int).Value = li_SalaryPayDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_SalaryPayDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_SalaryPayDetail(Li_SalaryPayDetail li_SalaryPayDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_SalaryPayDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@SalPayId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SalaryId", SqlDbType.Int).Value = li_SalaryPayDetail.SalaryId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_SalaryPayDetail.EmpSl;
            cmd.Parameters.Add("@PDayDetId", SqlDbType.Int).Value = li_SalaryPayDetail.PDayDetId;
            cmd.Parameters.Add("@PaHId", SqlDbType.Int).Value = li_SalaryPayDetail.PaHId;
            cmd.Parameters.Add("@FixedAmt", SqlDbType.Decimal).Value = li_SalaryPayDetail.FixedAmt;
            cmd.Parameters.Add("@PaidAmt", SqlDbType.Decimal).Value = li_SalaryPayDetail.PaidAmt;
            cmd.Parameters.Add("@DeductAmt", SqlDbType.Decimal).Value = li_SalaryPayDetail.DeductAmt;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_SalaryPayDetail.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_SalaryPayDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_SalaryPayDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_SalaryPayDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_SalaryPayDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_SalaryPayDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SalPayId"].Value;
        }
    }

    public bool UpdateLi_SalaryPayDetail(Li_SalaryPayDetail li_SalaryPayDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_SalaryPayDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
      
            cmd.Parameters.Add("@SalPayId", SqlDbType.Int).Value = li_SalaryPayDetail.SalPayId;
            cmd.Parameters.Add("@SalaryId", SqlDbType.Int).Value = li_SalaryPayDetail.SalaryId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_SalaryPayDetail.EmpSl;
            cmd.Parameters.Add("@PDayDetId", SqlDbType.Int).Value = li_SalaryPayDetail.PDayDetId;
            cmd.Parameters.Add("@PaHId", SqlDbType.Int).Value = li_SalaryPayDetail.PaHId;
            cmd.Parameters.Add("@FixedAmt", SqlDbType.Decimal).Value = li_SalaryPayDetail.FixedAmt;
            cmd.Parameters.Add("@PaidAmt", SqlDbType.Decimal).Value = li_SalaryPayDetail.PaidAmt;
            cmd.Parameters.Add("@DeductAmt", SqlDbType.Decimal).Value = li_SalaryPayDetail.DeductAmt;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_SalaryPayDetail.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_SalaryPayDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_SalaryPayDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_SalaryPayDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_SalaryPayDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_SalaryPayDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
