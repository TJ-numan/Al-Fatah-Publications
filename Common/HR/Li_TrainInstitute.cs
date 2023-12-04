using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_TrainInstitute
{
    public Li_TrainInstitute()
    {
    }

    public Li_TrainInstitute
        (
         
        int insId, 
        string insName, 
        string insAdd, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.InsId = insId;
        this.InsName = insName;
        this.InsAdd = insAdd;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _insId;
    public int InsId
    {
        get { return _insId; }
        set { _insId = value; }
    }

    private string _insName;
    public string InsName
    {
        get { return _insName; }
        set { _insName = value; }
    }

    private string _insAdd;
    public string InsAdd
    {
        get { return _insAdd; }
        set { _insAdd = value; }
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
