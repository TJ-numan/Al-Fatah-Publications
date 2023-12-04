using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_FinalSettlement
{
    public Li_FinalSettlement()
    {
    }

    public Li_FinalSettlement
        (
        
        int fiSetId, 
        int empSl, 
        int employmentStId, 
        DateTime doJ, 
        DateTime eoS, 
        string comments, 
        string nOCPath, 
        string resPath, 
        decimal ePOF, 
        decimal gratuity, 
        bool isAssetClear, 
        bool isDepClear, 
        decimal loan, 
        decimal othAmt, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.FiSetId = fiSetId;
        this.EmpSl = empSl;
        this.EmploymentStId = employmentStId;
        this.DoJ = doJ;
        this.EoS = eoS;
        this.Comments = comments;
        this.NOCPath = nOCPath;
        this.ResPath = resPath;
        this.EPOF = ePOF;
        this.Gratuity = gratuity;
        this.IsAssetClear = isAssetClear;
        this.IsDepClear = isDepClear;
        this.Loan = loan;
        this.OthAmt = othAmt;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _fiSetId;
    public int FiSetId
    {
        get { return _fiSetId; }
        set { _fiSetId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private int _employmentStId;
    public int EmploymentStId
    {
        get { return _employmentStId; }
        set { _employmentStId = value; }
    }

    private DateTime _doJ;
    public DateTime DoJ
    {
        get { return _doJ; }
        set { _doJ = value; }
    }

    private DateTime _eoS;
    public DateTime EoS
    {
        get { return _eoS; }
        set { _eoS = value; }
    }

    private string _comments;
    public string Comments
    {
        get { return _comments; }
        set { _comments = value; }
    }

    private string _nOCPath;
    public string NOCPath
    {
        get { return _nOCPath; }
        set { _nOCPath = value; }
    }

    private string _resPath;
    public string ResPath
    {
        get { return _resPath; }
        set { _resPath = value; }
    }

    private decimal _ePOF;
    public decimal EPOF
    {
        get { return _ePOF; }
        set { _ePOF = value; }
    }

    private decimal _gratuity;
    public decimal Gratuity
    {
        get { return _gratuity; }
        set { _gratuity = value; }
    }

    private bool _isAssetClear;
    public bool IsAssetClear
    {
        get { return _isAssetClear; }
        set { _isAssetClear = value; }
    }

    private bool _isDepClear;
    public bool IsDepClear
    {
        get { return _isDepClear; }
        set { _isDepClear = value; }
    }

    private decimal _loan;
    public decimal Loan
    {
        get { return _loan; }
        set { _loan = value; }
    }

    private decimal _othAmt;
    public decimal OthAmt
    {
        get { return _othAmt; }
        set { _othAmt = value; }
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
