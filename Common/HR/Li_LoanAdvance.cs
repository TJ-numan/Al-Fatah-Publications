using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_LoanAdvance
{
    public Li_LoanAdvance()
    {
    }

    public Li_LoanAdvance
        (
        
        int loAdId, 
        int empSl, 
        string loAdFor, 
        string loAdForDes, 
        bool isAdvance, 
        decimal isAdjusted, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
    
        this.LoAdId = loAdId;
        this.EmpSl = empSl;
        this.LoAdFor = loAdFor;
        this.LoAdForDes = loAdForDes;
        this.IsAdvance = isAdvance;
        this.IsAdjusted = isAdjusted;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _loAdId;
    public int LoAdId
    {
        get { return _loAdId; }
        set { _loAdId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private string _loAdFor;
    public string LoAdFor
    {
        get { return _loAdFor; }
        set { _loAdFor = value; }
    }

    private string _loAdForDes;
    public string LoAdForDes
    {
        get { return _loAdForDes; }
        set { _loAdForDes = value; }
    }

    private bool _isAdvance;
    public bool IsAdvance
    {
        get { return _isAdvance; }
        set { _isAdvance = value; }
    }

    private decimal _isAdjusted;
    public decimal IsAdjusted
    {
        get { return _isAdjusted; }
        set { _isAdjusted = value; }
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
