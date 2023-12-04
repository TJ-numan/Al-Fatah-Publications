using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Pesting
{
    public Li_Pesting()
    {
    }

    public Li_Pesting
        (
       
        string pest_OrderNo, 
        DateTime w_Date, 
        string partyID, 
        string bookID, 
        string edition, 
        string bookSizeID, 
        string exam, 
        int pageTotal, 
        decimal formaTotal, 
        decimal pest_Bill_Forma, 
        decimal rate, 
        decimal amount, 
        DateTime createdDate, 
        int createdBy, 
        
        string pestingType
         
        )
    {
   
        this.Pest_OrderNo = pest_OrderNo;
        this.W_Date = w_Date;
        this.PartyID = partyID;
        this.BookID = bookID;
        this.Edition = edition;
        this.BookSizeID = bookSizeID;
        this.Exam = exam;
        this.PageTotal = pageTotal;
        this.FormaTotal = formaTotal;
        this.Pest_Bill_Forma = pest_Bill_Forma;
        this.Rate = rate;
        this.Amount = amount;
        this.CreatedDate = createdDate;
        this.CreatedBy = createdBy;
        
        this.PestingType = pestingType;
      
    }

    public string PestingType { get; set; }

    private string _pest_OrderNo;
    public string Pest_OrderNo
    {
        get { return _pest_OrderNo; }
        set { _pest_OrderNo = value; }
    }

    private DateTime _w_Date;
    public DateTime W_Date
    {
        get { return _w_Date; }
        set { _w_Date = value; }
    }

    private string _partyID;
    public string PartyID
    {
        get { return _partyID; }
        set { _partyID = value; }
    }

    private string _bookID;
    public string BookID
    {
        get { return _bookID; }
        set { _bookID = value; }
    }

    private string _edition;
    public string Edition
    {
        get { return _edition; }
        set { _edition = value; }
    }

    private string _bookSizeID;
    public string BookSizeID
    {
        get { return _bookSizeID; }
        set { _bookSizeID = value; }
    }

    private string _exam;
    public string Exam
    {
        get { return _exam; }
        set { _exam = value; }
    }

    private int _pageTotal;
    public int PageTotal
    {
        get { return _pageTotal; }
        set { _pageTotal = value; }
    }

    private decimal _formaTotal;
    public decimal FormaTotal
    {
        get { return _formaTotal; }
        set { _formaTotal = value; }
    }

    private decimal _pest_Bill_Forma;
    public decimal Pest_Bill_Forma
    {
        get { return _pest_Bill_Forma; }
        set { _pest_Bill_Forma = value; }
    }

    private decimal _rate;
    public decimal Rate
    {
        get { return _rate; }
        set { _rate = value; }
    }

    private decimal _amount;
    public decimal Amount
    {
        get { return _amount; }
        set { _amount = value; }
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
