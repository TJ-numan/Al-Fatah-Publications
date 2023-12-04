using System;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_OffSchedule
{
    public Li_OffSchedule()
    {
    }

    public Li_OffSchedule
        (
        
        int schId, 
        string schName, 
        string officeLocation, 
        string startTime, 
        string endTime, 
        decimal maxLateDay, 
        decimal nextLateDay, 
        decimal maxOutH, 
        string comment, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
 
        this.SchId = schId;
        this.SchName = schName;
        this.OfficeLocation = officeLocation;
        this.StartTime = startTime;
        this.EndTime = endTime;
        this.MaxLateDay = maxLateDay;
        this.NextLateDay = nextLateDay;
        this.MaxOutH = maxOutH;
        this.Comment = comment;
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

    private string _schName;
    public string SchName
    {
        get { return _schName; }
        set { _schName = value; }
    }

    private string _officeLocation;
    public string OfficeLocation
    {
        get { return _officeLocation; }
        set { _officeLocation = value; }
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

    private decimal _maxLateDay;
    public decimal MaxLateDay
    {
        get { return _maxLateDay; }
        set { _maxLateDay = value; }
    }

    private decimal _nextLateDay;
    public decimal NextLateDay
    {
        get { return _nextLateDay; }
        set { _nextLateDay = value; }
    }

    private decimal _maxOutH;
    public decimal MaxOutH
    {
        get { return _maxOutH; }
        set { _maxOutH = value; }
    }

    private string _comment;
    public string Comment
    {
        get { return _comment; }
        set { _comment = value; }
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
