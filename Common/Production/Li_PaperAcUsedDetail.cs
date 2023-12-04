using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PaperAcUsedDetail
{
    public Li_PaperAcUsedDetail()
    {
    }

    public Li_PaperAcUsedDetail
        (
     
        int serialNo, 
        int printOrderSl, 
        string runNo, 
        string  rollNo, 
        string aFNo, 
        string bRNo, 
        decimal paperQty 
         
        )
    {
 
        this.SerialNo = serialNo;
        this.PrintOrderSl = printOrderSl;
        this.RunNo = runNo;
        this.RollNo = rollNo;
        this.AFNo = aFNo;
        this.BRNo = bRNo;
        this.PaperQty = paperQty;
       
    }


 
    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = value; }
    }

    private int _printOrderSl;
    public int PrintOrderSl
    {
        get { return _printOrderSl; }
        set { _printOrderSl = value; }
    }

    private string _runNo;
    public string RunNo
    {
        get { return _runNo; }
        set { _runNo = value; }
    }

    private string  _rollNo;
    public string  RollNo
    {
        get { return _rollNo; }
        set { _rollNo = value; }
    }

    private string _aFNo;
    public string AFNo
    {
        get { return _aFNo; }
        set { _aFNo = value; }
    }

    private string _bRNo;
    public string BRNo
    {
        get { return _bRNo; }
        set { _bRNo = value; }
    }

    private decimal _paperQty;
    public decimal PaperQty
    {
        get { return _paperQty; }
        set { _paperQty = value; }
    }

    
}
