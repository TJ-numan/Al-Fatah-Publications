using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
public class Li_RnDWorkOrderDetailsManager
{
    public Li_RnDWorkOrderDetailsManager()
	{
	}
    public static List<Li_RnDWorkOrderDetails> GetAllLi_RnDWorkOrderDetails()
    {
        List<Li_RnDWorkOrderDetails> li_RnDWorkOrderDetails = new List<Li_RnDWorkOrderDetails>();
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        li_RnDWorkOrderDetails = sqlLi_RnDWorkDetailsProvider.GetAllLi_RnDWorkOrderDetails();
        return li_RnDWorkOrderDetails;
    }


    public static Li_RnDWorkOrderDetails GetLi_RnDWorkOrderDetailsByID(int id)
    {
        Li_RnDWorkOrderDetails li_RnDWorkOrderDetails = new Li_RnDWorkOrderDetails();
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        li_RnDWorkOrderDetails = sqlLi_RnDWorkDetailsProvider.GetLi_RnDWorkOrderDetailsByID(id);
        return li_RnDWorkOrderDetails;
    }


    public static int InsertLi_RnDWorkOrderDetails(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.InsertLi_RnDWorkOrderDetails(li_RnDWorkOrderDetails);
    }


    public static bool UpdateLi_RnDWorkOrderDetails(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.UpdateLi_RnDWorkOrderDetails(li_RnDWorkOrderDetails);
    }

    public static bool DeleteLi_RnDWorkOrderDetails(int li_RnDWorkOrderDetails)
    {
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.DeleteLi_RnDWorkOrderDetails(li_RnDWorkOrderDetails);
    }
    public static DataSet Get_DateWiseRnDWorkOrderDetails(string fromDate, string toDate, string employeeID, int IsHired)
    {
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.Get_DateWiseRnDWorkOrderDetails(fromDate, toDate, employeeID, IsHired);

    }
    public static DataSet GetLi_RnDWorkOrderDetailsByWorkID(string WorkOrderID)
    {
        Li_RnDWorkOrderDetails li_RnDWorkDetails = new Li_RnDWorkOrderDetails();
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.GetLi_RnDWorkOrderDetailsByWorkID(WorkOrderID);
    }

    public static string InsertLi_RnDWorkOrder(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.InsertLi_RnDWorkOrder(li_RnDWorkOrderDetails);
    }
    public static int InsertLi_RnDWorkOrderBill(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.InsertLi_RnDWorkOrderBill(li_RnDWorkOrderDetails);
    }
    public static DataSet GetLi_RnDWorkOrderDetailsByWorkDetID(int WorkOrderID)
    {
        Li_RnDWorkOrderDetails li_RnDWorkDetails = new Li_RnDWorkOrderDetails();
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.GetLi_RnDWorkOrderDetailsByWorkDetID(WorkOrderID);
    }
    public static int UpdateLi_RnDWorkOrderBill(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.UpdateLi_RnDWorkOrderBill(li_RnDWorkOrderDetails);
    }
    public static DataSet GetLi_RnDWorkOrderBillNoByWorkDetID(int WorkOrderDetID)
    {
        Li_RnDWorkOrderDetails li_RnDWorkDetails = new Li_RnDWorkOrderDetails();
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.GetLi_RnDWorkOrderBillNoByWorkDetID(WorkOrderDetID);
    }
    public static int Delete_Li_RnDWorkOrder(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.Delete_Li_RnDWorkOrder(li_RnDWorkOrderDetails);
    }
    public static DataSet GetLi_RnDWorkOrderDetailsByWorkIDForUpdateAndDelete(string WorkOrderID, int UserID)
    {
        Li_RnDWorkOrderDetails li_RnDWorkDetails = new Li_RnDWorkOrderDetails();
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.GetLi_RnDWorkOrderDetailsByWorkIDForUpdateAndDelete(WorkOrderID, UserID);
    }
    public static DataSet GetLi_RnDWorkOrderDetailsByWorkOrderDetID(int WorkOrderDetailID)
    {
        Li_RnDWorkOrderDetails li_RnDWorkOrderDetails = new Li_RnDWorkOrderDetails();
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.GetLi_RnDWorkOrderDetailsByWorkOrderDetID(WorkOrderDetailID);
    }
    public static DataSet GetDatewiseRndWorkOrderDetailsByEmployeeID(string fromDate, string toDate, string employeeID, int IsHired)
    {
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.GetDatewiseRndWorkOrderDetailsByEmployeeID(fromDate, toDate, employeeID, IsHired);

    }
    public static DataSet GetRndWorkOrderSearchByEmployeeName(string EmployeeName)
    {
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.GetRndWorkOrderSearchByEmployeeName(EmployeeName);

    }
    public static DataSet GetLi_RnDWorkOrderDetailsByWorkOrderDetIDForTransfer(int WorkOrderDetailID)
    {
        Li_RnDWorkOrderDetails li_RnDWorkOrderDetails = new Li_RnDWorkOrderDetails();
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.GetLi_RnDWorkOrderDetailsByWorkOrderDetIDForTransfer(WorkOrderDetailID);
    }
    public static DataSet GetLi_RnDWorkOrderBillInfoByOrderNo(string WorkOrderID)
    {
        Li_RnDWorkOrderDetails li_RnDWorkDetails = new Li_RnDWorkOrderDetails();
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.GetLi_RnDWorkOrderBillInfoByOrderNo(WorkOrderID);
    }
    public static int TransferLi_RnDWorkOrderDetails(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.TransferLi_RnDWorkOrderDetails(li_RnDWorkOrderDetails);
    }
    public static int ApprovalLi_RnDWorkOrderBill(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.ApprovalLi_RnDWorkOrderBill(li_RnDWorkOrderDetails);
    }
    public static int RejectLi_RnDWorkOrderBill(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.RejectLi_RnDWorkOrderBill(li_RnDWorkOrderDetails);
    }
    public static DataSet GetLi_RnDWorkOrderBillDetailsByBillNo(int BillNo)
    {
        Li_RnDWorkOrderDetails li_RnDWorkOrderDetails = new Li_RnDWorkOrderDetails();
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.GetLi_RnDWorkOrderBillDetailsByBillNo(BillNo);
    }
    public static DataSet GetLi_RnDWorkOrderBillUpdateInfoByOrderNo(string WorkOrderID, int UserID)
    {
        Li_RnDWorkOrderDetails li_RnDWorkDetails = new Li_RnDWorkOrderDetails();
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.GetLi_RnDWorkOrderBillUpdateInfoByOrderNo(WorkOrderID, UserID);
    }
    public static DataSet GetLi_RnDWorkOrderBillPrintInfoByOrderNo(string WorkOrderID, int UserID)
    {
        Li_RnDWorkOrderDetails li_RnDWorkDetails = new Li_RnDWorkOrderDetails();
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.GetLi_RnDWorkOrderBillPrintInfoByOrderNo(WorkOrderID, UserID);
    }
    public static string InsertLi_RnDWorkPlanForNewBook(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.InsertLi_RnDWorkPlanForNewBook(li_RnDWorkOrderDetails);
    }
    public static int InsertLi_RnDWorkPlanForNewBookDetails(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.InsertLi_RnDWorkPlanForNewBookDetails(li_RnDWorkOrderDetails);
    }
    public static DataSet GetRndWorkOrderUpdateSearchByEmployeeName(string EmployeeName, int UserID)
    {
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.GetRndWorkOrderUpdateSearchByEmployeeName(EmployeeName, UserID);

    }
    public static DataSet GetLi_RnDWorkOrderBillAprovalInfoByOrderNo(string WorkOrderID, int UserID)
    {
        Li_RnDWorkOrderDetails li_RnDWorkDetails = new Li_RnDWorkOrderDetails();
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.GetLi_RnDWorkOrderBillAprovalInfoByOrderNo(WorkOrderID, UserID);
    }
    public static DataSet GetLi_RnDWorkOrderDetailsByWorkIDforBillGenerate(string WorkOrderID, int UserID)
    {
        Li_RnDWorkOrderDetails li_RnDWorkDetails = new Li_RnDWorkOrderDetails();
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.GetLi_RnDWorkOrderDetailsByWorkIDforBillGenerate(WorkOrderID, UserID);
    }
    public static DataSet GetLi_RnDWorkOrderBillStatus(string WorkOrderID, int UserID)
    {
        Li_RnDWorkOrderDetails li_RnDWorkDetails = new Li_RnDWorkOrderDetails();
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.GetLi_RnDWorkOrderBillStatus(WorkOrderID, UserID);
    }
    public static string InsertLi_RnDWorkOrderGraphics(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.InsertLi_RnDWorkOrderGraphics(li_RnDWorkOrderDetails);
    }
    public static int InsertLi_RnDWorkOrderDetailsGraphics(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.InsertLi_RnDWorkOrderDetailsGraphics(li_RnDWorkOrderDetails);
    }
    public static DataSet GetLi_RnDWorkOrderDetailsByWorkIDforBillGenerateGraphics(string WorkOrderID, int UserID)
    {
        Li_RnDWorkOrderDetails li_RnDWorkDetails = new Li_RnDWorkOrderDetails();
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.GetLi_RnDWorkOrderDetailsByWorkIDforBillGenerateGraphics(WorkOrderID, UserID);
    }
    public static int InsertLi_RnDWorkOrderBillGraphics(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.InsertLi_RnDWorkOrderBillGraphics(li_RnDWorkOrderDetails);
    }
    public static DataSet GetLi_RnDWorkOrderBillAprovalInfoByOrderNoGraphics(string WorkOrderID, int UserID)
    {
        Li_RnDWorkOrderDetails li_RnDWorkDetails = new Li_RnDWorkOrderDetails();
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.GetLi_RnDWorkOrderBillAprovalInfoByOrderNoGraphics(WorkOrderID, UserID);
    }
    public static DataSet GetLi_RnDWorkOrderDetailsByWorkDetIDGraphics(int WorkOrderID)
    {
        Li_RnDWorkOrderDetails li_RnDWorkDetails = new Li_RnDWorkOrderDetails();
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.GetLi_RnDWorkOrderDetailsByWorkDetIDGraphics(WorkOrderID);
    }
    public static int ApprovalLi_RnDWorkOrderBillGraphics(Li_RnDWorkOrderDetails li_RnDWorkOrderDetails)
    {
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.ApprovalLi_RnDWorkOrderBillGraphics(li_RnDWorkOrderDetails);
    }
    public static DataSet GetLi_RnDWorkOrderBillPrintInfoByOrderNoGraphics(string WorkOrderID, int UserID)
    {
        Li_RnDWorkOrderDetails li_RnDWorkDetails = new Li_RnDWorkOrderDetails();
        Sqlli_RnDWorkOrderDetailsProvider sqlLi_RnDWorkOrderDetailsProvider = new Sqlli_RnDWorkOrderDetailsProvider();
        return sqlLi_RnDWorkOrderDetailsProvider.GetLi_RnDWorkOrderBillPrintInfoByOrderNoGraphics(WorkOrderID, UserID);
    }
}

