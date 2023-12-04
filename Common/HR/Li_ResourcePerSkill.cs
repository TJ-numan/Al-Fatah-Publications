using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_ResourcePerSkill
{
    public Li_ResourcePerSkill()
    {
    }

    public Li_ResourcePerSkill
        (
        
        int resoProfId, 
        int resoPId, 
        string resoSkill, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.ResoProfId = resoProfId;
        this.ResoPId = resoPId;
        this.ResoSkill = resoSkill;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _resoProfId;
    public int ResoProfId
    {
        get { return _resoProfId; }
        set { _resoProfId = value; }
    }

    private int _resoPId;
    public int ResoPId
    {
        get { return _resoPId; }
        set { _resoPId = value; }
    }

    private string _resoSkill;
    public string ResoSkill
    {
        get { return _resoSkill; }
        set { _resoSkill = value; }
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
