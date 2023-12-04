using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EduResult
{
    public Li_EduResult()
    {
    }

    public Li_EduResult
        (
      
        int eduReId, 
        string eduReName, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.EduReId = eduReId;
        this.EduReName = eduReName;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _eduReId;
    public int EduReId
    {
        get { return _eduReId; }
        set { _eduReId = value; }
    }

    private string _eduReName;
    public string EduReName
    {
        get { return _eduReName; }
        set { _eduReName = value; }
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
