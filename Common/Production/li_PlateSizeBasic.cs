using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PlateSizeBasic
{
    public Li_PlateSizeBasic()
    {
    }

    public Li_PlateSizeBasic
        (
      
        string iD, 
        string size, 
        int createdBy, 
        DateTime createdDate 
         
        )
    {
        
        this.ID = iD;
        this.Size = size;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
       
    }


   

    private string _iD;
    public string ID
    {
        get { return _iD; }
        set { _iD = value; }
    }

    private string _size;
    public string Size
    {
        get { return _size; }
        set { _size = value; }
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
