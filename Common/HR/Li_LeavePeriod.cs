using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_LeavePeriod
{
    public Li_LeavePeriod()
    {
    }

    public Li_LeavePeriod
        (
        
        int perId, 
        string perName, 
        DateTime perStDate, 
        DateTime perEnDate, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
         
        this.PerId = perId;
        this.PerName = perName;
        this.PerStDate = perStDate;
        this.PerEnDate = perEnDate;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _perId;
    public int PerId
    {
        get { return _perId; }
        set { _perId = value; }
    }

    private string _perName;
    public string PerName
    {
        get { return _perName; }
        set { _perName = value; }
    }

    private DateTime _perStDate;
    public DateTime PerStDate
    {
        get { return _perStDate; }
        set { _perStDate = value; }
    }

    private DateTime _perEnDate;
    public DateTime PerEnDate
    {
        get { return _perEnDate; }
        set { _perEnDate = value; }
    }

    private string _comments;
    public string Comments
    {
        get { return _comments; }
        set { _comments = value; }
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
