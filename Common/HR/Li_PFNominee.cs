using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PFNominee
{
    public Li_PFNominee()
    {
    }

    public Li_PFNominee
        (
        
        int nomiId, 
        int pFAppId, 
        string nomiName, 
        string empRelation, 
        string nomiPerAddress, 
        string nomiPreAddress, 
        string nID, 
        string birthId, 
        decimal percentRatio, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.NomiId = nomiId;
        this.PFAppId = pFAppId;
        this.NomiName = nomiName;
        this.EmpRelation = empRelation;
        this.NomiPerAddress = nomiPerAddress;
        this.NomiPreAddress = nomiPreAddress;
        this.NID = nID;
        this.BirthId = birthId;
        this.PercentRatio = percentRatio;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _nomiId;
    public int NomiId
    {
        get { return _nomiId; }
        set { _nomiId = value; }
    }

    private int _pFAppId;
    public int PFAppId
    {
        get { return _pFAppId; }
        set { _pFAppId = value; }
    }

    private string _nomiName;
    public string NomiName
    {
        get { return _nomiName; }
        set { _nomiName = value; }
    }

    private string _empRelation;
    public string EmpRelation
    {
        get { return _empRelation; }
        set { _empRelation = value; }
    }

    private string _nomiPerAddress;
    public string NomiPerAddress
    {
        get { return _nomiPerAddress; }
        set { _nomiPerAddress = value; }
    }

    private string _nomiPreAddress;
    public string NomiPreAddress
    {
        get { return _nomiPreAddress; }
        set { _nomiPreAddress = value; }
    }

    private string _nID;
    public string NID
    {
        get { return _nID; }
        set { _nID = value; }
    }

    private string _birthId;
    public string BirthId
    {
        get { return _birthId; }
        set { _birthId = value; }
    }

    private decimal _percentRatio;
    public decimal PercentRatio
    {
        get { return _percentRatio; }
        set { _percentRatio = value; }
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
