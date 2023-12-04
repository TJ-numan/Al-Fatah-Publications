using System;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_PayScale
{
    public Li_PayScale()
    {
    }

    public Li_PayScale
        (
  
        int pScId, 
        int payGrId, 
        decimal pSAmt, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
      
        this.PScId = pScId;
        this.PayGrId = payGrId;
        this.PSAmt = pSAmt;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _pScId;
    public int PScId
    {
        get { return _pScId; }
        set { _pScId = value; }
    }

    private int _payGrId;
    public int PayGrId
    {
        get { return _payGrId; }
        set { _payGrId = value; }
    }

    private decimal _pSAmt;
    public decimal PSAmt
    {
        get { return _pSAmt; }
        set { _pSAmt = value; }
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
