using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_AttnPolicy
{
    public Li_AttnPolicy()
    {
    }

    public Li_AttnPolicy
        (
 
        int poliId, 
        string poliName, 
        string poliDes, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
       
        this.PoliId = poliId;
        this.PoliName = poliName;
        this.PoliDes = poliDes;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }

 
    private int _poliId;
    public int PoliId
    {
        get { return _poliId; }
        set { _poliId = value; }
    }

    private string _poliName;
    public string PoliName
    {
        get { return _poliName; }
        set { _poliName = value; }
    }

    private string _poliDes;
    public string PoliDes
    {
        get { return _poliDes; }
        set { _poliDes = value; }
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
