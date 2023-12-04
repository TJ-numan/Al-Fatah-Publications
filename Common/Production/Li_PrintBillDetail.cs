using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PrintBillDetail
{
    public Li_PrintBillDetail()
    {
    }

    public Li_PrintBillDetail
        (
        
        int serialNo, 
        int billSerial, 
        int pintDSerial, 
        decimal rate, 
        decimal bill 
         
        )
    {
       
        this.SerialNo = serialNo;
        this.BillSerial = billSerial;
        this.PintDSerial = pintDSerial;
        this.Rate = rate;
        this.Bill = bill;
         
    }


  

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

    private int _pintDSerial;
    public int PintDSerial
    {
        get { return _pintDSerial; }
        set { _pintDSerial = value; }
    }

    private decimal _rate;
    public decimal Rate
    {
        get { return _rate; }
        set { _rate = value; }
    }

    private decimal _bill;
    public decimal Bill
    {
        get { return _bill; }
        set { _bill = value; }
    }

    
}
