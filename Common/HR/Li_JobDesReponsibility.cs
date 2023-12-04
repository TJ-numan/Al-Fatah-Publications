using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_JobDesReponsibility
{
    public Li_JobDesReponsibility()
    {
    }

    public Li_JobDesReponsibility
        (
       
        int jobResId, 
        string jobRes, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.JobResId = jobResId;
        this.JobRes = jobRes;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _jobResId;
    public int JobResId
    {
        get { return _jobResId; }
        set { _jobResId = value; }
    }

    private string _jobRes;
    public string JobRes
    {
        get { return _jobRes; }
        set { _jobRes = value; }
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
