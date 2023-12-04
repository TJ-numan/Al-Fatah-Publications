using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PlateBrandBasic
{
    public Li_PlateBrandBasic()
    {
    }

    public Li_PlateBrandBasic
        (
        
        string iD, 
        string brandName, 
        int createdBy, 
        DateTime createdDate ,
        string plateSizeType
         
        )
    {
         
        this.ID = iD;
        this.BrandName = brandName;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.PlateSizeType = plateSizeType;
        
    }


    public string PlateSizeType { get; set; }

    private string _iD;
    public string ID
    {
        get { return _iD; }
        set { _iD = value; }
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

    
}
