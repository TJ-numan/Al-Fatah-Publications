using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_CoverBill
{
    public Li_CoverBill()
    {
    }

    public Li_CoverBill
        (
        
        string billID, 
        DateTime billDate, 
        string billNo, 
        string supplierID, 
        string bookCode, 
        bool isRebind, 
        decimal totalQty, 
        decimal billRate, 
        decimal totalBill, 
        DateTime createdDate, 
        int createBy, 
        char status_D, 
        DateTime delDate, 
        string causeOfDel, 
        int deleBy  
         
        )
    {
 
        this.BillID = billID;
        this.BillDate = billDate;
        this.BillNo = billNo;
        this.SupplierID = supplierID;
        this.BookCode = bookCode;
        this.IsRebind = isRebind;
        this.TotalQty = totalQty;
        this.BillRate = billRate;
        this.TotalBill = totalBill;
        this.CreatedDate = createdDate;
        this.CreateBy = createBy;
        this.Status_D = status_D;
        this.DelDate = delDate;
        this.CauseOfDel = causeOfDel;
        this.DeleBy = deleBy;
      
    }


  
    private string _billID;
    public string BillID
    {
        get { return _billID; }
        set { _billID = value; }
    }

    private DateTime _billDate;
    public DateTime BillDate
    {
        get { return _billDate; }
        set { _billDate = value; }
    }

    private string _billNo;
    public string BillNo
    {
        get { return _billNo; }
        set { _billNo = value; }
    }

    private string _supplierID;
    public string SupplierID
    {
        get { return _supplierID; }
        set { _supplierID = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private bool _isRebind;
    public bool IsRebind
    {
        get { return _isRebind; }
        set { _isRebind = value; }
    }

    private decimal _totalQty;
    public decimal TotalQty
    {
        get { return _totalQty; }
        set { _totalQty = value; }
    }

    private decimal _billRate;
    public decimal BillRate
    {
        get { return _billRate; }
        set { _billRate = value; }
    }

    private decimal _totalBill;
    public decimal TotalBill
    {
        get { return _totalBill; }
        set { _totalBill = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private int _createBy;
    public int CreateBy
    {
        get { return _createBy; }
        set { _createBy = value; }
    }

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

    private DateTime _delDate;
    public DateTime DelDate
    {
        get { return _delDate; }
        set { _delDate = value; }
    }

    private string _causeOfDel;
    public string CauseOfDel
    {
        get { return _causeOfDel; }
        set { _causeOfDel = value; }
    }

    private int _deleBy;
    public int DeleBy
    {
        get { return _deleBy; }
        set { _deleBy = value; }
    }

  
}
