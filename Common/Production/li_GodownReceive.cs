using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_GodownReceive
{
    public Li_GodownReceive()
    {
    }

    public Li_GodownReceive
        (
        
        int serialNo, 
        string stockID, 
        string receiveID, 
        string receiveMemo, 
        int receiveBy, 
        DateTime receiveDate, 
        string bookCode, 
        int qty, 
        bool isReprinted, 
        bool isRebind ,
        string  ispromotionalItemID,
        bool isopeningStock,
        bool isreceiveReturnStock ,
        bool isSpecimen,
        string edition

        
         
        )
    {
         
        this.SerialNo = serialNo;
        this.StockID = stockID;
        this.ReceiveID = receiveID;
        this.ReceiveMemo = receiveMemo;
        this.ReceiveBy = receiveBy;
        this.ReceiveDate = receiveDate;
        this.BookCode = bookCode;
        this.Qty = qty;
        this.IsReprinted = isReprinted;
        this.IsRebind = isRebind;
        this.IsopeningStock = isopeningStock;
        this.IspromotionalItemID = ispromotionalItemID;
        this.IsreceiveReturnStock = isreceiveReturnStock;
        this.IsSpecimen =  isSpecimen ;
        this.Edition = edition;
    }

        private string _edition;
        public string Edition
        {
            get { return _edition; }
            set { _edition = value; }
        }
   

    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = value; }
    }

    private string _stockID;
    public string StockID
    {
        get { return _stockID; }
        set { _stockID = value; }
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

    private int _qty;
    public int Qty
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

    private string  _ispromotionalItemID;
    public string  IspromotionalItemID
    {
        get { return _ispromotionalItemID; }
        set { _ispromotionalItemID = value; }
    }
    private bool _isopeningStock;
    public bool IsopeningStock
    {
        get { return _isopeningStock; }
        set { _isopeningStock = value; }
    }
    private bool _isreceiveReturnStock;
    public bool IsreceiveReturnStock 
    {
        get { return _isreceiveReturnStock; }
        set { _isreceiveReturnStock = value; }
    }
    private bool _isSpecimen;
    public bool IsSpecimen
    {
        get { return _isSpecimen; }
        set { _isSpecimen = value; }
    }
   
     
   
}