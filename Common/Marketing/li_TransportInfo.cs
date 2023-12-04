using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_TransportInfo
{
    public Li_TransportInfo()
    {
    }

    public Li_TransportInfo
        (
        
        string transportID, 
        string transportName, 
        string address, 
        string phone, 
        int createdBy, 
        DateTime createdDate 
        
         
        )
    {
         
        this.TransportID = transportID;
        this.TransportName = transportName;
        this.Address = address;
        this.Phone = phone;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
         
    }
    
 
    private string _transportID;
    public string TransportID
    {
        get { return _transportID; }
        set { _transportID = value; }
    }

    private string _transportName;
    public string TransportName
    {
        get { return _transportName; }
        set { _transportName = value; }
    }

    private string _address;
    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }

    private string _phone;
    public string Phone
    {
        get { return _phone; }
        set { _phone = value; }
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
