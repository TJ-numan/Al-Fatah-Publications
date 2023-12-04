using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
public class Li_RnDQawmiWorkOrderDetails
{
    public Li_RnDQawmiWorkOrderDetails()
    {
    }
    public Li_RnDQawmiWorkOrderDetails
        (
        int workOrderDetID, 
        int workOrderID, 
        DateTime workDate,
        string employeeID,
        int sectionID,
        int isHired,
        int workTypeID, 
        string bookID,
        int classID,
        int pageStart, 
        int pageEnd,
        int totalPage,
        decimal totalForma,
        decimal totalCharacter,
        int createdBy, 
        DateTime createdDate,
        string sizeID,
        string edition,
        string comments



         
         
        )
    {
        this.WorkOrderDetID = workOrderDetID;
        this.WorkOrderID = workOrderID;
        this.WorkDate = workDate;
        this.EmployeeID = employeeID;
        this.WorkTypeID = workTypeID;
        this.BookID = bookID;
        this.ClassID = classID;
        this.PageStart = pageStart;
        this.PageEnd = pageEnd;
        this.TotalPage = totalPage;
        this.TotalForma = totalForma;
        this.TotalCharacter = totalCharacter;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.SectionID = sectionID;
        this.IsHired = isHired;
        this.SizeID = sizeID;
        this.Edition = edition;
        this.Comments = comments;
       
    }


    public int SectionID { get; set; }
    public int IsHired {get;set;}

    private int _workOrderDetID;
    public int WorkOrderDetID
    {
        get { return _workOrderDetID; }
        set { _workOrderDetID = value; }
    }

    private int _workOrderID;
    public int WorkOrderID
    {
        get { return _workOrderID; }
        set { _workOrderID = value; }
    }

    private DateTime _workDate;
    public DateTime WorkDate
    {
        get { return _workDate; }
        set { _workDate = value; }
    }

    private string _employeeID;
    public string EmployeeID
    {
        get { return _employeeID; }
        set { _employeeID = value; }
    }

    private int _workTypeID;
    public int WorkTypeID
    {
        get { return _workTypeID; }
        set { _workTypeID = value; }
    }

    private string _bookID;
    public string BookID
    {
        get { return _bookID; }
        set { _bookID = value; }
    }
    private int _classID;
    public int ClassID
    {
        get { return _classID; }
        set { _classID = value; }
    }

    private int _pageStart;
    public int PageStart
    {
        get { return _pageStart; }
        set { _pageStart = value; }
    }

    private int _pageEnd;
    public int PageEnd
    {
        get { return _pageEnd; }
        set { _pageEnd = value; }
    }

    private int _totalPage;
    public int TotalPage
    {
        get { return _totalPage; }
        set { _totalPage = value; }
    }

    private decimal _totalForma;
    public decimal TotalForma
    {
        get { return _totalForma; }
        set { _totalForma = value; }
    }
    private decimal _totalCharacter;
    public decimal TotalCharacter
    {
        get { return _totalCharacter; }
        set { _totalCharacter = value; }
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
    private string _sizeID;
    public string SizeID
    {
        get { return _sizeID; }
        set { _sizeID = value; }
    }
    private string _edition;
    public string Edition
    {
        get { return _edition; }
        set { _edition = value; }
    }
    private string _comments;
    public string Comments
    {
        get { return _comments; }
        set { _comments = value; }
    }
    
}



