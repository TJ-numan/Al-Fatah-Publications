using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_EmpPayDayDetailProvider:DataAccessObject
{
	public SqlLi_EmpPayDayDetailProvider()
    {
    }


    public bool DeleteLi_EmpPayDayDetail(int li_EmpPayDayDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmpPayDayDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PDayDetId", SqlDbType.Int).Value = li_EmpPayDayDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmpPayDayDetail> GetAllLi_EmpPayDayDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmpPayDayDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmpPayDayDetailsFromReader(reader);
        }
    }
    public List<Li_EmpPayDayDetail> GetLi_EmpPayDayDetailsFromReader(IDataReader reader)
    {
        List<Li_EmpPayDayDetail> li_EmpPayDayDetails = new List<Li_EmpPayDayDetail>();

        while (reader.Read())
        {
            li_EmpPayDayDetails.Add(GetLi_EmpPayDayDetailFromReader(reader));
        }
        return li_EmpPayDayDetails;
    }

    public Li_EmpPayDayDetail GetLi_EmpPayDayDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_EmpPayDayDetail li_EmpPayDayDetail = new Li_EmpPayDayDetail
                (
                   
                    (int)reader["PDayDetId"],
                    (int)reader["PDayCId"],
                    (int)reader["EmpSl"],
                    reader["YearName"].ToString(),
                    reader["MonthName"].ToString(),
                    (decimal)reader["MonthDay"],
                    (decimal)reader["WorkingDay"],
                    (decimal)reader["Weekend"],
                    (decimal)reader["Holiday"],
                    (decimal)reader["LeaveWPay"],
                    (decimal)reader["LeaveWOPay"],
                    (decimal)reader["AbsentDay"],
                    (decimal)reader["LateCDay"],
                    (decimal)reader["OutStyCDay"],
                    (decimal)reader["PayDay"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EmpPayDayDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmpPayDayDetail GetLi_EmpPayDayDetailByID(int li_EmpPayDayDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmpPayDayDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PDayDetId", SqlDbType.Int).Value = li_EmpPayDayDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmpPayDayDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmpPayDayDetail(Li_EmpPayDayDetail li_EmpPayDayDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmpPayDayDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@PDayDetId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PDayCId", SqlDbType.Int).Value = li_EmpPayDayDetail.PDayCId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpPayDayDetail.EmpSl;
            cmd.Parameters.Add("@YearName", SqlDbType.VarChar).Value = li_EmpPayDayDetail.YearName;
            cmd.Parameters.Add("@MonthName", SqlDbType.VarChar).Value = li_EmpPayDayDetail.MonthName;
            cmd.Parameters.Add("@MonthDay", SqlDbType.Decimal).Value = li_EmpPayDayDetail.MonthDay;
            cmd.Parameters.Add("@WorkingDay", SqlDbType.Decimal).Value = li_EmpPayDayDetail.WorkingDay;
            cmd.Parameters.Add("@Weekend", SqlDbType.Decimal).Value = li_EmpPayDayDetail.Weekend;
            cmd.Parameters.Add("@Holiday", SqlDbType.Decimal).Value = li_EmpPayDayDetail.Holiday;
            cmd.Parameters.Add("@LeaveWPay", SqlDbType.Decimal).Value = li_EmpPayDayDetail.LeaveWPay;
            cmd.Parameters.Add("@LeaveWOPay", SqlDbType.Decimal).Value = li_EmpPayDayDetail.LeaveWOPay;
            cmd.Parameters.Add("@AbsentDay", SqlDbType.Decimal).Value = li_EmpPayDayDetail.AbsentDay;
            cmd.Parameters.Add("@LateCDay", SqlDbType.Decimal).Value = li_EmpPayDayDetail.LateCDay;
            cmd.Parameters.Add("@OutStyCDay", SqlDbType.Decimal).Value = li_EmpPayDayDetail.OutStyCDay;
            cmd.Parameters.Add("@PayDay", SqlDbType.Decimal).Value = li_EmpPayDayDetail.PayDay;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_EmpPayDayDetail.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpPayDayDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpPayDayDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpPayDayDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpPayDayDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpPayDayDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PDayDetId"].Value;
        }
    }

    public bool UpdateLi_EmpPayDayDetail(Li_EmpPayDayDetail li_EmpPayDayDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmpPayDayDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@PDayDetId", SqlDbType.Int).Value = li_EmpPayDayDetail.PDayDetId;
            cmd.Parameters.Add("@PDayCId", SqlDbType.Int).Value = li_EmpPayDayDetail.PDayCId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpPayDayDetail.EmpSl;
            cmd.Parameters.Add("@YearName", SqlDbType.VarChar).Value = li_EmpPayDayDetail.YearName;
            cmd.Parameters.Add("@MonthName", SqlDbType.VarChar).Value = li_EmpPayDayDetail.MonthName;
            cmd.Parameters.Add("@MonthDay", SqlDbType.Decimal).Value = li_EmpPayDayDetail.MonthDay;
            cmd.Parameters.Add("@WorkingDay", SqlDbType.Decimal).Value = li_EmpPayDayDetail.WorkingDay;
            cmd.Parameters.Add("@Weekend", SqlDbType.Decimal).Value = li_EmpPayDayDetail.Weekend;
            cmd.Parameters.Add("@Holiday", SqlDbType.Decimal).Value = li_EmpPayDayDetail.Holiday;
            cmd.Parameters.Add("@LeaveWPay", SqlDbType.Decimal).Value = li_EmpPayDayDetail.LeaveWPay;
            cmd.Parameters.Add("@LeaveWOPay", SqlDbType.Decimal).Value = li_EmpPayDayDetail.LeaveWOPay;
            cmd.Parameters.Add("@AbsentDay", SqlDbType.Decimal).Value = li_EmpPayDayDetail.AbsentDay;
            cmd.Parameters.Add("@LateCDay", SqlDbType.Decimal).Value = li_EmpPayDayDetail.LateCDay;
            cmd.Parameters.Add("@OutStyCDay", SqlDbType.Decimal).Value = li_EmpPayDayDetail.OutStyCDay;
            cmd.Parameters.Add("@PayDay", SqlDbType.Decimal).Value = li_EmpPayDayDetail.PayDay;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_EmpPayDayDetail.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpPayDayDetail.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpPayDayDetail.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpPayDayDetail.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpPayDayDetail.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpPayDayDetail.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
