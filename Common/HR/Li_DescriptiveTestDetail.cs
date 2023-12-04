using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_DescriptiveTestDetail
{
    public Li_DescriptiveTestDetail()
    {
    }

    public Li_DescriptiveTestDetail
        (
         
        int desTestDeId, 
        int testId, 
        int desQuesId, 
        decimal marks, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
         
        this.DesTestDeId = desTestDeId;
        this.TestId = testId;
        this.DesQuesId = desQuesId;
        this.Marks = marks;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _desTestDeId;
    public int DesTestDeId
    {
        get { return _desTestDeId; }
        set { _desTestDeId = value; }
    }

    private int _testId;
    public int TestId
    {
        get { return _testId; }
        set { _testId = value; }
    }

    private int _desQuesId;
    public int DesQuesId
    {
        get { return _desQuesId; }
        set { _desQuesId = value; }
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
