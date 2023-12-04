using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_MCQTestDetail
{
    public Li_MCQTestDetail()
    {
    }

    public Li_MCQTestDetail
        (
        
        int mcqTestDeId, 
        int testId, 
        int mCQuesId, 
        decimal marks, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.McqTestDeId = mcqTestDeId;
        this.TestId = testId;
        this.MCQuesId = mCQuesId;
        this.Marks = marks;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _mcqTestDeId;
    public int McqTestDeId
    {
        get { return _mcqTestDeId; }
        set { _mcqTestDeId = value; }
    }

    private int _testId;
    public int TestId
    {
        get { return _testId; }
        set { _testId = value; }
    }

    private int _mCQuesId;
    public int MCQuesId
    {
        get { return _mCQuesId; }
        set { _mCQuesId = value; }
    }

    private decimal _marks;
    public decimal Marks
    {
        get { return _marks; }
        set { _marks = value; }
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
