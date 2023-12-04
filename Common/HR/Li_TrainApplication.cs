using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_TrainApplication
{
    public Li_TrainApplication()
    {
    }

    public Li_TrainApplication
        (
        
        int trainAppId, 
        int empSl, 
        int courseId, 
        int insId, 
        int resoPId, 
        string couSession, 
        string couHour, 
        decimal couCost, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
       
        this.TrainAppId = trainAppId;
        this.EmpSl = empSl;
        this.CourseId = courseId;
        this.InsId = insId;
        this.ResoPId = resoPId;
        this.CouSession = couSession;
        this.CouHour = couHour;
        this.CouCost = couCost;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _trainAppId;
    public int TrainAppId
    {
        get { return _trainAppId; }
        set { _trainAppId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private int _courseId;
    public int CourseId
    {
        get { return _courseId; }
        set { _courseId = value; }
    }

    private int _insId;
    public int InsId
    {
        get { return _insId; }
        set { _insId = value; }
    }

    private int _resoPId;
    public int ResoPId
    {
        get { return _resoPId; }
        set { _resoPId = value; }
    }

    private string _couSession;
    public string CouSession
    {
        get { return _couSession; }
        set { _couSession = value; }
    }

    private string _couHour;
    public string CouHour
    {
        get { return _couHour; }
        set { _couHour = value; }
    }

    private decimal _couCost;
    public decimal CouCost
    {
        get { return _couCost; }
        set { _couCost = value; }
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
