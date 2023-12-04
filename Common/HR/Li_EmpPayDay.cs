using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpPayDay
{
    public Li_EmpPayDay()
    {
    }

    public Li_EmpPayDay
        (
       
        int pDayCId, 
        string payTitle, 
        int totalEmpNo, 
        string payYear, 
        string payMonth, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.PDayCId = pDayCId;
        this.PayTitle = payTitle;
        this.TotalEmpNo = totalEmpNo;
        this.PayYear = payYear;
        this.PayMonth = payMonth;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _pDayCId;
    public int PDayCId
    {
        get { return _pDayCId; }
        set { _pDayCId = value; }
    }

    private string _payTitle;
    public string PayTitle
    {
        get { return _payTitle; }
        set { _payTitle = value; }
    }

    private int _totalEmpNo;
    public int TotalEmpNo
    {
        get { return _totalEmpNo; }
        set { _totalEmpNo = value; }
    }

    private string _payYear;
    public string PayYear
    {
        get { return _payYear; }
        set { _payYear = value; }
    }

    private string _payMonth;
    public string PayMonth
    {
        get { return _payMonth; }
        set { _payMonth = value; }
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
