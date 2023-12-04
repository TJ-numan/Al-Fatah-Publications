using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_BloodGroup
{
    public Li_BloodGroup()
    {
    }

    public Li_BloodGroup
        (
         
        int bGId, 
        string bGName, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
     
        this.BGId = bGId;
        this.BGName = bGName;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }

 

    private int _bGId;
    public int BGId
    {
        get { return _bGId; }
        set { _bGId = value; }
    }

    private string _bGName;
    public string BGName
    {
        get { return _bGName; }
        set { _bGName = value; }
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
