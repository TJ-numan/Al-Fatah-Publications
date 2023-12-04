using System;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_ReturnDetails
{
    public li_ReturnDetails()
    {
    }


    public li_ReturnDetails
        (
            int   returnDetailsID,

            string bookAcCode,
            string   returnID,
            int  qty,
            decimal  unitPrice,
            decimal  totalPrice,

            decimal damageQty,
            int specimenQty,
            decimal discountPercentage,
         string edition 
        )

    {
this.ReturnDetailsID = returnDetailsID;

this.ReturnID = returnID;
this.Qty = qty;
this.UnitPrice = unitPrice;
this.TotalPrice = totalPrice;

this.BookAcCode = bookAcCode;
this.DamageQuentity = damageQty;
this.SpecimenQty = specimenQty;

this.DiscountPercentage = discountPercentage;

this.Edition = edition;
    }

    private int  _returnDetailsID;
    public int  ReturnDetailsID
    {
        get { return _returnDetailsID; }
        set { _returnDetailsID = value; }
    }

    private string _edition;
    public string Edition
    {
        get { return _edition; }
        set { _edition = value; }
    }
 
    private string   _returnID;
    public string   ReturnID
    {
        get { return _returnID; }
        set { _returnID = value; }
    }

    private int  _qty;
    public int  Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }
    private int _specimenQty;
    public int SpecimenQty
    {
        get { return _specimenQty; }
        set { _specimenQty = value; }
    }
    private decimal  _unitPrice;
    public decimal  UnitPrice
    {
        get { return _unitPrice; }
        set { _unitPrice = value; }
    }
    private decimal _discountPercentage;
    public decimal DiscountPercentage
    {
        get { return _discountPercentage; }
        set { _discountPercentage = value; }
    }
    private decimal  _totalPrice;
    public decimal  TotalPrice
    {
        get { return _totalPrice; }
        set { _totalPrice = value; }
    }

   

    private string _bookAcCode;
    public string BookAcCode
    {
        get { return _bookAcCode; }
        set { _bookAcCode = value; }
    }



    private decimal _damageQuentity;

    public decimal DamageQuentity
    {
        get { return _damageQuentity; }
        set { _damageQuentity = value; }
    }
}

