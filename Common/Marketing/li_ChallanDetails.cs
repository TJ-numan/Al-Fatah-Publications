using System;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_ChallanDetails
{
    public li_ChallanDetails()
    {
    }


    public li_ChallanDetails
        (
        string challanDetailsID,
        string challanID,
        string bookAcCode,
        int qty,
        decimal unitPrice,
        DateTime createdDate,
        long oldStock,
        decimal bonusPercentage,
        int specimen,
        bool boishaki,
        bool dakhilBonus,
        bool alimBonus,
        bool alimSpecial,
        string edition 

        )
    {
        this.ChallanDetailsID = challanDetailsID;
        this.ChallanID = challanID;
        this.BookAcCode = bookAcCode;
        this.Qty = qty;
        this.UnitPrice = unitPrice;
        this.CreatedDate = createdDate;
        this.OldStock = oldStock;
        this.BonusPercentage = bonusPercentage;
        this.Specimen = specimen;
        this.Boishaki = boishaki;
        this.DakhilBonus = dakhilBonus;
        this.AlimBonus = alimBonus;
        this.AlimSpecial = alimSpecial;
        this.Edition = edition;

    }

    //public li_ChallanDetails
    //    (
    //        string challanDetailsID,
    //        string challanID,
    //        string bookAcCode,
    //        int qty,
    //        decimal unitPrice,
    //        string bookID,
    //        DateTime createdDate,
    //        int specimen,
    //        bool boishaki

    //    )
    //{
    //    this.ChallanDetailsID = challanDetailsID;
    //    this.ChallanID = challanID;
    //    this.BookAcCode = bookAcCode;
    //    this.Qty = qty;
    //    this.UnitPrice = unitPrice;
    //    this.BookID = bookID;
    //    this.CreatedDate = createdDate;
    //    this.Specimen = specimen;
    //    this.Boishaki = boishaki;

    //}
    private string _edition;
    public string Edition
    {
        get { return _edition; }
        set { _edition = value; }
    }

    private string _challanDetailsID;
    public string ChallanDetailsID
    {
        get { return _challanDetailsID; }
        set { _challanDetailsID = value; }
    }

    private string _challanID;
    public string ChallanID
    {
        get { return _challanID; }
        set { _challanID = value; }
    }

    private string _bookAcCode;
    public string BookAcCode
    {
        get { return _bookAcCode; }
        set { _bookAcCode = value; }
    }

    private int _qty;
    public int Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

    private decimal _unitPrice;
    public decimal UnitPrice
    {
        get { return _unitPrice; }
        set { _unitPrice = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private long _oldStock;
    public long OldStock
    {
        get { return _oldStock; }
        set { _oldStock = value; }
    }

    private decimal _bonusPercentage;
    public decimal BonusPercentage
    {
        get { return _bonusPercentage; }
        set { _bonusPercentage = value; }
    }

    private int _specimen;
    public int Specimen
    {
        get { return _specimen; }
        set { _specimen = value; }
    }

    private bool _boishaki;
    public bool Boishaki
    {
        get { return _boishaki; }
        set { _boishaki = value; }
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

