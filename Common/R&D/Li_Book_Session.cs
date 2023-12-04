using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Book_Session
{
    public Li_Book_Session()
    {
    }

    public Li_Book_Session
        (
        
        int sessionID, 
        string sessionName, 
        DateTime createdDate, 
        int createdBy, 
        string sessDetail 
         
        )
    {
         
        this.SessionID = sessionID;
        this.SessionName = sessionName;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.SessDetail = sessDetail;
    }

 
    private int _sessionID;
    public int SessionID
    {
        get { return _sessionID; }
        set { _sessionID = value; }
    }

    private string _sessionName;
    public string SessionName
    {
        get { return _sessionName; }
        set { _sessionName = value; }
    }

    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

    private string _sessDetail;
    public string SessDetail
    {
        get { return _sessDetail; }
        set { _sessDetail = value; }
    }

    
}
