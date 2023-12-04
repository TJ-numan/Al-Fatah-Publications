using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_SalaryDetail
{
    public Li_SalaryDetail()
    {
    }

    public Li_SalaryDetail
        (
        
        int salDetId, 
        int salaryId, 
        decimal paidAmt, 
        decimal returnAmt, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.SalDetId = salDetId;
        this.SalaryId = salaryId;
        this.PaidAmt = paidAmt;
        this.ReturnAmt = returnAmt;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _salDetId;
    public int SalDetId
    {
        get { return _salDetId; }
        set { _salDetId = value; }
    }

    private int _salaryId;
    public int SalaryId
    {
        get { return _salaryId; }
        set { _salaryId = value; }
    }

    private decimal _paidAmt;
    public decimal PaidAmt
    {
        get { return _paidAmt; }
        set { _paidAmt = value; }
    }

    private decimal _returnAmt;
    public decimal ReturnAmt
    {
        get { return _returnAmt; }
        set { _returnAmt = value; }
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
