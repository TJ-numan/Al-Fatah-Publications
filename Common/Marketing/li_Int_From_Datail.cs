using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Int_From_Datail
{
    public Li_Int_From_Datail()
    {
    }

    public Li_Int_From_Datail
        (
         
        int ser_No, 
        string iD, 
        string bookCode, 
        int qty, 
        bool isBoishki, 
        bool isBoishaki_Bonus, 
        bool isAlim, 
        bool isAlim_Bonus, 
        bool isRegular, 
        char status_D ,
        decimal disAmount
         
        )
    {
        
        this.Ser_No = ser_No;
        this.ID = iD;
        this.BookCode = bookCode;
        this.Qty = qty;
        this.IsBoishki = isBoishki;
        this.IsBoishaki_Bonus = isBoishaki_Bonus;
        this.IsAlim = isAlim;
        this.IsAlim_Bonus = isAlim_Bonus;
        this.IsRegular = isRegular;
        this.Status_D = status_D;
        this.DisAmount = disAmount;
         
    }


    public decimal DisAmount { get; set; }

    private int _ser_No;
    public int Ser_No
    {
        get { return _ser_No; }
        set { _ser_No = value; }
    }

    private string _iD;
    public string ID
    {
        get { return _iD; }
        set { _iD = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private int _qty;
    public int Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

    private bool _isBoishki;
    public bool IsBoishki
    {
        get { return _isBoishki; }
        set { _isBoishki = value; }
    }

    private bool _isBoishaki_Bonus;
    public bool IsBoishaki_Bonus
    {
        get { return _isBoishaki_Bonus; }
        set { _isBoishaki_Bonus = value; }
    }

    private bool _isAlim;
    public bool IsAlim
    {
        get { return _isAlim; }
        set { _isAlim = value; }
    }

    private bool _isAlim_Bonus;
    public bool IsAlim_Bonus
    {
        get { return _isAlim_Bonus; }
        set { _isAlim_Bonus = value; }
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

  
}
