using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_InterviewTemplate
{
    public Li_InterviewTemplate()
    {
    }

    public Li_InterviewTemplate
        (
        
        int intTemId, 
        int intSchId, 
        int vacId, 
        int testId, 
        string canName, 
        string eduQualification, 
        string skill, 
        decimal obtainMarks, 
        decimal vivaMarks, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
         
        this.IntTemId = intTemId;
        this.IntSchId = intSchId;
        this.VacId = vacId;
        this.TestId = testId;
        this.CanName = canName;
        this.EduQualification = eduQualification;
        this.Skill = skill;
        this.ObtainMarks = obtainMarks;
        this.VivaMarks = vivaMarks;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _intTemId;
    public int IntTemId
    {
        get { return _intTemId; }
        set { _intTemId = value; }
    }

    private int _intSchId;
    public int IntSchId
    {
        get { return _intSchId; }
        set { _intSchId = value; }
    }

    private int _vacId;
    public int VacId
    {
        get { return _vacId; }
        set { _vacId = value; }
    }

    private int _testId;
    public int TestId
    {
        get { return _testId; }
        set { _testId = value; }
    }

    private string _canName;
    public string CanName
    {
        get { return _canName; }
        set { _canName = value; }
    }

    private string _eduQualification;
    public string EduQualification
    {
        get { return _eduQualification; }
        set { _eduQualification = value; }
    }

    private string _skill;
    public string Skill
    {
        get { return _skill; }
        set { _skill = value; }
    }

    private decimal _obtainMarks;
    public decimal ObtainMarks
    {
        get { return _obtainMarks; }
        set { _obtainMarks = value; }
    }

    private decimal _vivaMarks;
    public decimal VivaMarks
    {
        get { return _vivaMarks; }
        set { _vivaMarks = value; }
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
