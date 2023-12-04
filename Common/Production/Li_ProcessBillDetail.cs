using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_ProcessBillDetail
{
    public Li_ProcessBillDetail()
    {
    }

    public Li_ProcessBillDetail
        (
        
        int serialNo, 
        int billSerial, 
        string pro_Order, 
        decimal bill ,
         string pressID
        )
    {
         this.SerialNo = serialNo;
        this.BillSerial = billSerial;
        this.Pro_Order = pro_Order;
        this.Bill = bill;
        this.PressID = pressID;
        
    }

    public string PressID { get; set; }

 

    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = value; }
    }

    private int _billSerial;
    public int BillSerial
    {
        get { return _billSerial; }
        set { _billSerial = value; }
    }

    private string _pro_Order;
    public string Pro_Order
    {
        get { return _pro_Order; }
        set { _pro_Order = value; }
    }

    private decimal _bill;
    public decimal Bill
    {
        get { return _bill; }
        set { _bill = value; }
    }

    
}
