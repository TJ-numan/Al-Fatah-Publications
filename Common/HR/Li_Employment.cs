using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_Employment
{
    public Li_Employment()
    {
    }

    public Li_Employment
        (
        
        int experId, 
        int empSl, 
        string compName, 
        string compBusiness, 
        string designation, 
        string department, 
        string responsibilities, 
        string comLocation, 
        string employPeriod, 
        bool isCurrentlyWorking, 
        string areaOfExperi, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
   
        this.ExperId = experId;
        this.EmpSl = empSl;
        this.CompName = compName;
        this.CompBusiness = compBusiness;
        this.Designation = designation;
        this.Department = department;
        this.Responsibilities = responsibilities;
        this.ComLocation = comLocation;
        this.EmployPeriod = employPeriod;
        this.IsCurrentlyWorking = isCurrentlyWorking;
        this.AreaOfExperi = areaOfExperi;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _experId;
    public int ExperId
    {
        get { return _experId; }
        set { _experId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private string _compName;
    public string CompName
    {
        get { return _compName; }
        set { _compName = value; }
    }

    private string _compBusiness;
    public string CompBusiness
    {
        get { return _compBusiness; }
        set { _compBusiness = value; }
    }

    private string _designation;
    public string Designation
    {
        get { return _designation; }
        set { _designation = value; }
    }

    private string _department;
    public string Department
    {
        get { return _department; }
        set { _department = value; }
    }

    private string _responsibilities;
    public string Responsibilities
    {
        get { return _responsibilities; }
        set { _responsibilities = value; }
    }

    private string _comLocation;
    public string ComLocation
    {
        get { return _comLocation; }
        set { _comLocation = value; }
    }

    private string _employPeriod;
    public string EmployPeriod
    {
        get { return _employPeriod; }
        set { _employPeriod = value; }
    }

    private bool _isCurrentlyWorking;
    public bool IsCurrentlyWorking
    {
        get { return _isCurrentlyWorking; }
        set { _isCurrentlyWorking = value; }
    }

    private string _areaOfExperi;
    public string AreaOfExperi
    {
        get { return _areaOfExperi; }
        set { _areaOfExperi = value; }
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
