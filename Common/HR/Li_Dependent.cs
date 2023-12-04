using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_Dependent
{
    public Li_Dependent()
    {
    }

    public Li_Dependent
        (
       
        int depenId, 
        string depenName, 
        int empSl, 
        string relation, 
        DateTime doB, 
        string certificateNo, 
        string certifPath, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.DepenId = depenId;
        this.DepenName = depenName;
        this.EmpSl = empSl;
        this.Relation = relation;
        this.DoB = doB;
        this.CertificateNo = certificateNo;
        this.CertifPath = certifPath;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _depenId;
    public int DepenId
    {
        get { return _depenId; }
        set { _depenId = value; }
    }

    private string _depenName;
    public string DepenName
    {
        get { return _depenName; }
        set { _depenName = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private string _relation;
    public string Relation
    {
        get { return _relation; }
        set { _relation = value; }
    }

    private DateTime _doB;
    public DateTime DoB
    {
        get { return _doB; }
        set { _doB = value; }
    }

    private string _certificateNo;
    public string CertificateNo
    {
        get { return _certificateNo; }
        set { _certificateNo = value; }
    }

    private string _certifPath;
    public string CertifPath
    {
        get { return _certifPath; }
        set { _certifPath = value; }
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
