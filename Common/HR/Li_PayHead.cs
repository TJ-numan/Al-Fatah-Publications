using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PayHead
{
    public Li_PayHead()
    {
    }

    public Li_PayHead
        (
        
        int paHId, 
        string paHName, 
        bool isExcluedGross, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
       
        this.PaHId = paHId;
        this.PaHName = paHName;
        this.IsExcluedGross = isExcluedGross;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 
    private int _paHId;
    public int PaHId
    {
        get { return _paHId; }
        set { _paHId = value; }
    }

    private string _paHName;
    public string PaHName
    {
        get { return _paHName; }
        set { _paHName = value; }
    }

    private bool _isExcluedGross;
    public bool IsExcluedGross
    {
        get { return _isExcluedGross; }
        set { _isExcluedGross = value; }
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
