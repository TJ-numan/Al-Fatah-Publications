using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpShiftMap
{
    public Li_EmpShiftMap()
    {
    }

    public Li_EmpShiftMap
        (
        
        int empMapId, 
        int empSl, 
        int shiftId, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.EmpMapId = empMapId;
        this.EmpSl = empSl;
        this.ShiftId = shiftId;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _empMapId;
    public int EmpMapId
    {
        get { return _empMapId; }
        set { _empMapId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private int _shiftId;
    public int ShiftId
    {
        get { return _shiftId; }
        set { _shiftId = value; }
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
