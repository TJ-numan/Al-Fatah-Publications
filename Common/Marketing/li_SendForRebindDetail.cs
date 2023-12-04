using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_SendForRebindDetail
{
    public Li_SendForRebindDetail()
    {
    }

    public Li_SendForRebindDetail
        (


        string receiveID,
        string bookCode,
        int qty,
        decimal price,
        char status_D,
        string edition,
        bool fromCentral
         
        )
    {

        this.ReceiveID = receiveID;
        this.BookCode = bookCode;
        this.Qty = qty;
        this.Price = price;
        this.Status_D = status_D;
        this.Edition = edition;
        this.FromCentral = fromCentral; 
         
    }


    public string Edition { get; set; }

    public bool FromCentral { get; set; }

    

    private string _receiveID;
    public string ReceiveID
    {
        get { return _receiveID; }
        set { _receiveID = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private int _qty;
    public int Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

    private decimal _price;
    public decimal Price
    {
        get { return _price; }
        set { _price = value; }
    }

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

     
}
