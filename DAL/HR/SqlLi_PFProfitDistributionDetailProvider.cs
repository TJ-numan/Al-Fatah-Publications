using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_PFProfitDistributionDetailProvider:DataAccessObject
{
	public SqlLi_PFProfitDistributionDetailProvider()
    {
    }


    public bool DeleteLi_PFProfitDistributionDetail(int li_PFProfitDistributionDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_PFProfitDistributionDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PDisDet", SqlDbType.Int).Value = li_PFProfitDistributionDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PFProfitDistributionDetail> GetAllLi_PFProfitDistributionDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_PFProfitDistributionDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PFProfitDistributionDetailsFromReader(reader);
        }
    }
    public List<Li_PFProfitDistributionDetail> GetLi_PFProfitDistributionDetailsFromReader(IDataReader reader)
    {
        List<Li_PFProfitDistributionDetail> li_PFProfitDistributionDetails = new List<Li_PFProfitDistributionDetail>();

        while (reader.Read())
        {
            li_PFProfitDistributionDetails.Add(GetLi_PFProfitDistributionDetailFromReader(reader));
        }
        return li_PFProfitDistributionDetails;
    }

    public Li_PFProfitDistributionDetail GetLi_PFProfitDistributionDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_PFProfitDistributionDetail li_PFProfitDistributionDetail = new Li_PFProfitDistributionDetail
                (
                    
                    (int)reader["PDisDet"],
                    (int)reader["PDisId"],
                    (int)reader["EmpSl"],
                    (decimal)reader["PFAmount"],
                    (decimal)reader["ProPercentage"],
                    (decimal)reader["ProAmt"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_PFProfitDistributionDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PFProfitDistributionDetail GetLi_PFProfitDistributionDetailByID(int li_PFProfitDistributionDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_PFProfitDistributionDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PDisDet", SqlDbType.Int).Value = li_PFProfitDistributionDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PFProfitDistributionDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PFProfitDistributionDetail(Li_PFProfitDistributionDetail li_PFProfitDistributionDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_PFProfitDistributionDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@PDisDet", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PDisId", SqlDbType.Int).Value = li_PFProfitDistributionDetail.PDisId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_PFProfitDistributionDetail.EmpSl;
            cmd.Parameters.Add("@PFAmount", SqlDbType.Decimal).Value = li_PFProfitDistributionDetail.PFAmount;
            cmd.Parameters.Add("@ProPercentage", SqlDbType.Decimal).Value = li_PFProfitDistributionDetail.ProPercentage;
            cmd.Parameters.Add("@ProAmt", SqlDbType.Decimal).Value = li_PFProfitDistributionDetail.ProAmt;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PFProfitDistributionDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PFProfitDistributionDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PFProfitDistributionDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PFProfitDistributionDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PFProfitDistributionDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PDisDet"].Value;
        }
    }

    public bool UpdateLi_PFProfitDistributionDetail(Li_PFProfitDistributionDetail li_PFProfitDistributionDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_PFProfitDistributionDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@PDisDet", SqlDbType.Int).Value = li_PFProfitDistributionDetail.PDisDet;
            cmd.Parameters.Add("@PDisId", SqlDbType.Int).Value = li_PFProfitDistributionDetail.PDisId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_PFProfitDistributionDetail.EmpSl;
            cmd.Parameters.Add("@PFAmount", SqlDbType.Decimal).Value = li_PFProfitDistributionDetail.PFAmount;
            cmd.Parameters.Add("@ProPercentage", SqlDbType.Decimal).Value = li_PFProfitDistributionDetail.ProPercentage;
            cmd.Parameters.Add("@ProAmt", SqlDbType.Decimal).Value = li_PFProfitDistributionDetail.ProAmt;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PFProfitDistributionDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PFProfitDistributionDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PFProfitDistributionDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PFProfitDistributionDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PFProfitDistributionDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
