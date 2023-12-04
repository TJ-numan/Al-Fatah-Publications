using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_Holiday
{
    public Li_Holiday()
    {
    }

    public Li_Holiday
        (
         
        int holiId, 
        int locId, 
        string holiDayTitle, 
        DateTime stDate, 
        DateTime enDate, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.HoliId = holiId;
        this.LocId = locId;
        this.HoliDayTitle = holiDayTitle;
        this.StDate = stDate;
        this.EnDate = enDate;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _holiId;
    public int HoliId
    {
        get { return _holiId; }
        set { _holiId = value; }
    }

    private int _locId;
    public int LocId
    {
        get { return _locId; }
        set { _locId = value; }
    }

    private string _holiDayTitle;
    public string HoliDayTitle
    {
        get { return _holiDayTitle; }
        set { _holiDayTitle = value; }
    }

    private DateTime _stDate;
    public DateTime StDate
    {
        get { return _stDate; }
        set { _stDate = value; }
    }

    private DateTime _enDate;
    public DateTime EnDate
    {
        get { return _enDate; }
        set { _enDate = value; }
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
