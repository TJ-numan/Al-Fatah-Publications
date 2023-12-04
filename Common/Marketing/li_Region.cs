using System;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_Region
{
    public li_Region()
    {
    }
    public li_Region
        ( 
        int regionID,
        string regionName,
        int createdBy,
        DateTime createdDate,
        int modifiedBy,
        DateTime modifiedDate,
        string region_Bn
        )
    {
        
        this.RegionID = regionID;
        this.RegionName = regionName;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.Region_Bn = region_Bn;


    }




 
    private int _regionID;
    public int RegionID
    {
        get { return _regionID; }
        set { _regionID = value; }
    }

    private string _regionName;
    public string RegionName
    {
        get { return _regionName; }
        set { _regionName = value; }
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

    private string _region_Bn;
    public string Region_Bn
    {
        get { return _region_Bn; }
        set { _region_Bn = value; }
    }
     
    
}

