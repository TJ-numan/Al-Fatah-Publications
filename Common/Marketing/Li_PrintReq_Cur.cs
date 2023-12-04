using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PrintReq_Cur
{
    public Li_PrintReq_Cur()
    {
    }

    public Li_PrintReq_Cur
        (
       
        int curSl, 
        string reqNo, 
        string bookCode, 
        int printSl, 
        int target,
        int printReq,
        int printed, 
        int receive, 
        int challan, 
        int retQty, 
        int specimen,
        int stockInHand,
        int approvedQty,
        int entryBy,
        DateTime entryDate,
        bool isApproved,
        int stockQty,
        int retStkQty
         
        )
    {
    
        this.CurSl = curSl;
        this.ReqNo = reqNo;
        this.BookCode = bookCode;
        this.PrintSl = printSl;
        this.Target = target;
        this.PrintReq = printReq;
        this.Printed = printed;
        this.Receive = receive;
        this.Challan = challan;
        this.RetQty = retQty;
        this.Specimen = specimen;
        this.StockInHand = stockInHand;
        this.ApprovedQty = approvedQty;
        this.EntryBy = entryBy;
        this.EntryDate = entryDate;
        this.IsApproved = isApproved;
        this.StockQty=stockQty;
        this.RetStkQty = retStkQty;
    }

    public int PrintReq  { get; set; }
    public int ApprovedQty { get; set; }
    public int EntryBy { get; set; }
    public DateTime EntryDate { get; set; }
    public bool IsApproved { get; set; }
    public int StockQty { get; set; }
    public int RetStkQty { get; set; }

  

    private int _curSl;
    public int CurSl
    {
        get { return _curSl; }
        set { _curSl = value; }
    }

    private string _reqNo;
    public string ReqNo
    {
        get { return _reqNo; }
        set { _reqNo = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private int _printSl;
    public int PrintSl
    {
        get { return _printSl; }
        set { _printSl = value; }
    }

    private int _target;
    public int Target
    {
        get { return _target; }
        set { _target = value; }
    }

    private int _printed;
    public int Printed
    {
        get { return _printed; }
        set { _printed = value; }
    }

    private int _receive;
    public int Receive
    {
        get { return _receive; }
        set { _receive = value; }
    }

    private int _challan;
    public int Challan
    {
        get { return _challan; }
        set { _challan = value; }
    }

    private int _retQty;
    public int RetQty
    {
        get { return _retQty; }
        set { _retQty = value; }
    }

    private int _specimen;
    public int Specimen
    {
        get { return _specimen; }
        set { _specimen = value; }
    }

    private int _stockInHand;
    public int StockInHand
    {
        get { return _stockInHand; }
        set { _stockInHand = value; }
    }

    
}
