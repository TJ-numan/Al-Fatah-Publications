using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_VacancyTemplate
{
    public Li_VacancyTemplate()
    {
    }

    public Li_VacancyTemplate
        (
       
        int vacTemId, 
        int posId, 
        string temPath, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.VacTemId = vacTemId;
        this.PosId = posId;
        this.TemPath = temPath;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }

 
    private int _vacTemId;
    public int VacTemId
    {
        get { return _vacTemId; }
        set { _vacTemId = value; }
    }

    private int _posId;
    public int PosId
    {
        get { return _posId; }
        set { _posId = value; }
    }

    private string _temPath;
    public string TemPath
    {
        get { return _temPath; }
        set { _temPath = value; }
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
