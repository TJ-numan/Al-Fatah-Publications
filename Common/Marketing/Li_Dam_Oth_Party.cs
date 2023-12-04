using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Dam_Oth_Party
{
    public Li_Dam_Oth_Party()
    {
    }

    public Li_Dam_Oth_Party
        (
       
        string partyID, 
        string partName, 
        string p_Add, 
        DateTime createdDate, 
        int createdBy, 
        string ownerName, 
        string contactPer, 
        string phone 
         
        )
    {
        
        this.PartyID = partyID;
        this.PartName = partName;
        this.P_Add = p_Add;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.OwnerName = ownerName;
        this.ContactPer = contactPer;
        this.Phone = phone;
     
       
    }

 
    private string _partyID;
    public string PartyID
    {
        get { return _partyID; }
        set { _partyID = value; }
    }

    private string _partName;
    public string PartName
    {
        get { return _partName; }
        set { _partName = value; }
    }

    private string _p_Add;
    public string P_Add
    {
        get { return _p_Add; }
        set { _p_Add = value; }
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

    private string _ownerName;
    public string OwnerName
    {
        get { return _ownerName; }
        set { _ownerName = value; }
    }

    private string _contactPer;
    public string ContactPer
    {
        get { return _contactPer; }
        set { _contactPer = value; }
    }

    private string _phone;
    public string Phone
    {
        get { return _phone; }
        set { _phone = value; }
    }

  

  
}
