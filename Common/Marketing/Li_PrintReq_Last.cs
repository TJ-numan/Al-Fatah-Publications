using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PrintReq_Last
{
    public Li_PrintReq_Last()
    {
    }

    public Li_PrintReq_Last
        (
      
        int lastSl, 
        string reqNo, 
        string bookCode, 
        int printed, 
        int rec_Qty, 
        int challan, 
        int specimen, 
        int rebinding, 
        int damage, 
        int stockInHand, 
        DateTime startDate, 
        DateTime endDate 
         
        )
    {
       
        this.LastSl = lastSl;
        this.ReqNo = reqNo;
        this.BookCode = bookCode;
        this.Printed = printed;
        this.Rec_Qty = rec_Qty;
        this.Challan = challan;
        this.Specimen = specimen;
        this.Rebinding = rebinding;
        this.Damage = damage;
        this.StockInHand = stockInHand;
        this.StartDate = startDate;
        this.EndDate = endDate;
      
    }


   

    private int _lastSl;
    public int LastSl
    {
        get { return _lastSl; }
        set { _lastSl = value; }
    }

    private string _reqNo;
    public string ReqNo
    {
        get { return _reqNo; }
        set { _reqNo = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private int _printed;
    public int Printed
    {
        get { return _printed; }
        set { _printed = value; }
    }

    private int _rec_Qty;
    public int Rec_Qty
    {
        get { return _rec_Qty; }
        set { _rec_Qty = value; }
    }

    private int _challan;
    public int Challan
    {
        get { return _challan; }
        set { _challan = value; }
    }

    private int _specimen;
    public int Specimen
    {
        get { return _specimen; }
        set { _specimen = value; }
    }

    private int _rebinding;
    public int Rebinding
    {
        get { return _rebinding; }
        set { _rebinding = value; }
    }

    private int _damage;
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    private int _stockInHand;
    public int StockInHand
    {
        get { return _stockInHand; }
        set { _stockInHand = value; }
    }

    private DateTime _startDate;
    public DateTime StartDate
    {
        get { return _startDate; }
        set { _startDate = value; }
    }

    private DateTime _endDate;
    public DateTime EndDate
    {
        get { return _endDate; }
        set { _endDate = value; }
    }

   
}
