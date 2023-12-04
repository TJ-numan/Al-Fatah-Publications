using System;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_Return
{
   public li_Return()
   
    {
    }


   public li_Return
   
     (
                string returnID, 
                string challanID, 
                string libraryID, 
                decimal totalAmount,
                DateTime returnDate, 
                int bookReceivedBy,
                decimal damageAmount,
                string memoNo, 
                decimal amountReceivable, 
                int packetNo, 
                decimal perPacketCost,
                decimal Spcimentotal,
                int serialNo,
                decimal dicountAmount
        )
    {
       
        this.ReturnID = returnID;
        this.ChallanID = challanID;
        this.LibraryID = libraryID;
        this.TotalAmount = totalAmount;
        this.ReturnDate = returnDate;
        this.BookReceivedBy = bookReceivedBy;
        this.DamageAmount = damageAmount;
        this.MemoNo = memoNo;
        this.AmountReceivable = amountReceivable;
        this.PacketNo = packetNo;
        this.PerPacketCost = perPacketCost;
        this.SpcimenTotal = Spcimentotal;
        this.SerialNo = serialNo;
        this.DiscountAmount = dicountAmount;
    }



    private string _returnID;
    public string ReturnID
    {
        get { return _returnID; }
        set { _returnID = value; }
    }

    private string _challanID;
    public string ChallanID
    {
        get { return _challanID; }
        set { _challanID = value; }
    }

    private string _libraryID;
    public string LibraryID
    {
        get { return _libraryID; }
        set { _libraryID = value; }
    }

    private decimal _totalAmount;
    public decimal TotalAmount
    {
        get { return _totalAmount; }
        set { _totalAmount = value; }
    }
    private decimal _dicountAmount;
    public decimal DiscountAmount
    {
        get { return _dicountAmount; }
        set { _dicountAmount = value; }
    }
    private DateTime _returnDate;
    public DateTime ReturnDate
    {
        get { return _returnDate; }
        set { _returnDate = value; }
    }

    private int _bookReceivedBy;
    public int BookReceivedBy
    {
        get { return _bookReceivedBy; }
        set { _bookReceivedBy = value; }
    }

    private decimal _damageAmount;
    public decimal DamageAmount
    {
        get { return _damageAmount; }
        set { _damageAmount = value; }
    }

    private string _memoNo;
    public string MemoNo
    {
        get { return _memoNo; }
        set { _memoNo = value; }
    }

    private decimal _amountReceivable;
    public decimal AmountReceivable
    {
        get { return _amountReceivable; }
        set { _amountReceivable = value; }
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

    private decimal _Specimentotal;
    public decimal SpcimenTotal
    {
        get { return _Specimentotal; }
        set { _Specimentotal = value; }
    }
    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = value; }
    }
}

