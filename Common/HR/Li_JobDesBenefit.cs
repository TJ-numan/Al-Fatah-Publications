using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_JobDesBenefit
{
    public Li_JobDesBenefit()
    {
    }

    public Li_JobDesBenefit
        (
        
        int jobBenId, 
        string jobBenefit, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
     
        this.JobBenId = jobBenId;
        this.JobBenefit = jobBenefit;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _jobBenId;
    public int JobBenId
    {
        get { return _jobBenId; }
        set { _jobBenId = value; }
    }

    private string _jobBenefit;
    public string JobBenefit
    {
        get { return _jobBenefit; }
        set { _jobBenefit = value; }
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
