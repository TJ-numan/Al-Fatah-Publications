using System;
using System.Data;
using System.Configuration;
using System.Linq; 
public class Li_WorkShift
{
    public Li_WorkShift()
    {
    }

    public Li_WorkShift
        (
      
        int wkShfId, 
        int schedId, 
        string wkShfStartT, 
        string wkShfEndT, 
        string wkShfDes, 
        int graceMinute, 
        decimal minStayHour, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
         
        this.WkShfId = wkShfId;
        this.SchedId = schedId;
        this.WkShfStartT = wkShfStartT;
        this.WkShfEndT = wkShfEndT;
        this.WkShfDes = wkShfDes;
        this.GraceMinute = graceMinute;
        this.MinStayHour = minStayHour;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _wkShfId;
    public int WkShfId
    {
        get { return _wkShfId; }
        set { _wkShfId = value; }
    }

    private int _schedId;
    public int SchedId
    {
        get { return _schedId; }
        set { _schedId = value; }
    }

    private string _wkShfStartT;
    public string WkShfStartT
    {
        get { return _wkShfStartT; }
        set { _wkShfStartT = value; }
    }

    private string _wkShfEndT;
    public string WkShfEndT
    {
        get { return _wkShfEndT; }
        set { _wkShfEndT = value; }
    }

    private string _wkShfDes;
    public string WkShfDes
    {
        get { return _wkShfDes; }
        set { _wkShfDes = value; }
    }

    private int _graceMinute;
    public int GraceMinute
    {
        get { return _graceMinute; }
        set { _graceMinute = value; }
    }

    private decimal _minStayHour;
    public decimal MinStayHour
    {
        get { return _minStayHour; }
        set { _minStayHour = value; }
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
