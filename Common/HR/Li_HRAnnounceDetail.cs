using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_HRAnnounceDetail
{
    public Li_HRAnnounceDetail()
    {
    }

    public Li_HRAnnounceDetail
        (
        
        int annDetId, 
        int empSl, 
        bool isPubAllow, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
 
        this.AnnDetId = annDetId;
        this.EmpSl = empSl;
        this.IsPubAllow = isPubAllow;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _annDetId;
    public int AnnDetId
    {
        get { return _annDetId; }
        set { _annDetId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private bool _isPubAllow;
    public bool IsPubAllow
    {
        get { return _isPubAllow; }
        set { _isPubAllow = value; }
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
