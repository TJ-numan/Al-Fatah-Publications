using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_ProvidentFundDetailProvider:DataAccessObject
{
	public SqlLi_ProvidentFundDetailProvider()
    {
    }


    public bool DeleteLi_ProvidentFundDetail(int li_ProvidentFundDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_ProvidentFundDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PFDetId", SqlDbType.Int).Value = li_ProvidentFundDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_ProvidentFundDetail> GetAllLi_ProvidentFundDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_ProvidentFundDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ProvidentFundDetailsFromReader(reader);
        }
    }
    public List<Li_ProvidentFundDetail> GetLi_ProvidentFundDetailsFromReader(IDataReader reader)
    {
        List<Li_ProvidentFundDetail> li_ProvidentFundDetails = new List<Li_ProvidentFundDetail>();

        while (reader.Read())
        {
            li_ProvidentFundDetails.Add(GetLi_ProvidentFundDetailFromReader(reader));
        }
        return li_ProvidentFundDetails;
    }

    public Li_ProvidentFundDetail GetLi_ProvidentFundDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_ProvidentFundDetail li_ProvidentFundDetail = new Li_ProvidentFundDetail
                (
                    
                    (int)reader["PFDetId"],
                    (int)reader["PFId"],
                    (int)reader["EmpSl"],
                    (decimal)reader["EPFAmt"],
                    (decimal)reader["ComAmt"],
                    (decimal)reader["ProfitAmt"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_ProvidentFundDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_ProvidentFundDetail GetLi_ProvidentFundDetailByID(int li_ProvidentFundDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_ProvidentFundDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PFDetId", SqlDbType.Int).Value = li_ProvidentFundDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ProvidentFundDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_ProvidentFundDetail(Li_ProvidentFundDetail li_ProvidentFundDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_ProvidentFundDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@PFDetId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PFId", SqlDbType.Int).Value = li_ProvidentFundDetail.PFId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_ProvidentFundDetail.EmpSl;
            cmd.Parameters.Add("@EPFAmt", SqlDbType.Decimal).Value = li_ProvidentFundDetail.EPFAmt;
            cmd.Parameters.Add("@ComAmt", SqlDbType.Decimal).Value = li_ProvidentFundDetail.ComAmt;
            cmd.Parameters.Add("@ProfitAmt", SqlDbType.Decimal).Value = li_ProvidentFundDetail.ProfitAmt;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ProvidentFundDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ProvidentFundDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ProvidentFundDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ProvidentFundDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_ProvidentFundDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PFDetId"].Value;
        }
    }

    public bool UpdateLi_ProvidentFundDetail(Li_ProvidentFundDetail li_ProvidentFundDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_ProvidentFundDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@PFDetId", SqlDbType.Int).Value = li_ProvidentFundDetail.PFDetId;
            cmd.Parameters.Add("@PFId", SqlDbType.Int).Value = li_ProvidentFundDetail.PFId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_ProvidentFundDetail.EmpSl;
            cmd.Parameters.Add("@EPFAmt", SqlDbType.Decimal).Value = li_ProvidentFundDetail.EPFAmt;
            cmd.Parameters.Add("@ComAmt", SqlDbType.Decimal).Value = li_ProvidentFundDetail.ComAmt;
            cmd.Parameters.Add("@ProfitAmt", SqlDbType.Decimal).Value = li_ProvidentFundDetail.ProfitAmt;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ProvidentFundDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ProvidentFundDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ProvidentFundDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ProvidentFundDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_ProvidentFundDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public DataSet GetAll_EmployeeProvidentFundByCompany(string CompanyId)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = CompanyId;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
}
