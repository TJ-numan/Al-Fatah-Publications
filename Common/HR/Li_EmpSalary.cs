using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpSalary
{
    public Li_EmpSalary()
    {
    }

    public Li_EmpSalary
        (
         
        int salId, 
        int empSl, 
        int payGrId, 
        int pScId, 
        decimal ePF, 
        decimal companyCost, 
        decimal deductionAmt, 
        decimal payableAmt, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.SalId = salId;
        this.EmpSl = empSl;
        this.PayGrId = payGrId;
        this.PScId = pScId;
        this.EPF = ePF;
        this.CompanyCost = companyCost;
        this.DeductionAmt = deductionAmt;
        this.PayableAmt = payableAmt;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _salId;
    public int SalId
    {
        get { return _salId; }
        set { _salId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private int _payGrId;
    public int PayGrId
    {
        get { return _payGrId; }
        set { _payGrId = value; }
    }

    private int _pScId;
    public int PScId
    {
        get { return _pScId; }
        set { _pScId = value; }
    }

    private decimal _ePF;
    public decimal EPF
    {
        get { return _ePF; }
        set { _ePF = value; }
    }

    private decimal _companyCost;
    public decimal CompanyCost
    {
        get { return _companyCost; }
        set { _companyCost = value; }
    }

    private decimal _deductionAmt;
    public decimal DeductionAmt
    {
        get { return _deductionAmt; }
        set { _deductionAmt = value; }
    }

    private decimal _payableAmt;
    public decimal PayableAmt
    {
        get { return _payableAmt; }
        set { _payableAmt = value; }
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
