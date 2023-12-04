using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PFProjectTran
{
    public Li_PFProjectTran()
    {
    }

    public Li_PFProjectTran
        (
        
        int projectInvestId, 
        int projectId, 
        DateTime tranDate, 
        decimal invAmt, 
        decimal retAmt, 
        decimal profitAmt, 
        string bankName, 
        string bankAdd, 
        string bankAcNo, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.ProjectInvestId = projectInvestId;
        this.ProjectId = projectId;
        this.TranDate = tranDate;
        this.InvAmt = invAmt;
        this.RetAmt = retAmt;
        this.ProfitAmt = profitAmt;
        this.BankName = bankName;
        this.BankAdd = bankAdd;
        this.BankAcNo = bankAcNo;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _projectInvestId;
    public int ProjectInvestId
    {
        get { return _projectInvestId; }
        set { _projectInvestId = value; }
    }

    private int _projectId;
    public int ProjectId
    {
        get { return _projectId; }
        set { _projectId = value; }
    }

    private DateTime _tranDate;
    public DateTime TranDate
    {
        get { return _tranDate; }
        set { _tranDate = value; }
    }

    private decimal _invAmt;
    public decimal InvAmt
    {
        get { return _invAmt; }
        set { _invAmt = value; }
    }

    private decimal _retAmt;
    public decimal RetAmt
    {
        get { return _retAmt; }
        set { _retAmt = value; }
    }

    private decimal _profitAmt;
    public decimal ProfitAmt
    {
        get { return _profitAmt; }
        set { _profitAmt = value; }
    }

    private string _bankName;
    public string BankName
    {
        get { return _bankName; }
        set { _bankName = value; }
    }

    private string _bankAdd;
    public string BankAdd
    {
        get { return _bankAdd; }
        set { _bankAdd = value; }
    }

    private string _bankAcNo;
    public string BankAcNo
    {
        get { return _bankAcNo; }
        set { _bankAcNo = value; }
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
