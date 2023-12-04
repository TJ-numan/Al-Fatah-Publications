using System;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_VacancyReqApproval
{
    public Li_VacancyReqApproval()
    {
    }

    public Li_VacancyReqApproval
        (
        
        int appId, 
        int vacId, 
        int empSl, 
        bool isApproved, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
         
        this.AppId = appId;
        this.VacId = vacId;
        this.EmpSl = empSl;
        this.IsApproved = isApproved;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _appId;
    public int AppId
    {
        get { return _appId; }
        set { _appId = value; }
    }

    private int _vacId;
    public int VacId
    {
        get { return _vacId; }
        set { _vacId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private bool _isApproved;
    public bool IsApproved
    {
        get { return _isApproved; }
        set { _isApproved = value; }
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
