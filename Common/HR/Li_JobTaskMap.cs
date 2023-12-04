using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_JobTaskMap
{
    public Li_JobTaskMap()
    {
    }

    public Li_JobTaskMap
        (
       
        int depId, 
        int jobTaskId, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.DepId = depId;
        this.JobTaskId = jobTaskId;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _depId;
    public int DepId
    {
        get { return _depId; }
        set { _depId = value; }
    }

    private int _jobTaskId;
    public int JobTaskId
    {
        get { return _jobTaskId; }
        set { _jobTaskId = value; }
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
