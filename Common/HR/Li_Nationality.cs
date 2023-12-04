using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_Nationality
{
    public Li_Nationality()
    {
    }

    public Li_Nationality
        (
        
        int natiId, 
        string natiName, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
         
        this.NatiId = natiId;
        this.NatiName = natiName;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


    

    private int _natiId;
    public int NatiId
    {
        get { return _natiId; }
        set { _natiId = value; }
    }

    private string _natiName;
    public string NatiName
    {
        get { return _natiName; }
        set { _natiName = value; }
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
