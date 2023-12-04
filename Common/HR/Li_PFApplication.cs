using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PFApplication
{
    public Li_PFApplication()
    {
    }

    public Li_PFApplication
        (
        
        int pFAppId, 
        string pFAcNo, 
        int empSl, 
        DateTime effectiveDate, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
         
        this.PFAppId = pFAppId;
        this.PFAcNo = pFAcNo;
        this.EmpSl = empSl;
        this.EffectiveDate = effectiveDate;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


    

    private int _pFAppId;
    public int PFAppId
    {
        get { return _pFAppId; }
        set { _pFAppId = value; }
    }

    private string _pFAcNo;
    public string PFAcNo
    {
        get { return _pFAcNo; }
        set { _pFAcNo = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private DateTime _effectiveDate;
    public DateTime EffectiveDate
    {
        get { return _effectiveDate; }
        set { _effectiveDate = value; }
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
