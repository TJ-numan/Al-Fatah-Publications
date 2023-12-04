using System;
using System.Data;
using System.Configuration;
using System.Linq; 
public class Li_MadrasahEntry
{
    public Li_MadrasahEntry()
    {
    }

    public Li_MadrasahEntry
        (
    
        string code, 
        string name, 
        string address, 
        string postOffice, 
        string mobile, 
        int madLevel, 
        int th_ID, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate
        )
    {
     
        this.Code = code;
        this.Name = name;
        this.Address = address;
        this.PostOffice = postOffice;
        this.Mobile = mobile;
        this.MadLevel = madLevel;
        this.Th_ID = th_ID;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
    }

 

    private string _code;
    public string Code
    {
        get { return _code; }
        set { _code = value; }
    }

    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    private string _address;
    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }

    private string _postOffice;
    public string PostOffice
    {
        get { return _postOffice; }
        set { _postOffice = value; }
    }

    private string _mobile;
    public string Mobile
    {
        get { return _mobile; }
        set { _mobile = value; }
    }

    private int _madLevel;
    public int MadLevel
    {
        get { return _madLevel; }
        set { _madLevel = value; }
    }

    private int _th_ID;
    public int Th_ID
    {
        get { return _th_ID; }
        set { _th_ID = value; }
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
}
