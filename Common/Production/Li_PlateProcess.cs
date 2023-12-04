using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PlateProcess
{
    public Li_PlateProcess()
    {
    }

    public Li_PlateProcess
        (
       
        string pro_ID, 
        string processID, 
        int plateQty, 
        decimal rate, 
        decimal totalBill, 
        int createdBy, 
        DateTime createdDate, 
        DateTime delDate, 
        int delBy, 
        string causeOfDel, 
        char status_D 
         
        )
    {
       
        this.Pro_ID = pro_ID;
        this.ProcessID = processID;
        this.PlateQty = plateQty;
        this.Rate = rate;
        this.TotalBill = totalBill;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.DelDate = delDate;
        this.DelBy = delBy;
        this.CauseOfDel = causeOfDel;
        this.Status_D = status_D;
       
    }


  

    private string _pro_ID;
    public string Pro_ID
    {
        get { return _pro_ID; }
        set { _pro_ID = value; }
    }

    private string _processID;
    public string ProcessID
    {
        get { return _processID; }
        set { _processID = value; }
    }

    private int _plateQty;
    public int PlateQty
    {
        get { return _plateQty; }
        set { _plateQty = value; }
    }

    private decimal _rate;
    public decimal Rate
    {
        get { return _rate; }
        set { _rate = value; }
    }

    private decimal _totalBill;
    public decimal TotalBill
    {
        get { return _totalBill; }
        set { _totalBill = value; }
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

    private string _causeOfDel;
    public string CauseOfDel
    {
        get { return _causeOfDel; }
        set { _causeOfDel = value; }
    }

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }
 
}
