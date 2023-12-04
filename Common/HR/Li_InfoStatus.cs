using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_InfoStatus
{
    public Li_InfoStatus()
    {
    }

    public Li_InfoStatus
        (
        
        int infStId, 
        string infStatus, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate
        )
    {
        
        this.InfStId = infStId;
        this.InfStatus = infStatus;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
    }


 
    private int _infStId;
    public int InfStId
    {
        get { return _infStId; }
        set { _infStId = value; }
    }

    private string _infStatus;
    public string InfStatus
    {
        get { return _infStatus; }
        set { _infStatus = value; }
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
}
