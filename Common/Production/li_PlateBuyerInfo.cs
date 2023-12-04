using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PlateBuyerInfo
{
    public Li_PlateBuyerInfo()
    {
    }

    public Li_PlateBuyerInfo
        (
        
        string iD, 
        string name, 
        string address, 
        string phone, 
        decimal o_Balance, 
        
        int createdBy, 
        DateTime  createdDate ,
        string b_Name,
        string b_Add 
         
        )
    {  
        this.ID = iD;
        this.Name = name;
        this.Address = address;
        this.Phone = phone;
        this.O_Balance = o_Balance;
        
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.B_Name=b_Name;
        this.B_Add = b_Add;
         
    }



    private string _iD;
    public string ID
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

    private decimal _o_Balance;
    public decimal O_Balance
    {
        get { return _o_Balance; }
        set { _o_Balance = value; }
    }

     

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private DateTime   _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private string _b_Name;
    public string B_Name
    {
        get { return _b_Name; }
        set { _b_Name = value; }
    }

    private string _b_Add;
    public string B_Add
    {
        get { return _b_Add; }
        set { _b_Add = value; }
    }
}
