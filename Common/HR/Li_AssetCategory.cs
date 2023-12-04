using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_AssetCategory
{
    public Li_AssetCategory()
    {
    }

    public Li_AssetCategory
        (
        
        int assetCatId, 
        string category,
        string catePrefix,
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
       
        this.AssetCatId = assetCatId;
        this.Category = category;
        this.CatePrefix = catePrefix;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _assetCatId;
    public int AssetCatId
    {
        get { return _assetCatId; }
        set { _assetCatId = value; }
    }

    private string _category;
    public string Category
    {
        get { return _category; }
        set { _category = value; }
    }

    private string _catePrefix;
    public string CatePrefix
    {
        get { return _catePrefix; }
        set { _catePrefix = value; }
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
