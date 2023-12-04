using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PrintBillDetail_Plate
{
    public Li_PrintBillDetail_Plate()
    {
    }

    public Li_PrintBillDetail_Plate
        (
        
        int serialNo, 
        int billSerial, 
        int pintPSerial, 
        int plateQty, 
        decimal plateRate, 
        decimal processRate, 
        decimal totalBill 
         
        )
    {
      
        this.SerialNo = serialNo;
        this.BillSerial = billSerial;
        this.PintPSerial = pintPSerial;
        this.PlateQty = plateQty;
        this.PlateRate = plateRate;
        this.ProcessRate = processRate;
        this.TotalBill = totalBill;
        
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

    private int _pintPSerial;
    public int PintPSerial
    {
        get { return _pintPSerial; }
        set { _pintPSerial = value; }
    }

    private int _plateQty;
    public int PlateQty
    {
        get { return _plateQty; }
        set { _plateQty = value; }
    }

    private decimal _plateRate;
    public decimal PlateRate
    {
        get { return _plateRate; }
        set { _plateRate = value; }
    }

    private decimal _processRate;
    public decimal ProcessRate
    {
        get { return _processRate; }
        set { _processRate = value; }
    }

    private decimal _totalBill;
    public decimal TotalBill
    {
        get { return _totalBill; }
        set { _totalBill = value; }
    }

    
}
