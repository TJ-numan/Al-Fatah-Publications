using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_InnerFormaPrinting
{
    public Li_InnerFormaPrinting()
    {
    }

    public Li_InnerFormaPrinting
        (
        
        string orderNo, 
        string pressID, 
        string bookCode, 
        string bookSize, 
        string formaDetail, 
        decimal formaNo, 
        string formaColour, 
        string paperSizeID, 
        string paperTypeID, 
        string paperBrandID, 
        string paperGSMID, 
        bool is1stPrint, 
        bool is2ndPrint, 
        bool is3rdPrint, 
        bool is4thPrint, 
        bool is5thPrint, 
        decimal printQty, 
        string paperType, 
        decimal paperQty, 
        decimal printUnitPrice, 
        decimal printTotalPrice, 
        string paperMUnit, 
        DateTime orderDate, 
        string remark, 
        DateTime createdDate, 
        int createdBy, 
        DateTime modifiedDate, 
        int modifiedBy, 
        bool isForma 
         
        )
    {
       
        this.OrderNo = orderNo;
        this.PressID = pressID;
        this.BookCode = bookCode;
        this.BookSize = bookSize;
        this.FormaDetail = formaDetail;
        this.FormaNo = formaNo;
        this.FormaColour = formaColour;
        this.PaperSizeID = paperSizeID;
        this.PaperTypeID = paperTypeID;
        this.PaperBrandID = paperBrandID;
        this.PaperGSMID = paperGSMID;
        this.Is1stPrint = is1stPrint;
        this.Is2ndPrint = is2ndPrint;
        this.Is3rdPrint = is3rdPrint;
        this.Is4thPrint = is4thPrint;
        this.Is5thPrint = is5thPrint;
        this.PrintQty = printQty;
        this.PaperType = paperType;
        this.PaperQty = paperQty;
        this.PrintUnitPrice = printUnitPrice;
        this.PrintTotalPrice = printTotalPrice;
        this.PaperMUnit = paperMUnit;
        this.OrderDate = orderDate;
        this.Remark = remark;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.ModifiedDate = modifiedDate;
        this.ModifiedBy = modifiedBy;
        this.IsForma = isForma;
        
    }


     

    private string _orderNo;
    public string OrderNo
    {
        get { return _orderNo; }
        set { _orderNo = value; }
    }

    private string _pressID;
    public string PressID
    {
        get { return _pressID; }
        set { _pressID = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private string _bookSize;
    public string BookSize
    {
        get { return _bookSize; }
        set { _bookSize = value; }
    }

    private string _formaDetail;
    public string FormaDetail
    {
        get { return _formaDetail; }
        set { _formaDetail = value; }
    }

    private decimal _formaNo;
    public decimal FormaNo
    {
        get { return _formaNo; }
        set { _formaNo = value; }
    }

    private string _formaColour;
    public string FormaColour
    {
        get { return _formaColour; }
        set { _formaColour = value; }
    }

    private string _paperSizeID;
    public string PaperSizeID
    {
        get { return _paperSizeID; }
        set { _paperSizeID = value; }
    }

    private string _paperTypeID;
    public string PaperTypeID
    {
        get { return _paperTypeID; }
        set { _paperTypeID = value; }
    }

    private string _paperBrandID;
    public string PaperBrandID
    {
        get { return _paperBrandID; }
        set { _paperBrandID = value; }
    }

    private string _paperGSMID;
    public string PaperGSMID
    {
        get { return _paperGSMID; }
        set { _paperGSMID = value; }
    }

    private bool _is1stPrint;
    public bool Is1stPrint
    {
        get { return _is1stPrint; }
        set { _is1stPrint = value; }
    }

    private bool _is2ndPrint;
    public bool Is2ndPrint
    {
        get { return _is2ndPrint; }
        set { _is2ndPrint = value; }
    }

    private bool _is3rdPrint;
    public bool Is3rdPrint
    {
        get { return _is3rdPrint; }
        set { _is3rdPrint = value; }
    }

    private bool _is4thPrint;
    public bool Is4thPrint
    {
        get { return _is4thPrint; }
        set { _is4thPrint = value; }
    }

    private bool _is5thPrint;
    public bool Is5thPrint
    {
        get { return _is5thPrint; }
        set { _is5thPrint = value; }
    }

    private decimal _printQty;
    public decimal PrintQty
    {
        get { return _printQty; }
        set { _printQty = value; }
    }

    private string _paperType;
    public string PaperType
    {
        get { return _paperType; }
        set { _paperType = value; }
    }

    private decimal _paperQty;
    public decimal PaperQty
    {
        get { return _paperQty; }
        set { _paperQty = value; }
    }

    private decimal _printUnitPrice;
    public decimal PrintUnitPrice
    {
        get { return _printUnitPrice; }
        set { _printUnitPrice = value; }
    }

    private decimal _printTotalPrice;
    public decimal PrintTotalPrice
    {
        get { return _printTotalPrice; }
        set { _printTotalPrice = value; }
    }

    private string _paperMUnit;
    public string PaperMUnit
    {
        get { return _paperMUnit; }
        set { _paperMUnit = value; }
    }

    private DateTime _orderDate;
    public DateTime OrderDate
    {
        get { return _orderDate; }
        set { _orderDate = value; }
    }

    private string _remark;
    public string Remark
    {
        get { return _remark; }
        set { _remark = value; }
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

    private DateTime _modifiedDate;
    public DateTime ModifiedDate
    {
        get { return _modifiedDate; }
        set { _modifiedDate = value; }
    }

    private int _modifiedBy;
    public int ModifiedBy
    {
        get { return _modifiedBy; }
        set { _modifiedBy = value; }
    }

    private bool _isForma;
    public bool IsForma
    {
        get { return _isForma; }
        set { _isForma = value; }
    }

   
 
}
