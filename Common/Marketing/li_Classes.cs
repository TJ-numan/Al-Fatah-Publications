using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Classes
{
    public Li_Classes()
    {
    }

    public Li_Classes
        (
      
        int classID, 
        string className, 
        string classDescription, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate 
         
        )
    {
        
        this.ClassID = classID;
        this.ClassName = className;
        this.ClassDescription = classDescription;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        
    }


     

    private int _classID;
    public int ClassID
    {
        get { return _classID; }
        set { _classID = value; }
    }

    private string _className;
    public string ClassName
    {
        get { return _className; }
        set { _className = value; }
    }

    private string _classDescription;
    public string ClassDescription
    {
        get { return _classDescription; }
        set { _classDescription = value; }
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

    
}
