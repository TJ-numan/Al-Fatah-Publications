using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_ProvidentFund
{
    public Li_ProvidentFund()
    {
    }

    public Li_ProvidentFund
        (
        
        int pFId, 
        string pFTitle, 
        string pFYear, 
        string pFMonth, 
        DateTime monthLDate, 
        int salaryId, 
        decimal totalEPFAmt, 
        decimal totalComAmt, 
        decimal totalProfitAmt, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
         
        this.PFId = pFId;
        this.PFTitle = pFTitle;
        this.PFYear = pFYear;
        this.PFMonth = pFMonth;
        this.MonthLDate = monthLDate;
        this.SalaryId = salaryId;
        this.TotalEPFAmt = totalEPFAmt;
        this.TotalComAmt = totalComAmt;
        this.TotalProfitAmt = totalProfitAmt;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _pFId;
    public int PFId
    {
        get { return _pFId; }
        set { _pFId = value; }
    }

    private string _pFTitle;
    public string PFTitle
    {
        get { return _pFTitle; }
        set { _pFTitle = value; }
    }

    private string _pFYear;
    public string PFYear
    {
        get { return _pFYear; }
        set { _pFYear = value; }
    }

    private string _pFMonth;
    public string PFMonth
    {
        get { return _pFMonth; }
        set { _pFMonth = value; }
    }

    private DateTime _monthLDate;
    public DateTime MonthLDate
    {
        get { return _monthLDate; }
        set { _monthLDate = value; }
    }

    private int _salaryId;
    public int SalaryId
    {
        get { return _salaryId; }
        set { _salaryId = value; }
    }

    private decimal _totalEPFAmt;
    public decimal TotalEPFAmt
    {
        get { return _totalEPFAmt; }
        set { _totalEPFAmt = value; }
    }

    private decimal _totalComAmt;
    public decimal TotalComAmt
    {
        get { return _totalComAmt; }
        set { _totalComAmt = value; }
    }

    private decimal _totalProfitAmt;
    public decimal TotalProfitAmt
    {
        get { return _totalProfitAmt; }
        set { _totalProfitAmt = value; }
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
