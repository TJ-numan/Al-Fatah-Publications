using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_AdjustChalan
{
    public Li_AdjustChalan()
    {
    }

    public Li_AdjustChalan
        (
        
        string iD, 
        string refNo, 
        int memoNo, 
        string libraryID, 
        decimal sHAmount, 
        decimal oVAmount, 
        decimal bonusAmount, 
        int pacQty, 
        decimal per_Pac_Cost, 
        decimal amoutReceivable, 
        DateTime trans_Date, 
        int createdBy, 
        DateTime createdDate, 
        bool isBoishki, 
        bool isBoishki_Bonus, 
        bool isAlim, 
        bool isAlim_bonus, 
        char status_D, 
        int deleteBy, 
        DateTime dele_Date, 
        string cause_Del ,
        bool forReturn
         
        )
    {
       
        this.ID = iD;
        this.RefNo = refNo;
        this.MemoNo = memoNo;
        this.LibraryID = libraryID;
        this.SHAmount = sHAmount;
        this.OVAmount = oVAmount;
        this.BonusAmount = bonusAmount;
        this.PacQty = pacQty;
        this.Per_Pac_Cost = per_Pac_Cost;
        this.AmoutReceivable = amoutReceivable;
        this.Trans_Date = trans_Date;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.IsBoishki = isBoishki;
        this.IsBoishki_Bonus = isBoishki_Bonus;
        this.IsAlim = isAlim;
        this.IsAlim_bonus = isAlim_bonus;
        this.Status_D = status_D;
        this.DeleteBy = deleteBy;
        this.Dele_Date = dele_Date;
        this.Cause_Del = cause_Del;
        this.ForReturn = forReturn;
       
    }

    public bool ForReturn { get; set; }
   
    private string _iD;
    public string ID
    {
        get { return _iD; }
        set { _iD = value; }
    }

    private string _refNo;
    public string RefNo
    {
        get { return _refNo; }
        set { _refNo = value; }
    }

    private int _memoNo;
    public int MemoNo
    {
        get { return _memoNo; }
        set { _memoNo = value; }
    }

    private string _libraryID;
    public string LibraryID
    {
        get { return _libraryID; }
        set { _libraryID = value; }
    }

    private decimal _sHAmount;
    public decimal SHAmount
    {
        get { return _sHAmount; }
        set { _sHAmount = value; }
    }

    private decimal _oVAmount;
    public decimal OVAmount
    {
        get { return _oVAmount; }
        set { _oVAmount = value; }
    }

    private decimal _bonusAmount;
    public decimal BonusAmount
    {
        get { return _bonusAmount; }
        set { _bonusAmount = value; }
    }

    private int _pacQty;
    public int PacQty
    {
        get { return _pacQty; }
        set { _pacQty = value; }
    }

    private decimal _per_Pac_Cost;
    public decimal Per_Pac_Cost
    {
        get { return _per_Pac_Cost; }
        set { _per_Pac_Cost = value; }
    }

    private decimal _amoutReceivable;
    public decimal AmoutReceivable
    {
        get { return _amoutReceivable; }
        set { _amoutReceivable = value; }
    }

    private DateTime _trans_Date;
    public DateTime Trans_Date
    {
        get { return _trans_Date; }
        set { _trans_Date = value; }
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

    private bool _isBoishki;
    public bool IsBoishki
    {
        get { return _isBoishki; }
        set { _isBoishki = value; }
    }

    private bool _isBoishki_Bonus;
    public bool IsBoishki_Bonus
    {
        get { return _isBoishki_Bonus; }
        set { _isBoishki_Bonus = value; }
    }

    private bool _isAlim;
    public bool IsAlim
    {
        get { return _isAlim; }
        set { _isAlim = value; }
    }

    private bool _isAlim_bonus;
    public bool IsAlim_bonus
    {
        get { return _isAlim_bonus; }
        set { _isAlim_bonus = value; }
    }

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

    private int _deleteBy;
    public int DeleteBy
    {
        get { return _deleteBy; }
        set { _deleteBy = value; }
    }

    private DateTime _dele_Date;
    public DateTime Dele_Date
    {
        get { return _dele_Date; }
        set { _dele_Date = value; }
    }

    private string _cause_Del;
    public string Cause_Del
    {
        get { return _cause_Del; }
        set { _cause_Del = value; }
    }
 
}
