using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PaperTransfer
{
    public Li_PaperTransfer()
    {
    }

    public Li_PaperTransfer
        (
 
        int transNo, 
        string refNo, 
        DateTime transDate, 
        string prssFrom, 
        string pressTo, 
        decimal totalBill, 
        decimal labourBill, 
        string remark, 
        DateTime createdDate, 
        int createdBy, 
        char status_D, 
        int deletBy, 
        DateTime deleteDate, 
        string causeOFDel 
         
        )
    {
         this.TransNo = transNo;
        this.RefNo = refNo;
        this.TransDate = transDate;
        this.PrssFrom = prssFrom;
        this.PressTo = pressTo;
        this.TotalBill = totalBill;
        this.LabourBill = labourBill;
        this.Remark = remark;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.Status_D = status_D;
        this.DeletBy = deletBy;
        this.DeleteDate = deleteDate;
        this.CauseOFDel = causeOFDel;
       
    }

 

    private int _transNo;
    public int TransNo
    {
        get { return _transNo; }
        set { _transNo = value; }
    }

    private string _refNo;
    public string RefNo
    {
        get { return _refNo; }
        set { _refNo = value; }
    }

    private DateTime _transDate;
    public DateTime TransDate
    {
        get { return _transDate; }
        set { _transDate = value; }
    }

    private string _prssFrom;
    public string PrssFrom
    {
        get { return _prssFrom; }
        set { _prssFrom = value; }
    }

    private string _pressTo;
    public string PressTo
    {
        get { return _pressTo; }
        set { _pressTo = value; }
    }

    private decimal _totalBill;
    public decimal TotalBill
    {
        get { return _totalBill; }
        set { _totalBill = value; }
    }

    private decimal _labourBill;
    public decimal LabourBill
    {
        get { return _labourBill; }
        set { _labourBill = value; }
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

    private int _deletBy;
    public int DeletBy
    {
        get { return _deletBy; }
        set { _deletBy = value; }
    }

    private DateTime _deleteDate;
    public DateTime DeleteDate
    {
        get { return _deleteDate; }
        set { _deleteDate = value; }
    }

    private string _causeOFDel;
    public string CauseOFDel
    {
        get { return _causeOFDel; }
        set { _causeOFDel = value; }
    }
 
}
