using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_TermReason
{
    public Li_TermReason()
    {
    }

    public Li_TermReason
        (
       
        int teReId, 
        string teReName, 
        string teReDes, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.TeReId = teReId;
        this.TeReName = teReName;
        this.TeReDes = teReDes;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _teReId;
    public int TeReId
    {
        get { return _teReId; }
        set { _teReId = value; }
    }

    private string _teReName;
    public string TeReName
    {
        get { return _teReName; }
        set { _teReName = value; }
    }

    private string _teReDes;
    public string TeReDes
    {
        get { return _teReDes; }
        set { _teReDes = value; }
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
