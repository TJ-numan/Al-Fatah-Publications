using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BindOrder
{
    public Li_BindOrder()
    {
    }

    public Li_BindOrder
        (
        
        string bindCode, 
        string pressID, 
        string binderID, 
        string bookCode, 
        bool iscover, 
        bool inInner, 
        bool isNew, 
        bool isRb, 
        int qty, 
        string workType, 
        int createdBy, 
        DateTime createdDate, 
        bool isForma,
        decimal formaQty,
        bool inInnerForma ,
        string printOrder,
        string edition
         
        )
    {
         
        this.BindCode = bindCode;
        this.PressID = pressID;
        this.BinderID = binderID;
        this.BookCode = bookCode;
        this.Iscover = iscover;
        this.InInner = inInner;
        this.IsNew = isNew;
        this.IsRb = isRb;
        this.Qty = qty;
        this.WorkType = workType;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.IsForma = isForma;
        this.FormaQty = formaQty;
        this.IsInnerForma = inInnerForma;
        this.PrintOrder = printOrder;
        this.Edition = edition;

        
    }
    private string _edition;
    public string Edition
    {
        get { return _edition ; }
        set { _edition = value; }
    }

    private decimal  _formaQty;
    public decimal FormaQty
    {
        get { return _formaQty; }
        set { _formaQty = value; }
    }
 
    private string _bindCode;
    public string BindCode
    {
        get { return _bindCode; }
        set { _bindCode = value; }
    }
    private string _printOrder;
    public string PrintOrder
    {
        get { return _printOrder; }
        set { _printOrder = value; }
    }
    private string _pressID;
    public string PressID
    {
        get { return _pressID; }
        set { _pressID = value; }
    }

    private string _binderID;
    public string BinderID
    {
        get { return _binderID; }
        set { _binderID = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private bool _iscover;
    public bool Iscover
    {
        get { return _iscover; }
        set { _iscover = value; }
    }

    private bool _inInner;
    public bool InInner
    {
        get { return _inInner; }
        set { _inInner = value; }
    }


    private bool _inInnerForma;
    public bool IsInnerForma
    {
        get { return _inInnerForma; }
        set { _inInnerForma = value; }
    }


    private bool _isNew;
    public bool IsNew
    {
        get { return _isNew; }
        set { _isNew = value; }
    }

    private bool _isRb;
    public bool IsRb
    {
        get { return _isRb; }
        set { _isRb = value; }
    }

    private int _qty;
    public int Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

    private string _workType;
    public string WorkType
    {
        get { return _workType; }
        set { _workType = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private bool _isForma;
    public bool IsForma
    {
        get { return _isForma; }
        set { _isForma = value; }
    }

    
}
