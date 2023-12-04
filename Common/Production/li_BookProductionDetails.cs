using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookProductionDetails
{
    public Li_BookProductionDetails()
    {
    }

    public Li_BookProductionDetails
        (
         string bookCode, 
        string bookID, 
        string edition, 
        int bookQty, 
        DateTime createdDate, 
        int createdBy, 
        string coverColor, 
        string innerColor, 
        string formaColor, 
        string bookForma, 
        string bookSize, 
        string coverPaperType, 
        string coverPaperSize, 
        string coverPaperWeight, 
        string coverPaperManufacturer, 
        string innerPaperType, 
        string innerPaperSize, 
        string innerPaperWeight, 
        string innerPaperManufacturer, 
        string formaPaperType, 
        string formaPaperSize, 
        string formaPaperWeight, 
        string formaPaperManufacturer, 
        string linationType, 
        string bindingType, 
        bool isCreasing ,
        string innerPageQty
         
        )
    {
         this.BookCode = bookCode;
        this.BookID = bookID;
        this.Edition = edition;
        this.BookQty = bookQty;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.CoverColor = coverColor;
        this.InnerColor = innerColor;
        this.FormaColor = formaColor;
        this.BookForma = bookForma;
        this.BookSize = bookSize;
        this.CoverPaperType = coverPaperType;
        this.CoverPaperSize = coverPaperSize;
        this.CoverPaperWeight = coverPaperWeight;
        this.CoverPaperManufacturer = coverPaperManufacturer;
        this.InnerPaperType = innerPaperType;
        this.InnerPaperSize = innerPaperSize;
        this.InnerPaperWeight = innerPaperWeight;
        this.InnerPaperManufacturer = innerPaperManufacturer;
        this.FormaPaperType = formaPaperType;
        this.FormaPaperSize = formaPaperSize;
        this.FormaPaperWeight = formaPaperWeight;
        this.FormaPaperManufacturer = formaPaperManufacturer;
        this.LinationType = linationType;
        this.BindingType = bindingType;
        this.IsCreasing = isCreasing;
        this.InnerPageQty = innerPageQty;
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

    private string _edition;
    public string Edition
    {
        get { return _edition; }
        set { _edition = value; }
    }

    private int _bookQty;
    public int BookQty
    {
        get { return _bookQty; }
        set { _bookQty = value; }
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

    private string _coverColor;
    public string CoverColor
    {
        get { return _coverColor; }
        set { _coverColor = value; }
    }

    private string _innerColor;
    public string InnerColor
    {
        get { return _innerColor; }
        set { _innerColor = value; }
    }

    private string _formaColor;
    public string FormaColor
    {
        get { return _formaColor; }
        set { _formaColor = value; }
    }

    private string _bookForma;
    public string BookForma
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

    private string _coverPaperType;
    public string CoverPaperType
    {
        get { return _coverPaperType; }
        set { _coverPaperType = value; }
    }

    private string _coverPaperSize;
    public string CoverPaperSize
    {
        get { return _coverPaperSize; }
        set { _coverPaperSize = value; }
    }

    private string _coverPaperWeight;
    public string CoverPaperWeight
    {
        get { return _coverPaperWeight; }
        set { _coverPaperWeight = value; }
    }

    private string _coverPaperManufacturer;
    public string CoverPaperManufacturer
    {
        get { return _coverPaperManufacturer; }
        set { _coverPaperManufacturer = value; }
    }

    private string _innerPaperType;
    public string InnerPaperType
    {
        get { return _innerPaperType; }
        set { _innerPaperType = value; }
    }

    private string _innerPaperSize;
    public string InnerPaperSize
    {
        get { return _innerPaperSize; }
        set { _innerPaperSize = value; }
    }

    private string _innerPaperWeight;
    public string InnerPaperWeight
    {
        get { return _innerPaperWeight; }
        set { _innerPaperWeight = value; }
    }

    private string _innerPaperManufacturer;
    public string InnerPaperManufacturer
    {
        get { return _innerPaperManufacturer; }
        set { _innerPaperManufacturer = value; }
    }

    private string _formaPaperType;
    public string FormaPaperType
    {
        get { return _formaPaperType; }
        set { _formaPaperType = value; }
    }

    private string _formaPaperSize;
    public string FormaPaperSize
    {
        get { return _formaPaperSize; }
        set { _formaPaperSize = value; }
    }

    private string _formaPaperWeight;
    public string FormaPaperWeight
    {
        get { return _formaPaperWeight; }
        set { _formaPaperWeight = value; }
    }

    private string _formaPaperManufacturer;
    public string FormaPaperManufacturer
    {
        get { return _formaPaperManufacturer; }
        set { _formaPaperManufacturer = value; }
    }

    private string _linationType;
    public string LinationType
    {
        get { return _linationType; }
        set { _linationType = value; }
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

    private string _innerPageQty;
    public string InnerPageQty
    {
        get { return _innerPageQty; }
        set { _innerPageQty = value; }
    }
  
}
