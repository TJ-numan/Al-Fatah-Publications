using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_JobDesEducationalReq
{
    public Li_JobDesEducationalReq()
    {
    }

    public Li_JobDesEducationalReq
        (
   
        int eduReqId, 
        string eduReq, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
       
        this.EduReqId = eduReqId;
        this.EduReq = eduReq;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _eduReqId;
    public int EduReqId
    {
        get { return _eduReqId; }
        set { _eduReqId = value; }
    }

    private string _eduReq;
    public string EduReq
    {
        get { return _eduReq; }
        set { _eduReq = value; }
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
