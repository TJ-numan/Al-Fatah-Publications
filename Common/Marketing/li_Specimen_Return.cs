using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Specimen_Return
{
    public Li_Specimen_Return()
    {
    }

    public Li_Specimen_Return
        (
        
        string returnID, 
        string memoNo, 
        decimal totalAmount, 
        decimal adjustedAmount, 
        decimal amountPayable, 
        string createdBy, 
        string deliveredBy, 
        DateTime createdDate, 
        DateTime receiveDate, 
        string tSO, 
        int packetNo, 
        decimal perPacketCost, 
        int modifiedBy, 
        DateTime modifiedDate ,
        bool donation
         
         
        )
    {
         
        this.ReturnID = returnID;
        this.MemoNo = memoNo;
        this.TotalAmount = totalAmount;
        this.AdjustedAmount = adjustedAmount;
        this.AmountPayable = amountPayable;
        this.CreatedBy = createdBy;
        this.DeliveredBy = deliveredBy;
        this.CreatedDate = createdDate;
        this.ReceiveDate = receiveDate;
        this.TSO = tSO;
        this.PacketNo = packetNo;
        this.PerPacketCost = perPacketCost;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.Donation = donation;
    }

    public bool Donation { get; set; }
    

    private string _returnID;
    public string ReturnID
    {
        get { return _returnID; }
        set { _returnID = value; }
    }

    private string _memoNo;
    public string MemoNo
    {
        get { return _memoNo; }
        set { _memoNo = value; }
    }

    private decimal _totalAmount;
    public decimal TotalAmount
    {
        get { return _totalAmount; }
        set { _totalAmount = value; }
    }

    private decimal _adjustedAmount;
    public decimal AdjustedAmount
    {
        get { return _adjustedAmount; }
        set { _adjustedAmount = value; }
    }

    private decimal _amountPayable;
    public decimal AmountPayable
    {
        get { return _amountPayable; }
        set { _amountPayable = value; }
    }

    private string _createdBy;
    public string CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private string _deliveredBy;
    public string DeliveredBy
    {
        get { return _deliveredBy; }
        set { _deliveredBy = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private DateTime _receiveDate;
    public DateTime ReceiveDate
    {
        get { return _receiveDate; }
        set { _receiveDate = value; }
    }

    private string _tSO;
    public string TSO
    {
        get { return _tSO; }
        set { _tSO = value; }
    }

    private int _packetNo;
    public int PacketNo
    {
        get { return _packetNo; }
        set { _packetNo = value; }
    }

    private decimal _perPacketCost;
    public decimal PerPacketCost
    {
        get { return _perPacketCost; }
        set { _perPacketCost = value; }
    }

    private int _modifiedBy;
    public int ModifiedBy
    {
        get { return _modifiedBy; }
        set { _modifiedBy = value; }
    }

    private DateTime _modifiedDate;
    public DateTime ModifiedDate
    {
        get { return _modifiedDate; }
        set { _modifiedDate = value; }
    }

     
}
