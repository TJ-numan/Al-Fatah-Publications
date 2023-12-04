using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_ChalanDelivery
{
    public Li_ChalanDelivery()
    {
    }

    public Li_ChalanDelivery
        (
        
        int memoNo, 
        DateTime createdDate, 
        DateTime deliveryDate, 
        int proofBy, 
        string receivedby, 
        string packetBy, 
        string checkedby, 
        decimal packetNo, 
        decimal packetCost, 
        DateTime postedDate, 
        int modifiedBy, 
        DateTime modifiedDate  
         
        )
    {
         
        this.MemoNo = memoNo;
        this.CreatedDate = createdDate;
        this.DeliveryDate = deliveryDate;
        this.ProofBy = proofBy;
        this.Receivedby = receivedby;
        this.PacketBy = packetBy;
        this.Checkedby = checkedby;
        this.PacketNo = packetNo;
        this.PacketCost = packetCost;
        this.PostedDate = postedDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        
    }


   

    private int _memoNo;
    public int MemoNo
    {
        get { return _memoNo; }
        set { _memoNo = value; }
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

    private int _proofBy;
    public int ProofBy
    {
        get { return _proofBy; }
        set { _proofBy = value; }
    }

    private string _receivedby;
    public string Receivedby
    {
        get { return _receivedby; }
        set { _receivedby = value; }
    }

    private string _packetBy;
    public string PacketBy
    {
        get { return _packetBy; }
        set { _packetBy = value; }
    }

    private string _checkedby;
    public string Checkedby
    {
        get { return _checkedby; }
        set { _checkedby = value; }
    }

    private decimal _packetNo;
    public decimal PacketNo
    {
        get { return _packetNo; }
        set { _packetNo = value; }
    }

    private decimal _packetCost;
    public decimal PacketCost
    {
        get { return _packetCost; }
        set { _packetCost = value; }
    }

    private DateTime _postedDate;
    public DateTime PostedDate
    {
        get { return _postedDate; }
        set { _postedDate = value; }
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
