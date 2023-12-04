using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_Goal
{
    public Li_Goal()
    {
    }

    public Li_Goal
        (
        
        int goalId, 
        string goalTitle, 
        string goalDes, 
        int depId, 
        int secId, 
        int empNo, 
        DateTime stDate, 
        DateTime enDate, 
        decimal amount, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
     
        this.GoalId = goalId;
        this.GoalTitle = goalTitle;
        this.GoalDes = goalDes;
        this.DepId = depId;
        this.SecId = secId;
        this.EmpNo = empNo;
        this.StDate = stDate;
        this.EnDate = enDate;
        this.Amount = amount;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _goalId;
    public int GoalId
    {
        get { return _goalId; }
        set { _goalId = value; }
    }

    private string _goalTitle;
    public string GoalTitle
    {
        get { return _goalTitle; }
        set { _goalTitle = value; }
    }

    private string _goalDes;
    public string GoalDes
    {
        get { return _goalDes; }
        set { _goalDes = value; }
    }

    private int _depId;
    public int DepId
    {
        get { return _depId; }
        set { _depId = value; }
    }

    private int _secId;
    public int SecId
    {
        get { return _secId; }
        set { _secId = value; }
    }

    private int _empNo;
    public int EmpNo
    {
        get { return _empNo; }
        set { _empNo = value; }
    }

    private DateTime _stDate;
    public DateTime StDate
    {
        get { return _stDate; }
        set { _stDate = value; }
    }

    private DateTime _enDate;
    public DateTime EnDate
    {
        get { return _enDate; }
        set { _enDate = value; }
    }

    private decimal _amount;
    public decimal Amount
    {
        get { return _amount; }
        set { _amount = value; }
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
