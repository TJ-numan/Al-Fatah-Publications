using System;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_Area
{
    public li_Area()
    {
    }


    public li_Area
        (
        int areaID,
        string areaName,
        int regionID,
        int createdBy,
        DateTime createdDate,
        int modifiedBy,
        DateTime modifiedDate,
        string area_Bn

        )

    {
        this.AreaID = areaID;
        this.AreaName = areaName;
        this.RegionID = regionID;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.Area_Bn = area_Bn;


    }

    public li_Area
    (
        int areaID,
        string areaName

    )
    {
        this.AreaID = areaID;
        this.AreaName = areaName;

    }


    private int _areaID;
    public int AreaID
    {
        get { return _areaID; }
        set { _areaID = value; }
    }

    private string _areaName;
    public string AreaName
    {
        get { return _areaName; }
        set { _areaName = value; }
    }

    private int _regionID;
    public int RegionID
    {
        get { return _regionID; }
        set { _regionID = value; }
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

    private string _area_Bn;
    public string Area_Bn
    {
        get { return _area_Bn; }
        set { _area_Bn = value; }
    }


}

