using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_DonPaymentShedule
{
    public Li_DonPaymentShedule()
    {
    }

    public Li_DonPaymentShedule
        (
        
        int pSId, 
        int sheId, 
        int detId, 
        int doDesId, 
        decimal amount, 
        string status_d, 
        DateTime  startingDate, 
        DateTime   endingDate, 
        int createdBy, 
        DateTime createdDate
        )
    {
      
        this.PSId = pSId;
        this.SheId = sheId;
        this.DetId = detId;
        this.DoDesId = doDesId;
        this.Amount = amount;
        this.Status_d = status_d;
        this.StartingDate = startingDate;
        this.EndingDate = endingDate;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
    }


 
    private int _pSId;
    public int PSId
    {
        get { return _pSId; }
        set { _pSId = value; }
    }

    private int _sheId;
    public int SheId
    {
        get { return _sheId; }
        set { _sheId = value; }
    }

    private int _detId;
    public int DetId
    {
        get { return _detId; }
        set { _detId = value; }
    }

    private int _doDesId;
    public int DoDesId
    {
        get { return _doDesId; }
        set { _doDesId = value; }
    }

    private decimal _amount;
    public decimal Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }

    private string _status_d;
    public string Status_d
    {
        get { return _status_d; }
        set { _status_d = value; }
    }

    private DateTime  _startingDate;
    public DateTime  StartingDate
    {
        get { return _startingDate; }
        set { _startingDate = value; }
    }

    private DateTime   _endingDate;
    public DateTime   EndingDate
    {
        get { return _endingDate; }
        set { _endingDate = value; }
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
