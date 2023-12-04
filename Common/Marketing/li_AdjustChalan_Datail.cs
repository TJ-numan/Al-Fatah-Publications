using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_AdjustChalan_Datail
{
    public Li_AdjustChalan_Datail()
    {
    }

    public Li_AdjustChalan_Datail
        (
     
        int serialNo, 
        string iD, 
        string bookCode, 
        int sHQty, 
        int ovQty, 
        decimal sHDisAmount, 
        decimal overDisAmount, 
        bool isBoishki, 
        bool isBoishaki_Bonus, 
        bool isAlim, 
        bool isAlim_Bonus, 
        
        char status_D 
         
        )
    {
      
        this.SerialNo = serialNo;
        this.ID = iD;
        this.BookCode = bookCode;
        this.SHQty = sHQty;
        this.OvQty = ovQty;
        this.SHDisAmount = sHDisAmount;
        this.OverDisAmount = overDisAmount;
        this.IsBoishki = isBoishki;
        this.IsBoishaki_Bonus = isBoishaki_Bonus;
        this.IsAlim = isAlim;
        this.IsAlim_Bonus = isAlim_Bonus;
        
        this.Status_D = status_D;
         
    }


 

    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = value; }
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

    private int _sHQty;
    public int SHQty
    {
        get { return _sHQty; }
        set { _sHQty = value; }
    }

    private int _ovQty;
    public int OvQty
    {
        get { return _ovQty; }
        set { _ovQty = value; }
    }

    private decimal _sHDisAmount;
    public decimal SHDisAmount
    {
        get { return _sHDisAmount; }
        set { _sHDisAmount = value; }
    }

    private decimal _overDisAmount;
    public decimal OverDisAmount
    {
        get { return _overDisAmount; }
        set { _overDisAmount = value; }
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
 

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

  
}
