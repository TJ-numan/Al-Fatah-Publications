using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PktReceivedBy
{
    public Li_PktReceivedBy()
    {
    }

    public Li_PktReceivedBy
        (
        
        int iD, 
        string receivedBy, 
        DateTime createdDate, 
        int createdBy, 
        DateTime modifiedDate, 
        int modifiedBy  
         
        )
    {
        
        this.ID = iD;
        this.ReceivedBy = receivedBy;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.ModifiedDate = modifiedDate;
        this.ModifiedBy = modifiedBy;
         
    }

     

    private int _iD;
    public int ID
    {
        get { return _iD; }
        set { _iD = value; }
    }

    private string _receivedBy;
    public string ReceivedBy
    {
        get { return _receivedBy; }
        set { _receivedBy = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private DateTime _modifiedDate;
    public DateTime ModifiedDate
    {
        get { return _modifiedDate; }
        set { _modifiedDate = value; }
    }

    private int _modifiedBy;
    public int ModifiedBy
    {
        get { return _modifiedBy; }
        set { _modifiedBy = value; }
    }
 
}
