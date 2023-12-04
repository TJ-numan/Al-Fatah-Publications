using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PrintBill
{
    public Li_PrintBill()
    {
    }

    public Li_PrintBill
        (
       
        int billSerial, 
        string billNo, 
        DateTime billDate, 
        string orderNo, 
        string bookCode, 
        decimal printBill, 
        decimal plateBill, 
        decimal processBill, 
        decimal totalBill, 
        string remark, 
        DateTime createdDate, 
        int createdBy, 
        char status_D, 
        string causeOfDel, 
        DateTime delDate, 
        int delBy ,
        string pressID,
        decimal printQty,
        bool extra
        )
    {
         
        this.BillSerial = billSerial;
        this.BillNo = billNo;
        this.BillDate = billDate;
        this.OrderNo = orderNo;
        this.BookCode = bookCode;
        this.PrintBill = printBill;
        this.PlateBill = plateBill;
        this.ProcessBill = processBill;
        this.TotalBill = totalBill;
        this.Remark = remark;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.Status_D = status_D;
        this.CauseOfDel = causeOfDel;
        this.DelDate = delDate;
        this.DelBy = delBy;
        this.PrintQty = printQty;
        this.Extra = extra;
    }
    public bool Extra { get; set; }
    public decimal PrintQty { get; set; }
    public string PressID { get; set; }

    private int _billSerial;
    public int BillSerial
    {
        get { return _billSerial; }
        set { _billSerial = value; }
    }

    private string _billNo;
    public string BillNo
    {
        get { return _billNo; }
        set { _billNo = value; }
    }

    private DateTime _billDate;
    public DateTime BillDate
    {
        get { return _billDate; }
        set { _billDate = value; }
    }

    private string _orderNo;
    public string OrderNo
    {
        get { return _orderNo; }
        set { _orderNo = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private decimal _printBill;
    public decimal PrintBill
    {
        get { return _printBill; }
        set { _printBill = value; }
    }

    private decimal _plateBill;
    public decimal PlateBill
    {
        get { return _plateBill; }
        set { _plateBill = value; }
    }

    private decimal _processBill;
    public decimal ProcessBill
    {
        get { return _processBill; }
        set { _processBill = value; }
    }

    private decimal _totalBill;
    public decimal TotalBill
    {
        get { return _totalBill; }
        set { _totalBill = value; }
    }

    private string _remark;
    public string Remark
    {
        get { return _remark; }
        set { _remark = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

    private string _causeOfDel;
    public string CauseOfDel
    {
        get { return _causeOfDel; }
        set { _causeOfDel = value; }
    }

    private DateTime _delDate;
    public DateTime DelDate
    {
        get { return _delDate; }
        set { _delDate = value; }
    }

    private int _delBy;
    public int DelBy
    {
        get { return _delBy; }
        set { _delBy = value; }
    }

    
}
