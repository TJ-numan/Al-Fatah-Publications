using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_JobTitle
{
    public Li_JobTitle()
    {
    }

    public Li_JobTitle
        (
        
        int jobTiId, 
        string jobTiName, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.JobTiId = jobTiId;
        this.JobTiName = jobTiName;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _jobTiId;
    public int JobTiId
    {
        get { return _jobTiId; }
        set { _jobTiId = value; }
    }

    private string _jobTiName;
    public string JobTiName
    {
        get { return _jobTiName; }
        set { _jobTiName = value; }
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
