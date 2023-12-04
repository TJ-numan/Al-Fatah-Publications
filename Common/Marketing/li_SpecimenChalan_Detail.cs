using System;
using System.Data;
using System.Configuration;
using System.Linq;



public class Li_SpecimenChalan_Detail
{
    public Li_SpecimenChalan_Detail()
    {
    }

    public Li_SpecimenChalan_Detail
        (

        string challanDetailsID,
        string challanID,
        string bookAcCode,
        int qty,
        decimal unitPrice,
        string edition

        )
    {

        this.ChallanDetailsID = challanDetailsID;
        this.ChallanID = challanID;
        this.BookAcCode = bookAcCode;
        this.Qty = qty;
        this.UnitPrice = unitPrice;
        this.Edition = edition;
    }

    private string _edition;
    public string Edition
    {
        get { return _edition; }
        set { _edition = value; }
    }


    private string _challanDetailsID;
    public string ChallanDetailsID
    {
        get { return _challanDetailsID; }
        set { _challanDetailsID = value; }
    }

    private string _challanID;
    public string ChallanID
    {
        get { return _challanID; }
        set { _challanID = value; }
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

    private decimal _unitPrice;
    public decimal UnitPrice
    {
        get { return _unitPrice; }
        set { _unitPrice = value; }
    }


}
