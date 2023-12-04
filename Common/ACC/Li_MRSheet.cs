using System;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_MRSheet
{
    public Li_MRSheet()
    {
    }

    public Li_MRSheet
        (
      
        int mRId, 
        decimal totalAmount, 
        bool isSend, 
        bool isReSend, 
        bool isLocked, 
        int senderId, 
        DateTime sendDate, 
        int reSendId, 
        DateTime reSendDate, 
        int lockedId, 
        DateTime lockedDate, 
        int createBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        string remarks,
        DateTime mrDate 

        )
    {
       
        this.MRId = mRId;
        this.TotalAmount = totalAmount;
        this.IsSend = isSend;
        this.IsReSend = isReSend;
        this.IsLocked = isLocked;
        this.SenderId = senderId;
        this.SendDate = sendDate;
        this.ReSendId = reSendId;
        this.ReSendDate = reSendDate;
        this.LockedId = lockedId;
        this.LockedDate = lockedDate;
        this.CreateBy = createBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.Remarks = remarks;
        this.MRDate = mrDate;
    }

    public DateTime MRDate { get; set; }

    private int _mRId;
    public int MRId
    {
        get { return _mRId; }
        set { _mRId = value; }
    }

    private decimal _totalAmount;
    public decimal TotalAmount
    {
        get { return _totalAmount; }
        set { _totalAmount = value; }
    }

    private bool _isSend;
    public bool IsSend
    {
        get { return _isSend; }
        set { _isSend = value; }
    }

    private bool _isReSend;
    public bool IsReSend
    {
        get { return _isReSend; }
        set { _isReSend = value; }
    }

    private bool _isLocked;
    public bool IsLocked
    {
        get { return _isLocked; }
        set { _isLocked = value; }
    }

    private int _senderId;
    public int SenderId
    {
        get { return _senderId; }
        set { _senderId = value; }
    }

    private DateTime _sendDate;
    public DateTime SendDate
    {
        get { return _sendDate; }
        set { _sendDate = value; }
    }

    private int _reSendId;
    public int ReSendId
    {
        get { return _reSendId; }
        set { _reSendId = value; }
    }

    private DateTime _reSendDate;
    public DateTime ReSendDate
    {
        get { return _reSendDate; }
        set { _reSendDate = value; }
    }

    private int _lockedId;
    public int LockedId
    {
        get { return _lockedId; }
        set { _lockedId = value; }
    }

    private DateTime _lockedDate;
    public DateTime LockedDate
    {
        get { return _lockedDate; }
        set { _lockedDate = value; }
    }

    private int _createBy;
    public int CreateBy
    {
        get { return _createBy; }
        set { _createBy = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
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

    private string _remarks;
    public string Remarks
    {
        get { return _remarks; }
        set { _remarks = value; }
    }
}
