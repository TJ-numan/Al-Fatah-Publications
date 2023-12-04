using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_LeaveApproval
{
    public Li_LeaveApproval()
    {
    }

    public Li_LeaveApproval
        (
         
        int approSl, 
        int leavSl, 
        int empSl, 
        int approEmpSl, 
        int resposibleEmpSl, 
        bool isApproved, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.ApproSl = approSl;
        this.LeavSl = leavSl;
        this.EmpSl = empSl;
        this.ApproEmpSl = approEmpSl;
        this.ResposibleEmpSl = resposibleEmpSl;
        this.IsApproved = isApproved;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


   

    private int _approSl;
    public int ApproSl
    {
        get { return _approSl; }
        set { _approSl = value; }
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

    private int _approEmpSl;
    public int ApproEmpSl
    {
        get { return _approEmpSl; }
        set { _approEmpSl = value; }
    }

    private int _resposibleEmpSl;
    public int ResposibleEmpSl
    {
        get { return _resposibleEmpSl; }
        set { _resposibleEmpSl = value; }
    }

    private bool _isApproved;
    public bool IsApproved
    {
        get { return _isApproved; }
        set { _isApproved = value; }
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
