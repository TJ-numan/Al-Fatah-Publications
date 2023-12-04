using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_ReceivePolithin
{
    public Li_ReceivePolithin()
    {
    }

    public Li_ReceivePolithin
        (
        
        int iD, 
        int partyID, 
        int qty, 
        decimal unitPrice, 
        decimal totalPrice, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate 
        )
    {
         
        this.ID = iD;
        this.PartyID = partyID;
        this.Qty = qty;
        this.UnitPrice = unitPrice;
        this.TotalPrice = totalPrice;
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

    private int _partyID;
    public int PartyID
    {
        get { return _partyID; }
        set { _partyID = value; }
    }

    private int _qty;
    public int Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

    private decimal _unitPrice;
    public decimal UnitPrice
    {
        get { return _unitPrice; }
        set { _unitPrice = value; }
    }

    private decimal _totalPrice;
    public decimal TotalPrice
    {
        get { return _totalPrice; }
        set { _totalPrice = value; }
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
