using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_JobDescription
{
    public Li_JobDescription()
    {
    }

    public Li_JobDescription
        (
     
        int jDId, 
        int posId, 
        int jobResId, 
        int eduReqId, 
        int expReqId, 
        int jobReqId, 
        int jobBenId, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
         
        this.JDId = jDId;
        this.PosId = posId;
        this.JobResId = jobResId;
        this.EduReqId = eduReqId;
        this.ExpReqId = expReqId;
        this.JobReqId = jobReqId;
        this.JobBenId = jobBenId;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _jDId;
    public int JDId
    {
        get { return _jDId; }
        set { _jDId = value; }
    }

    private int _posId;
    public int PosId
    {
        get { return _posId; }
        set { _posId = value; }
    }

    private int _jobResId;
    public int JobResId
    {
        get { return _jobResId; }
        set { _jobResId = value; }
    }

    private int _eduReqId;
    public int EduReqId
    {
        get { return _eduReqId; }
        set { _eduReqId = value; }
    }

    private int _expReqId;
    public int ExpReqId
    {
        get { return _expReqId; }
        set { _expReqId = value; }
    }

    private int _jobReqId;
    public int JobReqId
    {
        get { return _jobReqId; }
        set { _jobReqId = value; }
    }

    private int _jobBenId;
    public int JobBenId
    {
        get { return _jobBenId; }
        set { _jobBenId = value; }
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
