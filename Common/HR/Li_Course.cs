using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_Course
{
    public Li_Course()
    {
    }

    public Li_Course
        (
        
        int courseId, 
        string courseTitle, 
        string courseDes, 
        string comments, 
        int defaultDepId, 
        string defaultSes, 
        string defaultDuration, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
       
        this.CourseId = courseId;
        this.CourseTitle = courseTitle;
        this.CourseDes = courseDes;
        this.Comments = comments;
        this.DefaultDepId = defaultDepId;
        this.DefaultSes = defaultSes;
        this.DefaultDuration = defaultDuration;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _courseId;
    public int CourseId
    {
        get { return _courseId; }
        set { _courseId = value; }
    }

    private string _courseTitle;
    public string CourseTitle
    {
        get { return _courseTitle; }
        set { _courseTitle = value; }
    }

    private string _courseDes;
    public string CourseDes
    {
        get { return _courseDes; }
        set { _courseDes = value; }
    }

    private string _comments;
    public string Comments
    {
        get { return _comments; }
        set { _comments = value; }
    }

    private int _defaultDepId;
    public int DefaultDepId
    {
        get { return _defaultDepId; }
        set { _defaultDepId = value; }
    }

    private string _defaultSes;
    public string DefaultSes
    {
        get { return _defaultSes; }
        set { _defaultSes = value; }
    }

    private string _defaultDuration;
    public string DefaultDuration
    {
        get { return _defaultDuration; }
        set { _defaultDuration = value; }
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
