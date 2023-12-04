using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_ApprisalExecution
{
    public Li_ApprisalExecution()
    {
    }

    public Li_ApprisalExecution
        (
   
        int appExHId, 
        string exHName, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
     
        this.AppExHId = appExHId;
        this.ExHName = exHName;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _appExHId;
    public int AppExHId
    {
        get { return _appExHId; }
        set { _appExHId = value; }
    }

    private string _exHName;
    public string ExHName
    {
        get { return _exHName; }
        set { _exHName = value; }
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
