using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_Salary
{
    public Li_Salary()
    {
    }

    public Li_Salary
        (
        
        int salaryId, 
        string salTitle, 
        string salYear, 
        string salMonth, 
        decimal basicSalAmt, 
        decimal alowanceAmt, 
        decimal bonusAmt, 
        decimal pFDeductedAmt, 
        decimal attnDeductedAmt, 
        decimal othDeductAmt, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.SalaryId = salaryId;
        this.SalTitle = salTitle;
        this.SalYear = salYear;
        this.SalMonth = salMonth;
        this.BasicSalAmt = basicSalAmt;
        this.AlowanceAmt = alowanceAmt;
        this.BonusAmt = bonusAmt;
        this.PFDeductedAmt = pFDeductedAmt;
        this.AttnDeductedAmt = attnDeductedAmt;
        this.OthDeductAmt = othDeductAmt;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _salaryId;
    public int SalaryId
    {
        get { return _salaryId; }
        set { _salaryId = value; }
    }

    private string _salTitle;
    public string SalTitle
    {
        get { return _salTitle; }
        set { _salTitle = value; }
    }

    private string _salYear;
    public string SalYear
    {
        get { return _salYear; }
        set { _salYear = value; }
    }

    private string _salMonth;
    public string SalMonth
    {
        get { return _salMonth; }
        set { _salMonth = value; }
    }

    private decimal _basicSalAmt;
    public decimal BasicSalAmt
    {
        get { return _basicSalAmt; }
        set { _basicSalAmt = value; }
    }

    private decimal _alowanceAmt;
    public decimal AlowanceAmt
    {
        get { return _alowanceAmt; }
        set { _alowanceAmt = value; }
    }

    private decimal _bonusAmt;
    public decimal BonusAmt
    {
        get { return _bonusAmt; }
        set { _bonusAmt = value; }
    }

    private decimal _pFDeductedAmt;
    public decimal PFDeductedAmt
    {
        get { return _pFDeductedAmt; }
        set { _pFDeductedAmt = value; }
    }

    private decimal _attnDeductedAmt;
    public decimal AttnDeductedAmt
    {
        get { return _attnDeductedAmt; }
        set { _attnDeductedAmt = value; }
    }

    private decimal _othDeductAmt;
    public decimal OthDeductAmt
    {
        get { return _othDeductAmt; }
        set { _othDeductAmt = value; }
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
