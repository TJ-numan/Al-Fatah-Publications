using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_LetterTemplate
{
    public Li_LetterTemplate()
    {
    }

    public Li_LetterTemplate
        (
       
        int tempId, 
        string tempName, 
        string tempPath, 
        string tempDes, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.TempId = tempId;
        this.TempName = tempName;
        this.TempPath = tempPath;
        this.TempDes = tempDes;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _tempId;
    public int TempId
    {
        get { return _tempId; }
        set { _tempId = value; }
    }

    private string _tempName;
    public string TempName
    {
        get { return _tempName; }
        set { _tempName = value; }
    }

    private string _tempPath;
    public string TempPath
    {
        get { return _tempPath; }
        set { _tempPath = value; }
    }

    private string _tempDes;
    public string TempDes
    {
        get { return _tempDes; }
        set { _tempDes = value; }
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
