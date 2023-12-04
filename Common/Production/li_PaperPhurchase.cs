using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PaperPhurchase
{
    public Li_PaperPhurchase()
    {
    }

    public Li_PaperPhurchase
        (
         
        string orderNo, 
        DateTime orderDate, 
        string partyID, 
        string paperSize, 
        string paperType, 
        string paperBrand, 
        string paperOrigin, 
        string gSM, 
        decimal qty, 
        string mUint, 
        decimal unitPrice, 
        decimal total, 
        string remark, 
          
        int createdBy, 
        DateTime createdDate ,

        decimal roll,

        string pur_Ref_no
         
        )
    {
         this.OrderNo = orderNo;
        this.OrderDate = orderDate;
        this.PartyID = partyID;
        this.PaperSize = paperSize;
        this.PaperType = paperType;
        this.PaperBrand = paperBrand;
        this.PaperOrigin = paperOrigin;
        this.GSM = gSM;
        this.Qty = qty;
        this.MUint = mUint;
        this.UnitPrice = unitPrice;
        this.Total = total;
        this.Remark = remark;
         
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.Roll = roll;
        this.Purchase_OrderNo = pur_Ref_no;
    }


    public string Purchase_OrderNo { get; set; }

    private string _orderNo;
    public string OrderNo
    {
        get { return _orderNo; }
        set { _orderNo = value; }
    }

    private DateTime _orderDate;
    public DateTime OrderDate
    {
        get { return _orderDate; }
        set { _orderDate = value; }
    }

    private string _partyID;
    public string PartyID
    {
        get { return _partyID; }
        set { _partyID = value; }
    }

    private string _paperSize;
    public string PaperSize
    {
        get { return _paperSize; }
        set { _paperSize = value; }
    }

    private string _paperType;
    public string PaperType
    {
        get { return _paperType; }
        set { _paperType = value; }
    }

    private string _paperBrand;
    public string PaperBrand
    {
        get { return _paperBrand; }
        set { _paperBrand = value; }
    }

    private string _paperOrigin;
    public string PaperOrigin
    {
        get { return _paperOrigin; }
        set { _paperOrigin = value; }
    }

    private string _gSM;
    public string GSM
    {
        get { return _gSM; }
        set { _gSM = value; }
    }

    private decimal _qty;
    public decimal Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

    private string _mUint;
    public string MUint
    {
        get { return _mUint; }
        set { _mUint = value; }
    }

    private decimal _unitPrice;
    public decimal UnitPrice
    {
        get { return _unitPrice; }
        set { _unitPrice = value; }
    }


    private decimal _roll;
    public decimal Roll
    {
        get { return _roll; }
        set { _roll = value; }
    }


    private decimal _total;
    public decimal Total
    {
        get { return _total; }
        set { _total = value; }
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

    
}
