using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_MadrasahQawmi
{
    public Li_MadrasahQawmi()
    {
    }

    public Li_MadrasahQawmi
        (
 
        int madrashId, 
        string madName, 
        int madType, 
        string ested, 
        string madAddress, 
        string madrasahPhone,
        string territoryID, 
        int districtID, 
        int thanaID, 
        int madrasahPosition, 
        string maximumClass, 
        int totalStudent, 
        string board, 
        string principalName, 
        string principalPhone, 
        string contactPublishers, 
        string madrasahRelatedLibrary, 
        string ownerName, 
        string ownerPhone, 
        decimal yearlySale, 
        string agentOf  
         
        )
    {
      
        this.MadrashId = madrashId;
        this.MadName = madName;
        this.MadType = madType;
        this.Ested = ested;
        this.MadAddress = madAddress;
        this.MadrasahPhone = madrasahPhone;
        this.TerritoryID = territoryID;
        this.DistrictID = districtID;
        this.ThanaID = thanaID;
        this.MadrasahPosition = madrasahPosition;
        this.MaximumClass = maximumClass;
        this.TotalStudent = totalStudent;
        this.Board = board;
        this.PrincipalName = principalName;
        this.PrincipalPhone = principalPhone;
        this.ContactPublishers = contactPublishers;
        this.MadrasahRelatedLibrary = madrasahRelatedLibrary;
        this.OwnerName = ownerName;
        this.OwnerPhone = ownerPhone;
        this.YearlySale = yearlySale;
        this.AgentOf = agentOf;
        
    }


    public string MadrasahPhone { get; set; }

    private int _madrashId;
    public int MadrashId
    {
        get { return _madrashId; }
        set { _madrashId = value; }
    }

    private string _madName;
    public string MadName
    {
        get { return _madName; }
        set { _madName = value; }
    }

    private int _madType;
    public int MadType
    {
        get { return _madType; }
        set { _madType = value; }
    }

    private string _ested;
    public string Ested
    {
        get { return _ested; }
        set { _ested = value; }
    }

    private string _madAddress;
    public string MadAddress
    {
        get { return _madAddress; }
        set { _madAddress = value; }
    }

    private string _territoryID;
    public string TerritoryID
    {
        get { return _territoryID; }
        set { _territoryID = value; }
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

    private int _madrasahPosition;
    public int MadrasahPosition
    {
        get { return _madrasahPosition; }
        set { _madrasahPosition = value; }
    }

    private string _maximumClass;
    public string MaximumClass
    {
        get { return _maximumClass; }
        set { _maximumClass = value; }
    }

    private int _totalStudent;
    public int TotalStudent
    {
        get { return _totalStudent; }
        set { _totalStudent = value; }
    }

    private string _board;
    public string Board
    {
        get { return _board; }
        set { _board = value; }
    }

    private string _principalName;
    public string PrincipalName
    {
        get { return _principalName; }
        set { _principalName = value; }
    }

    private string _principalPhone;
    public string PrincipalPhone
    {
        get { return _principalPhone; }
        set { _principalPhone = value; }
    }

    private string _contactPublishers;
    public string ContactPublishers
    {
        get { return _contactPublishers; }
        set { _contactPublishers = value; }
    }

    private string _madrasahRelatedLibrary;
    public string MadrasahRelatedLibrary
    {
        get { return _madrasahRelatedLibrary; }
        set { _madrasahRelatedLibrary = value; }
    }

    private string _ownerName;
    public string OwnerName
    {
        get { return _ownerName; }
        set { _ownerName = value; }
    }

    private string _ownerPhone;
    public string OwnerPhone
    {
        get { return _ownerPhone; }
        set { _ownerPhone = value; }
    }

    private decimal _yearlySale;
    public decimal YearlySale
    {
        get { return _yearlySale; }
        set { _yearlySale = value; }
    }

    private string _agentOf;
    public string AgentOf
    {
        get { return _agentOf; }
        set { _agentOf = value; }
    }

   
}
