using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_CompetencyMap
{
    public Li_CompetencyMap()
    {
    }

    public Li_CompetencyMap
        (
       
        int coMapId, 
        int compeId, 
        int empSl, 
        decimal weight, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
     
        this.CoMapId = coMapId;
        this.CompeId = compeId;
        this.EmpSl = empSl;
        this.Weight = weight;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _coMapId;
    public int CoMapId
    {
        get { return _coMapId; }
        set { _coMapId = value; }
    }

    private int _compeId;
    public int CompeId
    {
        get { return _compeId; }
        set { _compeId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private decimal _weight;
    public decimal Weight
    {
        get { return _weight; }
        set { _weight = value; }
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
