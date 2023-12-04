using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_DonPayType
{
    public Li_DonPayType()
    {
    }

    public Li_DonPayType
        (
        
        int payTypId, 
        string payTypName, 
        bool isBank, 
        int createdBy, 
        DateTime createdDate
        )
    {
        
        this.PayTypId = payTypId;
        this.PayTypName = payTypName;
        this.IsBank = isBank;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
    }

 

    private int _payTypId;
    public int PayTypId
    {
        get { return _payTypId; }
        set { _payTypId = value; }
    }

    private string _payTypName;
    public string PayTypName
    {
        get { return _payTypName; }
        set { _payTypName = value; }
    }

    private bool _isBank;
    public bool IsBank
    {
        get { return _isBank; }
        set { _isBank = value; }
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
