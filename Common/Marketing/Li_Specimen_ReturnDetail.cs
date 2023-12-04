using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Specimen_ReturnDetail
{
    public Li_Specimen_ReturnDetail()
    {
    }

    public Li_Specimen_ReturnDetail
        (
         
        string returnDetailsID, 
        string returnID, 
        string bookAcCode, 
        int qty, 
        int adjustQty, 
        decimal unitPrice 
         
        )
    {
       
        this.ReturnDetailsID = returnDetailsID;
        this.ReturnID = returnID;
        this.BookAcCode = bookAcCode;
        this.Qty = qty;
        this.AdjustQty = adjustQty;
        this.UnitPrice = unitPrice;
         
    }

 
    private string _returnDetailsID;
    public string ReturnDetailsID
    {
        get { return _returnDetailsID; }
        set { _returnDetailsID = value; }
    }

    private string _returnID;
    public string ReturnID
    {
        get { return _returnID; }
        set { _returnID = value; }
    }

    private string _bookAcCode;
    public string BookAcCode
    {
        get { return _bookAcCode; }
        set { _bookAcCode = value; }
    }

    private int _qty;
    public int Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

    private int _adjustQty;
    public int AdjustQty
    {
        get { return _adjustQty; }
        set { _adjustQty = value; }
    }

    private decimal _unitPrice;
    public decimal UnitPrice
    {
        get { return _unitPrice; }
        set { _unitPrice = value; }
    }

   
}
