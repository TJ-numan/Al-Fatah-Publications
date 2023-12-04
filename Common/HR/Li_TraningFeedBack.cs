using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_TraningFeedBack
{
    public Li_TraningFeedBack()
    {
    }

    public Li_TraningFeedBack
        (
       
        int trainFId, 
        int trainFeedback, 
        int trainAppId, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
   
        this.TrainFId = trainFId;
        this.TrainFeedback = trainFeedback;
        this.TrainAppId = trainAppId;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _trainFId;
    public int TrainFId
    {
        get { return _trainFId; }
        set { _trainFId = value; }
    }

    private int _trainFeedback;
    public int TrainFeedback
    {
        get { return _trainFeedback; }
        set { _trainFeedback = value; }
    }

    private int _trainAppId;
    public int TrainAppId
    {
        get { return _trainAppId; }
        set { _trainAppId = value; }
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
