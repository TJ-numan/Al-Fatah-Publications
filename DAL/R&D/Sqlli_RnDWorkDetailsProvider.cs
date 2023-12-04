using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_RnDWorkDetailsProvider : DataAccessObject
{
    public SqlLi_RnDWorkDetailsProvider()
    {
    }


    public bool DeleteLi_RnDWorkDetails(int li_RnDWorkDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_RnDWorkDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_RnDWorkDetailsID", SqlDbType.Int).Value = li_RnDWorkDetailsID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_RnDWorkDetails> GetAllLi_RnDWorkDetailss()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_RnDWorkDetailss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_RnDWorkDetailssFromReader(reader);
        }
    }
    public List<Li_RnDWorkDetails> GetLi_RnDWorkDetailssFromReader(IDataReader reader)
    {
        List<Li_RnDWorkDetails> li_RnDWorkDetailss = new List<Li_RnDWorkDetails>();

        while (reader.Read())
        {
            li_RnDWorkDetailss.Add(GetLi_RnDWorkDetailsFromReader(reader));
        }
        return li_RnDWorkDetailss;
    }

    public Li_RnDWorkDetails GetLi_RnDWorkDetailsFromReader(IDataReader reader)
    {
        try
        {
            Li_RnDWorkDetails li_RnDWorkDetails = new Li_RnDWorkDetails
                (

                    (int)reader["WorkDetailID"],
                    (DateTime)reader["WorkDate"],
                    (int)reader["EmployeeID"],
                    (int)reader["WorkTypeID"],
                    reader["BookID"].ToString(),
                    reader["WorkStartTime"].ToString(),
                    reader["WorkEndTime"].ToString(),
                    (decimal)reader["WorkTimeSpan"],
                    (int)reader["PageStart"],
                    (int)reader["PageEnd"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["SectionID"],
                    (bool)reader["IsHired"]
                );
            return li_RnDWorkDetails;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Li_RnDWorkDetails GetLi_RnDWorkDetailsByID(int li_RnDWorkDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_RnDWorkDetailsByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_RnDWorkDetailsID", SqlDbType.Int).Value = li_RnDWorkDetailsID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_RnDWorkDetailsFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_RnDWorkDetails(Li_RnDWorkDetails li_RnDWorkDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_RnDWorkDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@WorkDetailID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@WorkDate", SqlDbType.DateTime).Value = li_RnDWorkDetails.WorkDate;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = li_RnDWorkDetails.EmployeeID;
            cmd.Parameters.Add("@WorkTypeID", SqlDbType.Int).Value = li_RnDWorkDetails.WorkTypeID;
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = li_RnDWorkDetails.BookID;
            cmd.Parameters.Add("@WorkStartTime", SqlDbType.VarChar).Value = li_RnDWorkDetails.WorkStartTime;
            cmd.Parameters.Add("@WorkEndTime", SqlDbType.VarChar).Value = li_RnDWorkDetails.WorkEndTime;
            cmd.Parameters.Add("@WorkTimeSpan", SqlDbType.Decimal).Value = li_RnDWorkDetails.WorkTimeSpan;
            cmd.Parameters.Add("@PageStart", SqlDbType.Int).Value = li_RnDWorkDetails.PageStart;
            cmd.Parameters.Add("@PageEnd", SqlDbType.Int).Value = li_RnDWorkDetails.PageEnd;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_RnDWorkDetails.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_RnDWorkDetails.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_RnDWorkDetails.CreatedDate;
            cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = li_RnDWorkDetails.SectionID;
            cmd.Parameters.Add("@IsHired", SqlDbType.Bit).Value = li_RnDWorkDetails.IsHired;


            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_RnDWorkDetails(Li_RnDWorkDetails li_RnDWorkDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_RnDWorkDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@WorkDetailID", SqlDbType.Int).Value = li_RnDWorkDetails.WorkDetailID;
            cmd.Parameters.Add("@WorkDate", SqlDbType.DateTime).Value = li_RnDWorkDetails.WorkDate;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = li_RnDWorkDetails.EmployeeID;
            cmd.Parameters.Add("@WorkTypeID", SqlDbType.Int).Value = li_RnDWorkDetails.WorkTypeID;
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = li_RnDWorkDetails.BookID;
            cmd.Parameters.Add("@WorkStartTime", SqlDbType.VarChar).Value = li_RnDWorkDetails.WorkStartTime;
            cmd.Parameters.Add("@WorkEndTime", SqlDbType.VarChar).Value = li_RnDWorkDetails.WorkEndTime;
            cmd.Parameters.Add("@WorkTimeSpan", SqlDbType.Decimal).Value = li_RnDWorkDetails.WorkTimeSpan;
            cmd.Parameters.Add("@PageStart", SqlDbType.Int).Value = li_RnDWorkDetails.PageStart;
            cmd.Parameters.Add("@PageEnd", SqlDbType.Int).Value = li_RnDWorkDetails.PageEnd;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_RnDWorkDetails.Comments;
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
    public DataSet Get_DateWiseRnDWorkDetails(string fromDate, string toDate, string employeeID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_getDatewiseRndWorkDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromDate;
            cmd.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = toDate;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = employeeID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public DataSet GetLi_RnDWorkDetailsByWorkID(int WorkDetailID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_getRndWorkDetailsByWorkDetailsID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkDetailID", SqlDbType.Int).Value = WorkDetailID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    //--------------------------------------------rezaul Hossain------------------2021-06-01-----------
    public int InsertLi_RnDWorkDetailsQawmi(Li_RnDWorkDetails li_RnDWorkDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_RnDWorkDetailsQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@WorkDetailID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@WorkDate", SqlDbType.DateTime).Value = li_RnDWorkDetails.WorkDate;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = li_RnDWorkDetails.EmployeeID;
            cmd.Parameters.Add("@WorkTypeID", SqlDbType.Int).Value = li_RnDWorkDetails.WorkTypeID;
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = li_RnDWorkDetails.BookID;
            cmd.Parameters.Add("@WorkStartTime", SqlDbType.VarChar).Value = li_RnDWorkDetails.WorkStartTime;
            cmd.Parameters.Add("@WorkEndTime", SqlDbType.VarChar).Value = li_RnDWorkDetails.WorkEndTime;
            cmd.Parameters.Add("@WorkTimeSpan", SqlDbType.Decimal).Value = li_RnDWorkDetails.WorkTimeSpan;
            cmd.Parameters.Add("@PageStart", SqlDbType.Int).Value = li_RnDWorkDetails.PageStart;
            cmd.Parameters.Add("@PageEnd", SqlDbType.Int).Value = li_RnDWorkDetails.PageEnd;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_RnDWorkDetails.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_RnDWorkDetails.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_RnDWorkDetails.CreatedDate;
            cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = li_RnDWorkDetails.SectionID;
            cmd.Parameters.Add("@IsHired", SqlDbType.Bit).Value = li_RnDWorkDetails.IsHired;


            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }
    public DataSet Get_DateWiseRnDWorkDetailsQawmi(string fromDate, string toDate, string employeeID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_getDatewiseRndWorkDetailsQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromDate;
            cmd.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = toDate;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = employeeID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public DataSet GetLi_RnDWorkDetailsByWorkIDQawmi(int WorkDetailID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_getRndWorkDetailsByWorkDetailsIDQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkDetailID", SqlDbType.Int).Value = WorkDetailID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public bool UpdateLi_RnDWorkDetailsQawmi(Li_RnDWorkDetails li_RnDWorkDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_RnDWorkDetailsQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@WorkDetailID", SqlDbType.Int).Value = li_RnDWorkDetails.WorkDetailID;
            cmd.Parameters.Add("@WorkDate", SqlDbType.DateTime).Value = li_RnDWorkDetails.WorkDate;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = li_RnDWorkDetails.EmployeeID;
            cmd.Parameters.Add("@WorkTypeID", SqlDbType.Int).Value = li_RnDWorkDetails.WorkTypeID;
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = li_RnDWorkDetails.BookID;
            cmd.Parameters.Add("@WorkStartTime", SqlDbType.VarChar).Value = li_RnDWorkDetails.WorkStartTime;
            cmd.Parameters.Add("@WorkEndTime", SqlDbType.VarChar).Value = li_RnDWorkDetails.WorkEndTime;
            cmd.Parameters.Add("@WorkTimeSpan", SqlDbType.Decimal).Value = li_RnDWorkDetails.WorkTimeSpan;
            cmd.Parameters.Add("@PageStart", SqlDbType.Int).Value = li_RnDWorkDetails.PageStart;
            cmd.Parameters.Add("@PageEnd", SqlDbType.Int).Value = li_RnDWorkDetails.PageEnd;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_RnDWorkDetails.Comments;
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
    public int Delete_Li_RnDWorkDetails(Li_RnDWorkDetails li_RnDWorkDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_DeleteLi_RnDWorkDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkDetailID", SqlDbType.Int).Value = li_RnDWorkDetails.WorkDetailID;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = li_RnDWorkDetails.Comments;
            cmd.Parameters.Add("@DeletedBy", SqlDbType.Int).Value = li_RnDWorkDetails.CreatedBy;
            cmd.Parameters.Add("@DeletedDate", SqlDbType.DateTime).Value = li_RnDWorkDetails.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }
    public int Delete_Li_RnDWorkDetailsQawmi(Li_RnDWorkDetails li_RnDWorkDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_DeleteLi_RnDWorkDetailsQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkDetailID", SqlDbType.Int).Value = li_RnDWorkDetails.WorkDetailID;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = li_RnDWorkDetails.Comments;
            cmd.Parameters.Add("@DeletedBy", SqlDbType.Int).Value = li_RnDWorkDetails.CreatedBy;
            cmd.Parameters.Add("@DeletedDate", SqlDbType.DateTime).Value = li_RnDWorkDetails.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }
}
