using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpIncrePromoTran
{
    public Li_EmpIncrePromoTran()
    {
    }

    public Li_EmpIncrePromoTran
        (
       
        int inPrTrId, 
        int empSl, 
        int preDepId, 
        int preDesId, 
        int preSecId, 
        int prePayGrId, 
        int prePScId, 
        int employmentStId, 
        string comments, 
        int curDepId, 
        int curDesId, 
        int curSecId, 
        int curPayGrId, 
        int curPScId, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.InPrTrId = inPrTrId;
        this.EmpSl = empSl;
        this.PreDepId = preDepId;
        this.PreDesId = preDesId;
        this.PreSecId = preSecId;
        this.PrePayGrId = prePayGrId;
        this.PrePScId = prePScId;
        this.EmploymentStId = employmentStId;
        this.Comments = comments;
        this.CurDepId = curDepId;
        this.CurDesId = curDesId;
        this.CurSecId = curSecId;
        this.CurPayGrId = curPayGrId;
        this.CurPScId = curPScId;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _inPrTrId;
    public int InPrTrId
    {
        get { return _inPrTrId; }
        set { _inPrTrId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private int _preDepId;
    public int PreDepId
    {
        get { return _preDepId; }
        set { _preDepId = value; }
    }

    private int _preDesId;
    public int PreDesId
    {
        get { return _preDesId; }
        set { _preDesId = value; }
    }

    private int _preSecId;
    public int PreSecId
    {
        get { return _preSecId; }
        set { _preSecId = value; }
    }

    private int _prePayGrId;
    public int PrePayGrId
    {
        get { return _prePayGrId; }
        set { _prePayGrId = value; }
    }

    private int _prePScId;
    public int PrePScId
    {
        get { return _prePScId; }
        set { _prePScId = value; }
    }

    private int _employmentStId;
    public int EmploymentStId
    {
        get { return _employmentStId; }
        set { _employmentStId = value; }
    }

    private string _comments;
    public string Comments
    {
        get { return _comments; }
        set { _comments = value; }
    }

    private int _curDepId;
    public int CurDepId
    {
        get { return _curDepId; }
        set { _curDepId = value; }
    }

    private int _curDesId;
    public int CurDesId
    {
        get { return _curDesId; }
        set { _curDesId = value; }
    }

    private int _curSecId;
    public int CurSecId
    {
        get { return _curSecId; }
        set { _curSecId = value; }
    }

    private int _curPayGrId;
    public int CurPayGrId
    {
        get { return _curPayGrId; }
        set { _curPayGrId = value; }
    }

    private int _curPScId;
    public int CurPScId
    {
        get { return _curPScId; }
        set { _curPScId = value; }
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
