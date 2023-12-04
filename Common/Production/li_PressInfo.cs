using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PressInfo
{
    public Li_PressInfo()
    {
    }

    public Li_PressInfo
        (
         
        string pressID,
        string pressname,
        string address, 
        string phone, 
        decimal openingBalance, 
        DateTime crteatedDate, 
        int createdBy,      
        string name_Bn,  
        string add_Bn
         
        )
    {
        
        this.PressID = pressID;
        this.PressName = pressname;
        this.Address = address;
        this.Phone = phone;
        this.OpeningBalance = openingBalance;
        this.CrteatedDate = crteatedDate;
        this.CreatedBy = createdBy;
        this.Name_Bn = name_Bn;
        this.Add_Bn = add_Bn;
         
    }
    public string Name_Bn { get; set;}
    public string Add_Bn { get; set; }
    

    private string _pressID;
    public string PressID
    {
        get { return _pressID; }
        set { _pressID = value; }
    }

   private string _pressname;
    public string PressName
    {
        get { return _pressname; }
        set { _pressname = value; }
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

   
}
