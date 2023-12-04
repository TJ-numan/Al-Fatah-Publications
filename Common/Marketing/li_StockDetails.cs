using System;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_StockDetails
{
    public li_StockDetails()
    {
    }


    public li_StockDetails
        (
string  stockID,
string  bookAcCode,
int  quantity,
decimal  currentStock,
DateTime  stockEntryDate

        )

    {
this.StockID = stockID;
this.BookAcCode = bookAcCode;
this.Quantity = quantity;
this.CurrentStock = currentStock;
this.StockEntryDate = stockEntryDate;

    }

    private string  _stockID;
    public string  StockID
    {
        get { return _stockID; }
        set { _stockID = value; }
    }

    private string  _bookAcCode;
    public string  BookAcCode
    {
        get { return _bookAcCode; }
        set { _bookAcCode = value; }
    }

    private int  _quantity;
    public int  Quantity
    {
        get { return _quantity; }
        set { _quantity = value; }
    }

    private decimal  _currentStock;
    public decimal  CurrentStock
    {
        get { return _currentStock; }
        set { _currentStock = value; }
    }

    private DateTime  _stockEntryDate;
    public DateTime  StockEntryDate
    {
        get { return _stockEntryDate; }
        set { _stockEntryDate = value; }
    }

}

