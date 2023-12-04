using System; 
using System.Linq; 

public class Li_ApprisalCycle
{
    public Li_ApprisalCycle()
    {
    }

    public Li_ApprisalCycle
        (
       
        int appId, 
        string appTitle, 
        DateTime cyStDate, 
        DateTime cyEnDate, 
        DateTime teFDate, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
       
        this.AppId = appId;
        this.AppTitle = appTitle;
        this.CyStDate = cyStDate;
        this.CyEnDate = cyEnDate;
        this.TeFDate = teFDate;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _appId;
    public int AppId
    {
        get { return _appId; }
        set { _appId = value; }
    }

    private string _appTitle;
    public string AppTitle
    {
        get { return _appTitle; }
        set { _appTitle = value; }
    }

    private DateTime _cyStDate;
    public DateTime CyStDate
    {
        get { return _cyStDate; }
        set { _cyStDate = value; }
    }

    private DateTime _cyEnDate;
    public DateTime CyEnDate
    {
        get { return _cyEnDate; }
        set { _cyEnDate = value; }
    }

    private DateTime _teFDate;
    public DateTime TeFDate
    {
        get { return _teFDate; }
        set { _teFDate = value; }
    }

    private string _comments;
    public string Comments
    {
        get { return _comments; }
        set { _comments = value; }
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
