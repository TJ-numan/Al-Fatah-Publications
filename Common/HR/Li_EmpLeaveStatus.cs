using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpLeaveStatus
{
    public Li_EmpLeaveStatus()
    {
    }

    public Li_EmpLeaveStatus
        (
        
        int empLeEnId, 
        int empSl, 
        int perId, 
        int leTypId, 
        decimal alotment, 
        decimal leaveTaken, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
         
        this.EmpLeEnId = empLeEnId;
        this.EmpSl = empSl;
        this.PerId = perId;
        this.LeTypId = leTypId;
        this.Alotment = alotment;
        this.LeaveTaken = leaveTaken;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _empLeEnId;
    public int EmpLeEnId
    {
        get { return _empLeEnId; }
        set { _empLeEnId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private int _perId;
    public int PerId
    {
        get { return _perId; }
        set { _perId = value; }
    }

    private int _leTypId;
    public int LeTypId
    {
        get { return _leTypId; }
        set { _leTypId = value; }
    }

    private decimal _alotment;
    public decimal Alotment
    {
        get { return _alotment; }
        set { _alotment = value; }
    }

    private decimal _leaveTaken;
    public decimal LeaveTaken
    {
        get { return _leaveTaken; }
        set { _leaveTaken = value; }
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
