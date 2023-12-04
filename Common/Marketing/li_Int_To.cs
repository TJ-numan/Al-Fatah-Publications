using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Int_To
{
    public Li_Int_To()
    {
    }

    public Li_Int_To
        (
        
        string iD, 
        string slipNo, 
        string libraryID, 
        decimal totalAmount, 
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
        bool isRegular, 
        char status_D, 
        int deleteBy, 
        DateTime dele_Date, 
        string cause_Del ,
        decimal bonusAmount
         
        )
    {
     
        this.ID = iD;
        this.SlipNo = slipNo;
        this.LibraryID = libraryID;
        this.TotalAmount = totalAmount;
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
        this.IsRegular = isRegular;
        this.Status_D = status_D;
        this.DeleteBy = deleteBy;
        this.Dele_Date = dele_Date;
        this.Cause_Del = cause_Del;
        this.BonusAmount = bonusAmount;
    }

    public decimal BonusAmount { get; set; }

    private string _iD;
    public string ID
    {
        get { return _iD; }
        set { _iD = value; }
    }

    private string _slipNo;
    public string SlipNo
    {
        get { return _slipNo; }
        set { _slipNo = value; }
    }

    private string _libraryID;
    public string LibraryID
    {
        get { return _libraryID; }
        set { _libraryID = value; }
    }

    private decimal _totalAmount;
    public decimal TotalAmount
    {
        get { return _totalAmount; }
        set { _totalAmount = value; }
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

    private bool _isRegular;
    public bool IsRegular
    {
        get { return _isRegular; }
        set { _isRegular = value; }
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
