using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookTarget
{
    public Li_BookTarget()
    {
    }

    public Li_BookTarget
        (
       
        DateTime sDate, 
        DateTime eDate, 
        string territoryCode, 
        string tSOCode, 
        string bookCode, 
        decimal price, 
        decimal qty, 
        DateTime createdDate, 
        int createdBy ,
         string edition
        )
    {
 
        this.SDate = sDate;
        this.EDate = eDate;
        this.TerritoryCode = territoryCode;
        this.TSOCode = tSOCode;
        this.BookCode = bookCode;
        this.Price = price;
        this.Qty = qty;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.Edition = edition;
    }

    public string Edition { get; set; }
    
    private DateTime _sDate;
    public DateTime SDate
    {
        get { return _sDate; }
        set { _sDate = value; }
    }

    private DateTime _eDate;
    public DateTime EDate
    {
        get { return _eDate; }
        set { _eDate = value; }
    }

    private string _territoryCode;
    public string TerritoryCode
    {
        get { return _territoryCode; }
        set { _territoryCode = value; }
    }

    private string _tSOCode;
    public string TSOCode
    {
        get { return _tSOCode; }
        set { _tSOCode = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private decimal _price;
    public decimal Price
    {
        get { return _price; }
        set { _price = value; }
    }

    private decimal _qty;
    public decimal Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    
}
