using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_LeminationOrderDetail
{
    public Li_LeminationOrderDetail()
    {
    }

    public Li_LeminationOrderDetail
        (
       
        int serialNo, 
        string orderID, 
        string lemiPartyID, 
        string lemiTypeID, 
        int qty 
         
        )
    {
        
        this.SerialNo = serialNo;
        this.OrderID = orderID;
        this.LemiPartyID = lemiPartyID;
        this.LemiTypeID = lemiTypeID;
        this.Qty = qty;
         
    }

 

    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = value; }
    }

    private string _orderID;
    public string OrderID
    {
        get { return _orderID; }
        set { _orderID = value; }
    }

    private string _lemiPartyID;
    public string LemiPartyID
    {
        get { return _lemiPartyID; }
        set { _lemiPartyID = value; }
    }

    private string _lemiTypeID;
    public string LemiTypeID
    {
        get { return _lemiTypeID; }
        set { _lemiTypeID = value; }
    }

    private int _qty;
    public int Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

   
}
