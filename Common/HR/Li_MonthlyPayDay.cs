using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_MonthlyPayDay
{
    public Li_MonthlyPayDay()
    {
    }

    public Li_MonthlyPayDay
        (
       
        int payMSl, 
        string payMonth, 
        int empSl, 
        decimal presentDay, 
        decimal leaveDay, 
        decimal leaveWithOutPay, 
        decimal weekend, 
        decimal holiday, 
        decimal payDay, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.PayMSl = payMSl;
        this.PayMonth = payMonth;
        this.EmpSl = empSl;
        this.PresentDay = presentDay;
        this.LeaveDay = leaveDay;
        this.LeaveWithOutPay = leaveWithOutPay;
        this.Weekend = weekend;
        this.Holiday = holiday;
        this.PayDay = payDay;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _payMSl;
    public int PayMSl
    {
        get { return _payMSl; }
        set { _payMSl = value; }
    }

    private string _payMonth;
    public string PayMonth
    {
        get { return _payMonth; }
        set { _payMonth = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private decimal _presentDay;
    public decimal PresentDay
    {
        get { return _presentDay; }
        set { _presentDay = value; }
    }

    private decimal _leaveDay;
    public decimal LeaveDay
    {
        get { return _leaveDay; }
        set { _leaveDay = value; }
    }

    private decimal _leaveWithOutPay;
    public decimal LeaveWithOutPay
    {
        get { return _leaveWithOutPay; }
        set { _leaveWithOutPay = value; }
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

    private decimal _payDay;
    public decimal PayDay
    {
        get { return _payDay; }
        set { _payDay = value; }
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
