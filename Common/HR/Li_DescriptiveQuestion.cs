using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_DescriptiveQuestion
{
    public Li_DescriptiveQuestion()
    {
    }

    public Li_DescriptiveQuestion
        (
       
        int desQuesId, 
        int quesTemId, 
        string desQues, 
        string desAns, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.DesQuesId = desQuesId;
        this.QuesTemId = quesTemId;
        this.DesQues = desQues;
        this.DesAns = desAns;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _desQuesId;
    public int DesQuesId
    {
        get { return _desQuesId; }
        set { _desQuesId = value; }
    }

    private int _quesTemId;
    public int QuesTemId
    {
        get { return _quesTemId; }
        set { _quesTemId = value; }
    }

    private string _desQues;
    public string DesQues
    {
        get { return _desQues; }
        set { _desQues = value; }
    }

    private string _desAns;
    public string DesAns
    {
        get { return _desAns; }
        set { _desAns = value; }
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
