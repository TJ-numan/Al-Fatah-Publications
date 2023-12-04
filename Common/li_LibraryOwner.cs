using System;
using System.Configuration;
using System.Data;
using System.Linq;



public class li_LibraryOwner
{
    public li_LibraryOwner()
    {
    }


    public li_LibraryOwner
        (
string  libraryOwnerID,
string  ownerName,
string  propitorMobile,
string  managerMobile,
string  probableFutueAgent,
int regionID,int teritoryID, int  areaID,int districtID,int thanaID

        )

    {
this.LibraryOwnerID = libraryOwnerID;
this.OwnerName = ownerName;
this.PropitorMobile = propitorMobile;
this.ManagerMobile = managerMobile;
this.ProbableFutueAgent = probableFutueAgent;
this.RegionID = regionID;
this.TeritoryID = teritoryID;
this.Area = areaID;
this.District = districtID;
this.Thana = thanaID;

    }

    private string  _libraryOwnerID;
    public string  LibraryOwnerID
    {
        get { return _libraryOwnerID; }
        set { _libraryOwnerID = value; }
    }

    private string  _ownerName;
    public string  OwnerName
    {
        get { return _ownerName; }
        set { _ownerName = value; }
    }

    private string  _propitorMobile;
    public string  PropitorMobile
    {
        get { return _propitorMobile; }
        set { _propitorMobile = value; }
    }

    private string  _managerMobile;
    public string  ManagerMobile
    {
        get { return _managerMobile; }
        set { _managerMobile = value; }
    }

    private string  _probableFutueAgent;
    public string  ProbableFutueAgent
    {
        get { return _probableFutueAgent; }
        set { _probableFutueAgent = value; }
    }

    private int _regionID;
    public int RegionID {

        get { return _regionID; }
        set {_regionID =value ;}
    }
    private int _teritoryID;
    public int TeritoryID
    {
        get { return _teritoryID; }
        set { _teritoryID = value; }
    
    }

    private int _area;
    public int Area
    {
        get { return _area; }
        set { _area = value; }
    }

    private int _district;
    public int District
    {
        get { return _district; }
        set { _district = value; }
    }

    private int _thana;
    public int Thana 
    {
        get { return _thana; }
        set { _thana = value; }
    }

}

