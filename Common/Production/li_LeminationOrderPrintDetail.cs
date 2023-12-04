using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_LeminationOrderPrintDetail
{
    public Li_LeminationOrderPrintDetail()
    {
    }

    public Li_LeminationOrderPrintDetail
        (
      
        int serialNo, 
        string   orderID, 
        int lemiSerial 
         
        )
    {
       
        this.SerialNo = serialNo;
        this.OrderID = orderID;
        this.LemiSerial = lemiSerial;
        
    }


    
    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = value; }
    }

    private string  _orderID;
    public string OrderID
    {
        get { return _orderID; }
        set { _orderID = value; }
    }

    private int  _lemiSerial;
    public int LemiSerial
    {
        get { return _lemiSerial; }
        set { _lemiSerial = value; }
    }

     
}
