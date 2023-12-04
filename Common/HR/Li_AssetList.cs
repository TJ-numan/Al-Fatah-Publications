using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_AssetList
{
    public Li_AssetList()
    {
    }

    public Li_AssetList
        (
         
        int assetId, 
        string assetCode,
        string assetName, 
        string modelNo, 
        int brandId, 
        int assetCatId, 
        int assetVenId, 
        Decimal purchaseAmt,
        DateTime purchaseDate,
        DateTime warrantyPeriod,
        DateTime lifeTime,
        int depId,
        int employeID,
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
         
        this.AssetId = assetId;
        this.AssetCode = assetCode;
        this.AssetName = assetName;
        this.ModelNo = modelNo;
        this.BrandId = brandId;
        this.AssetCatId = assetCatId;
        this.AssetVenId = assetVenId;
        this.PurchaseAmt = purchaseAmt;
        this.PurchaseDate = purchaseDate;
        this.WarrantyPeriod = warrantyPeriod;
        this.Life_Time = lifeTime;
        this.DepId = depId;
        this.EmployeID = employeID;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }

    public string AssetCode { get; set; }

 
    private int _assetId;
    public int AssetId
    {
        get { return _assetId; }
        set { _assetId = value; }
    }

    private string _assetName;
    public string AssetName
    {
        get { return _assetName; }
        set { _assetName = value; }
    }

    private string _modelNo;
    public string ModelNo
    {
        get { return _modelNo; }
        set { _modelNo = value; }
    }

    private int _brandId;
    public int BrandId
    {
        get { return _brandId; }
        set { _brandId = value; }
    }

    private int _assetCatId;
    public int AssetCatId
    {
        get { return _assetCatId; }
        set { _assetCatId = value; }
    }

    private int _assetVenId;
    public int AssetVenId
    {
        get { return _assetVenId; }
        set { _assetVenId = value; }
    }

    private Decimal _purchaseAmt;
    public Decimal PurchaseAmt
    {
        get { return  _purchaseAmt; }
        set {   _purchaseAmt= value; }
    }

    private DateTime _purchaseDate;
    public DateTime PurchaseDate
    {
        get { return  _purchaseDate; }
        set {   _purchaseDate= value; }
    }

    private DateTime _warrantyPeriod;
    public DateTime WarrantyPeriod
    {
        get { return  _warrantyPeriod; }
        set {   _warrantyPeriod= value; }
    }

    private DateTime _lifeTime;
    public DateTime Life_Time
    {
        get { return  _lifeTime; }
        set {   _lifeTime= value; }
    }

    private int _depId;
    public int DepId
    {
        get { return _depId; }
        set { _depId = value; }
    }
    private int _employeID;
    public int EmployeID
    {
        get { return _employeID; }
        set { _employeID = value; }
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

    private int _modifiedBy;
    public int ModifiedBy
    {
        get { return _modifiedBy; }
        set { _modifiedBy = value; }
    }

    private DateTime _modifiedDate;
    public DateTime ModifiedDate
    {
        get { return _modifiedDate; }
        set { _modifiedDate = value; }
    }

    private int _infStId;
    public int InfStId
    {
        get { return _infStId; }
        set { _infStId = value; }
    }
}
