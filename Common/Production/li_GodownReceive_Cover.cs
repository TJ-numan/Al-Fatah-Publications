using System;
using System.Data;
using System.Configuration;
using System.Linq;
 
public class Li_GodownReceive_Cover
{
    public Li_GodownReceive_Cover()
    {
    }

    public Li_GodownReceive_Cover
        (
   
        int serialNo, 
        string pressID, 
        string receiveID, 
        string receiveMemo, 
        int receiveBy, 
        DateTime receiveDate, 
        string bookCode, 
        decimal qty, 
        bool isReprinted, 
        bool isRebind, 
        string promotionalItemID, 
        bool isSpecimen, 
        bool isopeningStock, 
        bool isPaid, 
        char status_D, 
        string causeOfDel, 
        int delBy, 
        DateTime delDate,
        int sourceNo,
        string sizeID
        
         
        )
    {
       
        this.SerialNo = serialNo;
        this.PressID = pressID;
        this.ReceiveID = receiveID;
        this.ReceiveMemo = receiveMemo;
        this.ReceiveBy = receiveBy;
        this.ReceiveDate = receiveDate;
        this.BookCode = bookCode;
        this.Qty = qty;
        this.IsReprinted = isReprinted;
        this.IsRebind = isRebind;
        this.PromotionalItemID = promotionalItemID;
        this.IsSpecimen = isSpecimen;
        this.IsopeningStock = isopeningStock;
        this.IsPaid = isPaid;
        this.Status_D = status_D;
        this.CauseOfDel = causeOfDel;
        this.DelBy = delBy;
        this.DelDate = delDate;
        this.SourceNo = sourceNo;
        this.SizeID = sizeID;
    }
    public string SizeID { get; set; }
 

    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = value; }
    }

    private string _pressID;
    public string PressID
    {
        get { return _pressID; }
        set { _pressID = value; }
    }

    private string _receiveID;
    public string ReceiveID
    {
        get { return _receiveID; }
        set { _receiveID = value; }
    }

    private string _receiveMemo;
    public string ReceiveMemo
    {
        get { return _receiveMemo; }
        set { _receiveMemo = value; }
    }

    private int _receiveBy;
    public int ReceiveBy
    {
        get { return _receiveBy; }
        set { _receiveBy = value; }
    }

    private DateTime _receiveDate;
    public DateTime ReceiveDate
    {
        get { return _receiveDate; }
        set { _receiveDate = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private decimal _qty;
    public decimal Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

    private bool _isReprinted;
    public bool IsReprinted
    {
        get { return _isReprinted; }
        set { _isReprinted = value; }
    }

    private bool _isRebind;
    public bool IsRebind
    {
        get { return _isRebind; }
        set { _isRebind = value; }
    }

    private string _promotionalItemID;
    public string PromotionalItemID
    {
        get { return _promotionalItemID; }
        set { _promotionalItemID = value; }
    }

    private bool _isSpecimen;
    public bool IsSpecimen
    {
        get { return _isSpecimen; }
        set { _isSpecimen = value; }
    }

    private bool _isopeningStock;
    public bool IsopeningStock
    {
        get { return _isopeningStock; }
        set { _isopeningStock = value; }
    }

    private bool _isPaid;
    public bool IsPaid
    {
        get { return _isPaid; }
        set { _isPaid = value; }
    }

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

    private string _causeOfDel;
    public string CauseOfDel
    {
        get { return _causeOfDel; }
        set { _causeOfDel = value; }
    }

    private int _delBy;
    public int DelBy
    {
        get { return _delBy; }
        set { _delBy = value; }
    }

    private DateTime _delDate;
    public DateTime DelDate
    {
        get { return _delDate; }
        set { _delDate = value; }
    }

    private int _sourceNo;
    public int SourceNo
    {
        get { return _sourceNo; }
        set { _sourceNo = value; }
    }

   
}
