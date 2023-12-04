using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_LaminationTypeBasic
{
    public Li_LaminationTypeBasic()
    {
    }

    public Li_LaminationTypeBasic
        (
        
        string iD, 
        string type, 
        int createdBy, 
        DateTime createdDate 
         
        )
    {
         this.ID = iD;
        this.Type = type;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
     }

 

    private string _iD;
    public string ID
    {
        get { return _iD; }
        set { _iD = value; }
    }

    private string _type;
    public string Type
    {
        get { return _type; }
        set { _type = value; }
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

    
}
