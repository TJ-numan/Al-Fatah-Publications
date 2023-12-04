using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_VacancyAnounce
{
    public Li_VacancyAnounce()
    {
    }

    public Li_VacancyAnounce
        (
         
        int vacAnId, 
        int vacId, 
        int vacTemId, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.VacAnId = vacAnId;
        this.VacId = vacId;
        this.VacTemId = vacTemId;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _vacAnId;
    public int VacAnId
    {
        get { return _vacAnId; }
        set { _vacAnId = value; }
    }

    private int _vacId;
    public int VacId
    {
        get { return _vacId; }
        set { _vacId = value; }
    }

    private int _vacTemId;
    public int VacTemId
    {
        get { return _vacTemId; }
        set { _vacTemId = value; }
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
