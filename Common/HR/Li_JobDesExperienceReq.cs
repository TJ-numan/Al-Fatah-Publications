using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_JobDesExperienceReq
{
    public Li_JobDesExperienceReq()
    {
    }

    public Li_JobDesExperienceReq
        (
       
        int expReqId, 
        string expReq, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.ExpReqId = expReqId;
        this.ExpReq = expReq;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }



    private int _expReqId;
    public int ExpReqId
    {
        get { return _expReqId; }
        set { _expReqId = value; }
    }

    private string _expReq;
    public string ExpReq
    {
        get { return _expReq; }
        set { _expReq = value; }
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
