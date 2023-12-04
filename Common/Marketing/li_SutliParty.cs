using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_SutliParty
{
    public Li_SutliParty()
    {
    }

    public Li_SutliParty
        (
         
        int iD, 
        string name, 
        string address, 
        string phone, 
        int createdBy, 
        DateTime createdDate, 
      
        int modifiedBy, 
        DateTime modifiedDate  
         
        )
    {
        
        this.ID = iD;
        this.Name = name;
        this.Address = address;
        this.Phone = phone;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
       
    }


   

    private int _iD;
    public int ID
    {
        get { return _iD; }
        set { _iD = value; }
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
