using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class Li_Designation
{
    public Li_Designation()
    {
    }

    public Li_Designation
        (
         
        int desId,
        string desName,
        int createdBy,
        DateTime createdDate,
        int modifiedBy,
        DateTime modifiedDate,
        int infStId
        )
    {
      
        this.DesId = desId;
        this.DesName = desName;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _desId;
    public int DesId
    {
        get { return _desId; }
        set { _desId = value; }
    }

    private string _desName;
    public string DesName
    {
        get { return _desName; }
        set { _desName = value; }
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
