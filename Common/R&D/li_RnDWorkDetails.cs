using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

public class Li_RnDWorkDetails
{
    public Li_RnDWorkDetails()
    {
    }

    public Li_RnDWorkDetails
        (
       
        int workDetailID, 
        DateTime workDate, 
        int employeeID, 
        int workTypeID, 
        string bookID, 
        string workStartTime, 
        string workEndTime, 
        decimal workTimeSpan, 
        int pageStart, 
        int pageEnd, 
        string comments, 
        int createdBy, 
        DateTime createdDate, 
        int sectionID ,
        bool isHired

         
         
        )
    { 
        this.WorkDetailID = workDetailID;
        this.WorkDate = workDate;
        this.EmployeeID = employeeID;
        this.WorkTypeID = workTypeID;
        this.BookID = bookID;
        this.WorkStartTime = workStartTime;
        this.WorkEndTime = workEndTime;
        this.WorkTimeSpan = workTimeSpan;
        this.PageStart = pageStart;
        this.PageEnd = pageEnd;
        this.Comments = comments;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.SectionID = sectionID;
        this.IsHired = isHired;
       
    }


    public int SectionID { get; set; }
    public bool IsHired {get;set;}
    private int _workDetailID;
    public int WorkDetailID
    {
        get { return _workDetailID; }
        set { _workDetailID = value; }
    }

    private DateTime _workDate;
    public DateTime WorkDate
    {
        get { return _workDate; }
        set { _workDate = value; }
    }

    private int _employeeID;
    public int EmployeeID
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

    private string _workStartTime;
    public string WorkStartTime
    {
        get { return _workStartTime; }
        set { _workStartTime = value; }
    }

    private string _workEndTime;
    public string WorkEndTime
    {
        get { return _workEndTime; }
        set { _workEndTime = value; }
    }

    private decimal _workTimeSpan;
    public decimal WorkTimeSpan
    {
        get { return _workTimeSpan; }
        set { _workTimeSpan = value; }
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

    private string _comments;
    public string Comments
    {
        get { return _comments; }
        set { _comments = value; }
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
