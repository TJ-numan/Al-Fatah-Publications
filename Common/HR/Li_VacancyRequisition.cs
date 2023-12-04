using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_VacancyRequisition
{
    public Li_VacancyRequisition()
    {
    }

    public Li_VacancyRequisition
        (
        
        int vacId, 
        string vacTitle, 
        int posId, 
        int vacForId, 
        int empTypeId, 
        string qualification, 
        string experience, 
        string requiredTime, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
       
        this.VacId = vacId;
        this.VacTitle = vacTitle;
        this.PosId = posId;
        this.VacForId = vacForId;
        this.EmpTypeId = empTypeId;
        this.Qualification = qualification;
        this.Experience = experience;
        this.RequiredTime = requiredTime;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _vacId;
    public int VacId
    {
        get { return _vacId; }
        set { _vacId = value; }
    }

    private string _vacTitle;
    public string VacTitle
    {
        get { return _vacTitle; }
        set { _vacTitle = value; }
    }

    private int _posId;
    public int PosId
    {
        get { return _posId; }
        set { _posId = value; }
    }

    private int _vacForId;
    public int VacForId
    {
        get { return _vacForId; }
        set { _vacForId = value; }
    }

    private int _empTypeId;
    public int EmpTypeId
    {
        get { return _empTypeId; }
        set { _empTypeId = value; }
    }

    private string _qualification;
    public string Qualification
    {
        get { return _qualification; }
        set { _qualification = value; }
    }

    private string _experience;
    public string Experience
    {
        get { return _experience; }
        set { _experience = value; }
    }

    private string _requiredTime;
    public string RequiredTime
    {
        get { return _requiredTime; }
        set { _requiredTime = value; }
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
