using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmployeeInfo
{
    public Li_EmployeeInfo()
    {
    }

    public Li_EmployeeInfo
        (
        
        int empSl, 
        string iDNo, 
        string proximityNo, 
        string empName, 
        string empNameBn, 
        string nickName, 
        int depId, 
        int desId, 
        int secId, 
        int genId, 
        int bGId, 
        int regId, 
        int employmentStId, 
        int reportTo, 
        DateTime joiningDate, 
        DateTime dateOfBirth, 
        decimal empAge, 
        string phoneNo, 
        byte[] imgPath, 
        byte[] signPath, 
        string fName, 
        string mName, 
        int marStId, 
        string sName, 
        string preAdd, 
        int preThanaId, 
        int preDistrictId, 
        string perAdd, 
        int perThanaId, 
        int perDistrictId, 
        int  natiId, 
        string emailAdd, 
        byte[] cvPath, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId,
        string nid,
        int jobTitleId
        )
    {
        
        this.EmpSl = empSl;
        this.IDNo = iDNo;
        this.ProximityNo = proximityNo;
        this.EmpName = empName;
        this.EmpNameBn = empNameBn;
        this.NickName = nickName;
        this.DepId = depId;
        this.DesId = desId;
        this.SecId = secId;
        this.GenId = genId;
        this.BGId = bGId;
        this.RegId = regId;
        this.EmploymentStId = employmentStId;
        this.ReportTo = reportTo;
        this.JoiningDate = joiningDate;
        this.DateOfBirth = dateOfBirth;
        this.EmpAge = empAge;
        this.PhoneNo = phoneNo;
        this.ImgPath = imgPath;
        this.SignPath = signPath;
        this.FName = fName;
        this.MName = mName;
        this.MarStId = marStId;
        this.SName = sName;
        this.PreAdd = preAdd;
        this.PreThanaId = preThanaId;
        this.PreDistrictId = preDistrictId;
        this.PerAdd = perAdd;
        this.PerThanaId = perThanaId;
        this.PerDistrictId = perDistrictId;
        this.NatiId = natiId;
        this.EmailAdd = emailAdd;
        this.CvPath = cvPath;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
        this.NID = nid;
        this.JobTitleId = jobTitleId;
    }

    public string NID { get; set; }
    public int JobTitleId { get; set; }

 
    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private string _iDNo;
    public string IDNo
    {
        get { return _iDNo; }
        set { _iDNo = value; }
    }

    private string _proximityNo;
    public string ProximityNo
    {
        get { return _proximityNo; }
        set { _proximityNo = value; }
    }

    private string _empName;
    public string EmpName
    {
        get { return _empName; }
        set { _empName = value; }
    }

    private string _empNameBn;
    public string EmpNameBn
    {
        get { return _empNameBn; }
        set { _empNameBn = value; }
    }

    private string _nickName;
    public string NickName
    {
        get { return _nickName; }
        set { _nickName = value; }
    }

    private int _depId;
    public int DepId
    {
        get { return _depId; }
        set { _depId = value; }
    }

    private int _desId;
    public int DesId
    {
        get { return _desId; }
        set { _desId = value; }
    }

    private int _secId;
    public int SecId
    {
        get { return _secId; }
        set { _secId = value; }
    }

    private int _genId;
    public int GenId
    {
        get { return _genId; }
        set { _genId = value; }
    }

    private int _bGId;
    public int BGId
    {
        get { return _bGId; }
        set { _bGId = value; }
    }

    private int _regId;
    public int RegId
    {
        get { return _regId; }
        set { _regId = value; }
    }

    private int _employmentStId;
    public int EmploymentStId
    {
        get { return _employmentStId; }
        set { _employmentStId = value; }
    }

    private int _reportTo;
    public int ReportTo
    {
        get { return _reportTo; }
        set { _reportTo = value; }
    }

    private DateTime _joiningDate;
    public DateTime JoiningDate
    {
        get { return _joiningDate; }
        set { _joiningDate = value; }
    }

    private DateTime _dateOfBirth;
    public DateTime DateOfBirth
    {
        get { return _dateOfBirth; }
        set { _dateOfBirth = value; }
    }

    private decimal _empAge;
    public decimal EmpAge
    {
        get { return _empAge; }
        set { _empAge = value; }
    }

    private string _phoneNo;
    public string PhoneNo
    {
        get { return _phoneNo; }
        set { _phoneNo = value; }
    }


    public byte[] ImgPath { get; set; }





    public byte[] SignPath { get; set; }
     

    private string _fName;
    public string FName
    {
        get { return _fName; }
        set { _fName = value; }
    }

    private string _mName;
    public string MName
    {
        get { return _mName; }
        set { _mName = value; }
    }

    private int _marStId;
    public int MarStId
    {
        get { return _marStId; }
        set { _marStId = value; }
    }

    private string _sName;
    public string SName
    {
        get { return _sName; }
        set { _sName = value; }
    }

    private string _preAdd;
    public string PreAdd
    {
        get { return _preAdd; }
        set { _preAdd = value; }
    }

    private int _preThanaId;
    public int PreThanaId
    {
        get { return _preThanaId; }
        set { _preThanaId = value; }
    }

    private int _preDistrictId;
    public int PreDistrictId
    {
        get { return _preDistrictId; }
        set { _preDistrictId = value; }
    }

    private string _perAdd;
    public string PerAdd
    {
        get { return _perAdd; }
        set { _perAdd = value; }
    }

    private int _perThanaId;
    public int PerThanaId
    {
        get { return _perThanaId; }
        set { _perThanaId = value; }
    }

    private int _perDistrictId;
    public int PerDistrictId
    {
        get { return _perDistrictId; }
        set { _perDistrictId = value; }
    }

    private int  _natiId;
    public int   NatiId
    {
        get { return _natiId; }
        set { _natiId = value; }
    }

    private string _emailAdd;
    public string EmailAdd
    {
        get { return _emailAdd; }
        set { _emailAdd = value; }
    }


    public byte[] CvPath   { get;   set;  }

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
