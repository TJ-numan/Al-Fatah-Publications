using System;
using System.Data;
using System.Configuration;
using System.Linq;


public class Li_TeacherInfo
{
    public Li_TeacherInfo()
    {
    }

    public Li_TeacherInfo
        (
      

        int teacherId, 
        string teachderName, 
        int designationId, 
        string subjectName, 
        string madrasahName, 
        string mobileNo, 
        string paperSl, 
        int createdBy, 
        DateTime createdDate, 
        string territory, 
        string className, 
        string accTitle, 
        string accType, 
        string depositType, 
        string accNo, 
        string bankName, 
        string bankAddress, 
        string madrasahAdd,
        DateTime verifyDate
        )
    {
        

        this.TeacherId = teacherId;
        this.TeachderName = teachderName;
        this.DesignationId = designationId;
        this.SubjectName = subjectName;
        this.MadrasahName = madrasahName;
        this.MobileNo = mobileNo;
        this.PaperSl = paperSl;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.Territory = territory;
        this.ClassName = className;
        this.AccTitle = accTitle;
        this.AccType = accType;
        this.DepositType = depositType;
        this.AccNo = accNo;
        this.BankName = bankName;
        this.BankAddress = bankAddress;
        this.MadrasahAdd = madrasahAdd;
        this.VerifyDate = verifyDate;

    }




    private int _teacherId;
    public int TeacherId
    {
        get { return _teacherId; }
        set { _teacherId = value; }
    }

    private string _teachderName;
    public string TeachderName
    {
        get { return _teachderName; }
        set { _teachderName = value; }
    }

    private int _designationId;
    public int DesignationId
    {
        get { return _designationId; }
        set { _designationId = value; }
    }

    private string _subjectName;
    public string SubjectName
    {
        get { return _subjectName; }
        set { _subjectName = value; }
    }

    private string _madrasahName;
    public string MadrasahName
    {
        get { return _madrasahName; }
        set { _madrasahName = value; }
    }

    private string _mobileNo;
    public string MobileNo
    {
        get { return _mobileNo; }
        set { _mobileNo = value; }
    }

    private string _paperSl;
    public string PaperSl
    {
        get { return _paperSl; }
        set { _paperSl = value; }
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

    private string _territory;
    public string Territory
    {
        get { return _territory; }
        set { _territory = value; }
    }

    private string _className;
    public string ClassName
    {
        get { return _className; }
        set { _className = value; }
    }

    private string _accTitle;
    public string AccTitle
    {
        get { return _accTitle; }
        set { _accTitle = value; }
    }
    private string _accType;
    public string AccType
    {
        get { return _accType; }
        set { _accType = value; }
    }

    private string _depositType;
    public string DepositType
    {
        get { return _depositType; }
        set { _depositType = value; }
    }

    private string _accNo;
    public string AccNo
    {
        get { return _accNo; }
        set { _accNo = value; }
    }

    private string _bankName;
    public string BankName
    {
        get { return _bankName; }
        set { _bankName = value; }
    }

    private string _bankAddress;
    public string BankAddress
    {
        get { return _bankAddress; }
        set { _bankAddress = value; }
    }

    private string _madrasahAdd;
    public string MadrasahAdd
    {
        get { return _madrasahAdd; }
        set { _madrasahAdd = value; }
    }
    private DateTime _verifyDate;
    public DateTime VerifyDate
    {
        get { return _verifyDate; }
        set { _verifyDate = value; }
    }
}
