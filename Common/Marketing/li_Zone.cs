using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Zone
{
    public Li_Zone()
    {
    }

    public Li_Zone
        (
       
        int zonID, 
        string zonName, 
        int divID, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        string zon_Bn ,
        string divName
         
        )
    {
      
        this.ZonID = zonID;
        this.ZonName = zonName;
        this.DivID = divID;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.Zon_Bn = zon_Bn;
        this.DivName = divName;
    }
    public string DivName { get; set; }

 
    private int _zonID;
    public int ZonID
    {
        get { return _zonID; }
        set { _zonID = value; }
    }

    private string _zonName;
    public string ZonName
    {
        get { return _zonName; }
        set { _zonName = value; }
    }

    private int _divID;
    public int DivID
    {
        get { return _divID; }
        set { _divID = value; }
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

    private string _zon_Bn;
    public string Zon_Bn
    {
        get { return _zon_Bn; }
        set { _zon_Bn = value; }
    }
 
}
