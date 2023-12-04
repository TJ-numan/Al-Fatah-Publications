using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_ProductionBookDetails
{
    public Li_ProductionBookDetails()
    {
    }

    public Li_ProductionBookDetails
        (
         
        string bookCode, 
        string bookID, 
        int printQty, 
        decimal bookForma, 
        string bookSize, 
        string eddition, 
        DateTime createdDate, 
        DateTime printDate, 
        int createdBy, 
        string leminationType, 
        string bindingType, 
        bool isCreasing 
         
        )
    {
         
        this.BookCode = bookCode;
        this.BookID = bookID;
        this.PrintQty = printQty;
        this.BookForma = bookForma;
        this.BookSize = bookSize;
        this.Eddition = eddition;
        this.CreatedDate = createdDate;
        this.PrintDate = printDate;
        this.CreatedBy = createdBy;
        this.LeminationType = leminationType;
        this.BindingType = bindingType;
        this.IsCreasing = isCreasing;
         
    }


    

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private string _bookID;
    public string BookID
    {
        get { return _bookID; }
        set { _bookID = value; }
    }

    private int _printQty;
    public int PrintQty
    {
        get { return _printQty; }
        set { _printQty = value; }
    }

    private decimal _bookForma;
    public decimal BookForma
    {
        get { return _bookForma; }
        set { _bookForma = value; }
    }

    private string _bookSize;
    public string BookSize
    {
        get { return _bookSize; }
        set { _bookSize = value; }
    }

    private string _eddition;
    public string Eddition
    {
        get { return _eddition; }
        set { _eddition = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private DateTime _printDate;
    public DateTime PrintDate
    {
        get { return _printDate; }
        set { _printDate = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private string _leminationType;
    public string LeminationType
    {
        get { return _leminationType; }
        set { _leminationType = value; }
    }

    private string _bindingType;
    public string BindingType
    {
        get { return _bindingType; }
        set { _bindingType = value; }
    }

    private bool _isCreasing;
    public bool IsCreasing
    {
        get { return _isCreasing; }
        set { _isCreasing = value; }
    }

     
}
