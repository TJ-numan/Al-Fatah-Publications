using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_AssetBrand
{
    public Li_AssetBrand()
    {
    }

    public Li_AssetBrand
        (
        
        int brandId, 
        string brandName, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
    
        this.BrandId = brandId;
        this.BrandName = brandName;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _brandId;
    public int BrandId
    {
        get { return _brandId; }
        set { _brandId = value; }
    }

    private string _brandName;
    public string BrandName
    {
        get { return _brandName; }
        set { _brandName = value; }
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
