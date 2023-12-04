using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_LemiChallanDetailProvider:DataAccessObject
{
	public SqlLi_LemiChallanDetailProvider()
    {
    }


    public bool DeleteLi_LemiChallanDetail(int li_LemiChallanDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_LemiChallanDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_LemiChallanDetailID", SqlDbType.Int).Value = li_LemiChallanDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_LemiChallanDetail> GetAllLi_LemiChallanDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_LemiChallanDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_LemiChallanDetailsFromReader(reader);
        }
    }
    public List<Li_LemiChallanDetail> GetLi_LemiChallanDetailsFromReader(IDataReader reader)
    {
        List<Li_LemiChallanDetail> li_LemiChallanDetails = new List<Li_LemiChallanDetail>();

        while (reader.Read())
        {
            li_LemiChallanDetails.Add(GetLi_LemiChallanDetailFromReader(reader));
        }
        return li_LemiChallanDetails;
    }

    public Li_LemiChallanDetail GetLi_LemiChallanDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_LemiChallanDetail li_LemiChallanDetail = new Li_LemiChallanDetail
                (
                     
                    (int)reader["ChallanDetailID"],
                    (int)reader["MemoNo"],
                     reader["P_S_ID"].ToString(),
                     reader["RollNo"].ToString(),
                    (decimal)reader["Qty"],
                    (decimal)reader["CQty"],
                    (decimal)reader["UnitPrice"],
                    (decimal)reader["Total"],
                    (decimal)reader["DiscountPercent"],
                    (decimal)reader["DisAmt"],
                    reader["Status_D"].ToString()
                );
             return li_LemiChallanDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_LemiChallanDetail GetLi_LemiChallanDetailByID(int li_LemiChallanDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_LemiChallanDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_LemiChallanDetailID", SqlDbType.Int).Value = li_LemiChallanDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_LemiChallanDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_LemiChallanDetail(Li_LemiChallanDetail li_LemiChallanDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_LemiChallanDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@ChallanDetailID", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MemoNo", SqlDbType.Int).Value = li_LemiChallanDetail.MemoNo;
            cmd.Parameters.Add("@P_S_ID", SqlDbType.VarChar).Value = li_LemiChallanDetail.P_S_ID;
            cmd.Parameters.Add("@RollNo", SqlDbType.VarChar).Value = li_LemiChallanDetail.RollNo;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_LemiChallanDetail.Qty;
            cmd.Parameters.Add("@CQty", SqlDbType.Decimal).Value = li_LemiChallanDetail.CQty;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = li_LemiChallanDetail.UnitPrice;
            cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = li_LemiChallanDetail.Total;
            cmd.Parameters.Add("@DiscountPercent", SqlDbType.Decimal).Value = li_LemiChallanDetail.DiscountPercent;
            cmd.Parameters.Add("@DisAmt", SqlDbType.Decimal).Value = li_LemiChallanDetail.DisAmt;
            cmd.Parameters.Add("@Status_D", SqlDbType.VarChar).Value = li_LemiChallanDetail.Status_D;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_LemiChallanDetail(Li_LemiChallanDetail li_LemiChallanDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_LemiChallanDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@ChallanDetailID", SqlDbType.Int).Value = li_LemiChallanDetail.ChallanDetailID;
            cmd.Parameters.Add("@MemoNo", SqlDbType.Int).Value = li_LemiChallanDetail.MemoNo;
            cmd.Parameters.Add("@P_S_ID", SqlDbType.VarChar).Value = li_LemiChallanDetail.P_S_ID;
            cmd.Parameters.Add("@RollNo", SqlDbType.VarChar).Value = li_LemiChallanDetail.RollNo;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_LemiChallanDetail.Qty;
            cmd.Parameters.Add("@CQty", SqlDbType.Decimal).Value = li_LemiChallanDetail.CQty;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = li_LemiChallanDetail.UnitPrice;
            cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = li_LemiChallanDetail.Total;
            cmd.Parameters.Add("@DiscountPercent", SqlDbType.Decimal).Value = li_LemiChallanDetail.DiscountPercent;
            cmd.Parameters.Add("@DisAmt", SqlDbType.Decimal).Value = li_LemiChallanDetail.DisAmt;
            cmd.Parameters.Add("@Status_D", SqlDbType.VarChar).Value = li_LemiChallanDetail.Status_D;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
