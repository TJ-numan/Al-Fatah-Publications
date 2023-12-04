using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PFProfitDistribution
{
    public Li_PFProfitDistribution()
    {
    }

    public Li_PFProfitDistribution
        (
        
        int pDisId, 
        string refNo, 
        string disTitle, 
        int projectId, 
        decimal distriAmount, 
        decimal distriPercent, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.PDisId = pDisId;
        this.RefNo = refNo;
        this.DisTitle = disTitle;
        this.ProjectId = projectId;
        this.DistriAmount = distriAmount;
        this.DistriPercent = distriPercent;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _pDisId;
    public int PDisId
    {
        get { return _pDisId; }
        set { _pDisId = value; }
    }

    private string _refNo;
    public string RefNo
    {
        get { return _refNo; }
        set { _refNo = value; }
    }

    private string _disTitle;
    public string DisTitle
    {
        get { return _disTitle; }
        set { _disTitle = value; }
    }

    private int _projectId;
    public int ProjectId
    {
        get { return _projectId; }
        set { _projectId = value; }
    }

    private decimal _distriAmount;
    public decimal DistriAmount
    {
        get { return _distriAmount; }
        set { _distriAmount = value; }
    }

    private decimal _distriPercent;
    public decimal DistriPercent
    {
        get { return _distriPercent; }
        set { _distriPercent = value; }
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
