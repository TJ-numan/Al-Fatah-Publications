using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;

public class li_PlateTransferDetail
{ 

    public li_PlateTransferDetail()
    {
    }

    public li_PlateTransferDetail
        (
    
        int slNo, 
        int transNo, 
        string plateBrand, 
        decimal unitPrice, 
        decimal qty, 
        string plateType,
        string plateSize,
        DateTime supplyDate,
        string receipt
         
        )
    {
        this.SlNo = slNo;
        this.TransNo = transNo;
        this.PlateBrand = plateBrand;
        this.UnitPrice = unitPrice;
        this.Qty = qty;
        this.PlateType = plateType;
        this.PlateSize = plateSize;
        this.SupplyDate = supplyDate;
        this.Receipt = receipt;
    }
    public DateTime SupplyDate  { get; set; }

    public string  Receipt { get; set; }
    public string PlateType { get; set; }

    public string PlateSize { get; set; } 



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


    private string _plateBrand;
    public string PlateBrand
    {
        get { return _plateBrand; }
        set { _plateBrand = value; }
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


  
}
