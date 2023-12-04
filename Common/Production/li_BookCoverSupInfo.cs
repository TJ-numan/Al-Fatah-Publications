using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookCoverSupInfo
{
    public Li_BookCoverSupInfo()
    {
    }

    public Li_BookCoverSupInfo
        (
         
        string cOSCode, 
        string supName, 
        string address, 
        string phone, 
        decimal opennigBalance, 
        DateTime createdDate, 
        int createdBy, 
        string b_Name, 
        string b_Add 
         
        )
    {
 
        this.COSCode = cOSCode;
        this.SupName = supName;
        this.Address = address;
        this.Phone = phone;
        this.OpennigBalance = opennigBalance;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.B_Name = b_Name;
        this.B_Add = b_Add;
       
    }


   
    private string _cOSCode;
    public string COSCode
    {
        get { return _cOSCode; }
        set { _cOSCode = value; }
    }

    private string _supName;
    public string SupName
    {
        get { return _supName; }
        set { _supName = value; }
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

    private decimal _opennigBalance;
    public decimal OpennigBalance
    {
        get { return _opennigBalance; }
        set { _opennigBalance = value; }
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
