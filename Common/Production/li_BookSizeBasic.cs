using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookSizeBasic
{
    public Li_BookSizeBasic()
    {
    }

    public Li_BookSizeBasic
        (
        
        string bookSizeID, 
        string sizeType, 
        int createdBy, 
        DateTime createdDate  
         
        )
    {
       
        this.BookSizeID = bookSizeID;
        this.SizeType = sizeType;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        
    }


    

    private string _bookSizeID;
    public string BookSizeID
    {
        get { return _bookSizeID; }
        set { _bookSizeID = value; }
    }

    private string _sizeType;
    public string SizeType
    {
        get { return _sizeType; }
        set { _sizeType = value; }
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
