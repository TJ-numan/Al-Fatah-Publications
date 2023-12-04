using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Pesting_Page
{
    public Li_Pesting_Page()
    {
    }

    public Li_Pesting_Page
        (
    
        int serialNo, 
        string orderNo, 
        int inner_P, 
        int suggestion_P, 
        int index_P, 
        int main_P, 
        int last_P, 
        int total_P, 
        char status_D 
         
        )
    {
  
        this.SerialNo = serialNo;
        this.OrderNo = orderNo;
        this.Inner_P = inner_P;
        this.Suggestion_P = suggestion_P;
        this.Index_P = index_P;
        this.Main_P = main_P;
        this.Last_P = last_P;
        this.Total_P = total_P;
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

    private int _inner_P;
    public int Inner_P
    {
        get { return _inner_P; }
        set { _inner_P = value; }
    }

    private int _suggestion_P;
    public int Suggestion_P
    {
        get { return _suggestion_P; }
        set { _suggestion_P = value; }
    }

    private int _index_P;
    public int Index_P
    {
        get { return _index_P; }
        set { _index_P = value; }
    }

    private int _main_P;
    public int Main_P
    {
        get { return _main_P; }
        set { _main_P = value; }
    }

    private int _last_P;
    public int Last_P
    {
        get { return _last_P; }
        set { _last_P = value; }
    }

    private int _total_P;
    public int Total_P
    {
        get { return _total_P; }
        set { _total_P = value; }
    }

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

  
}
