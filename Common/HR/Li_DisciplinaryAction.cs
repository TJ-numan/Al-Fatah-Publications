using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_DisciplinaryAction
{
    public Li_DisciplinaryAction()
    {
    }

    public Li_DisciplinaryAction
        (
        
        int disAcId, 
        int empSl, 
        int employmentStId, 
        string actionTitle, 
        string actionDes, 
        string acDocPath, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.DisAcId = disAcId;
        this.EmpSl = empSl;
        this.EmploymentStId = employmentStId;
        this.ActionTitle = actionTitle;
        this.ActionDes = actionDes;
        this.AcDocPath = acDocPath;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }

 

    private int _disAcId;
    public int DisAcId
    {
        get { return _disAcId; }
        set { _disAcId = value; }
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

    private string _actionTitle;
    public string ActionTitle
    {
        get { return _actionTitle; }
        set { _actionTitle = value; }
    }

    private string _actionDes;
    public string ActionDes
    {
        get { return _actionDes; }
        set { _actionDes = value; }
    }

    private string _acDocPath;
    public string AcDocPath
    {
        get { return _acDocPath; }
        set { _acDocPath = value; }
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
