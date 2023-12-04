using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookBinderInfo
{
    public Li_BookBinderInfo()
    {
    }

    public Li_BookBinderInfo
        (
         
        string binderCode, 
        string binderName, 
        string address, 
        string phone, 
        decimal opennigBalance, 
        DateTime createdDate, 
        int createdBy , 
        string b_Name, 
        string b_Add  
         
        )
    {
         this.BinderCode = binderCode;
        this.BinderName = binderName;
        this.Address = address;
        this.Phone = phone;
        this.OpennigBalance = opennigBalance;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.B_Name = b_Name;
        this.B_Add = b_Add;
    
    }


    

    private string _binderCode;
    public string BinderCode
    {
        get { return _binderCode; }
        set { _binderCode = value; }
    }

    private string _binderName;
    public string BinderName
    {
        get { return _binderName; }
        set { _binderName = value; }
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
