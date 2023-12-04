using System;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_LemiChallanDetail
{
    public Li_LemiChallanDetail()
    {
    }

    public Li_LemiChallanDetail
        (
       
        int challanDetailID, 
        int memoNo, 
        string  p_S_ID, 
        string rollNo, 
        decimal qty, 
        decimal cQty, 
        decimal unitPrice, 
        decimal total, 
        decimal discountPercent, 
        decimal disAmt, 
        string status_D
        )
    {
     
        this.ChallanDetailID = challanDetailID;
        this.MemoNo = memoNo;
        this.P_S_ID = p_S_ID;
        this.RollNo = rollNo;
        this.Qty = qty;
        this.CQty = cQty;
        this.UnitPrice = unitPrice;
        this.Total = total;
        this.DiscountPercent = discountPercent;
        this.DisAmt = disAmt;
        this.Status_D = status_D;
    }


 
    private int _challanDetailID;
    public int ChallanDetailID
    {
        get { return _challanDetailID; }
        set { _challanDetailID = value; }
    }

    private int _memoNo;
    public int MemoNo
    {
        get { return _memoNo; }
        set { _memoNo = value; }
    }

    private string  _p_S_ID;
    public string  P_S_ID
    {
        get { return _p_S_ID; }
        set { _p_S_ID = value; }
    }

    private string _rollNo;
    public string RollNo
    {
        get { return _rollNo; }
        set { _rollNo = value; }
    }

    private decimal _qty;
    public decimal Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

    private decimal _cQty;
    public decimal CQty
    {
        get { return _cQty; }
        set { _cQty = value; }
    }

    private decimal _unitPrice;
    public decimal UnitPrice
    {
        get { return _unitPrice; }
        set { _unitPrice = value; }
    }

    private decimal _total;
    public decimal Total
    {
        get { return _total; }
        set { _total = value; }
    }

    private decimal _discountPercent;
    public decimal DiscountPercent
    {
        get { return _discountPercent; }
        set { _discountPercent = value; }
    }

    private decimal _disAmt;
    public decimal DisAmt
    {
        get { return _disAmt; }
        set { _disAmt = value; }
    }

    private string _status_D;
    public string Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }
}
