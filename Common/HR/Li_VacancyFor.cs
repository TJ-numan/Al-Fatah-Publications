using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_VacancyFor
{
    public Li_VacancyFor()
    {
    }

    public Li_VacancyFor
        (
        
        int vacForId, 
        string vacForName, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.VacForId = vacForId;
        this.VacForName = vacForName;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _vacForId;
    public int VacForId
    {
        get { return _vacForId; }
        set { _vacForId = value; }
    }

    private string _vacForName;
    public string VacForName
    {
        get { return _vacForName; }
        set { _vacForName = value; }
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
