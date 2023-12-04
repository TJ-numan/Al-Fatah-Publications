using System;
using System.Data;
using System.Configuration;
using System.Linq;  

public class Li_LemiSizeBasic
{
    public Li_LemiSizeBasic()
    {
    }

    public Li_LemiSizeBasic
        (
        
        string lemiSizeID, 
        string lemiSize, 
        int createdBy, 
        DateTime createdDate
        )
    {
       
        this.LemiSizeID = lemiSizeID;
        this.LemiSize = lemiSize;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
    }

 
    private string _lemiSizeID;
    public string LemiSizeID
    {
        get { return _lemiSizeID; }
        set { _lemiSizeID = value; }
    }

    private string _lemiSize;
    public string LemiSize
    {
        get { return _lemiSize; }
        set { _lemiSize = value; }
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
