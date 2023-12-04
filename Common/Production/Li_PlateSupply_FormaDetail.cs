using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PlateSupply_FormaDetail
{
    public Li_PlateSupply_FormaDetail()
    {
    }

    public Li_PlateSupply_FormaDetail
        (
        
        int slNo, 
        string plate_SID, 
        string presID, 
        string plateTypeID, 
        string plateSizeID, 
        decimal plateQty, 
        int plateGivenType, 
        decimal plateBillRate, 
        int processGivenType, 
        decimal processBillRate, 
         decimal totalAmount 
         
        )
    {
         
        this.SlNo = slNo;
        this.Plate_SID = plate_SID;
        this.PresID = presID;
        this.PlateTypeID = plateTypeID;
        this.PlateSizeID = plateSizeID;
        this.PlateQty = plateQty;
        this.PlateGivenType = plateGivenType;
        this.PlateBillRate = plateBillRate;
        this.ProcessGivenType = processGivenType;
        this.ProcessBillRate = processBillRate;
        this.TotalAmount = totalAmount;
         
    }


    

    private int _slNo;
    public int SlNo
    {
        get { return _slNo; }
        set { _slNo = value; }
    }

    private string _plate_SID;
    public string Plate_SID
    {
        get { return _plate_SID; }
        set { _plate_SID = value; }
    }

    private string _presID;
    public string PresID
    {
        get { return _presID; }
        set { _presID = value; }
    }

    private string _plateTypeID;
    public string PlateTypeID
    {
        get { return _plateTypeID; }
        set { _plateTypeID = value; }
    }

    private string _plateSizeID;
    public string PlateSizeID
    {
        get { return _plateSizeID; }
        set { _plateSizeID = value; }
    }

    private decimal _plateQty;
    public decimal PlateQty
    {
        get { return _plateQty; }
        set { _plateQty = value; }
    }

    private int _plateGivenType;
    public int PlateGivenType
    {
        get { return _plateGivenType; }
        set { _plateGivenType = value; }
    }

    private decimal _plateBillRate;
    public decimal PlateBillRate
    {
        get { return _plateBillRate; }
        set { _plateBillRate = value; }
    }

    private int _processGivenType;
    public int ProcessGivenType
    {
        get { return _processGivenType; }
        set { _processGivenType = value; }
    }

    private decimal _processBillRate;
    public decimal ProcessBillRate
    {
        get { return _processBillRate; }
        set { _processBillRate = value; }
    }

    private  decimal _totalAmount;
    public  decimal TotalAmount
    {
        get { return _totalAmount; }
        set { _totalAmount = value; }
    }

    
}
