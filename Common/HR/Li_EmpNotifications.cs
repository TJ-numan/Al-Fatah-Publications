using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpNotifications
{
    public Li_EmpNotifications()
    {
    }

    public Li_EmpNotifications
        (
         
        int notId, 
        string notTitle, 
        string notDes, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.NotId = notId;
        this.NotTitle = notTitle;
        this.NotDes = notDes;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _notId;
    public int NotId
    {
        get { return _notId; }
        set { _notId = value; }
    }

    private string _notTitle;
    public string NotTitle
    {
        get { return _notTitle; }
        set { _notTitle = value; }
    }

    private string _notDes;
    public string NotDes
    {
        get { return _notDes; }
        set { _notDes = value; }
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
