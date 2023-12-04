using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_ApprisalResult
{
    public Li_ApprisalResult()
    {
    }

    public Li_ApprisalResult
        (
 
        int appExId, 
        int empSl, 
        int appId, 
        int appExHId, 
        bool isApproved, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
      
        this.AppExId = appExId;
        this.EmpSl = empSl;
        this.AppId = appId;
        this.AppExHId = appExHId;
        this.IsApproved = isApproved;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _appExId;
    public int AppExId
    {
        get { return _appExId; }
        set { _appExId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private int _appId;
    public int AppId
    {
        get { return _appId; }
        set { _appId = value; }
    }

    private int _appExHId;
    public int AppExHId
    {
        get { return _appExHId; }
        set { _appExHId = value; }
    }

    private bool _isApproved;
    public bool IsApproved
    {
        get { return _isApproved; }
        set { _isApproved = value; }
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
