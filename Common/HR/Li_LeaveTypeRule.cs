using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_LeaveTypeRule
{
    public Li_LeaveTypeRule()
    {
    }

    public Li_LeaveTypeRule
        (
       
        int leTyRuId, 
        int leTypId, 
        int leRuId, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.LeTyRuId = leTyRuId;
        this.LeTypId = leTypId;
        this.LeRuId = leRuId;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _leTyRuId;
    public int LeTyRuId
    {
        get { return _leTyRuId; }
        set { _leTyRuId = value; }
    }

    private int _leTypId;
    public int LeTypId
    {
        get { return _leTypId; }
        set { _leTypId = value; }
    }

    private int _leRuId;
    public int LeRuId
    {
        get { return _leRuId; }
        set { _leRuId = value; }
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
