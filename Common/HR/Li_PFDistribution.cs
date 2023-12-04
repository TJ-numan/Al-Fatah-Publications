using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PFDistribution
{
    public Li_PFDistribution()
    {
    }

    public Li_PFDistribution
        (
         
        int disId, 
        int empSl, 
        string refNo, 
        string pFAcNo, 
        string tranPurpose, 
        DateTime tranDate, 
        decimal amount, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.DisId = disId;
        this.EmpSl = empSl;
        this.RefNo = refNo;
        this.PFAcNo = pFAcNo;
        this.TranPurpose = tranPurpose;
        this.TranDate = tranDate;
        this.Amount = amount;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _disId;
    public int DisId
    {
        get { return _disId; }
        set { _disId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private string _refNo;
    public string RefNo
    {
        get { return _refNo; }
        set { _refNo = value; }
    }

    private string _pFAcNo;
    public string PFAcNo
    {
        get { return _pFAcNo; }
        set { _pFAcNo = value; }
    }

    private string _tranPurpose;
    public string TranPurpose
    {
        get { return _tranPurpose; }
        set { _tranPurpose = value; }
    }

    private DateTime _tranDate;
    public DateTime TranDate
    {
        get { return _tranDate; }
        set { _tranDate = value; }
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
