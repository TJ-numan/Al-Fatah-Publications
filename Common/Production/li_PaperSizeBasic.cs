using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PaperSizeBasic
{
    public Li_PaperSizeBasic()
    {
    }

    public Li_PaperSizeBasic
        (
        
        string sizeID, 
        string size, 
        string paerType,
        int createdBy, 
        DateTime createdDate 
         
        )
    {
        
        this.SizeID = sizeID;
        this.Size = size;
        this.PaperType = paerType;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
         
    }

 

    private string _sizeID;
    public string SizeID
    {
        get { return _sizeID; }
        set { _sizeID = value; }
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

    public string PaperType { get; set; }

}
