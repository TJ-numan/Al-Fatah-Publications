using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PlatePurchase
{
    public Li_PlatePurchase()
    {
    }

    public Li_PlatePurchase
        (
        
        string pur_ID, 
        string pur_PartyID, 
        DateTime orderDate, 
        int totalPlateQty, 
        decimal totalBill, 
        string receiveID, 
        bool isPress, 
        int createdBy, 
        DateTime createdDate 
         
        )
    {
         this.Pur_ID = pur_ID;
        this.Pur_PartyID = pur_PartyID;
        this.OrderDate = orderDate;
        this.TotalPlateQty = totalPlateQty;
        this.TotalBill = totalBill;
        this.ReceiveID = receiveID;
        this.IsPress = isPress;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
      
    }


     

    private string _pur_ID;
    public string Pur_ID
    {
        get { return _pur_ID; }
        set { _pur_ID = value; }
    }

    private string _pur_PartyID;
    public string Pur_PartyID
    {
        get { return _pur_PartyID; }
        set { _pur_PartyID = value; }
    }

    private DateTime _orderDate;
    public DateTime OrderDate
    {
        get { return _orderDate; }
        set { _orderDate = value; }
    }

    private int _totalPlateQty;
    public int TotalPlateQty
    {
        get { return _totalPlateQty; }
        set { _totalPlateQty = value; }
    }

    private decimal _totalBill;
    public decimal TotalBill
    {
        get { return _totalBill; }
        set { _totalBill = value; }
    }

    private string _receiveID;
    public string ReceiveID
    {
        get { return _receiveID; }
        set { _receiveID = value; }
    }

    private bool _isPress;
    public bool IsPress
    {
        get { return _isPress; }
        set { _isPress = value; }
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
