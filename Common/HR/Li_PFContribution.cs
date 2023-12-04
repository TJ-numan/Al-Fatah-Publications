using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PFContribution
{
    public Li_PFContribution()
    {
    }

    public Li_PFContribution
        (
         
        int projectId, 
        string projectTitle, 
        DateTime projectStDate, 
        DateTime projectEnDate, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
         
        this.ProjectId = projectId;
        this.ProjectTitle = projectTitle;
        this.ProjectStDate = projectStDate;
        this.ProjectEnDate = projectEnDate;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }

 

    private int _projectId;
    public int ProjectId
    {
        get { return _projectId; }
        set { _projectId = value; }
    }

    private string _projectTitle;
    public string ProjectTitle
    {
        get { return _projectTitle; }
        set { _projectTitle = value; }
    }

    private DateTime _projectStDate;
    public DateTime ProjectStDate
    {
        get { return _projectStDate; }
        set { _projectStDate = value; }
    }

    private DateTime _projectEnDate;
    public DateTime ProjectEnDate
    {
        get { return _projectEnDate; }
        set { _projectEnDate = value; }
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
