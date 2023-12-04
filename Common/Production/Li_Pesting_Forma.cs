using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Pesting_Forma
{
    public Li_Pesting_Forma()
    {
    }

    public Li_Pesting_Forma
        (
  
        int serialNo, 
        string orderNo,
        decimal fi_Color,
        decimal fo_Color,
        decimal thr_Color,
        decimal tw_Color, 
        decimal si_Color, 
        decimal b_W, 
        decimal total, 
        string machine, 
        char status_D  
         
        )
    {
 
        this.SerialNo = serialNo;
        this.OrderNo = orderNo;
        this.Fi_Color = fi_Color;
        this.Fo_Color = fo_Color;
        this.Thr_Color = thr_Color;
        this.Tw_Color = tw_Color;
        this.Si_Color = si_Color;
        this.B_W = b_W;
        this.Total = total;
        this.Machine = machine;
        this.Status_D = status_D;
        
    }


  

    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = value; }
    }

    private string _orderNo;
    public string OrderNo
    {
        get { return _orderNo; }
        set { _orderNo = value; }
    }

    private decimal _fi_Color;
    public decimal Fi_Color
    {
        get { return _fi_Color; }
        set { _fi_Color = value; }
    }

    private decimal _fo_Color;
    public decimal Fo_Color
    {
        get { return _fo_Color; }
        set { _fo_Color = value; }
    }

    private decimal _thr_Color;
    public decimal Thr_Color
    {
        get { return _thr_Color; }
        set { _thr_Color = value; }
    }

    private decimal _tw_Color;
    public decimal Tw_Color
    {
        get { return _tw_Color; }
        set { _tw_Color = value; }
    }

    private decimal _si_Color;
    public decimal Si_Color
    {
        get { return _si_Color; }
        set { _si_Color = value; }
    }

    private decimal _b_W;
    public decimal B_W
    {
        get { return _b_W; }
        set { _b_W = value; }
    }

    private decimal _total;
    public decimal Total
    {
        get { return _total; }
        set { _total = value; }
    }

    private string _machine;
    public string Machine
    {
        get { return _machine; }
        set { _machine = value; }
    }

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

   
}
