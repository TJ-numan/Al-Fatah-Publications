using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_SalaryPayDetail
{
    public Li_SalaryPayDetail()
    {
    }

    public Li_SalaryPayDetail
        (
        
        int salPayId, 
        int salaryId, 
        int empSl, 
        int pDayDetId, 
        int paHId, 
        decimal fixedAmt, 
        decimal paidAmt, 
        decimal deductAmt, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
     
        this.SalPayId = salPayId;
        this.SalaryId = salaryId;
        this.EmpSl = empSl;
        this.PDayDetId = pDayDetId;
        this.PaHId = paHId;
        this.FixedAmt = fixedAmt;
        this.PaidAmt = paidAmt;
        this.DeductAmt = deductAmt;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _salPayId;
    public int SalPayId
    {
        get { return _salPayId; }
        set { _salPayId = value; }
    }

    private int _salaryId;
    public int SalaryId
    {
        get { return _salaryId; }
        set { _salaryId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private int _pDayDetId;
    public int PDayDetId
    {
        get { return _pDayDetId; }
        set { _pDayDetId = value; }
    }

    private int _paHId;
    public int PaHId
    {
        get { return _paHId; }
        set { _paHId = value; }
    }

    private decimal _fixedAmt;
    public decimal FixedAmt
    {
        get { return _fixedAmt; }
        set { _fixedAmt = value; }
    }

    private decimal _paidAmt;
    public decimal PaidAmt
    {
        get { return _paidAmt; }
        set { _paidAmt = value; }
    }

    private decimal _deductAmt;
    public decimal DeductAmt
    {
        get { return _deductAmt; }
        set { _deductAmt = value; }
    }

    private string _comments;
    public string Comments
    {
        get { return _comments; }
        set { _comments = value; }
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
