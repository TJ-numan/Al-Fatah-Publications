using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_LoanAdvanceDetail
{
    public Li_LoanAdvanceDetail()
    {
    }

    public Li_LoanAdvanceDetail
        (
      
        int loAdDetId, 
        int loAdId, 
        DateTime tranDate, 
        decimal takenAmt, 
        decimal adjAmt, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
       
        this.LoAdDetId = loAdDetId;
        this.LoAdId = loAdId;
        this.TranDate = tranDate;
        this.TakenAmt = takenAmt;
        this.AdjAmt = adjAmt;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }

 

    private int _loAdDetId;
    public int LoAdDetId
    {
        get { return _loAdDetId; }
        set { _loAdDetId = value; }
    }

    private int _loAdId;
    public int LoAdId
    {
        get { return _loAdId; }
        set { _loAdId = value; }
    }

    private DateTime _tranDate;
    public DateTime TranDate
    {
        get { return _tranDate; }
        set { _tranDate = value; }
    }

    private decimal _takenAmt;
    public decimal TakenAmt
    {
        get { return _takenAmt; }
        set { _takenAmt = value; }
    }

    private decimal _adjAmt;
    public decimal AdjAmt
    {
        get { return _adjAmt; }
        set { _adjAmt = value; }
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

    private int _infStId;
    public int InfStId
    {
        get { return _infStId; }
        set { _infStId = value; }
    }
}
