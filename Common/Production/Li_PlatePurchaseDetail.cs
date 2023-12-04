using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PlatePurchaseDetail
{
    public Li_PlatePurchaseDetail()
    {
    }

    public Li_PlatePurchaseDetail
        (
        
        int sl, 
        string pur_ID, 
        string bookCode, 
        string edition, 
        string plateTypeID, 
        string plateSizeID, 
        int    qty, 
        decimal billRate ,
        int plateFor,
        string refno,
        DateTime purDate
         
        )
    {
         
        this.Sl = sl;
        this.Pur_ID = pur_ID;
        this.BookCode = bookCode;
        this.Edition = edition;
        this.PlateTypeID = plateTypeID;
        this.PlateSizeID = plateSizeID;
        this.Qty = qty;
        this.BillRate = billRate;
        this.PlateFor = plateFor;
        this.Refno = refno;
        this.PurDate = purDate;
    }
    public DateTime PurDate  { get; set; }
    public string Refno { get; set; }
    public  int PlateFor { get; set; }
 
    private int _sl;
    public int Sl
    {
        get { return _sl; }
        set { _sl = value; }
    }

    private string _pur_ID;
    public string Pur_ID
    {
        get { return _pur_ID; }
        set { _pur_ID = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private string _edition;
    public string Edition
    {
        get { return _edition; }
        set { _edition = value; }
    }

    private string _plateTypeID;
    public string PlateTypeID
    {
        get { return _plateTypeID; }
        set { _plateTypeID = value; }
    }

    private string _plateSizeID;
    public string PlateSizeID
    {
        get { return _plateSizeID; }
        set { _plateSizeID = value; }
    }

    private int _qty;
    public int Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

    private decimal _billRate;
    public decimal BillRate
    {
        get { return _billRate; }
        set { _billRate = value; }
    }

     
}
