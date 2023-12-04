using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpEducation
{
    public Li_EmpEducation()
    {
    }

    public Li_EmpEducation
        (
       
        int eduId, 
        int empSl, 
        int eduLId, 
        int examId, 
        int eduReId, 
        string majorOrGroup, 
        string passYr, 
        string certifPath, 
        string instituteName, 
        bool isForeign, 
        string achievement, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.EduId = eduId;
        this.EmpSl = empSl;
        this.EduLId = eduLId;
        this.ExamId = examId;
        this.EduReId = eduReId;
        this.MajorOrGroup = majorOrGroup;
        this.PassYr = passYr;
        this.CertifPath = certifPath;
        this.InstituteName = instituteName;
        this.IsForeign = isForeign;
        this.Achievement = achievement;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


   

    private int _eduId;
    public int EduId
    {
        get { return _eduId; }
        set { _eduId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private int _eduLId;
    public int EduLId
    {
        get { return _eduLId; }
        set { _eduLId = value; }
    }

    private int _examId;
    public int ExamId
    {
        get { return _examId; }
        set { _examId = value; }
    }

    private int _eduReId;
    public int EduReId
    {
        get { return _eduReId; }
        set { _eduReId = value; }
    }

    private string _majorOrGroup;
    public string MajorOrGroup
    {
        get { return _majorOrGroup; }
        set { _majorOrGroup = value; }
    }

    private string _passYr;
    public string PassYr
    {
        get { return _passYr; }
        set { _passYr = value; }
    }

    private string _certifPath;
    public string CertifPath
    {
        get { return _certifPath; }
        set { _certifPath = value; }
    }

    private string _instituteName;
    public string InstituteName
    {
        get { return _instituteName; }
        set { _instituteName = value; }
    }

    private bool _isForeign;
    public bool IsForeign
    {
        get { return _isForeign; }
        set { _isForeign = value; }
    }

    private string _achievement;
    public string Achievement
    {
        get { return _achievement; }
        set { _achievement = value; }
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
