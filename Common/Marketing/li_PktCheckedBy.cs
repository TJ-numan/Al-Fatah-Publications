using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PktCheckedBy
{
    public Li_PktCheckedBy()
    {
    }

    public Li_PktCheckedBy
        (
          
        int iD, 
        string checkedBy, 
        DateTime createdDate, 
        int createdBy, 
        DateTime modifiedDate, 
        int modifiedBy 
        )
    {
        
        this.ID = iD;
        this.CheckedBy = checkedBy;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.ModifiedDate = modifiedDate;
        this.ModifiedBy = modifiedBy;
        
    }


   

    private int _iD;
    public int ID
    {
        get { return _iD; }
        set { _iD = value; }
    }

    private string _checkedBy;
    public string CheckedBy
    {
        get { return _checkedBy; }
        set { _checkedBy = value; }
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

    private DateTime _modifiedDate;
    public DateTime ModifiedDate
    {
        get { return _modifiedDate; }
        set { _modifiedDate = value; }
    }

    private int _modifiedBy;
    public int ModifiedBy
    {
        get { return _modifiedBy; }
        set { _modifiedBy = value; }
    }
 
}
