using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_BinderBill
{
    public Li_BinderBill()
    {
    }

    public Li_BinderBill
        (
       
        string billID, 
        DateTime billDate, 
        string billNo, 
        string binderID, 
        string bookCode, 
        bool isRebind, 
        decimal totalQty, 
        decimal ac_Forma, 
        decimal pay_Forma, 
        decimal miniRate, 
        decimal billRate, 
        decimal totalBill, 
        DateTime createdDate, 
        int createBy, 
        char status_D, 
        DateTime delDate, 
        string causeOfDel, 
        int deleBy ,
        int rateBy,
        decimal labourBill ,
        decimal otherCost
         
        )
    {
         
        this.BillID = billID;
        this.BillDate = billDate;
        this.BillNo = billNo;
        this.BinderID = binderID;
        this.BookCode = bookCode;
        this.IsRebind = isRebind;
        this.TotalQty = totalQty;
        this.Ac_Forma = ac_Forma;
        this.Pay_Forma = pay_Forma;
        this.MiniRate = miniRate;
        this.BillRate = billRate;
        this.TotalBill = totalBill;
        this.CreatedDate = createdDate;
        this.CreateBy = createBy;
        this.Status_D = status_D;
        this.DelDate = delDate;
        this.CauseOfDel = causeOfDel;
        this.DeleBy = deleBy;
        this.RateBy = rateBy;
        this.LabourBill = labourBill;
        this.OtherCost = otherCost;
    }

    public decimal OtherCost { get; set; }

    public int RateBy { get; set; }
    public decimal LabourBill {  get; set; }

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

    private string _binderID;
    public string BinderID
    {
        get { return _binderID; }
        set { _binderID = value; }
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

    private decimal _ac_Forma;
    public decimal Ac_Forma
    {
        get { return _ac_Forma; }
        set { _ac_Forma = value; }
    }

    private decimal _pay_Forma;
    public decimal Pay_Forma
    {
        get { return _pay_Forma; }
        set { _pay_Forma = value; }
    }

    private decimal _miniRate;
    public decimal MiniRate
    {
        get { return _miniRate; }
        set { _miniRate = value; }
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
