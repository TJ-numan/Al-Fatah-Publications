using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PaperAcUsed
{
    public Li_PaperAcUsed()
    {
    }

    public Li_PaperAcUsed
        (
        string pressID,
        int prOrderSl, 
        string print_OrderNo, 
        DateTime printDate, 
        int printQty, 
        decimal paperUsed, 
        int plateUsed, 
        decimal rollQty, 
        string remark, 
        int createdBy, 
        DateTime createdDate, 
        char status_D, 
        string causeOFDel, 
        int delBy 
         
        )
    {
        this.PressID = pressID;
        this.PrOrderSl = prOrderSl;
        this.Print_OrderNo = print_OrderNo;
        this.PrintDate = printDate;
        this.PrintQty = printQty;
        this.PaperUsed = paperUsed;
        this.PlateUsed = plateUsed;
        this.RollQty = rollQty;
        this.Remark = remark;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.Status_D = status_D;
        this.CauseOFDel = causeOFDel;
        this.DelBy = delBy;
       
    }

    public string PressID { get; set; }
    

    private int _prOrderSl;
    public int PrOrderSl
    {
        get { return _prOrderSl; }
        set { _prOrderSl = value; }
    }

    private string _print_OrderNo;
    public string Print_OrderNo
    {
        get { return _print_OrderNo; }
        set { _print_OrderNo = value; }
    }

    private DateTime _printDate;
    public DateTime PrintDate
    {
        get { return _printDate; }
        set { _printDate = value; }
    }

    private int _printQty;
    public int PrintQty
    {
        get { return _printQty; }
        set { _printQty = value; }
    }

    private decimal _paperUsed;
    public decimal PaperUsed
    {
        get { return _paperUsed; }
        set { _paperUsed = value; }
    }

    private int _plateUsed;
    public int PlateUsed
    {
        get { return _plateUsed; }
        set { _plateUsed = value; }
    }

    private decimal _rollQty;
    public decimal RollQty
    {
        get { return _rollQty; }
        set { _rollQty = value; }
    }

    private string _remark;
    public string Remark
    {
        get { return _remark; }
        set { _remark = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

    private string _causeOFDel;
    public string CauseOFDel
    {
        get { return _causeOFDel; }
        set { _causeOFDel = value; }
    }

    private int _delBy;
    public int DelBy
    {
        get { return _delBy; }
        set { _delBy = value; }
    }

   
}
