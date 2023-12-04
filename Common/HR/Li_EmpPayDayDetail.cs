using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpPayDayDetail
{
    public Li_EmpPayDayDetail()
    {
    }

    public Li_EmpPayDayDetail
        (
       
        int pDayDetId, 
        int pDayCId, 
        int empSl, 
        string yearName, 
        string monthName, 
        decimal monthDay, 
        decimal workingDay, 
        decimal weekend, 
        decimal holiday, 
        decimal leaveWPay, 
        decimal leaveWOPay, 
        decimal absentDay, 
        decimal lateCDay, 
        decimal outStyCDay, 
        decimal payDay, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
         
        this.PDayDetId = pDayDetId;
        this.PDayCId = pDayCId;
        this.EmpSl = empSl;
        this.YearName = yearName;
        this.MonthName = monthName;
        this.MonthDay = monthDay;
        this.WorkingDay = workingDay;
        this.Weekend = weekend;
        this.Holiday = holiday;
        this.LeaveWPay = leaveWPay;
        this.LeaveWOPay = leaveWOPay;
        this.AbsentDay = absentDay;
        this.LateCDay = lateCDay;
        this.OutStyCDay = outStyCDay;
        this.PayDay = payDay;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _pDayDetId;
    public int PDayDetId
    {
        get { return _pDayDetId; }
        set { _pDayDetId = value; }
    }

    private int _pDayCId;
    public int PDayCId
    {
        get { return _pDayCId; }
        set { _pDayCId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private string _yearName;
    public string YearName
    {
        get { return _yearName; }
        set { _yearName = value; }
    }

    private string _monthName;
    public string MonthName
    {
        get { return _monthName; }
        set { _monthName = value; }
    }

    private decimal _monthDay;
    public decimal MonthDay
    {
        get { return _monthDay; }
        set { _monthDay = value; }
    }

    private decimal _workingDay;
    public decimal WorkingDay
    {
        get { return _workingDay; }
        set { _workingDay = value; }
    }

    private decimal _weekend;
    public decimal Weekend
    {
        get { return _weekend; }
        set { _weekend = value; }
    }

    private decimal _holiday;
    public decimal Holiday
    {
        get { return _holiday; }
        set { _holiday = value; }
    }

    private decimal _leaveWPay;
    public decimal LeaveWPay
    {
        get { return _leaveWPay; }
        set { _leaveWPay = value; }
    }

    private decimal _leaveWOPay;
    public decimal LeaveWOPay
    {
        get { return _leaveWOPay; }
        set { _leaveWOPay = value; }
    }

    private decimal _absentDay;
    public decimal AbsentDay
    {
        get { return _absentDay; }
        set { _absentDay = value; }
    }

    private decimal _lateCDay;
    public decimal LateCDay
    {
        get { return _lateCDay; }
        set { _lateCDay = value; }
    }

    private decimal _outStyCDay;
    public decimal OutStyCDay
    {
        get { return _outStyCDay; }
        set { _outStyCDay = value; }
    }

    private decimal _payDay;
    public decimal PayDay
    {
        get { return _payDay; }
        set { _payDay = value; }
    }

    private string _comments;
    public string Comments
    {
        get { return _comments; }
        set { _comments = value; }
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

    private int _modifiedBy;
    public int ModifiedBy
    {
        get { return _modifiedBy; }
        set { _modifiedBy = value; }
    }

    private DateTime _modifiedDate;
    public DateTime ModifiedDate
    {
        get { return _modifiedDate; }
        set { _modifiedDate = value; }
    }

    private int _infStId;
    public int InfStId
    {
        get { return _infStId; }
        set { _infStId = value; }
    }
}
