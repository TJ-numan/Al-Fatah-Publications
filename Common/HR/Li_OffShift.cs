using System;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_OffShift
{
    public Li_OffShift()
    {
    }

    public Li_OffShift
        (
        
        int schId, 
        string startTime, 
        string endTime, 
        decimal minLateDay, 
        decimal nextLateDay, 
        decimal maxOutHr, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
         
        this.SchId = schId;
        this.StartTime = startTime;
        this.EndTime = endTime;
        this.MinLateDay = minLateDay;
        this.NextLateDay = nextLateDay;
        this.MaxOutHr = maxOutHr;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _schId;
    public int SchId
    {
        get { return _schId; }
        set { _schId = value; }
    }

    private string _startTime;
    public string StartTime
    {
        get { return _startTime; }
        set { _startTime = value; }
    }

    private string _endTime;
    public string EndTime
    {
        get { return _endTime; }
        set { _endTime = value; }
    }

    private decimal _minLateDay;
    public decimal MinLateDay
    {
        get { return _minLateDay; }
        set { _minLateDay = value; }
    }

    private decimal _nextLateDay;
    public decimal NextLateDay
    {
        get { return _nextLateDay; }
        set { _nextLateDay = value; }
    }

    private decimal _maxOutHr;
    public decimal MaxOutHr
    {
        get { return _maxOutHr; }
        set { _maxOutHr = value; }
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
