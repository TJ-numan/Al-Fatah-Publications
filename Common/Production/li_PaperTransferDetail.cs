using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PaperTransferDetail
{
    public Li_PaperTransferDetail()
    {
    }

    public Li_PaperTransferDetail
        (
    
        int slNo, 
        int transNo, 
        string p_TS_ID, 
        string paperBrand, 
        decimal unitPrice, 
        decimal qty, 
        decimal rollQty,  
        string paperType,
        string paperSize,
        string paperGSM,
        DateTime supplyDate,
        string receipt
         
        )
    {
        this.SlNo = slNo;
        this.TransNo = transNo;
        this.P_TS_ID = p_TS_ID;
        this.PaperBrand = paperBrand;
        this.UnitPrice = unitPrice;
        this.Qty = qty;
        this.RollQty = rollQty;
        this.PaperType = paperType;
        this.PaperSize = paperSize;
        this.PaperGSM = paperGSM;
        this.SupplyDate = supplyDate;
        this.Receipt = receipt;
    }
    public DateTime SupplyDate  { get; set; }

    public string  Receipt { get; set; }
    public string PaperType { get; set; }

    public string PaperSize { get; set; } 

    public string PaperGSM { get; set; } 



    private int _slNo;
    public int SlNo
    {
        get { return _slNo; }
        set { _slNo = value; }
    }

    private int _transNo;
    public int TransNo
    {
        get { return _transNo; }
        set { _transNo = value; }
    }

    private string _p_TS_ID;
    public string P_TS_ID
    {
        get { return _p_TS_ID; }
        set { _p_TS_ID = value; }
    }

    private string _paperBrand;
    public string PaperBrand
    {
        get { return _paperBrand; }
        set { _paperBrand = value; }
    }

    private decimal _unitPrice;
    public decimal UnitPrice
    {
        get { return _unitPrice; }
        set { _unitPrice = value; }
    }

    private decimal _qty;
    public decimal Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

    private decimal _rollQty;
    public decimal RollQty
    {
        get { return _rollQty; }
        set { _rollQty = value; }
    }

  
}
