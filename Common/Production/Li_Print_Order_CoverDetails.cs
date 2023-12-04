using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Print_Order_CoverDetails
{
    public Li_Print_Order_CoverDetails()
    {
    }

    public Li_Print_Order_CoverDetails
        (
     
        int serialNo, 
        string print_OrderNo, 
        int ups, 
        int impression, 
        int colorNo, 
        decimal billRate, 
        decimal totalBill, 
        int coverQty, 
        string exPrintNote 
         
        )
    {
       
        this.SerialNo = serialNo;
        this.Print_OrderNo = print_OrderNo;
        this.Ups = ups;
        this.Impression = impression;
        this.ColorNo = colorNo;
        this.BillRate = billRate;
        this.TotalBill = totalBill;
        this.CoverQty = coverQty;
        this.ExPrintNote = exPrintNote;
        
    }

 
    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = value; }
    }

    private string _print_OrderNo;
    public string Print_OrderNo
    {
        get { return _print_OrderNo; }
        set { _print_OrderNo = value; }
    }

    private int _ups;
    public int Ups
    {
        get { return _ups; }
        set { _ups = value; }
    }

    private int _impression;
    public int Impression
    {
        get { return _impression; }
        set { _impression = value; }
    }

    private int _colorNo;
    public int ColorNo
    {
        get { return _colorNo; }
        set { _colorNo = value; }
    }

    private decimal _billRate;
    public decimal BillRate
    {
        get { return _billRate; }
        set { _billRate = value; }
    }

    private decimal _totalBill;
    public decimal TotalBill
    {
        get { return _totalBill; }
        set { _totalBill = value; }
    }

    private int _coverQty;
    public int CoverQty
    {
        get { return _coverQty; }
        set { _coverQty = value; }
    }

    private string _exPrintNote;
    public string ExPrintNote
    {
        get { return _exPrintNote; }
        set { _exPrintNote = value; }
    }

   
}
