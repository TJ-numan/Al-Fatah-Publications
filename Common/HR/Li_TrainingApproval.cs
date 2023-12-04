using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_TrainingApproval
{
    public Li_TrainingApproval()
    {
    }

    public Li_TrainingApproval
        (
        
        int trainAproveId, 
        int trainAppId, 
        int empSl, 
        bool isApproved, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.TrainAproveId = trainAproveId;
        this.TrainAppId = trainAppId;
        this.EmpSl = empSl;
        this.IsApproved = isApproved;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _trainAproveId;
    public int TrainAproveId
    {
        get { return _trainAproveId; }
        set { _trainAproveId = value; }
    }

    private int _trainAppId;
    public int TrainAppId
    {
        get { return _trainAppId; }
        set { _trainAppId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private bool _isApproved;
    public bool IsApproved
    {
        get { return _isApproved; }
        set { _isApproved = value; }
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
