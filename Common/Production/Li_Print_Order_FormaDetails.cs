using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Print_Order_FormaDetails
{
    public Li_Print_Order_FormaDetails()
    {
    }

    public Li_Print_Order_FormaDetails
        (
  
        string print_OrderNo, 
        string bookPart, 
        string pressID, 
        string p_TypeID, 
        string p_SizeID, 
        string p_GSMID, 
        string p_BrandID, 
       
        int colorNo, 
        decimal formaQty, 
        decimal billRate, 
        decimal app_Paper ,
        string formaDis,
        decimal totalBill,
        string paperNote,
        int pressPrintQty,
        bool side

         
        )
    {
 
        this.Print_OrderNo = print_OrderNo;
        this.BookPart = bookPart;
        this.PressID = pressID;
        this.P_TypeID = p_TypeID;
        this.P_SizeID = p_SizeID;
        this.P_GSMID = p_GSMID;
        this.P_BrandID = p_BrandID;
        
        this.ColorNo = colorNo;
        this.FormaQty = formaQty;
        this.BillRate = billRate;
        this.App_Paper = app_Paper;
        this.FormaDis = formaDis;
        this.TotalBill = totalBill ;
        this.PaperNote = paperNote;
        this.PressPrintQty = pressPrintQty;
        this.Side = side;
        
    }
    public bool Side { get; set; } 
  
    public int PressPrintQty { get; set; }

    public string PaperNote { get; set; }
    public decimal  TotalBill { get; set; }
    public string FormaDis { get; set; }
     
    private string _print_OrderNo;
    public string Print_OrderNo
    {
        get { return _print_OrderNo; }
        set { _print_OrderNo = value; }
    }

    private string _bookPart;
    public string BookPart
    {
        get { return _bookPart; }
        set { _bookPart = value; }
    }

    private string _pressID;
    public string PressID
    {
        get { return _pressID; }
        set { _pressID = value; }
    }

    private string _p_TypeID;
    public string P_TypeID
    {
        get { return _p_TypeID; }
        set { _p_TypeID = value; }
    }

    private string _p_SizeID;
    public string P_SizeID
    {
        get { return _p_SizeID; }
        set { _p_SizeID = value; }
    }

    private string _p_GSMID;
    public string P_GSMID
    {
        get { return _p_GSMID; }
        set { _p_GSMID = value; }
    }

    private string _p_BrandID;
    public string P_BrandID
    {
        get { return _p_BrandID; }
        set { _p_BrandID = value; }
    }

    

    private int _colorNo;
    public int ColorNo
    {
        get { return _colorNo; }
        set { _colorNo = value; }
    }

    private decimal _formaQty;
    public decimal FormaQty
    {
        get { return _formaQty; }
        set { _formaQty = value; }
    }

    private decimal _billRate;
    public decimal BillRate
    {
        get { return _billRate; }
        set { _billRate = value; }
    }

    private decimal _app_Paper;
    public decimal App_Paper
    {
        get { return _app_Paper; }
        set { _app_Paper = value; }
    }
 
}
