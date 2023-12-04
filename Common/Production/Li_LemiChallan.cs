using System;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_LemiChallan
{
    public Li_LemiChallan()
    {
    }

    public Li_LemiChallan
        (
        
        string challanID, 
        int memoNo, 
        string  agentID, 
        DateTime challanDate, 
        decimal totalAmount, 
        decimal totalDiscount, 
        int packetNo, 
        decimal perPacketCost, 
        decimal amountReceivable, 
        bool isDelivered, 
        bool isPrinted, 
        int createdBy, 
        DateTime createdDate, 
        string status_D, 
        int canceledBy, 
        string causeOfCanel
        )
    {
     
        this.ChallanID = challanID;
        this.MemoNo = memoNo;
        this.AgentID = agentID;
        this.ChallanDate = challanDate;
        this.TotalAmount = totalAmount;
        this.TotalDiscount = totalDiscount;
        this.PacketNo = packetNo;
        this.PerPacketCost = perPacketCost;
        this.AmountReceivable = amountReceivable;
        this.IsDelivered = isDelivered;
        this.IsPrinted = isPrinted;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.Status_D = status_D;
        this.CanceledBy = canceledBy;
        this.CauseOfCanel = causeOfCanel;
    }

 

    private string _challanID;
    public string ChallanID
    {
        get { return _challanID; }
        set { _challanID = value; }
    }

    private int _memoNo;
    public int MemoNo
    {
        get { return _memoNo; }
        set { _memoNo = value; }
    }

    private string  _agentID;
    public string  AgentID
    {
        get { return _agentID; }
        set { _agentID = value; }
    }

    private DateTime _challanDate;
    public DateTime ChallanDate
    {
        get { return _challanDate; }
        set { _challanDate = value; }
    }

    private decimal _totalAmount;
    public decimal TotalAmount
    {
        get { return _totalAmount; }
        set { _totalAmount = value; }
    }

    private decimal _totalDiscount;
    public decimal TotalDiscount
    {
        get { return _totalDiscount; }
        set { _totalDiscount = value; }
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

    private decimal _amountReceivable;
    public decimal AmountReceivable
    {
        get { return _amountReceivable; }
        set { _amountReceivable = value; }
    }

    private bool _isDelivered;
    public bool IsDelivered
    {
        get { return _isDelivered; }
        set { _isDelivered = value; }
    }

    private bool _isPrinted;
    public bool IsPrinted
    {
        get { return _isPrinted; }
        set { _isPrinted = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private string _status_D;
    public string Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

    private int _canceledBy;
    public int CanceledBy
    {
        get { return _canceledBy; }
        set { _canceledBy = value; }
    }

    private string _causeOfCanel;
    public string CauseOfCanel
    {
        get { return _causeOfCanel; }
        set { _causeOfCanel = value; }
    }
}
