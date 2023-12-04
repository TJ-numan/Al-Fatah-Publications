using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_LeminatioPartyInfo
{
    public Li_LeminatioPartyInfo()
    {
    }

    public Li_LeminatioPartyInfo
        (
        
        string iD, 
        string name, 
        string address, 
        string phone, 
        decimal openingBalance, 
        DateTime crteatedDate, 
        int createdBy, 
        int serialNo, 
        string name_Bn, 
        string add_Bn 
         
        )
    {
        
        this.ID = iD;
        this.Name = name;
        this.Address = address;
        this.Phone = phone;
        this.OpeningBalance = openingBalance;
        this.CrteatedDate = crteatedDate;
        this.CreatedBy = createdBy;
        this.SerialNo = serialNo;
        this.Name_Bn = name_Bn;
        this.Add_Bn = add_Bn;
       
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

    private decimal _openingBalance;
    public decimal OpeningBalance
    {
        get { return _openingBalance; }
        set { _openingBalance = value; }
    }

    private DateTime _crteatedDate;
    public DateTime CrteatedDate
    {
        get { return _crteatedDate; }
        set { _crteatedDate = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = value; }
    }

    private string _name_Bn;
    public string Name_Bn
    {
        get { return _name_Bn; }
        set { _name_Bn = value; }
    }

    private string _add_Bn;
    public string Add_Bn
    {
        get { return _add_Bn; }
        set { _add_Bn = value; }
    }

    
}
