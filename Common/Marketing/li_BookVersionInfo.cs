using System;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_BookVersionInfo
{
    public li_BookVersionInfo()
    {
    }


    public li_BookVersionInfo
        (
         string bookAcCode,

         string bookID,
         string edition,
         DateTime printdate,
         bool isReprinted,
         bool isRebinding,
         decimal price,
         int quantity,
         bool isopeningStock,
         decimal bonus,
         int createdBy

        )
    {
        this.BookAcCode = bookAcCode;

        this.BookID = bookID;
        this.Edition = edition;
        this.Printdate = printdate;
        this.IsReprinted = isReprinted;
        this.IsRebinding = isRebinding;
        this.Price = price;
        this.Quantity = quantity;
        this.IsOpeningStock = isopeningStock;
        this.Bonus = bonus;
        this.CreatedBy = createdBy;
    }
    public li_BookVersionInfo
     (
string bookAcCode,

string bookID,
string edition

     )
    {
        this.BookAcCode = bookAcCode;

        this.BookID = bookID;
        this.Edition = edition;

    }
    private string _bookAcCode;
    public string BookAcCode
    {
        get { return _bookAcCode; }
        set { _bookAcCode = value; }
    }
    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }
    private int _quantity;
    public int Quantity
    {
        get { return _quantity; }
        set { _quantity = value; }
    }

    private string _bookID;
    public string BookID
    {
        get { return _bookID; }
        set { _bookID = value; }
    }

    private string _edition;
    public string Edition
    {
        get { return _edition; }
        set { _edition = value; }
    }

    private DateTime _printdate;
    public DateTime Printdate
    {
        get { return _printdate; }
        set { _printdate = value; }
    }

    private bool _isReprinted;
    public bool IsReprinted
    {
        get { return _isReprinted; }
        set { _isReprinted = value; }
    }

    private bool _isRebinding;
    public bool IsRebinding
    {
        get { return _isRebinding; }
        set { _isRebinding = value; }
    }
    private bool _isopeningstock;
    public bool IsOpeningStock
    {
        get { return _isopeningstock; }
        set { _isopeningstock = value; }
    }
    private decimal _price;
    public decimal Price
    {
        get { return _price; }
        set { _price = value; }
    }
 private decimal _bonus;
 public decimal Bonus
    {
        get { return _bonus; }
        set { _bonus = value; }
    }
}

