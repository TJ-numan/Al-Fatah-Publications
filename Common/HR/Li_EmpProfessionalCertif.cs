using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpProfessionalCertif
{
    public Li_EmpProfessionalCertif()
    {
    }

    public Li_EmpProfessionalCertif
        (
         
        int proQuaId, 
        int empSl, 
        string certification, 
        string instituteName, 
        string location, 
        string certificationPeriod, 
        string certifPath, 
        bool isMembership, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
     
        this.ProQuaId = proQuaId;
        this.EmpSl = empSl;
        this.Certification = certification;
        this.InstituteName = instituteName;
        this.Location = location;
        this.CertificationPeriod = certificationPeriod;
        this.CertifPath = certifPath;
        this.IsMembership = isMembership;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _proQuaId;
    public int ProQuaId
    {
        get { return _proQuaId; }
        set { _proQuaId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private string _certification;
    public string Certification
    {
        get { return _certification; }
        set { _certification = value; }
    }

    private string _instituteName;
    public string InstituteName
    {
        get { return _instituteName; }
        set { _instituteName = value; }
    }

    private string _location;
    public string Location
    {
        get { return _location; }
        set { _location = value; }
    }

    private string _certificationPeriod;
    public string CertificationPeriod
    {
        get { return _certificationPeriod; }
        set { _certificationPeriod = value; }
    }

    private string _certifPath;
    public string CertifPath
    {
        get { return _certifPath; }
        set { _certifPath = value; }
    }

    private bool _isMembership;
    public bool IsMembership
    {
        get { return _isMembership; }
        set { _isMembership = value; }
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
