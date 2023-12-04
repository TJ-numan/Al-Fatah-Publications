using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_SpecimenChalan
{
    public Li_SpecimenChalan()
    {
    }

    public Li_SpecimenChalan
        (
        
        string challanID, 
        string memoNo, 
        decimal totalAmount, 
        decimal amountReceivable, 
        string createdBy,
        string deliveredAddress, 
        DateTime createdDate, 
        DateTime deliveryDate, 
         
        string tSO, 
        int packetNo, 
        decimal perPacketCost,          
        int modifiedBy, 
        DateTime modifiedDate ,
        bool freeChalan,
        bool donation
         
        )
    {
         
        this.ChallanID = challanID;
        this.MemoNo = memoNo;
        this.TotalAmount = totalAmount;
        this.AmountReceivable = amountReceivable;
        this.CreatedBy = createdBy;
        this.DeliveredAddress = deliveredAddress;
        this.CreatedDate = createdDate;
        this.DeliveryDate = deliveryDate;
        
        this.TSO = tSO;
        this.PacketNo = packetNo;
        this.PerPacketCost = perPacketCost;
        
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.FreeChalan = freeChalan;
        this.Donation = donation;
    }


    public bool Donation { get; set; }

    private bool _freeChalan;
    public bool  FreeChalan
    {
        get { return _freeChalan; }
        set { _freeChalan = value; }
    }

    

    private string _challanID;
    public string ChallanID
    {
        get { return _challanID; }
        set { _challanID = value; }
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

    private decimal _amountReceivable;
    public decimal AmountReceivable
    {
        get { return _amountReceivable; }
        set { _amountReceivable = value; }
    }

    private string _createdBy;
    public string CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private string _deliveredAddress;
    public string DeliveredAddress
    {
        get { return _deliveredAddress; }
        set { _deliveredAddress = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private DateTime _deliveryDate;
    public DateTime DeliveryDate
    {
        get { return _deliveryDate; }
        set { _deliveryDate = value; }
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
