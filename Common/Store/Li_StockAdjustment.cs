using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_StockAdjustment
{
    public Li_StockAdjustment()
    {
    }

    public Li_StockAdjustment
        (
 
        int iD, 
        string bookCode, 
        decimal curStock, 
        decimal physicalStock, 
        decimal adjustStock, 
        bool isCentral, 
        DateTime adjustDate, 
        DateTime createdDate, 
        int createdBy, 
        string verifiedBy 
        
         
        )
    {
         this.ID = iD;
        this.BookCode = bookCode;
        this.CurStock = curStock;
        this.PhysicalStock = physicalStock;
        this.AdjustStock = adjustStock;
        this.IsCentral = isCentral;
        this.AdjustDate = adjustDate;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.VerifiedBy = verifiedBy;
   
    }

 
    private int _iD;
    public int ID
    {
        get { return _iD; }
        set { _iD = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private decimal _curStock;
    public decimal CurStock
    {
        get { return _curStock; }
        set { _curStock = value; }
    }

    private decimal _physicalStock;
    public decimal PhysicalStock
    {
        get { return _physicalStock; }
        set { _physicalStock = value; }
    }

    private decimal _adjustStock;
    public decimal AdjustStock
    {
        get { return _adjustStock; }
        set { _adjustStock = value; }
    }

    private bool _isCentral;
    public bool IsCentral
    {
        get { return _isCentral; }
        set { _isCentral = value; }
    }

    private DateTime _adjustDate;
    public DateTime AdjustDate
    {
        get { return _adjustDate; }
        set { _adjustDate = value; }
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

    private string _verifiedBy;
    public string VerifiedBy
    {
        get { return _verifiedBy; }
        set { _verifiedBy = value; }
    }

    
 
}
