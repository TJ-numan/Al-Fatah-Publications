using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookRecFrBinder
{
    public Li_BookRecFrBinder()
    {
    }

    public Li_BookRecFrBinder
        (
        
        int serialNo, 
        string bookCode, 
        string binderID, 
        int qty, 
        DateTime collectionDate, 
        DateTime createdDate, 
        int createdBy 
         
        )
    {
         this.SerialNo = serialNo;
        this.BookCode = bookCode;
        this.BinderID = binderID;
        this.Qty = qty;
        this.CollectionDate = collectionDate;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        
    }

 

    private int _serialNo;
    public int SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private string _binderID;
    public string BinderID
    {
        get { return _binderID; }
        set { _binderID = value; }
    }

    private int _qty;
    public int Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

    private DateTime _collectionDate;
    public DateTime CollectionDate
    {
        get { return _collectionDate; }
        set { _collectionDate = value; }
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

    
}
