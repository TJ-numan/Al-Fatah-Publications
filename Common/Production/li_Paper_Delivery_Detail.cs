using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Paper_Delivery_Detail
{
    public Li_Paper_Delivery_Detail()
    {
    }

    public Li_Paper_Delivery_Detail
        (
       
        int slNo, 
        string invID, 
        string pressID, 
        string pressRefNo, 
        DateTime deliveryDate, 
        string p_TS_ID, 
        string paperBrand, 
        string paperOrigin, 
        decimal unitPrice, 
        decimal qty, 
        DateTime createdDate, 
        int createdBy, 
        char status_D, 
        string typeID, 
        string sizeID, 
        string gSM ,
        string purchaseOrder,
        decimal rollQty
         
        )
    {
        
        this.SlNo = slNo;
        this.InvID = invID;
        this.PressID = pressID;
        this.PressRefNo = pressRefNo;
        this.DeliveryDate = deliveryDate;
        this.P_TS_ID = p_TS_ID;
        this.PaperBrand = paperBrand;
        this.PaperOrigin = paperOrigin;
        this.UnitPrice = unitPrice;
        this.Qty = qty;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.Status_D = status_D;
        this.TypeID = typeID;
        this.SizeID = sizeID;
        this.GSM = gSM;
        this.PurchaseOrder = purchaseOrder;
        this.RollQty = rollQty;
       
    }

    public decimal RollQty  { get; set; }
    public string PurchaseOrder { get; set; }
    

    private int _slNo;
    public int SlNo
    {
        get { return _slNo; }
        set { _slNo = value; }
    }

    private string _invID;
    public string InvID
    {
        get { return _invID; }
        set { _invID = value; }
    }

    private string _pressID;
    public string PressID
    {
        get { return _pressID; }
        set { _pressID = value; }
    }

    private string _pressRefNo;
    public string PressRefNo
    {
        get { return _pressRefNo; }
        set { _pressRefNo = value; }
    }

    private DateTime _deliveryDate;
    public DateTime DeliveryDate
    {
        get { return _deliveryDate; }
        set { _deliveryDate = value; }
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

    private string _paperOrigin;
    public string PaperOrigin
    {
        get { return _paperOrigin; }
        set { _paperOrigin = value; }
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

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

    private string _typeID;
    public string TypeID
    {
        get { return _typeID; }
        set { _typeID = value; }
    }

    private string _sizeID;
    public string SizeID
    {
        get { return _sizeID; }
        set { _sizeID = value; }
    }

    private string _gSM;
    public string GSM
    {
        get { return _gSM; }
        set { _gSM = value; }
    }

     
}
