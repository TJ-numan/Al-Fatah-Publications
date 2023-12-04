using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Overhead
{
    public Li_Overhead()
    {
    }

    public Li_Overhead
        (

        string bookCode,
        decimal manufacturingOverhead,
        decimal administrativeOverhead,
        decimal mKTOverhead,
        decimal wastage,
        decimal commission,
        decimal markUp,
        decimal bonus
        )
    {

        this.BookCode = bookCode;
        this.ManufacturingOverhead = manufacturingOverhead;
        this.AdministrativeOverhead = administrativeOverhead;
        this.MKTOverhead = mKTOverhead;
        this.Wastage = wastage;
        this.Commission = commission;
        this.MarkUp = markUp;
        this.Bonus = bonus;

    }




    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private decimal _manufacturingOverhead;
    public decimal ManufacturingOverhead
    {
        get { return _manufacturingOverhead; }
        set { _manufacturingOverhead = value; }
    }

    private decimal _administrativeOverhead;
    public decimal AdministrativeOverhead
    {
        get { return _administrativeOverhead; }
        set { _administrativeOverhead = value; }
    }

    private decimal _mKTOverhead;
    public decimal MKTOverhead
    {
        get { return _mKTOverhead; }
        set { _mKTOverhead = value; }
    }

    private decimal _wastage;
    public decimal Wastage
    {
        get { return _wastage; }
        set { _wastage = value; }
    }

    private decimal _commission;
    public decimal Commission
    {
        get { return _commission; }
        set { _commission = value; }
    }

    private decimal _markUp;
    public decimal MarkUp
    {
        get { return _markUp; }
        set { _markUp = value; }
    }

    private decimal _bonus;
    public decimal Bonus
    {
        get { return _bonus; }
        set { _bonus = value; }
    }
}
