using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using DAL;

public class Sqlli_RnDQawmiWorkOrderDetailsProvider : DataAccessObject
{
    public Sqlli_RnDQawmiWorkOrderDetailsProvider()
    {
    }


    public bool DeleteLi_RnDWorkOrderDetails(int li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_RnDWorkOrderDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_RnDWorkDetailsID", SqlDbType.Int).Value = li_RnDWorkOrderDetails;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_RnDQawmiWorkOrderDetails> GetAllLi_RnDWorkOrderDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_RnDWorkDetailss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_RnDWorkOrderDetailssFromReader(reader);
        }
    }
    public List<Li_RnDQawmiWorkOrderDetails> GetLi_RnDWorkOrderDetailssFromReader(IDataReader reader)
    {
        List<Li_RnDQawmiWorkOrderDetails> li_RnDWorkOrderDetailss = new List<Li_RnDQawmiWorkOrderDetails>();

        while (reader.Read())
        {
            li_RnDWorkOrderDetailss.Add(GetLi_RnDWorkOrderDetailsFromReader(reader));
        }
        return li_RnDWorkOrderDetailss;
    }

    public Li_RnDQawmiWorkOrderDetails GetLi_RnDWorkOrderDetailsFromReader(IDataReader reader)
    {
        try
        {
            Li_RnDQawmiWorkOrderDetails li_RnDWorkDetails = new Li_RnDQawmiWorkOrderDetails
                (
                    (int)reader["WorkOrderDetID"],
                    (int)reader["WorkOrderID"],
                    (DateTime)reader["WorkDate"],
                    (String)reader["EmployeeID"],
                    (int)reader["SectionID"],
                    (int)reader["IsHired"],
                    (int)reader["WorkTypeID"],
                    reader["BookID"].ToString(),
                    (int)reader["classID"],
                    (int)reader["PageStart"],
                    (int)reader["PageEnd"],
                    (int)reader["totalPage"],
                    (decimal)reader["totalForma"],
                    (Decimal)reader["totalCharacter"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (String)reader["SizeID"],
                    (String)reader["Edition"],
                    (String)reader["Comments"]


                );
            return li_RnDWorkDetails;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Li_RnDQawmiWorkOrderDetails GetLi_RnDWorkOrderDetailsByID(int li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_RnDWorkOrderDetailsByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_RnDWorkOrderDetailsID", SqlDbType.Int).Value = li_RnDWorkOrderDetails;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_RnDWorkOrderDetailsFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_RnDWorkOrderDetails(Li_RnDQawmiWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_RnDWorkOrderDetailsQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@WorkOrderDetID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@WorkOrderID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.WorkOrderID;
            cmd.Parameters.Add("@WorkDate", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.WorkDate;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = li_RnDWorkOrderDetails.EmployeeID;
            cmd.Parameters.Add("@WorkTypeID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.WorkTypeID;
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = li_RnDWorkOrderDetails.BookID;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.ClassID;
            cmd.Parameters.Add("@PageStart", SqlDbType.Int).Value = li_RnDWorkOrderDetails.PageStart;
            cmd.Parameters.Add("@PageEnd", SqlDbType.Int).Value = li_RnDWorkOrderDetails.PageEnd;
            cmd.Parameters.Add("@TotalPage", SqlDbType.Int).Value = li_RnDWorkOrderDetails.TotalPage;
            cmd.Parameters.Add("@TotalForma", SqlDbType.Decimal).Value = li_RnDWorkOrderDetails.TotalForma;
            cmd.Parameters.Add("@TotalCharacter", SqlDbType.Decimal).Value = li_RnDWorkOrderDetails.TotalCharacter;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_RnDWorkOrderDetails.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.CreatedDate;
            cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.SectionID;
            cmd.Parameters.Add("@IsHired", SqlDbType.Int).Value = li_RnDWorkOrderDetails.IsHired;
            cmd.Parameters.Add("@SizeID", SqlDbType.VarChar).Value = li_RnDWorkOrderDetails.SizeID;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_RnDWorkOrderDetails.Edition;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_RnDWorkOrderDetails.Comments;


            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_RnDWorkOrderDetails(Li_RnDQawmiWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_UpdateLi_RnDWorkOrderDetailsQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkOrderDetID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.WorkOrderDetID;
            cmd.Parameters.Add("@EDD", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.WorkDate;
            //cmd.Parameters.Add("@WorkTypeID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.WorkTypeID;
            cmd.Parameters.Add("@PageStart", SqlDbType.Int).Value = li_RnDWorkOrderDetails.PageStart;
            cmd.Parameters.Add("@PageEnd", SqlDbType.Int).Value = li_RnDWorkOrderDetails.PageEnd;
            cmd.Parameters.Add("@TotalPage", SqlDbType.Int).Value = li_RnDWorkOrderDetails.TotalPage;
            cmd.Parameters.Add("@TotalForma", SqlDbType.Decimal).Value = li_RnDWorkOrderDetails.TotalForma;
            cmd.Parameters.Add("@TotalCharacter", SqlDbType.Decimal).Value = li_RnDWorkOrderDetails.TotalCharacter;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_RnDWorkOrderDetails.CreatedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.CreatedDate;
            cmd.Parameters.Add("@WorkTypeID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.WorkTypeID;
            cmd.Parameters.Add("@SizeID", SqlDbType.VarChar).Value = li_RnDWorkOrderDetails.SizeID;
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
    public DataSet Get_DateWiseRnDWorkOrderDetails(string fromDate, string toDate, string employeeID, int IsHired)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_getDatewiseRndWorkOrderDetailsQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromDate;
            cmd.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = toDate;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = employeeID;
            cmd.Parameters.Add("@IsHired", SqlDbType.Int).Value = IsHired;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public DataSet GetLi_RnDWorkOrderDetailsByWorkID(string WorkOrderID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_PrintRnDWorkOrderQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = WorkOrderID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public string InsertLi_RnDWorkOrder(Li_RnDQawmiWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_RnDWorkOrderQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@WorkOrderID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@WorkDate", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.WorkDate;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = li_RnDWorkOrderDetails.EmployeeID;
            cmd.Parameters.Add("@TotalPage", SqlDbType.Int).Value = li_RnDWorkOrderDetails.TotalPage;
            cmd.Parameters.Add("@TotalForma", SqlDbType.Decimal).Value = li_RnDWorkOrderDetails.TotalForma;
            cmd.Parameters.Add("@TotalCharacter", SqlDbType.Decimal).Value = li_RnDWorkOrderDetails.TotalCharacter;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_RnDWorkOrderDetails.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.CreatedDate;
            cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.SectionID;
            cmd.Parameters.Add("@IsHired", SqlDbType.Int).Value = li_RnDWorkOrderDetails.IsHired;
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@WorkOrderID"].Value.ToString();
        }
    }
    public int InsertLi_RnDWorkOrderBill(Li_RnDQawmiWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_RnDWorkOrderBillQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@WorkOrderBillID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@WorkOrderDetID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.WorkOrderDetID;
            cmd.Parameters.Add("@WorkDeliveryDate", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.WorkDate;
            cmd.Parameters.Add("@ActualDelivery", SqlDbType.Decimal).Value = li_RnDWorkOrderDetails.TotalCharacter;
            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = li_RnDWorkOrderDetails.TotalForma;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_RnDWorkOrderDetails.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }
    public DataSet GetLi_RnDWorkOrderDetailsByWorkDetID(int WorkOrderDetID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_PrintRnDWorkOrderDetailsByDetIDQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkOrderDetID", SqlDbType.Int).Value = WorkOrderDetID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public int UpdateLi_RnDWorkOrderBill(Li_RnDQawmiWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_UpdateLi_RnDWorkOrderBillQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BillNo", SqlDbType.Int).Value = li_RnDWorkOrderDetails.WorkOrderID;
            cmd.Parameters.Add("@WorkDate", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.WorkDate;
            cmd.Parameters.Add("@DeliveryQty", SqlDbType.Decimal).Value = li_RnDWorkOrderDetails.TotalForma;
            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = li_RnDWorkOrderDetails.TotalCharacter;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_RnDWorkOrderDetails.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }
    public DataSet GetLi_RnDWorkOrderBillNoByWorkDetID(int WorkOrderDetID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_GetLi_RnDWorkOrderBillNoByWorkDetIDQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkOrderDetID", SqlDbType.Int).Value = WorkOrderDetID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public int Delete_Li_RnDWorkOrder(Li_RnDQawmiWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_DeleteLi_RnDWorkOrderQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkOrderDetID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.WorkOrderDetID;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = li_RnDWorkOrderDetails.EmployeeID;
            cmd.Parameters.Add("@DeletedBy", SqlDbType.Int).Value = li_RnDWorkOrderDetails.CreatedBy;
            cmd.Parameters.Add("@DeletedDate", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }
    public DataSet GetLi_RnDWorkOrderDetailsByWorkIDForUpdateAndDelete(String WorkOrderID, int UserID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_GetRnDWorkOrderDetailsByOrderIDForUpdateAndDeleteQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = WorkOrderID;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public DataSet GetLi_RnDWorkOrderDetailsByWorkOrderDetID(int WorkOrderDetailID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_getRndWorkOrderDetailsByWorkOrderDetailsIDQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkOrderDetailID", SqlDbType.Int).Value = WorkOrderDetailID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public DataSet GetDatewiseRndWorkOrderDetailsByEmployeeID(string fromDate, string toDate, string employeeID, int IsHired)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_getDatewiseRndWorkOrderDetailsByEmployeeIDQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromDate;
            cmd.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = toDate;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = employeeID;
            cmd.Parameters.Add("@IsHired", SqlDbType.Int).Value = IsHired;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public DataSet GetRndWorkOrderSearchByEmployeeName(string EmployeeName)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_GetRndWorkOrderSearchByEmployeeNameQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar).Value = EmployeeName;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public DataSet GetLi_RnDWorkOrderDetailsByWorkOrderDetIDForTransfer(int WorkOrderDetailID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_GetLi_RnDWorkOrderDetailsByWorkOrderDetIDForTransferQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkOrderDetailID", SqlDbType.Int).Value = WorkOrderDetailID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public DataSet GetLi_RnDWorkOrderBillInfoByOrderNo(string WorkOrderID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_GetRnDWorkOrderBillByOrderNoQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = WorkOrderID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public int TransferLi_RnDWorkOrderDetails(Li_RnDQawmiWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_RnDWorkOrderTransferQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TransID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@WorkOrderDetID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.WorkOrderDetID;
            cmd.Parameters.Add("@EDD", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.WorkDate;
            cmd.Parameters.Add("@TotalQty", SqlDbType.Decimal).Value = li_RnDWorkOrderDetails.TotalForma;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_RnDWorkOrderDetails.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.CreatedDate;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = li_RnDWorkOrderDetails.EmployeeID;
            cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.SectionID;
            cmd.Parameters.Add("@IsHired", SqlDbType.Int).Value = li_RnDWorkOrderDetails.IsHired;
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            return result = 1;
        }
    }
    public int ApprovalLi_RnDWorkOrderBill(Li_RnDQawmiWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_ApprovalLi_RnDWorkOrderBillQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkOrderDetID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.WorkOrderDetID;
            cmd.Parameters.Add("@BillNo", SqlDbType.Int).Value = li_RnDWorkOrderDetails.WorkOrderID;
            cmd.Parameters.Add("@DeliveryQty", SqlDbType.Decimal).Value = li_RnDWorkOrderDetails.TotalForma;
            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = li_RnDWorkOrderDetails.TotalCharacter;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = li_RnDWorkOrderDetails.EmployeeID;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_RnDWorkOrderDetails.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }
    public int RejectLi_RnDWorkOrderBill(Li_RnDQawmiWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_RejectLi_RnDWorkOrderBillQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkOrderDetID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.WorkOrderDetID;
            cmd.Parameters.Add("@BillNo", SqlDbType.Int).Value = li_RnDWorkOrderDetails.WorkOrderID;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = li_RnDWorkOrderDetails.EmployeeID;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_RnDWorkOrderDetails.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }
    public DataSet GetLi_RnDWorkOrderBillDetailsByBillNo(int BillNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_GetRnDWorkOrderBillByBillNoQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BillNo", SqlDbType.Int).Value = BillNo;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public DataSet GetLi_RnDWorkOrderBillUpdateInfoByOrderNo(string WorkOrderID, int UserID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_GetRnDWorkOrderBillUpdateByOrderNoQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = WorkOrderID;
            cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public DataSet GetLi_RnDWorkOrderBillPrintInfoByOrderNo(string WorkOrderID, int UserID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_GetLi_RnDWorkOrderBillPrintInfoByOrderNoQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = WorkOrderID;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public string InsertLi_RnDWorkPlanForNewBook(Li_RnDQawmiWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_RnDWorkPlanForNewBookQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@WorkPlanID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = li_RnDWorkOrderDetails.BookID;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.ClassID;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_RnDWorkOrderDetails.Edition;
            cmd.Parameters.Add("@SizeID", SqlDbType.VarChar).Value = li_RnDWorkOrderDetails.SizeID;
            cmd.Parameters.Add("@TotalTask", SqlDbType.Int).Value = li_RnDWorkOrderDetails.TotalPage;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_RnDWorkOrderDetails.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.CreatedDate;
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@WorkPlanID"].Value.ToString();
        }
    }
    public int InsertLi_RnDWorkPlanForNewBookDetails(Li_RnDQawmiWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_RnDWorkPlanForNewBookDetailsQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@WorkPlanDetID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@WorkPlanID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.WorkOrderID;
            cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.SectionID;
            cmd.Parameters.Add("@IsHired", SqlDbType.Int).Value = li_RnDWorkOrderDetails.IsHired;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = li_RnDWorkOrderDetails.EmployeeID;
            cmd.Parameters.Add("@WorkTypeID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.WorkTypeID;
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.CreatedDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.WorkDate;
            cmd.Parameters.Add("@PageStart", SqlDbType.Int).Value = li_RnDWorkOrderDetails.PageStart;
            cmd.Parameters.Add("@PageEnd", SqlDbType.Int).Value = li_RnDWorkOrderDetails.PageEnd;
            cmd.Parameters.Add("@TotalPage", SqlDbType.Int).Value = li_RnDWorkOrderDetails.TotalPage;
            cmd.Parameters.Add("@TotalForma", SqlDbType.Decimal).Value = li_RnDWorkOrderDetails.TotalForma;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_RnDWorkOrderDetails.CreatedBy;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }
    public DataSet GetRndWorkOrderUpdateSearchByEmployeeName(string EmployeeName, int UserID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_GetRndWorkOrderUpdateSearchByEmployeeNameQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar).Value = EmployeeName;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public DataSet GetLi_RnDWorkOrderBillAprovalInfoByOrderNo(string WorkOrderID, int UserID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_GetLi_RnDWorkOrderBillAprovalInfoByOrderNoQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = WorkOrderID;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public DataSet GetLi_RnDWorkOrderDetailsByWorkIDforBillGenerate(string WorkOrderID, int UserID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_RnDWorkOrderDetailsByWorkIDforBillGenerateQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = WorkOrderID;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
    public DataSet GetLi_RnDWorkOrderBillStatus(string WorkOrderID, int UserID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_GetLi_RnDWorkOrderBillStatusQawmi", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = WorkOrderID;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();
            return ds;
        }
    }
}


