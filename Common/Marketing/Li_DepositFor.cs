using System;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_DepositFor
{
    public Li_DepositFor()
    {
    }

    public Li_DepositFor
        (
        
        int depForId, 
        string depForName, 
        bool isActive, 
        string mrShortN, 
        int createdBy, 
        DateTime createdDate
        )
    {
 
        this.DepForId = depForId;
        this.DepForName = depForName;
        this.IsActive = isActive;
        this.MrShortN = mrShortN;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
    }

 

    private int _depForId;
    public int DepForId
    {
        get { return _depForId; }
        set { _depForId = value; }
    }

    private string _depForName;
    public string DepForName
    {
        get { return _depForName; }
        set { _depForName = value; }
    }

    private bool _isActive;
    public bool IsActive
    {
        get { return _isActive; }
        set { _isActive = value; }
    }

    private string _mrShortN;
    public string MrShortN
    {
        get { return _mrShortN; }
        set { _mrShortN = value; }
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
}
