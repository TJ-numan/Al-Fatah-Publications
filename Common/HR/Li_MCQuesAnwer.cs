using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_MCQuesAnwer
{
    public Li_MCQuesAnwer()
    {
    }

    public Li_MCQuesAnwer
        (
      
        int mcqAnsId, 
        int mCQuesId, 
        int quesSl, 
        string mcqAns, 
        bool isCorrect, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    { 
        this.McqAnsId = mcqAnsId;
        this.MCQuesId = mCQuesId;
        this.QuesSl = quesSl;
        this.McqAns = mcqAns;
        this.IsCorrect = isCorrect;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _mcqAnsId;
    public int McqAnsId
    {
        get { return _mcqAnsId; }
        set { _mcqAnsId = value; }
    }

    private int _mCQuesId;
    public int MCQuesId
    {
        get { return _mCQuesId; }
        set { _mCQuesId = value; }
    }

    private int _quesSl;
    public int QuesSl
    {
        get { return _quesSl; }
        set { _quesSl = value; }
    }

    private string _mcqAns;
    public string McqAns
    {
        get { return _mcqAns; }
        set { _mcqAns = value; }
    }

    private bool _isCorrect;
    public bool IsCorrect
    {
        get { return _isCorrect; }
        set { _isCorrect = value; }
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
