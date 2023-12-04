using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_BookInfo_Section
{
    public Li_BookInfo_Section()
    {
    }

    public Li_BookInfo_Section
        (
       
        int serialNo, 
        string bookID, 
        int sectionID, 
        bool isSelect, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate 
         
        )
    {
 
        this.SerialNo = serialNo;
        this.BookID = bookID;
        this.SectionID = sectionID;
        this.IsSelect = isSelect;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        
    }


 

    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = value; }
    }

    private string _bookID;
    public string BookID
    {
        get { return _bookID; }
        set { _bookID = value; }
    }

    private int _sectionID;
    public int SectionID
    {
        get { return _sectionID; }
        set { _sectionID = value; }
    }

    private bool _isSelect;
    public bool IsSelect
    {
        get { return _isSelect; }
        set { _isSelect = value; }
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
