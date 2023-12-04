using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_Organogram
{
    public Li_Organogram()
    {
    }

    public Li_Organogram
        (
        
        int posId, 
        string posTitle, 
        int depId, 
        int desId, 
        int jobNaId, 
        bool isDefault, 
        int reportToPosId, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.PosId = posId;
        this.PosTitle = posTitle;
        this.DepId = depId;
        this.DesId = desId;
        this.JobNaId = jobNaId;
        this.IsDefault = isDefault;
        this.ReportToPosId = reportToPosId;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _posId;
    public int PosId
    {
        get { return _posId; }
        set { _posId = value; }
    }

    private string _posTitle;
    public string PosTitle
    {
        get { return _posTitle; }
        set { _posTitle = value; }
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

    private int _jobNaId;
    public int JobNaId
    {
        get { return _jobNaId; }
        set { _jobNaId = value; }
    }

    private bool _isDefault;
    public bool IsDefault
    {
        get { return _isDefault; }
        set { _isDefault = value; }
    }

    private int _reportToPosId;
    public int ReportToPosId
    {
        get { return _reportToPosId; }
        set { _reportToPosId = value; }
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
