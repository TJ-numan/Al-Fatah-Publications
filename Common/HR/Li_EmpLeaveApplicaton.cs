using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpLeaveApplicaton
{
    public Li_EmpLeaveApplicaton()
    {
    }

    public Li_EmpLeaveApplicaton
        (
        
        int leavSl, 
        int empSl, 
        int leTypId, 
        DateTime leStDate, 
        DateTime leEnDate, 
        decimal leQty, 
        bool isDay, 
        bool isHalfDay, 
        bool isHour, 
        string leCause, 
        string conAddNPhone, 
        int resposibleEmpSl, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
   
        this.LeavSl = leavSl;
        this.EmpSl = empSl;
        this.LeTypId = leTypId;
        this.LeStDate = leStDate;
        this.LeEnDate = leEnDate;
        this.LeQty = leQty;
        this.IsDay = isDay;
        this.IsHalfDay = isHalfDay;
        this.IsHour = isHour;
        this.LeCause = leCause;
        this.ConAddNPhone = conAddNPhone;
        this.ResposibleEmpSl = resposibleEmpSl;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }

 
    private int _leavSl;
    public int LeavSl
    {
        get { return _leavSl; }
        set { _leavSl = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private int _leTypId;
    public int LeTypId
    {
        get { return _leTypId; }
        set { _leTypId = value; }
    }

    private DateTime _leStDate;
    public DateTime LeStDate
    {
        get { return _leStDate; }
        set { _leStDate = value; }
    }

    private DateTime _leEnDate;
    public DateTime LeEnDate
    {
        get { return _leEnDate; }
        set { _leEnDate = value; }
    }

    private decimal _leQty;
    public decimal LeQty
    {
        get { return _leQty; }
        set { _leQty = value; }
    }

    private bool _isDay;
    public bool IsDay
    {
        get { return _isDay; }
        set { _isDay = value; }
    }

    private bool _isHalfDay;
    public bool IsHalfDay
    {
        get { return _isHalfDay; }
        set { _isHalfDay = value; }
    }

    private bool _isHour;
    public bool IsHour
    {
        get { return _isHour; }
        set { _isHour = value; }
    }

    private string _leCause;
    public string LeCause
    {
        get { return _leCause; }
        set { _leCause = value; }
    }

    private string _conAddNPhone;
    public string ConAddNPhone
    {
        get { return _conAddNPhone; }
        set { _conAddNPhone = value; }
    }

    private int _resposibleEmpSl;
    public int ResposibleEmpSl
    {
        get { return _resposibleEmpSl; }
        set { _resposibleEmpSl = value; }
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
