using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Print_Order_Forma
{
    public Li_Print_Order_Forma()
    {
    }

    public Li_Print_Order_Forma
        (
        
        string print_OrderNo, 
        DateTime orderDate, 
        string bookID, 
        string edition, 
        int printQty, 
        int printSl, 
        decimal formaTotal, 
        decimal totalBill, 
        string remark, 
        int createdBy, 
        DateTime createdDate, 
        char status_D, 
        int deleBy, 
        DateTime deleDate, 
        string causeOfDel ,
        string p_Type,
        bool sPrint,
        bool oPrint
         
        )
    {
  
        this.Print_OrderNo = print_OrderNo;
        this.OrderDate = orderDate;
        this.BookID = bookID;
        this.Edition = edition;
        this.PrintQty = printQty;
        this.PrintSl = printSl;
        this.FormaTotal = formaTotal;
        this.TotalBill = totalBill;
        this.Remark = remark;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.Status_D = status_D;
        this.DeleBy = deleBy;
        this.DeleDate = deleDate;
        this.CauseOfDel = causeOfDel;
        this.P_Type = p_Type;
        this.S_Print = sPrint;
        this.O_Print = O_Print;

    }



    public bool S_Print { get; set; }

    public bool O_Print { get; set; }


 
    public string P_Type { get; set; }




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

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
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

     
}
