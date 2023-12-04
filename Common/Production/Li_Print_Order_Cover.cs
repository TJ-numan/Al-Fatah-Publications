using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Print_Order_Cover
{
    public Li_Print_Order_Cover()
    {
    }

    public Li_Print_Order_Cover
        (
        
        string print_OrderNo, 
        DateTime orderDate, 
        string bookCode, 
        string pressID, 
        int printQty, 
        int printSl, 
        decimal formaTotal, 
        string paperType, 
        string paperSize,
        string paperGsm,
        string brandID, 
        int sett_Sheet, 
        decimal app_Paper, 
        decimal  pcs_Sheet, 
        decimal  totalPcs, 
        int total_Impress, 
        int total_Cover, 
        decimal totalBill, 
        string remark, 
        int createdBy, 
        DateTime createdDate, 
        int deleBy, 
        DateTime deleDate, 
        string causeOfDel, 
        bool shortForma, 
        bool otherPrint ,
        string edition
         
         
        )
    {
         
        this.Print_OrderNo = print_OrderNo;
        this.OrderDate = orderDate;
        this.BookCode = bookCode;
        this.PressID = pressID;
        this.PrintQty = printQty;
        this.PrintSl = printSl;
        this.FormaTotal = formaTotal;
        this.PaperType  = paperType ;
        this.PaperSize = paperSize;
        this.PaperGsm = paperGsm;
        this.BrandID = brandID;
        this.Sett_Sheet = sett_Sheet;
        this.App_Paper = app_Paper;
        this.Pcs_Sheet = pcs_Sheet;
        this.TotalPcs = totalPcs;
        this.Total_Impress = total_Impress;
        this.Total_Cover = total_Cover;
        this.TotalBill = totalBill;
        this.Remark = remark;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.DeleBy = deleBy;
        this.DeleDate = deleDate;
        this.CauseOfDel = causeOfDel;
        this.ShortForma = shortForma;
        this.OtherPrint = otherPrint;
        this.Edition = edition;
    }

    public string Edition { get; set; }

    private string _print_OrderNo;
    public string Print_OrderNo
    {
        get { return _print_OrderNo; }
        set { _print_OrderNo = value; }
    }

    private DateTime _orderDate;
    public DateTime OrderDate
    {
        get { return _orderDate; }
        set { _orderDate = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private string _pressID;
    public string PressID
    {
        get { return _pressID; }
        set { _pressID = value; }
    }

    private int _printQty;
    public int PrintQty
    {
        get { return _printQty; }
        set { _printQty = value; }
    }

    private int _printSl;
    public int PrintSl
    {
        get { return _printSl; }
        set { _printSl = value; }
    }

    private decimal _formaTotal;
    public decimal FormaTotal
    {
        get { return _formaTotal; }
        set { _formaTotal = value; }
    }

    private string _paperType;
    public string PaperType
    {
        get { return _paperType; }
        set { _paperType = value; }
    }

    private string _paperSize;
    public string PaperSize
    {
        get { return _paperSize; }
        set { _paperSize = value; }
    }

    private string _paperGsm;
    public string PaperGsm
    {
        get { return _paperGsm; }
        set { _paperGsm = value; }
    }  
    
    
    private string _brandID;
    public string BrandID
    {
        get { return _brandID; }
        set { _brandID = value; }
    }

    private int _sett_Sheet;
    public int Sett_Sheet
    {
        get { return _sett_Sheet; }
        set { _sett_Sheet = value; }
    }

    private decimal _app_Paper;
    public decimal App_Paper
    {
        get { return _app_Paper; }
        set { _app_Paper = value; }
    }

    private decimal  _pcs_Sheet;
    public decimal  Pcs_Sheet
    {
        get { return _pcs_Sheet; }
        set { _pcs_Sheet = value; }
    }

    private decimal  _totalPcs;
    public decimal  TotalPcs
    {
        get { return _totalPcs; }
        set { _totalPcs = value; }
    }

    private int _total_Impress;
    public int Total_Impress
    {
        get { return _total_Impress; }
        set { _total_Impress = value; }
    }

    private int _total_Cover;
    public int Total_Cover
    {
        get { return _total_Cover; }
        set { _total_Cover = value; }
    }

    private decimal _totalBill;
    public decimal TotalBill
    {
        get { return _totalBill; }
        set { _totalBill = value; }
    }

    private string _remark;
    public string Remark
    {
        get { return _remark; }
        set { _remark = value; }
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

    private int _deleBy;
    public int DeleBy
    {
        get { return _deleBy; }
        set { _deleBy = value; }
    }

    private DateTime _deleDate;
    public DateTime DeleDate
    {
        get { return _deleDate; }
        set { _deleDate = value; }
    }

    private string _causeOfDel;
    public string CauseOfDel
    {
        get { return _causeOfDel; }
        set { _causeOfDel = value; }
    }

    private bool _shortForma;
    public bool ShortForma
    {
        get { return _shortForma; }
        set { _shortForma = value; }
    }

    private bool _otherPrint;
    public bool OtherPrint
    {
        get { return _otherPrint; }
        set { _otherPrint = value; }
    }

   

     
}
