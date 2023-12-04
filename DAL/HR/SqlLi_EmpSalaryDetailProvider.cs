using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_EmpSalaryDetailProvider:DataAccessObject
{
	public SqlLi_EmpSalaryDetailProvider()
    {
    }


    public bool DeleteLi_EmpSalaryDetail(int li_EmpSalaryDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmpSalaryDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalDeId", SqlDbType.Int).Value = li_EmpSalaryDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmpSalaryDetail> GetAllLi_EmpSalaryDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmpSalaryDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmpSalaryDetailsFromReader(reader);
        }
    }
    public List<Li_EmpSalaryDetail> GetLi_EmpSalaryDetailsFromReader(IDataReader reader)
    {
        List<Li_EmpSalaryDetail> li_EmpSalaryDetails = new List<Li_EmpSalaryDetail>();

        while (reader.Read())
        {
            li_EmpSalaryDetails.Add(GetLi_EmpSalaryDetailFromReader(reader));
        }
        return li_EmpSalaryDetails;
    }

    public Li_EmpSalaryDetail GetLi_EmpSalaryDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_EmpSalaryDetail li_EmpSalaryDetail = new Li_EmpSalaryDetail
                (
                    
                    (int)reader["SalDeId"],
                    (int)reader["SalId"],
                    (int)reader["PaHId"],
                    (decimal)reader["Amount"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EmpSalaryDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmpSalaryDetail GetLi_EmpSalaryDetailByID(int li_EmpSalaryDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmpSalaryDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalDeId", SqlDbType.Int).Value = li_EmpSalaryDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmpSalaryDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmpSalaryDetail(Li_EmpSalaryDetail li_EmpSalaryDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmpSalaryDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@SalDeId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SalId", SqlDbType.Int).Value = li_EmpSalaryDetail.SalId;
            cmd.Parameters.Add("@PaHId", SqlDbType.Int).Value = li_EmpSalaryDetail.PaHId;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_EmpSalaryDetail.Amount;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpSalaryDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpSalaryDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpSalaryDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpSalaryDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpSalaryDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SalDeId"].Value;
        }
    }

    public bool UpdateLi_EmpSalaryDetail(Li_EmpSalaryDetail li_EmpSalaryDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmpSalaryDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
  
            cmd.Parameters.Add("@SalDeId", SqlDbType.Int).Value = li_EmpSalaryDetail.SalDeId;
            cmd.Parameters.Add("@SalId", SqlDbType.Int).Value = li_EmpSalaryDetail.SalId;
            cmd.Parameters.Add("@PaHId", SqlDbType.Int).Value = li_EmpSalaryDetail.PaHId;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_EmpSalaryDetail.Amount;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpSalaryDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpSalaryDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpSalaryDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpSalaryDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpSalaryDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
