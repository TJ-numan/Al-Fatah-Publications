using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PaperOriginBasic
{
    public Li_PaperOriginBasic()
    {
    }

    public Li_PaperOriginBasic
        (
      
        string iD, 
        string origin, 
        int createdBy, 
        DateTime createdDate 
        )
    {
       
        this.ID = iD;
        this.Origin = origin;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        
    }


    

    private string _iD;
    public string ID
    {
        get { return _iD; }
        set { _iD = value; }
    }

    private string _origin;
    public string Origin
    {
        get { return _origin; }
        set { _origin = value; }
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
