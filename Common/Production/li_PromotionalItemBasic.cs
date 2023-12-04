using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PromotionalItemBasic
{
    public Li_PromotionalItemBasic()
    {
    }

    public Li_PromotionalItemBasic
        (
        
        string iD, 
        string name, 
        int createdBy, 
        DateTime createdDate  
         
        )
    {
         this.ID = iD;
        this.Name = name;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        
    }


   

    private string _iD;
    public string ID
    {
        get { return _iD; }
        set { _iD = value; }
    }

    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
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
