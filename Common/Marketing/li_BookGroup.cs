using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookGroup
{
    public Li_BookGroup()
    {
    }

    public Li_BookGroup
        (
     
        string mainItem, 
        string subItem, 
        char status_D, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate 
         
        )
    {
         
        this.MainItem = mainItem;
        this.SubItem = subItem;
        this.Status_D = status_D;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
         
    }

    public Li_BookGroup
       (

       string mainItem 
       

       )
    {

        this.MainItem = mainItem;
        
    }
    
    private string _mainItem;
    public string MainItem
    {
        get { return _mainItem; }
        set { _mainItem = value; }
    }

    private string _subItem;
    public string SubItem
    {
        get { return _subItem; }
        set { _subItem = value; }
    }

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
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
