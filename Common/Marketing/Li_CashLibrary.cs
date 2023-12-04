using System;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_CashLibrary
{
    public Li_CashLibrary()
    {
    }

    public Li_CashLibrary
        (
     
        string libraryID, 
        string libraryName, 
        string propName, 
        string mobile, 
        string category, 
        decimal monthlyAvg, 
        string add1, 
        string postNo, 
        string territoryID, 
        string districtID, 
        int thanaID, 
        int createdBy, 
        DateTime createdDate, 
        char status_D, 
        string causeOfDel, 
        DateTime delDate, 
        string creditID  
         
        )
    {
    
        this.LibraryID = libraryID;
        this.LibraryName = libraryName;
        this.PropName = propName;
        this.Mobile = mobile;
        this.Category = category;
        this.MonthlyAvg = monthlyAvg;
        this.Add1 = add1;
        this.PostNo = postNo;
        this.TerritoryID = territoryID;
        this.DistrictID = districtID;
        this.ThanaID = thanaID;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.Status_D = status_D;
        this.CauseOfDel = causeOfDel;
        this.DelDate = delDate;
        this.CreditID = creditID;
         
    }


 
    private string _libraryID;
    public string LibraryID
    {
        get { return _libraryID; }
        set { _libraryID = value; }
    }

    private string _libraryName;
    public string LibraryName
    {
        get { return _libraryName; }
        set { _libraryName = value; }
    }

    private string _propName;
    public string PropName
    {
        get { return _propName; }
        set { _propName = value; }
    }

    private string _mobile;
    public string Mobile
    {
        get { return _mobile; }
        set { _mobile = value; }
    }

    private string _category;
    public string Category
    {
        get { return _category; }
        set { _category = value; }
    }

    private decimal _monthlyAvg;
    public decimal MonthlyAvg
    {
        get { return _monthlyAvg; }
        set { _monthlyAvg = value; }
    }

    private string _add1;
    public string Add1
    {
        get { return _add1; }
        set { _add1 = value; }
    }

    private string _postNo;
    public string PostNo
    {
        get { return _postNo; }
        set { _postNo = value; }
    }

    private string _territoryID;
    public string TerritoryID
    {
        get { return _territoryID; }
        set { _territoryID = value; }
    }

    private string _districtID;
    public string DistrictID
    {
        get { return _districtID; }
        set { _districtID = value; }
    }

    private int _thanaID;
    public int ThanaID
    {
        get { return _thanaID; }
        set { _thanaID = value; }
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

    private char _status_D;
    public char Status_D
    {
        get { return _status_D; }
        set { _status_D = value; }
    }

    private string _causeOfDel;
    public string CauseOfDel
    {
        get { return _causeOfDel; }
        set { _causeOfDel = value; }
    }

    private DateTime _delDate;
    public DateTime DelDate
    {
        get { return _delDate; }
        set { _delDate = value; }
    }

    private string _creditID;
    public string CreditID
    {
        get { return _creditID; }
        set { _creditID = value; }
    }

   
}
