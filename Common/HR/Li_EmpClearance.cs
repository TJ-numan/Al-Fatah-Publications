using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpClearance
{
    public Li_EmpClearance()
    {
    }

    public Li_EmpClearance
        (
       
        int clearId, 
        int empSl, 
        int employmentStId, 
        string clearTitle, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.ClearId = clearId;
        this.EmpSl = empSl;
        this.EmploymentStId = employmentStId;
        this.ClearTitle = clearTitle;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _clearId;
    public int ClearId
    {
        get { return _clearId; }
        set { _clearId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private int _employmentStId;
    public int EmploymentStId
    {
        get { return _employmentStId; }
        set { _employmentStId = value; }
    }

    private string _clearTitle;
    public string ClearTitle
    {
        get { return _clearTitle; }
        set { _clearTitle = value; }
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
