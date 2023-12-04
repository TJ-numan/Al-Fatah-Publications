using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_GoalDetail
{
    public Li_GoalDetail()
    {
    }

    public Li_GoalDetail
        (
        
        string goalDetId, 
        int goalId, 
        int empSl, 
        string workDetail, 
        bool isTeamLead, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
      
        this.GoalDetId = goalDetId;
        this.GoalId = goalId;
        this.EmpSl = empSl;
        this.WorkDetail = workDetail;
        this.IsTeamLead = isTeamLead;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private string _goalDetId;
    public string GoalDetId
    {
        get { return _goalDetId; }
        set { _goalDetId = value; }
    }

    private int _goalId;
    public int GoalId
    {
        get { return _goalId; }
        set { _goalId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private string _workDetail;
    public string WorkDetail
    {
        get { return _workDetail; }
        set { _workDetail = value; }
    }

    private bool _isTeamLead;
    public bool IsTeamLead
    {
        get { return _isTeamLead; }
        set { _isTeamLead = value; }
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
