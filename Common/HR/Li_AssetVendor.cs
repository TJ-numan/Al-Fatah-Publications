using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_AssetVendor
{
    public Li_AssetVendor()
    {
    }

    public Li_AssetVendor
        (
       
        int assetVenId, 
        string vendorName, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
       
        this.AssetVenId = assetVenId;
        this.VendorName = vendorName;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _assetVenId;
    public int AssetVenId
    {
        get { return _assetVenId; }
        set { _assetVenId = value; }
    }

    private string _vendorName;
    public string VendorName
    {
        get { return _vendorName; }
        set { _vendorName = value; }
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
