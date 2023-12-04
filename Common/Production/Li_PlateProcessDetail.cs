using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PlateProcessDetail
{
    public Li_PlateProcessDetail()
    {
    }

    public Li_PlateProcessDetail
        (
       
        int serialNo, 
        string pro_ID, 
        string bookCode, 
        string pressID, 
        int pur_Sl, 
        int qty 
         
        )
    {
       
        this.SerialNo = serialNo;
        this.Pro_ID = pro_ID;
        this.BookCode = bookCode;
        this.PressID = pressID;
        this.Pur_Sl = pur_Sl;
        this.Qty = qty;
        
    }

 

    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = value; }
    }

    private string _pro_ID;
    public string Pro_ID
    {
        get { return _pro_ID; }
        set { _pro_ID = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private string _pressID;
    public string PressID
    {
        get { return _pressID; }
        set { _pressID = value; }
    }

    private int _pur_Sl;
    public int Pur_Sl
    {
        get { return _pur_Sl; }
        set { _pur_Sl = value; }
    }

    private int _qty;
    public int Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }
 
}
