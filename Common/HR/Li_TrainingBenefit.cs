using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_TrainingBenefit
{
    public Li_TrainingBenefit()
    {
    }

    public Li_TrainingBenefit
        (
         
        int trainBeId, 
        int trainAppId, 
        string trainBenefit, 
        bool isPersonal, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
         
        this.TrainBeId = trainBeId;
        this.TrainAppId = trainAppId;
        this.TrainBenefit = trainBenefit;
        this.IsPersonal = isPersonal;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _trainBeId;
    public int TrainBeId
    {
        get { return _trainBeId; }
        set { _trainBeId = value; }
    }

    private int _trainAppId;
    public int TrainAppId
    {
        get { return _trainAppId; }
        set { _trainAppId = value; }
    }

    private string _trainBenefit;
    public string TrainBenefit
    {
        get { return _trainBenefit; }
        set { _trainBenefit = value; }
    }

    private bool _isPersonal;
    public bool IsPersonal
    {
        get { return _isPersonal; }
        set { _isPersonal = value; }
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
