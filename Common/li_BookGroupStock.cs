using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookGroupStock
{
    public Li_BookGroupStock()
    {
    }

    public Li_BookGroupStock
        (
         
        string iD, 
        string bookCode, 
        decimal qty, 
        DateTime transDate, 
        int createdBy ,
        bool isTransferToGroup,
        bool isCentralStore
         
        )
    {
        
        this.ID = iD;
        this.BookCode = bookCode;
        this.Qty = qty;
        this.TransDate = transDate;
        this.CreatedBy = createdBy;
        this.IsTransferToGroup = isTransferToGroup;
        this.IsCentralStore = isCentralStore;
    }

    public bool IsTransferToGroup { get; set; }
    public bool IsCentralStore  { get; set; }

    private string _iD;
    public string ID
    {
        get { return _iD; }
        set { _iD = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private decimal _qty;
    public decimal Qty
    {
        get { return _qty; }
        set { _qty = value; }
    }

    private DateTime _transDate;
    public DateTime TransDate
    {
        get { return _transDate; }
        set { _transDate = value; }
    }

    private int _createdBy;
    public int CreatedBy
    {
        get { return _createdBy; }
        set { _createdBy = value; }
    }

     
}
