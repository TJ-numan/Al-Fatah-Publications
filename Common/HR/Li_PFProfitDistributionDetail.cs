using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PFProfitDistributionDetail
{
    public Li_PFProfitDistributionDetail()
    {
    }

    public Li_PFProfitDistributionDetail
        (
         
        int pDisDet, 
        int pDisId, 
        int empSl, 
        decimal pFAmount, 
        decimal proPercentage, 
        decimal proAmt, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.PDisDet = pDisDet;
        this.PDisId = pDisId;
        this.EmpSl = empSl;
        this.PFAmount = pFAmount;
        this.ProPercentage = proPercentage;
        this.ProAmt = proAmt;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _pDisDet;
    public int PDisDet
    {
        get { return _pDisDet; }
        set { _pDisDet = value; }
    }

    private int _pDisId;
    public int PDisId
    {
        get { return _pDisId; }
        set { _pDisId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private decimal _pFAmount;
    public decimal PFAmount
    {
        get { return _pFAmount; }
        set { _pFAmount = value; }
    }

    private decimal _proPercentage;
    public decimal ProPercentage
    {
        get { return _proPercentage; }
        set { _proPercentage = value; }
    }

    private decimal _proAmt;
    public decimal ProAmt
    {
        get { return _proAmt; }
        set { _proAmt = value; }
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
