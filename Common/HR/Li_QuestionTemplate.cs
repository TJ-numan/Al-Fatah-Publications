using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_QuestionTemplate
{
    public Li_QuestionTemplate()
    {
    }

    public Li_QuestionTemplate
        (
       
        int quesTemId, 
        string quesTemTitle, 
        int defPosId, 
        int inTypeId, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.QuesTemId = quesTemId;
        this.QuesTemTitle = quesTemTitle;
        this.DefPosId = defPosId;
        this.InTypeId = inTypeId;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _quesTemId;
    public int QuesTemId
    {
        get { return _quesTemId; }
        set { _quesTemId = value; }
    }

    private string _quesTemTitle;
    public string QuesTemTitle
    {
        get { return _quesTemTitle; }
        set { _quesTemTitle = value; }
    }

    private int _defPosId;
    public int DefPosId
    {
        get { return _defPosId; }
        set { _defPosId = value; }
    }

    private int _inTypeId;
    public int InTypeId
    {
        get { return _inTypeId; }
        set { _inTypeId = value; }
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
