using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpLanguage
{
    public Li_EmpLanguage()
    {
    }

    public Li_EmpLanguage
        (
      
        int lanId, 
        int empSl, 
        string language, 
        string reading, 
        string writing, 
        string speaking, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.LanId = lanId;
        this.EmpSl = empSl;
        this.Language = language;
        this.Reading = reading;
        this.Writing = writing;
        this.Speaking = speaking;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _lanId;
    public int LanId
    {
        get { return _lanId; }
        set { _lanId = value; }
    }

    private int _empSl;
    public int EmpSl
    {
        get { return _empSl; }
        set { _empSl = value; }
    }

    private string _language;
    public string Language
    {
        get { return _language; }
        set { _language = value; }
    }

    private string _reading;
    public string Reading
    {
        get { return _reading; }
        set { _reading = value; }
    }

    private string _writing;
    public string Writing
    {
        get { return _writing; }
        set { _writing = value; }
    }

    private string _speaking;
    public string Speaking
    {
        get { return _speaking; }
        set { _speaking = value; }
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
