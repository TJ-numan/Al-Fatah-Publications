using System;
 
 







public class Li_ApprisalDetail
{
    public Li_ApprisalDetail()
    {
    }

    public Li_ApprisalDetail
        (
         
        int appDeId, 
        int appId, 
        int compeId, 
        int empSl, 
        decimal weight, 
        decimal givenRate, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
    
        this.AppDeId = appDeId;
        this.AppId = appId;
        this.CompeId = compeId;
        this.EmpSl = empSl;
        this.Weight = weight;
        this.GivenRate = givenRate;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }

 

    private int _appDeId;
    public int AppDeId
    {
        get { return _appDeId; }
        set { _appDeId = value; }
    }

    private int _appId;
    public int AppId
    {
        get { return _appId; }
        set { _appId = value; }
    }

    private int _compeId;
    public int CompeId
    {
        get { return _compeId; }
        set { _compeId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private decimal _weight;
    public decimal Weight
    {
        get { return _weight; }
        set { _weight = value; }
    }

    private decimal _givenRate;
    public decimal GivenRate
    {
        get { return _givenRate; }
        set { _givenRate = value; }
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
