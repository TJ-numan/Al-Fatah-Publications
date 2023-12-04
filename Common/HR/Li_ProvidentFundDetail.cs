using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_ProvidentFundDetail
{
    public Li_ProvidentFundDetail()
    {
    }

    public Li_ProvidentFundDetail
        (
       
        int pFDetId, 
        int pFId, 
        int empSl, 
        decimal ePFAmt, 
        decimal comAmt, 
        decimal profitAmt, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.PFDetId = pFDetId;
        this.PFId = pFId;
        this.EmpSl = empSl;
        this.EPFAmt = ePFAmt;
        this.ComAmt = comAmt;
        this.ProfitAmt = profitAmt;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }

 

    private int _pFDetId;
    public int PFDetId
    {
        get { return _pFDetId; }
        set { _pFDetId = value; }
    }

    private int _pFId;
    public int PFId
    {
        get { return _pFId; }
        set { _pFId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private decimal _ePFAmt;
    public decimal EPFAmt
    {
        get { return _ePFAmt; }
        set { _ePFAmt = value; }
    }

    private decimal _comAmt;
    public decimal ComAmt
    {
        get { return _comAmt; }
        set { _comAmt = value; }
    }

    private decimal _profitAmt;
    public decimal ProfitAmt
    {
        get { return _profitAmt; }
        set { _profitAmt = value; }
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
