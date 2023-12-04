using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_DonPayment
{
    public Li_DonPayment()
    {
    }

    public Li_DonPayment
        (
        
        int payId, 
        int pSId, 
        string acName,
        string acName_bn, 
        string acMemNo, 
        string bankCof, 
        string acAddress, 
        int thanaId, 
        string contactNo, 
        bool isBankPay, 
        int accTypId, 
        int payTypId, 
        string transportID, 
        bool isRecAckNo, 
        string ackNo, 
        string remarks, 
        int createdBy, 
        DateTime createdDate
        )
    {
     
        this.PayId = payId;
        this.PSId = pSId;
        this.AcName = acName;
        this.AcName_bn = acName_bn;
        this.AcMemNo = acMemNo;
        this.BankCof = bankCof;
        this.AcAddress = acAddress;
        this.ThanaId = thanaId;
        this.ContactNo = contactNo;
        this.IsBankPay = isBankPay;
        this.AccTypId = accTypId;
        this.PayTypId = payTypId;
        this.TransportID = transportID;
        this.IsRecAckNo = isRecAckNo;
        this.AckNo = ackNo;
        this.Remarks = remarks;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
    }

 

    private int _payId;
    public int PayId
    {
        get { return _payId; }
        set { _payId = value; }
    }

    private int _pSId;
    public int PSId
    {
        get { return _pSId; }
        set { _pSId = value; }
    }

    private string _acName;
    public string AcName
    {
        get { return _acName; }
        set { _acName = value; }
    }

    private string _acName_bn;
    public string AcName_bn
    {
        get { return _acName_bn; }
        set { _acName_bn = value; }
    }

    private string _acMemNo;
    public string AcMemNo
    {
        get { return _acMemNo; }
        set { _acMemNo = value; }
    }

    private string _bankCof;
    public string BankCof
    {
        get { return _bankCof; }
        set { _bankCof = value; }
    }

    private string _acAddress;
    public string AcAddress
    {
        get { return _acAddress; }
        set { _acAddress = value; }
    }

    private int _thanaId;
    public int ThanaId
    {
        get { return _thanaId; }
        set { _thanaId = value; }
    }

    private string _contactNo;
    public string ContactNo
    {
        get { return _contactNo; }
        set { _contactNo = value; }
    }

    private bool _isBankPay;
    public bool IsBankPay
    {
        get { return _isBankPay; }
        set { _isBankPay = value; }
    }

    private int _accTypId;
    public int AccTypId
    {
        get { return _accTypId; }
        set { _accTypId = value; }
    }

    private int _payTypId;
    public int PayTypId
    {
        get { return _payTypId; }
        set { _payTypId = value; }
    }

    private string _transportID;
    public string TransportID
    {
        get { return _transportID; }
        set { _transportID = value; }
    }

    private bool _isRecAckNo;
    public bool IsRecAckNo
    {
        get { return _isRecAckNo; }
        set { _isRecAckNo = value; }
    }

    private string _ackNo;
    public string AckNo
    {
        get { return _ackNo; }
        set { _ackNo = value; }
    }

    private string _remarks;
    public string Remarks
    {
        get { return _remarks; }
        set { _remarks = value; }
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
}
