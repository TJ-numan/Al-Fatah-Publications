using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_InterviewType
{
    public Li_InterviewType()
    {
    }

    public Li_InterviewType
        (
        
        int inTypeId, 
        string intType, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
      
        this.InTypeId = inTypeId;
        this.IntType = intType;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _inTypeId;
    public int InTypeId
    {
        get { return _inTypeId; }
        set { _inTypeId = value; }
    }

    private string _intType;
    public string IntType
    {
        get { return _intType; }
        set { _intType = value; }
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
