using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_JobDesRequirment
{
    public Li_JobDesRequirment()
    {
    }

    public Li_JobDesRequirment
        (
        
        int jobReqId, 
        string jobReq, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.JobReqId = jobReqId;
        this.JobReq = jobReq;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }

 

    private int _jobReqId;
    public int JobReqId
    {
        get { return _jobReqId; }
        set { _jobReqId = value; }
    }

    private string _jobReq;
    public string JobReq
    {
        get { return _jobReq; }
        set { _jobReq = value; }
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
