using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_InterviewSchdule
{
    public Li_InterviewSchdule()
    {
    }

    public Li_InterviewSchdule
        (
        
        int intSchId, 
        string schTitle, 
        int inTypeId, 
        DateTime   timeSt, 
        DateTime  timeEn, 
        int canNo, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
         
        this.IntSchId = intSchId;
        this.SchTitle = schTitle;
        this.InTypeId = inTypeId;
        this.TimeSt = timeSt;
        this.TimeEn = timeEn;
        this.CanNo = canNo;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _intSchId;
    public int IntSchId
    {
        get { return _intSchId; }
        set { _intSchId = value; }
    }

    private string _schTitle;
    public string SchTitle
    {
        get { return _schTitle; }
        set { _schTitle = value; }
    }

    private int _inTypeId;
    public int InTypeId
    {
        get { return _inTypeId; }
        set { _inTypeId = value; }
    }

    private DateTime _timeSt;
    public DateTime TimeSt
    {
        get { return _timeSt; }
        set { _timeSt = value; }
    }

    private DateTime _timeEn;
    public DateTime TimeEn
    {
        get { return _timeEn; }
        set { _timeEn = value; }
    }

    private int _canNo;
    public int CanNo
    {
        get { return _canNo; }
        set { _canNo = value; }
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
