using System;
using System.Data;
using System.Configuration;

 


public class Li_AdminUser
{
    public Li_AdminUser()
    {
    }

    public Li_AdminUser
        (
        
        int userID, 
        string userName, 
        string password, 
        bool inRule, 
        bool upRule, 
        int delRule, 
        DateTime createdDate, 
        int createdBy, 
        bool isActive, 
        bool isSupAd 
         
        )
    {
       
        this.UserID = userID;
        this.UserName = userName;
        this.Password = password;
        this.InRule = inRule;
        this.UpRule = upRule;
        this.DelRule = delRule;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.IsActive = isActive;
        this.IsSupAd = isSupAd;
         
    }


 

    private int _userID;
    public int UserID
    {
        get { return _userID; }
        set { _userID = value; }
    }

    private string _userName;
    public string UserName
    {
        get { return _userName; }
        set { _userName = value; }
    }

    private string _password;
    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }

    private bool _inRule;
    public bool InRule
    {
        get { return _inRule; }
        set { _inRule = value; }
    }

    private bool _upRule;
    public bool UpRule
    {
        get { return _upRule; }
        set { _upRule = value; }
    }

    private int _delRule;
    public int DelRule
    {
        get { return _delRule; }
        set { _delRule = value; }
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

    private bool _isActive;
    public bool IsActive
    {
        get { return _isActive; }
        set { _isActive = value; }
    }

    private bool _isSupAd;
    public bool IsSupAd
    {
        get { return _isSupAd; }
        set { _isSupAd = value; }
    }
 
}
