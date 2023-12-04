using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PlateBillDetail
{
    public Li_PlateBillDetail()
    {
    }

    public Li_PlateBillDetail
        (
      
        int serialNo, 
        string pur_Order, 
        decimal orderAmount 
         
        )
    {
  
        this.SerialNo = serialNo;
        this.Pur_Order = pur_Order;
        this.OrderAmount = orderAmount;
      
    }


 

    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = value; }
    }

    private string _pur_Order;
    public string Pur_Order
    {
        get { return _pur_Order; }
        set { _pur_Order = value; }
    }

    private decimal _orderAmount;
    public decimal OrderAmount
    {
        get { return _orderAmount; }
        set { _orderAmount = value; }
    }

   
}
