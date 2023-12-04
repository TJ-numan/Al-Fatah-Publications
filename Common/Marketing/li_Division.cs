using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Division
{
    public Li_Division()
    {
    }

    public Li_Division
        (
        
        int divID, 
        string divName, 
        int regionID, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        string div_Bn  ,
        string regionName
         
        )
    {
         
        this.DivID = divID;
        this.DivName = divName;
        this.RegionID = regionID;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.Div_Bn = div_Bn;
        this.RegionName = regionName;
    }

    public string RegionName { get; set; }

    private int _divID;
    public int DivID
    {
        get { return _divID; }
        set { _divID = value; }
    }

    private string _divName;
    public string DivName
    {
        get { return _divName; }
        set { _divName = value; }
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

    private string _div_Bn;
    public string Div_Bn
    {
        get { return _div_Bn; }
        set { _div_Bn = value; }
    }

   
}
