using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_LibraryInformation
{
    public Li_LibraryInformation()
    {
    }

    public Li_LibraryInformation
        (
         
        string libraryID, 
        string libraryName, 
        string libraryAddress, 
        string shortAddress, 
        bool anualBonusBase, 
        int type, 
        string category, 
        string telephone, 
        string libraryOwnerName, 
        string salesPersonID, 
        int regionID, 
        int areaID, 
        string teritoryID, 
        int districtID, 
        int thanaID, 
        DateTime createdDate, 
        int createdBy, 
        int modifiedBy, 
        DateTime modefiedDate,
        string lib_Bn,
        string libAdd_Bn, 
        string shAdd_Bn,
         
        char status, 
        int deleBy, 
        DateTime deleDate  
         
        )
    {
       
        this.LibraryID = libraryID;
        this.LibraryName = libraryName;
        this.LibraryAddress = libraryAddress;
        this.ShortAddress = shortAddress;
        this.AnualBonusBase = anualBonusBase;
        this.Type = type;
        this.Category = category;
        this.Telephone = telephone;
        this.LibraryOwnerName = libraryOwnerName;
        this.SalesPersonID = salesPersonID;
        this.RegionID = regionID;
        this.AreaID = areaID;
        this.TeritoryID = teritoryID;
        this.DistrictID = districtID;
        this.ThanaID = thanaID;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.ModifiedBy = modifiedBy;
        this.ModefiedDate = modefiedDate;
        this.Lib_Bn = lib_Bn;
        this.LibAdd_Bn = libAdd_Bn;
        this.ShAdd_Bn = shAdd_Bn;
        
        this.Status = status;
        this.DeleBy = deleBy;
        this.DeleDate = deleDate;
         
    }

    public Li_LibraryInformation
    (
    string libraryID,
    string libraryName 
    )
    {
        this.LibraryID = libraryID;
        this.LibraryName = libraryName;
         
    }


    

    private string _libraryID;
    public string LibraryID
    {
        get { return _libraryID; }
        set { _libraryID = value; }
    }

    private string _libraryName;
    public string LibraryName
    {
        get { return _libraryName; }
        set { _libraryName = value; }
    }

    private string _libraryAddress;
    public string LibraryAddress
    {
        get { return _libraryAddress; }
        set { _libraryAddress = value; }
    }

    private string _shortAddress;
    public string ShortAddress
    {
        get { return _shortAddress; }
        set { _shortAddress = value; }
    }

    private bool _anualBonusBase;
    public bool AnualBonusBase
    {
        get { return _anualBonusBase; }
        set { _anualBonusBase = value; }
    }

    private int _type;
    public int Type
    {
        get { return _type; }
        set { _type = value; }
    }

    private string _category;
    public string Category
    {
        get { return _category; }
        set { _category = value; }
    }

    private string _telephone;
    public string Telephone
    {
        get { return _telephone; }
        set { _telephone = value; }
    }

    private string _libraryOwnerName;
    public string LibraryOwnerName
    {
        get { return _libraryOwnerName; }
        set { _libraryOwnerName = value; }
    }

    private string _salesPersonID;
    public string SalesPersonID
    {
        get { return _salesPersonID; }
        set { _salesPersonID = value; }
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

    private int _districtID;
    public int DistrictID
    {
        get { return _districtID; }
        set { _districtID = value; }
    }

    private int _thanaID;
    public int ThanaID
    {
        get { return _thanaID; }
        set { _thanaID = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private int _modifiedBy;
    public int ModifiedBy
    {
        get { return _modifiedBy; }
        set { _modifiedBy = value; }
    }

    private DateTime _modefiedDate;
    public DateTime ModefiedDate
    {
        get { return _modefiedDate; }
        set { _modefiedDate = value; }
    }


    private string _lib_Bn;
    public string Lib_Bn
    {
        get { return  _lib_Bn; }
        set { _lib_Bn  = value; }
    }

    private string _libAdd_Bn;
    public string LibAdd_Bn
    {
        get { return  _libAdd_Bn ; }
        set {  _libAdd_Bn  = value; }
    }

    private string _shAdd_Bn;
    public string ShAdd_Bn
    {
        get { return _shAdd_Bn  ; }
        set {   _shAdd_Bn = value; }
    }


    private char _status;
    public char Status
    {
        get { return _status; }
        set { _status = value; }
    }

    private int _deleBy;
    public int DeleBy
    {
        get { return _deleBy; }
        set { _deleBy = value; }
    }

    private DateTime _deleDate;
    public DateTime DeleDate
    {
        get { return _deleDate; }
        set { _deleDate = value; }
    }
 
}
