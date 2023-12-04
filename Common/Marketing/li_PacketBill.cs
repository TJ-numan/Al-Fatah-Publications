using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PacketBill
{
    public Li_PacketBill()
    {
    }

    public Li_PacketBill
        (
         
        string memoNo, 
        string transportID, 
        string libraryID, 
        string libraryName, 
        string libraryAddress, 
        string transportName, 
        string rRNo, 
        decimal packNo, 
        decimal perPacCost, 
        decimal totalPackCost, 
        DateTime chalanDate, 
        DateTime deliveryDate, 
        int createdBy,
        int ispending,
        decimal van,
        decimal vanOwn,
        decimal labourLoad,
        decimal labourUnload,
        decimal transport,
        decimal transportOwn,
        decimal choat,
        decimal polithin,
        decimal selaiIn,
        decimal selaiOut,
        bool isQawmi
        )
    {
        
        this.MemoNo = memoNo;
        this.TransportID = transportID;
        this.LibraryID = libraryID;
        this.LibraryName = libraryName;
        this.LibraryAddress = libraryAddress;
        this.TransportName = transportName;
        this.RRNo = rRNo;
        this.PackNo = packNo;
        this.PerPacCost = perPacCost;
        this.TotalPackCost = totalPackCost;
        this.ChalanDate = chalanDate;
        this.DeliveryDate = deliveryDate;
        this.CreatedBy = createdBy;
        this.IsPending = ispending;
        this.Van = van;
        this.VanOwn = vanOwn;
        this.LabourLoad = labourLoad;
        this.LabourUnload = labourUnload;
        this.Transport = transport;
        this.TransportOwn = transportOwn;
        this.Choat = choat;
        this.Polithin = polithin;
        this.SelaiIn = selaiIn;
        this.SelaiOut =  selaiOut  ;
        this.ISQawmi = isQawmi;  
    }

    public bool ISQawmi { get; set; }
   

    private string _memoNo;
    public string MemoNo
    {
        get { return _memoNo; }
        set { _memoNo = value; }
    }

    private string _transportID;
    public string TransportID
    {
        get { return _transportID; }
        set { _transportID = value; }
    }

    private string _libraryID;
    public string LibraryID
    {
        get { return _libraryID; }
        set { _libraryID = value; }
    }

    private string _libraryName;
    public string LibraryName
    {
        get { return _libraryName; }
        set { _libraryName = value; }
    }

    private string _libraryAddress;
    public string LibraryAddress
    {
        get { return _libraryAddress; }
        set { _libraryAddress = value; }
    }

    private string _transportName;
    public string TransportName
    {
        get { return _transportName; }
        set { _transportName = value; }
    }

    private string _rRNo;
    public string RRNo
    {
        get { return _rRNo; }
        set { _rRNo = value; }
    }

    private decimal _packNo;
    public decimal PackNo
    {
        get { return _packNo; }
        set { _packNo = value; }
    }

    private decimal _perPacCost;
    public decimal PerPacCost
    {
        get { return _perPacCost; }
        set { _perPacCost = value; }
    }

    private decimal _totalPackCost;
    public decimal TotalPackCost
    {
        get { return _totalPackCost; }
        set { _totalPackCost = value; }
    }

    private DateTime _chalanDate;
    public DateTime ChalanDate
    {
        get { return _chalanDate; }
        set { _chalanDate = value; }
    }

    private DateTime _deliveryDate;
    public DateTime DeliveryDate
    {
        get { return _deliveryDate; }
        set { _deliveryDate = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private int _ispending;
    public int IsPending
    {
        get { return _ispending; }
        set { _ispending = value; }
    }


    private decimal _van;
    public decimal Van
    {
        get { return _van; }
        set { _van = value; }
    }

    private decimal _vanOwn;
    public decimal VanOwn
    {
        get { return _vanOwn; }
        set { _vanOwn = value; }
    }

    private decimal _labourLoad;
    public decimal LabourLoad
    {
        get { return _labourLoad; }
        set { _labourLoad = value; }
    }

    private decimal _labourUnload;
    public decimal LabourUnload
    {
        get { return _labourUnload; }
        set { _labourUnload = value; }
    }
    private decimal _transport;
    public decimal Transport
    {
        get { return _transport; }
        set { _transport = value; }
    }

    private decimal _transportOwn;
    public decimal TransportOwn
    {
        get { return _transportOwn; }
        set { _transportOwn = value; }
    }

    private decimal _choat;
    public decimal Choat
    {
        get { return _choat; }
        set { _choat = value; }
    }

    private decimal _polithin;
    public decimal Polithin
    {
        get { return _polithin; }
        set { _polithin = value; }
    }
    private decimal _selaiIn;
    public decimal SelaiIn
    {
        get { return _selaiIn; }
        set { _selaiIn = value; }
    } 
    
    private decimal _selaiOut;
    public decimal SelaiOut
    {
        get { return _selaiOut; }
        set { _selaiOut = value; }
    }
}
