using System;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_Stock
{
    public li_Stock()
    {
    }


    public li_Stock
        (
string  bookAcCode,
decimal  stockQuantity,
DateTime  entryDate

        )

    {
this.BookAcCode = bookAcCode;
this.StockQuantity = stockQuantity;
this.EntryDate = entryDate;

    }

    private string  _bookAcCode;
    public string  BookAcCode
    {
        get { return _bookAcCode; }
        set { _bookAcCode = value; }
    }

    private decimal  _stockQuantity;
    public decimal  StockQuantity
    {
        get { return _stockQuantity; }
        set { _stockQuantity = value; }
    }

    private DateTime  _entryDate;
    public DateTime  EntryDate
    {
        get { return _entryDate; }
        set { _entryDate = value; }
    }

}

