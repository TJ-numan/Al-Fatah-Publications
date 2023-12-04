using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpSalaryDetail
{
    public Li_EmpSalaryDetail()
    {
    }

    public Li_EmpSalaryDetail
        (
         
        int salDeId, 
        int salId, 
        int paHId, 
        decimal amount, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.SalDeId = salDeId;
        this.SalId = salId;
        this.PaHId = paHId;
        this.Amount = amount;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _salDeId;
    public int SalDeId
    {
        get { return _salDeId; }
        set { _salDeId = value; }
    }

    private int _salId;
    public int SalId
    {
        get { return _salId; }
        set { _salId = value; }
    }

    private int _paHId;
    public int PaHId
    {
        get { return _paHId; }
        set { _paHId = value; }
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
