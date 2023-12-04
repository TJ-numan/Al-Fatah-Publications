using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_SalesPerson
{
    public Li_SalesPerson()
    {
    }


    

    public Li_SalesPerson
        (
         
        string tSOID,
        string employeeCode,
        string name, 
        string mobile, 
        string emailid,
        string address,
        string transportID,
        string transportID2,
        int regionID, 
        int areaID, 
        string teritoryID, 
        string thanaID,
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate 
         
        )
    {
       
        this.TSOID = tSOID;
        this.EmployeeCode = employeeCode;
        this.Name = name;
        this.Mobile = mobile;
        this.EmailID = emailid;
        this.Address = address;
        this.TransportID = transportID;
        this.TransportID2 = transportID2;
        this.RegionID = regionID;
        this.AreaID = areaID;
        this.TeritoryID = teritoryID;
        this.ThanaID = thanaID;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
       
    }
  //-----------------------Rezaul Hossain--------------------------
    //public Li_SalesPerson(string TSOID, string Name)
    //{
    //    // TODO: Complete member initialization
    //    this.TSOID = TSOID;
    //    this.Name = Name;
    //}

    //---------------------End Rezaul Hossain----------------------
   

    private string _tSOID;
    public string TSOID
    {
        get { return _tSOID; }
        set { _tSOID = value; }
    }
    private string _employeeCode;
    public string EmployeeCode
    {
        get { return _employeeCode; }
        set { _employeeCode = value; }
    }

    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    private string _mobile;
    public string Mobile
    {
        get { return _mobile; }
        set { _mobile = value; }
    }
    private string _emailid;
    public string EmailID
    {
        get { return _emailid; }
        set { _emailid = value; }
    }
    private string _address;
    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }

    private string _transportID;
    public string TransportID
    {
        get { return _transportID; }
        set { _transportID = value; }
    }

    private string _transportID2;
    public string TransportID2
    {
        get { return _transportID2; }
        set { _transportID2 = value; }
    }
    private int _regionID;
    public int RegionID
    {
        get { return _regionID; }
        set { _regionID = value; }
    }

    private int _areaID;
    public int AreaID
    {
        get { return _areaID; }
        set { _areaID = value; }
    }

    private string _teritoryID;
    public string TeritoryID
    {
        get { return _teritoryID; }
        set { _teritoryID = value; }
    }

    private string _thanaID;
    public string ThanaID
    {
        get { return _thanaID; }
        set { _thanaID = value; }
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
    private string p1;
    private string p2;
 
    public DateTime ModifiedDate
    {
        get { return _modifiedDate; }
        set { _modifiedDate = value; }
    }

    
}
