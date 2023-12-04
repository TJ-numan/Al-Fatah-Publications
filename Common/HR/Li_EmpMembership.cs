using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpMembership
{
    public Li_EmpMembership()
    {
    }

    public Li_EmpMembership
        (
        
        int memId, 
        int empSl, 
        string membership, 
        string subPaidBy, 
        string subsFee, 
        string currency, 
        DateTime subsCommenceDate, 
        DateTime subsReDate, 
        string memDes, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.MemId = memId;
        this.EmpSl = empSl;
        this.Membership = membership;
        this.SubPaidBy = subPaidBy;
        this.SubsFee = subsFee;
        this.Currency = currency;
        this.SubsCommenceDate = subsCommenceDate;
        this.SubsReDate = subsReDate;
        this.MemDes = memDes;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _memId;
    public int MemId
    {
        get { return _memId; }
        set { _memId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private string _membership;
    public string Membership
    {
        get { return _membership; }
        set { _membership = value; }
    }

    private string _subPaidBy;
    public string SubPaidBy
    {
        get { return _subPaidBy; }
        set { _subPaidBy = value; }
    }

    private string _subsFee;
    public string SubsFee
    {
        get { return _subsFee; }
        set { _subsFee = value; }
    }

    private string _currency;
    public string Currency
    {
        get { return _currency; }
        set { _currency = value; }
    }

    private DateTime _subsCommenceDate;
    public DateTime SubsCommenceDate
    {
        get { return _subsCommenceDate; }
        set { _subsCommenceDate = value; }
    }

    private DateTime _subsReDate;
    public DateTime SubsReDate
    {
        get { return _subsReDate; }
        set { _subsReDate = value; }
    }

    private string _memDes;
    public string MemDes
    {
        get { return _memDes; }
        set { _memDes = value; }
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
