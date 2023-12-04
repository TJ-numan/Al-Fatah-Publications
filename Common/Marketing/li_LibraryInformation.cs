using System;
using System.Data;
using System.Configuration;
using System.Linq;


public class li_LibraryInformation
{
    public li_LibraryInformation()
    {
    }
    public li_LibraryInformation
    (
    string libraryID,
    string libraryName
    )
    {
        this.LibraryID = libraryID;
        this.LibraryName = libraryName;

    }
    public li_LibraryInformation
        (
    string libraryID,
    string libraryName,
    string libraryNameB,
    string LibraryAddress,
    string AddressforGettingBook,
    string ShopNumber,
    string Sustainability,
    string BuildingName,
    string HoldingNo,
    string PostOffice,
    string MarketName,
    string SquireFoot,
    string LibraryAddressB,
    decimal OpeningBalance,
    bool CashAgent,
    int type,
    string category,
    string DeliveryType,
    string Ownership,
    string Partnership,
    string ResponsiblePersonName,
    string RpPhoneNo,
    string telephone,
    string emailid,
    string libraryOwnerID,
    string OwnerPermanentAddress,
    string OwnerPresentAddress,
    string OwnerEducation,
    string salesPersonID,
    int regionID,
    int areaID,
    string teritoryID,
    int districtID,
    int thanaID,
    string transportID,
    string transportID2,
    DateTime createdDate,
    int addedBy,
    int modifiedBy,
    DateTime modefiedDate,
    string shortAddress,
    string shortAddressB,
    bool isQawmi,
    bool isSMS,
    bool isBoth,
    bool isOwned,
    bool isGodown,
    string code,
    string tradeLicense,
    string nid,
    string bapusCard,
    string AmountofMoney,
    string MoneyInWord,
    string WayofPayment
        )
    {
        this.LibraryID = libraryID;
        this.LibraryName = libraryName;
        this.Lib_Bn = libraryNameB;
        this.ShopNumber = ShopNumber;
        this.Sustainability = Sustainability;
        this.BuildingName = BuildingName;

        this.HoldingNo = HoldingNo;
        this.PostOffice = PostOffice;
        this.MarketName = MarketName;
        this.SquireFoot = SquireFoot;
        this.AddressforGettingBook = AddressforGettingBook;


        this.LibraryAddress = LibraryAddress;
        this.LibAdd_Bn = LibraryAddressB;
        this.OpeningBalance = OpeningBalance;
        this.CashParty = CashAgent;
        this.Type = type;
        this.Category = category;
        this.DeliveryType = DeliveryType;
        this.Ownership = Ownership;
        this.Partnership = Partnership;
        this.ResponsiblePersonName = ResponsiblePersonName;
        this.RpPhoneNo = RpPhoneNo;
        this.Phone = telephone;
        this.EmailID = emailid;
        this.LibraryOwnerID = libraryOwnerID;
        this.OwnerPermanentAddress = OwnerPermanentAddress;
        this.OwnerPresentAddress = OwnerPresentAddress;
        this.OwnerEducation = OwnerEducation;
        this.SalesPersonID = salesPersonID;
        this.RegionID = regionID;
        this.AreaID = areaID;
        this.TeritoryID = teritoryID;
        this.DistrictID = districtID;
        this.ThanaID = thanaID;
        this.TransportID = transportID;
        this.TransportID2 = transportID2;
        this.CreatedDate = createdDate;
        this.AddedBy = addedBy;
        this.ModifiedBy = modifiedBy;
        this.ModefiedDate = modefiedDate;
        this.ShortAddress = shortAddress;
        this.ShAdd_Bn = shortAddressB;
        this.IsQawmi = isQawmi;
        this.IsSMS = isSMS;
        this.IsBoth = isBoth;
        this.IsOwned = isOwned;
        this.IsGodown = isGodown;
        this.Code = code;
        this.TradeLicense = tradeLicense;
        this.NID = nid;
        this.BapusCard = bapusCard;
        this.AmountofMoney = AmountofMoney;
        this.MoneyInWord = MoneyInWord;
        this.WayofPayment = WayofPayment;


    }
    public bool IsQawmi { get; set; }
    public bool IsSMS { get; set; }
    public bool IsBoth { get; set; }

    public bool IsOwned { get; set; }

    public bool IsGodown { get; set; }

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



    private string _AddressforGettingBook;
    public string AddressforGettingBook
    {
        get { return _AddressforGettingBook; }
        set { _AddressforGettingBook = value; }
    }

    private string _libraryNameB;
    public string Lib_Bn
    {
        get { return _libraryNameB; }
        set { _libraryNameB = value; }
    }

    private string _LibraryAddress;
    public string LibraryAddress
    {
        get { return _LibraryAddress; }
        set { _LibraryAddress = value; }
    }

    private string _ShopNumber;
    public string ShopNumber
    {
        get { return _ShopNumber; }
        set { _ShopNumber = value; }
    }


    private string _BuildingName;
    public string BuildingName
    {
        get { return _BuildingName; }
        set { _BuildingName = value; }
    }
    private string _HoldingNo;
    public string HoldingNo
    {
        get { return _HoldingNo; }
        set { _HoldingNo = value; }
    }

    private string _PostOffice;
    public string PostOffice
    {
        get { return _PostOffice; }
        set { _PostOffice = value; }
    }

    private string _MarketName;
    public string MarketName
    {
        get { return _MarketName; }
        set { _MarketName = value; }
    }


    private string _SquireFoot;
    public string SquireFoot
    {
        get { return _SquireFoot; }
        set { _SquireFoot = value; }
    }


    private string _Sustainability;
    public string Sustainability
    {
        get { return _Sustainability; }
        set { _Sustainability = value; }
    }


    private string _LibraryAddressB;
    public string LibAdd_Bn
    {
        get { return _LibraryAddressB; }
        set { _LibraryAddressB = value; }
    }

    private int _type;
    public int Type
    {
        get { return _type; }
        set { _type = value; }
    }

    private string _Category;
    public string Category
    {
        get { return _Category; }
        set { _Category = value; }
    }

    private string _DeliveryType;
    public string DeliveryType
    {
        get { return _DeliveryType; }
        set { _DeliveryType = value; }
    }

    private string _OwnerPermanentAddress;
    public string OwnerPermanentAddress
    {
        get { return _OwnerPermanentAddress; }
        set { _OwnerPermanentAddress = value; }
    }


    private string _OwnerPresentAddress;
    public string OwnerPresentAddress
    {
        get { return _OwnerPresentAddress; }
        set { _OwnerPresentAddress = value; }
    }

    private string _OwnerEducation;
    public string OwnerEducation
    {
        get { return _OwnerEducation; }
        set { _OwnerEducation = value; }
    }

    private string _Ownership;
    public string Ownership
    {
        get { return _Ownership; }
        set { _Ownership = value; }
    }

    private string _Partnership;
    public string Partnership
    {
        get { return _Partnership; }
        set { _Partnership = value; }
    }

    private string _ResponsiblePersonName;
    public string ResponsiblePersonName
    {
        get { return _ResponsiblePersonName; }
        set { _ResponsiblePersonName = value; }
    }

    private string _RpPhoneNo;
    public string RpPhoneNo
    {
        get { return _RpPhoneNo; }
        set { _RpPhoneNo = value; }
    }


    private string _Phone;
    public string Phone
    {
        get { return _Phone; }
        set { _Phone = value; }
    }
    private string _emailid;
    public string EmailID
    {
        get { return _emailid; }
        set { _emailid = value; }
    }
    private string _wholeSellerName;
    public string WholeSellerName
    {
        get { return _wholeSellerName; }
        set { _wholeSellerName = value; }
    }

    private bool _cashParty;
    public bool CashParty
    {
        get { return _cashParty; }
        set { _cashParty = value; }
    }

    private string _telephone;
    public string Telephone
    {
        get { return _telephone; }
        set { _telephone = value; }
    }

    private string _libraryOwnerID;
    public string LibraryOwnerID
    {
        get { return _libraryOwnerID; }
        set { _libraryOwnerID = value; }
    }

    private string _salesPersonID;
    public string SalesPersonID
    {
        get { return _salesPersonID; }
        set { _salesPersonID = value; }
    }

    private string _reference;
    public string Reference
    {
        get { return _reference; }
        set { _reference = value; }
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

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private int _addedBy;
    public int AddedBy
    {
        get { return _addedBy; }
        set { _addedBy = value; }
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
    private decimal _openingBalance;
    public decimal OpeningBalance
    {
        get { return _openingBalance; }

        set { _openingBalance = value; }
    }

    private string _shortAddress;
    public string ShortAddress
    {
        get { return _shortAddress; }
        set { _shortAddress = value; }
    }

    private string _shortAddressB;
    public string ShAdd_Bn
    {
        get { return _shortAddressB; }
        set { _shortAddressB = value; }
    }


    private string _code;
    public string Code
    {
        get { return _code; }
        set { _code = value; }
    }

    private string _tradeLicense;
    public string TradeLicense
    {
        get { return _tradeLicense; }
        set { _tradeLicense = value; }
    }

    private string _nid;
    public string NID
    {
        get { return _nid; }
        set { _nid = value; }
    }

    private string _bapusCard;
    public string BapusCard
    {
        get { return _bapusCard; }
        set { _bapusCard = value; }
    }

    private string _AmountofMoney;
    public string AmountofMoney
    {
        get { return _AmountofMoney; }
        set { _AmountofMoney = value; }
    }

    private string _MoneyInWord;
    public string MoneyInWord
    {
        get { return _MoneyInWord; }
        set { _MoneyInWord = value; }
    }

    private string _WayofPayment;
    public string WayofPayment
    {
        get { return _WayofPayment; }
        set { _WayofPayment = value; }
    }

}

