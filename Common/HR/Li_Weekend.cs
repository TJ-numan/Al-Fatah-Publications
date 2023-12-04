using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_Weekend
{
    public Li_Weekend()
    {
    }

    public Li_Weekend
        (
        
        int wekDayId, 
        int locId, 
        string dayName, 
        bool isWorkingDay, 
        bool isHalfDay, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.WekDayId = wekDayId;
        this.LocId = locId;
        this.DayName = dayName;
        this.IsWorkingDay = isWorkingDay;
        this.IsHalfDay = isHalfDay;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }

 

    private int _wekDayId;
    public int WekDayId
    {
        get { return _wekDayId; }
        set { _wekDayId = value; }
    }

    private int _locId;
    public int LocId
    {
        get { return _locId; }
        set { _locId = value; }
    }

    private string _dayName;
    public string DayName
    {
        get { return _dayName; }
        set { _dayName = value; }
    }

    private bool _isWorkingDay;
    public bool IsWorkingDay
    {
        get { return _isWorkingDay; }
        set { _isWorkingDay = value; }
    }

    private bool _isHalfDay;
    public bool IsHalfDay
    {
        get { return _isHalfDay; }
        set { _isHalfDay = value; }
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
