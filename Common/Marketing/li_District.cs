using System;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_District
{
    public li_District()
    {
    }


    public li_District
        (

        int districtID, 
        string districtName,        
        DateTime createdDate, 
        string createdBy, 
        string modifiedBy, 
        DateTime modefiedDate, 
        string district_Bn  


        )

    {
        this.DistrictID = districtID;
        this.DistrictName = districtName;
     
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.ModifiedBy = modifiedBy;
        this.ModefiedDate = modefiedDate;
        this.District_Bn = district_Bn;

    }

    public string District_Bn { get; set; }

    public li_District(int districtID,
     string districtName)
    {
        this.DistrictID = districtID;
        this.DistrictName = districtName;
    }


    private int  _districtID;
    public int  DistrictID
    {
        get { return _districtID; }
        set { _districtID = value; }
    }

    private string  _districtName;
    public string  DistrictName
    {
        get { return _districtName; }
        set { _districtName = value; }
    }


    private DateTime  _createdDate;
    public DateTime  CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private string  _createdBy;
    public string  CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private string  _modifiedBy;
    public string  ModifiedBy
    {
        get { return _modifiedBy; }
        set { _modifiedBy = value; }
    }

    private DateTime  _modefiedDate;
    public DateTime  ModefiedDate
    {
        get { return _modefiedDate; }
        set { _modefiedDate = value; }
    }

}

