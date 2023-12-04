using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpClearanceDetail
{
    public Li_EmpClearanceDetail()
    {
    }

    public Li_EmpClearanceDetail
        (
        
        int clearDetId, 
        int clearId, 
        int depId, 
        int athorizedId, 
        string depComments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.ClearDetId = clearDetId;
        this.ClearId = clearId;
        this.DepId = depId;
        this.AthorizedId = athorizedId;
        this.DepComments = depComments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _clearDetId;
    public int ClearDetId
    {
        get { return _clearDetId; }
        set { _clearDetId = value; }
    }

    private int _clearId;
    public int ClearId
    {
        get { return _clearId; }
        set { _clearId = value; }
    }

    private int _depId;
    public int DepId
    {
        get { return _depId; }
        set { _depId = value; }
    }

    private int _athorizedId;
    public int AthorizedId
    {
        get { return _athorizedId; }
        set { _athorizedId = value; }
    }

    private string _depComments;
    public string DepComments
    {
        get { return _depComments; }
        set { _depComments = value; }
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
