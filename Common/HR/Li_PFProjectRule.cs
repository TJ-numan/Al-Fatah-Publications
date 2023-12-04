using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PFProjectRule
{
    public Li_PFProjectRule()
    {
    }

    public Li_PFProjectRule
        (
       
        int proRulId, 
        int projectId, 
        string proRuleName, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
       
        this.ProRulId = proRulId;
        this.ProjectId = projectId;
        this.ProRuleName = proRuleName;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _proRulId;
    public int ProRulId
    {
        get { return _proRulId; }
        set { _proRulId = value; }
    }

    private int _projectId;
    public int ProjectId
    {
        get { return _projectId; }
        set { _projectId = value; }
    }

    private string _proRuleName;
    public string ProRuleName
    {
        get { return _proRuleName; }
        set { _proRuleName = value; }
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
