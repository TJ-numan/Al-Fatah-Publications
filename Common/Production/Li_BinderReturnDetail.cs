using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_BinderReturnDetail
{
    public Li_BinderReturnDetail()
    {
    }

    public Li_BinderReturnDetail
        (
 
        int serialNo, 
        string receiveID, 
        string bookCode, 
        int receiveItemType, 
        decimal qty  
         
        )
    {
     
        this.SerialNo = serialNo;
        this.ReceiveID = receiveID;
        this.BookCode = bookCode;
        this.ReceiveItemType = receiveItemType;
        this.Qty = qty;
      
    }

 

    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = value; }
    }

    private string _receiveID;
    public string ReceiveID
    {
        get { return _receiveID; }
        set { _receiveID = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private int _receiveItemType;
    public int ReceiveItemType
    {
        get { return _receiveItemType; }
        set { _receiveItemType = value; }
    }

    private decimal _qty;
    public decimal Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

   
}
