using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_McqQuestion
{
    public Li_McqQuestion()
    {
    }

    public Li_McqQuestion
        (
         
        int mCQuesId, 
        int quesTemId, 
        string mcqQues, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.MCQuesId = mCQuesId;
        this.QuesTemId = quesTemId;
        this.McqQues = mcqQues;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _mCQuesId;
    public int MCQuesId
    {
        get { return _mCQuesId; }
        set { _mCQuesId = value; }
    }

    private int _quesTemId;
    public int QuesTemId
    {
        get { return _quesTemId; }
        set { _quesTemId = value; }
    }

    private string _mcqQues;
    public string McqQues
    {
        get { return _mcqQues; }
        set { _mcqQues = value; }
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
