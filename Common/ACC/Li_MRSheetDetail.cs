using System;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_MRSheetDetail
{
    public Li_MRSheetDetail()
    {
    }

    public Li_MRSheetDetail
        (
       
        int mRDetId, 
        int mRId, 
        string com, 
        string libraryID, 
        bool isHeldUp, 
        int depositForId, 
        DateTime collectionDate, 
        string accountNo, 
        int depositType, 
        string bankSlipNo, 
        string bankCode, 
        string bankAddress, 
        decimal amount, 
        bool isDeleted, 
        int deletedBy, 
        string causeOfDelete, 
        DateTime deleteDate, 
        string remark,
        int modifiedBy
        )
    {
        
        this.MRDetId = mRDetId;
        this.MRId = mRId;
        this.Com = com;
        this.LibraryID = libraryID;
        this.IsHeldUp = isHeldUp;
        this.DepositForId = depositForId;
        this.CollectionDate = collectionDate;
        this.AccountNo = accountNo;
        this.DepositType = depositType;
        this.BankSlipNo = bankSlipNo;
        this.BankCode = bankCode;
        this.BankAddress = bankAddress;
        this.Amount = amount;
        this.IsDeleted = isDeleted;
        this.DeletedBy = deletedBy;
        this.CauseOfDelete = causeOfDelete;
        this.DeleteDate = deleteDate;
        this.Remark = remark;
        this.ModifiedBy = modifiedBy;
    }

 

    private int _mRDetId;
    public int MRDetId
    {
        get { return _mRDetId; }
        set { _mRDetId = value; }
    }

    private int _mRId;
    public int MRId
    {
        get { return _mRId; }
        set { _mRId = value; }
    }

    private string _com;
    public string Com
    {
        get { return _com; }
        set { _com = value; }
    }

    private string _libraryID;
    public string LibraryID
    {
        get { return _libraryID; }
        set { _libraryID = value; }
    }

    private bool _isHeldUp;
    public bool IsHeldUp
    {
        get { return _isHeldUp; }
        set { _isHeldUp = value; }
    }

    private int _depositForId;
    public int DepositForId
    {
        get { return _depositForId; }
        set { _depositForId = value; }
    }

    private DateTime _collectionDate;
    public DateTime CollectionDate
    {
        get { return _collectionDate; }
        set { _collectionDate = value; }
    }

    private string _accountNo;
    public string AccountNo
    {
        get { return _accountNo; }
        set { _accountNo = value; }
    }

    private int _depositType;
    public int DepositType
    {
        get { return _depositType; }
        set { _depositType = value; }
    }

    private string _bankSlipNo;
    public string BankSlipNo
    {
        get { return _bankSlipNo; }
        set { _bankSlipNo = value; }
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

    private decimal _amount;
    public decimal Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }

    private bool _isDeleted;
    public bool IsDeleted
    {
        get { return _isDeleted; }
        set { _isDeleted = value; }
    }

    private int _deletedBy;
    public int DeletedBy
    {
        get { return _deletedBy; }
        set { _deletedBy = value; }
    }

    private string _causeOfDelete;
    public string CauseOfDelete
    {
        get { return _causeOfDelete; }
        set { _causeOfDelete = value; }
    }

    private DateTime _deleteDate;
    public DateTime DeleteDate
    {
        get { return _deleteDate; }
        set { _deleteDate = value; }
    }

    private string _remark;
    public string Remark
    {
        get { return _remark; }
        set { _remark = value; }
    }

    private int _modifiedBy;
    public int ModifiedBy
    {
        get { return _modifiedBy; }
        set { _modifiedBy = value; }
    }
}
