using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using DAL;

public class Sqlli_RnDWorkOrderDetailsProvider : DataAccessObject
{
    public Sqlli_RnDWorkOrderDetailsProvider()
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

    public List<Li_RnDWorkOrderDetails> GetAllLi_RnDWorkOrderDetails()
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
    public List<Li_RnDWorkOrderDetails> GetLi_RnDWorkOrderDetailssFromReader(IDataReader reader)
    {
        List<Li_RnDWorkOrderDetails> li_RnDWorkOrderDetailss = new List<Li_RnDWorkOrderDetails>();

        while (reader.Read())
        {
            li_RnDWorkOrderDetailss.Add(GetLi_RnDWorkOrderDetailsFromReader(reader));
        }
        return li_RnDWorkOrderDetailss;
    }

    public Li_RnDWorkOrderDetails GetLi_RnDWorkOrderDetailsFromReader(IDataReader reader)
    {
        try
        {
            Li_RnDWorkOrderDetails li_RnDWorkDetails = new Li_RnDWorkOrderDetails
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
                    (String)reader["Edition"]


                );
            return li_RnDWorkDetails;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Li_RnDWorkOrderDetails GetLi_RnDWorkOrderDetailsByID(int li_RnDWorkOrderDetails)
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

    public int InsertLi_RnDWorkOrderDetails(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_RnDWorkOrderDetails", connection);
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


            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_RnDWorkOrderDetails(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_UpdateLi_RnDWorkOrderDetails", connection);
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
            SqlCommand cmd = new SqlCommand("SMPM_li_getDatewiseRndWorkOrderDetails", connection);
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
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_PrintRnDWorkOrder", connection);
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
    public string InsertLi_RnDWorkOrder(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_RnDWorkOrder", connection);
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
    public int InsertLi_RnDWorkOrderBill(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_RnDWorkOrderBill", connection);
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
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_PrintRnDWorkOrderDetailsByDetID", connection);
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
    public int UpdateLi_RnDWorkOrderBill(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_UpdateLi_RnDWorkOrderBill", connection);
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
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_GetLi_RnDWorkOrderBillNoByWorkDetID", connection);
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
    public int Delete_Li_RnDWorkOrder(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_DeleteLi_RnDWorkOrder", connection);
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
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_GetRnDWorkOrderDetailsByOrderIDForUpdateAndDelete", connection);
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
            SqlCommand cmd = new SqlCommand("SMPM_li_getRndWorkOrderDetailsByWorkOrderDetailsID", connection);
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
            SqlCommand cmd = new SqlCommand("SMPM_li_getDatewiseRndWorkOrderDetailsByEmployeeID", connection);
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
            SqlCommand cmd = new SqlCommand("SMPM_li_GetRndWorkOrderSearchByEmployeeName", connection);
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
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_GetLi_RnDWorkOrderDetailsByWorkOrderDetIDForTransfer", connection);
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
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_GetRnDWorkOrderBillByOrderNo", connection);
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
    public int TransferLi_RnDWorkOrderDetails(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_RnDWorkOrderTransfer", connection);
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
    public int ApprovalLi_RnDWorkOrderBill(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_ApprovalLi_RnDWorkOrderBill", connection);
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
    public int RejectLi_RnDWorkOrderBill(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_RejectLi_RnDWorkOrderBill", connection);
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
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_GetRnDWorkOrderBillByBillNo", connection);
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
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_GetRnDWorkOrderBillUpdateByOrderNo", connection);
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
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_GetLi_RnDWorkOrderBillPrintInfoByOrderNo", connection);
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
    public string InsertLi_RnDWorkPlanForNewBook(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_RnDWorkPlanForNewBook", connection);
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
    public int InsertLi_RnDWorkPlanForNewBookDetails(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_RnDWorkPlanForNewBookDetails", connection);
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
            SqlCommand cmd = new SqlCommand("SMPM_li_GetRndWorkOrderUpdateSearchByEmployeeName", connection);
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
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_GetLi_RnDWorkOrderBillAprovalInfoByOrderNo", connection);
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
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_RnDWorkOrderDetailsByWorkIDforBillGenerate", connection);
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
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_GetLi_RnDWorkOrderBillStatus", connection);
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
    public string InsertLi_RnDWorkOrderGraphics(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_RnDWorkOrderGraphics", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@WorkOrderID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@WorkDate", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.WorkDate;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = li_RnDWorkOrderDetails.EmployeeID;
            cmd.Parameters.Add("@TotalUnit", SqlDbType.Decimal).Value = li_RnDWorkOrderDetails.TotalCharacter;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_RnDWorkOrderDetails.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.CreatedDate;
            cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.SectionID;
            cmd.Parameters.Add("@IsHired", SqlDbType.Int).Value = li_RnDWorkOrderDetails.IsHired;
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@WorkOrderID"].Value.ToString();
        }
    }
    public int InsertLi_RnDWorkOrderDetailsGraphics(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_RnDWorkOrderDetailsGraphics", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@WorkOrderDetID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@WorkOrderID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.WorkOrderID;
            cmd.Parameters.Add("@WorkDate", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.WorkDate;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = li_RnDWorkOrderDetails.EmployeeID;
            cmd.Parameters.Add("@WorkTypeID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.WorkTypeID;
            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = li_RnDWorkOrderDetails.BookID;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.ClassID;
            cmd.Parameters.Add("@Unit", SqlDbType.Decimal).Value = li_RnDWorkOrderDetails.TotalCharacter;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_RnDWorkOrderDetails.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_RnDWorkOrderDetails.CreatedDate;
            cmd.Parameters.Add("@SectionID", SqlDbType.Int).Value = li_RnDWorkOrderDetails.SectionID;
            cmd.Parameters.Add("@IsHired", SqlDbType.Int).Value = li_RnDWorkOrderDetails.IsHired;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_RnDWorkOrderDetails.Edition;


            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }
    public DataSet GetLi_RnDWorkOrderDetailsByWorkIDforBillGenerateGraphics(string WorkOrderID, int UserID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_RnDWorkOrderDetailsByWorkIDforBillGenerateGraphics", connection);
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
    public int InsertLi_RnDWorkOrderBillGraphics(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_InsertLi_RnDWorkOrderBillGraphics", connection);
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
    public DataSet GetLi_RnDWorkOrderBillAprovalInfoByOrderNoGraphics(string WorkOrderID, int UserID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_GetLi_RnDWorkOrderBillAprovalInfoByOrderNoGraphics", connection);
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
    public DataSet GetLi_RnDWorkOrderDetailsByWorkDetIDGraphics(int WorkOrderDetID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_PrintRnDWorkOrderDetailsByDetIDGraphics", connection);
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
    public int ApprovalLi_RnDWorkOrderBillGraphics(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_ApprovalLi_RnDWorkOrderBillGraphics", connection);
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
    public DataSet GetLi_RnDWorkOrderBillPrintInfoByOrderNoGraphics(string WorkOrderID, int UserID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Web_SMPM_li_GetLi_RnDWorkOrderBillPrintInfoByOrderNoGraphics", connection);
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

