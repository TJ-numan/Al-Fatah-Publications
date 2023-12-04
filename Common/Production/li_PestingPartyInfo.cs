using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PestingPartyInfo
{
    public Li_PestingPartyInfo()
    {
    }

    public Li_PestingPartyInfo
        (
        
        string iD, 
        string name, 
        string name_bn,
        string address, 
        string address_bn, 
        string phone, 
        decimal o_Balance, 
        int serialNo, 
        int createdBy, 
        DateTime  createdDate  
         
        )
    {
        

        this.ID = iD;
        this.Name = name;
        this.Name_Bn = name_bn;
        this.Address = address;
        this.Address_Bn = address_bn;
        this.Phone = phone;
        this.O_Balance = o_Balance;
        this.SerialNo = serialNo;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        
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

    private string _name_bn;
    public string Name_Bn
    {
        get { return _name_bn; }
        set { _name_bn = value; }
    }
    private string _address;
    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }

    private string _address_bn;
    public string Address_Bn
    {
        get { return _address_bn; }
        set { _address_bn = value; }
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

    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private DateTime  _createdDate;
    public DateTime  CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    
}
