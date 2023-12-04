using System;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_Challan
{
    public li_Challan()
    {
    }


    public li_Challan
        (
            
         
        string challanID,
        string memoNo,
        decimal totalAmount,
        decimal amountReceivable,
        string createdBy,
        string deliveredBy,
        DateTime createdDate,
        DateTime deliveryDate,
        decimal bonus,
        string libraryID,
        bool isBonuChalan,
        int packetNo,
        decimal perPacketCost,        
        int modifiedBy,
        DateTime modifiedDate,
        bool isPaid,
        int isComplete,
        bool dakhilBonus,
        bool alimBonus,
        bool alimSpecial ,
        string comp
        )

    {
        this.ChallanID = challanID;
        this.MemoNo = memoNo;
        this.TotalAmount = totalAmount;
        this.AmountReceivable = amountReceivable;
        this.CreatedBy = createdBy;
        this.DeliveredBy = deliveredBy;
        this.CreatedDate = createdDate;
        this.DeliveryDate = deliveryDate;
        this.Bonus = bonus;
        this.LibraryID = libraryID;
        this.IsBonuChalan = isBonuChalan;
        this.PacketNo = packetNo;
        this.PerPacketCost = perPacketCost;        
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.IsPaid = isPaid;
        this.IsComplete = isComplete;
        this.DakhilBonus = dakhilBonus;
        this.AlimBonus = alimBonus;
        this.AlimSpecial = alimSpecial;
        this.Comp = comp;

    }


    public string Comp { get; set; }

    private string _challanID;
    public string ChallanID
    {
        get { return _challanID; }
        set { _challanID = value; }
    }

    private string _memoNo;
    public string MemoNo
    {
        get { return _memoNo; }
        set { _memoNo = value; }
    }

    private decimal _totalAmount;
    public decimal TotalAmount
    {
        get { return _totalAmount; }
        set { _totalAmount = value; }
    }

    private decimal _amountReceivable;
    public decimal AmountReceivable
    {
        get { return _amountReceivable; }
        set { _amountReceivable = value; }
    }

    private string _createdBy;
    public string CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private string _deliveredBy;
    public string DeliveredBy
    {
        get { return _deliveredBy; }
        set { _deliveredBy = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private DateTime _deliveryDate;
    public DateTime DeliveryDate
    {
        get { return _deliveryDate; }
        set { _deliveryDate = value; }
    }

    private decimal _bonus;
    public decimal Bonus
    {
        get { return _bonus; }
        set { _bonus = value; }
    }

    private string _libraryID;
    public string LibraryID
    {
        get { return _libraryID; }
        set { _libraryID = value; }
    }

    private bool _isBonuChalan;
    public bool IsBonuChalan
    {
        get { return _isBonuChalan; }
        set { _isBonuChalan = value; }
    }

    private int _packetNo;
    public int PacketNo
    {
        get { return _packetNo; }
        set { _packetNo = value; }
    }

    private decimal _perPacketCost;
    public decimal PerPacketCost
    {
        get { return _perPacketCost; }
        set { _perPacketCost = value; }
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

    private bool _isPaid;
    public bool IsPaid
    {
        get { return _isPaid; }
        set { _isPaid = value; }
    }

    private int _isComplete;
    public int IsComplete
    {
        get { return _isComplete; }
        set { _isComplete = value; }
    }

    private bool _dakhilBonus;
    public bool DakhilBonus
    {
        get { return _dakhilBonus; }
        set { _dakhilBonus = value; }
    }

    private bool _alimBonus;
    public bool AlimBonus
    {
        get { return _alimBonus; }
        set { _alimBonus = value; }
    }

    private bool _alimSpecial;
    public bool AlimSpecial
    {
        get { return _alimSpecial; }
        set { _alimSpecial = value; }
    }
}

