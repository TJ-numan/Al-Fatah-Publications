using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookDeliveryToBinder
{
    public Li_BookDeliveryToBinder()
    {
    }

    public Li_BookDeliveryToBinder
        (
        
        int deID, 
        string bookCode, 
        string edition, 
        int printNo, 
        decimal printQty, 
        DateTime deliveryDate, 
        DateTime createdDate, 
        int createdBy, 
        char status_D ,
        bool isForma
         
        )
    {
         
        this.DeID = deID;
        this.BookCode = bookCode;
        this.Edition = edition;
        this.PrintNo = printNo;
        this.PrintQty = printQty;
        this.DeliveryDate = deliveryDate;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        this.Status_D = status_D;
        this.IsForma = isForma;
    }

    public bool IsForma { get; set; }
     

    private int _deID;
    public int DeID
    {
        get { return _deID; }
        set { _deID = value; }
    }

    private string _bookCode;
    public string BookCode
    {
        get { return _bookCode; }
        set { _bookCode = value; }
    }

    private string _edition;
    public string Edition
    {
        get { return _edition; }
        set { _edition = value; }
    }

    private int _printNo;
    public int PrintNo
    {
        get { return _printNo; }
        set { _printNo = value; }
    }

    private decimal _printQty;
    public decimal PrintQty
    {
        get { return _printQty; }
        set { _printQty = value; }
    }

    private DateTime _deliveryDate;
    public DateTime DeliveryDate
    {
        get { return _deliveryDate; }
        set { _deliveryDate = value; }
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

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

 
}
