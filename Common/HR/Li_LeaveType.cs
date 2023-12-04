using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_LeaveType
{
    public Li_LeaveType()
    {
    }

    public Li_LeaveType
        (
 
        int leTypId, 
        string leTyName, 
        decimal dayCount, 
        bool balForword, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.LeTypId = leTypId;
        this.LeTyName = leTyName;
        this.DayCount = dayCount;
        this.BalForword = balForword;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _leTypId;
    public int LeTypId
    {
        get { return _leTypId; }
        set { _leTypId = value; }
    }

    private string _leTyName;
    public string LeTyName
    {
        get { return _leTyName; }
        set { _leTyName = value; }
    }

    private decimal _dayCount;
    public decimal DayCount
    {
        get { return _dayCount; }
        set { _dayCount = value; }
    }

    private bool _balForword;
    public bool BalForword
    {
        get { return _balForword; }
        set { _balForword = value; }
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
