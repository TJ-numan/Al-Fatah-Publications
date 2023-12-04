using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_ExamTitle
{
    public Li_ExamTitle()
    {
    }

    public Li_ExamTitle
        (
      
        int examId, 
        string examName, 
        int eduLId, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.ExamId = examId;
        this.ExamName = examName;
        this.EduLId = eduLId;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _examId;
    public int ExamId
    {
        get { return _examId; }
        set { _examId = value; }
    }

    private string _examName;
    public string ExamName
    {
        get { return _examName; }
        set { _examName = value; }
    }

    private int _eduLId;
    public int EduLId
    {
        get { return _eduLId; }
        set { _eduLId = value; }
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
