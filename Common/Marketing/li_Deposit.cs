using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Deposit
{
    public Li_Deposit()
    {
    }

    public Li_Deposit
        (
         
        string invoiceNo, 
        string mRno, 
        string libraryID, 
        decimal amountOfMoney, 
        DateTime depositedDate, 
        DateTime clearDate, 
        DateTime mRDate, 
        string bankCode, 
        string bankAddress, 
        string bankSlipNo, 
        int depositeTpe, 
        int createdBy, 
        string vrifiedBy, 
        string remark, 
        bool boishaki, 
        bool alim, 
        char status_D, 
        int dele_By, 
        DateTime deledate, 
        string causeOfDelete ,
        bool dam_BookSale,
        bool houseRent,
        bool dam_Other,
        bool others,
        string comp,
        int depositForId,
        int assetList  
        )
    {
       
        this.InvoiceNo = invoiceNo;
        this.MRno = mRno;
        this.LibraryID = libraryID;
        this.AmountOfMoney = amountOfMoney;
        this.DepositedDate = depositedDate;
        this.ClearDate = clearDate;
        this.MRDate = mRDate;
        this.BankCode = bankCode;
        this.BankAddress = bankAddress;
        this.BankSlipNo = bankSlipNo;
        this.DepositeTpe = depositeTpe;
        this.CreatedBy = createdBy;
        this.VrifiedBy = vrifiedBy;
        this.Remark = remark;
        this.Boishaki = boishaki;
        this.Alim = alim;
        this.Status_D = status_D;
        this.Dele_By = dele_By;
        this.Deledate = deledate;
        this.CauseOfDelete = causeOfDelete;
        this.Dam_BookSale = dam_BookSale;
        this.HouseRent = houseRent;
        this.Dam_Other = dam_Other;
        this.Others = others;
        this.Comp = comp;
        this.DepositForId = depositForId;
        this . AssetList=assetList ;
    }
    
    public int AssetList{get;set;}
    public int DepositForId { get; set; }
    public string Comp {get; set ;}
    
    private string _invoiceNo;
    public string InvoiceNo
    {
        get { return _invoiceNo; }
        set { _invoiceNo = value; }
    }

    private string _mRno;
    public string MRno
    {
        get { return _mRno; }
        set { _mRno = value; }
    }

    private string _libraryID;
    public string LibraryID
    {
        get { return _libraryID; }
        set { _libraryID = value; }
    }

    private decimal _amountOfMoney;
    public decimal AmountOfMoney
    {
        get { return _amountOfMoney; }
        set { _amountOfMoney = value; }
    }

    private DateTime _depositedDate;
    public DateTime DepositedDate
    {
        get { return _depositedDate; }
        set { _depositedDate = value; }
    }

    private DateTime _clearDate;
    public DateTime ClearDate
    {
        get { return _clearDate; }
        set { _clearDate = value; }
    }

    private DateTime _mRDate;
    public DateTime MRDate
    {
        get { return _mRDate; }
        set { _mRDate = value; }
    }

    private string _bankCode;
    public string BankCode
    {
        get { return _bankCode; }
        set { _bankCode = value; }
    }

    private string _bankAddress;
    public string BankAddress
    {
        get { return _bankAddress; }
        set { _bankAddress = value; }
    }

    private string _bankSlipNo;
    public string BankSlipNo
    {
        get { return _bankSlipNo; }
        set { _bankSlipNo = value; }
    }

    private int _depositeTpe;
    public int DepositeTpe
    {
        get { return _depositeTpe; }
        set { _depositeTpe = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private string _vrifiedBy;
    public string VrifiedBy
    {
        get { return _vrifiedBy; }
        set { _vrifiedBy = value; }
    }

    private string _remark;
    public string Remark
    {
        get { return _remark; }
        set { _remark = value; }
    }

    private bool _boishaki;
    public bool Boishaki
    {
        get { return _boishaki; }
        set { _boishaki = value; }
    }

    private bool _alim;
    public bool Alim
    {
        get { return _alim; }
        set { _alim = value; }
    }

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

    private int _dele_By;
    public int Dele_By
    {
        get { return _dele_By; }
        set { _dele_By = value; }
    }

    private DateTime _deledate;
    public DateTime Deledate
    {
        get { return _deledate; }
        set { _deledate = value; }
    }

    private string _causeOfDelete;
    public string CauseOfDelete
    {
        get { return _causeOfDelete; }
        set { _causeOfDelete = value; }
    }

    private bool _dam_BookSale;
    public bool Dam_BookSale
    {
        get { return _dam_BookSale; }
        set { _dam_BookSale = value; }
    }

    private bool _houseRent;
    public bool HouseRent
    {
        get { return _houseRent; }
        set { _houseRent = value; }
    }

    private bool _dam_Other;
    public bool Dam_Other
    {
        get { return _dam_Other; }
        set { _dam_Other = value; }
    }

    private bool _others;
    public bool Others
    {
        get { return _others; }
        set { _others = value; }
    }
}
