using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_IntTest
{
    public Li_IntTest()
    {
    }

    public Li_IntTest
        (
       
        int testId, 
        int posId, 
        string testTitle, 
        decimal totalMarks, 
        decimal totalTime, 
        string timeSeg, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId, 
        string obtainMark
        )
    {
        
        this.TestId = testId;
        this.PosId = posId;
        this.TestTitle = testTitle;
        this.TotalMarks = totalMarks;
        this.TotalTime = totalTime;
        this.TimeSeg = timeSeg;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
        this.ObtainMark = obtainMark;
    }

 
    private int _testId;
    public int TestId
    {
        get { return _testId; }
        set { _testId = value; }
    }

    private int _posId;
    public int PosId
    {
        get { return _posId; }
        set { _posId = value; }
    }

    private string _testTitle;
    public string TestTitle
    {
        get { return _testTitle; }
        set { _testTitle = value; }
    }

    private decimal _totalMarks;
    public decimal TotalMarks
    {
        get { return _totalMarks; }
        set { _totalMarks = value; }
    }

    private decimal _totalTime;
    public decimal TotalTime
    {
        get { return _totalTime; }
        set { _totalTime = value; }
    }

    private string _timeSeg;
    public string TimeSeg
    {
        get { return _timeSeg; }
        set { _timeSeg = value; }
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

    private string _obtainMark;
    public string ObtainMark
    {
        get { return _obtainMark; }
        set { _obtainMark = value; }
    }
}
