using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_DonationAmt
{
    public Li_DonationAmt()
    {
    }

    public Li_DonationAmt
        (
  
        int slNo, 
        int detId, 
        int doDesId, 
        decimal amount, 
        int createdBy, 
        DateTime createdDate
        )
    {
       
        this.SlNo = slNo;
        this.DetId = detId;
        this.DoDesId = doDesId;
        this.Amount = amount;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
    }


 
    private int _slNo;
    public int SlNo
    {
        get { return _slNo; }
        set { _slNo = value; }
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
