using System;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_DonYear
{
    public Li_DonYear()
    {
    }

    public Li_DonYear
        (
   
        string donYear, 
        DateTime statingDate, 
        DateTime endDate, 
        int createdBy, 
        DateTime createdDate
        )
    {
     
        this.DonYear = donYear;
        this.StatingDate = statingDate;
        this.EndDate = endDate;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
    }


 

    private string _donYear;
    public string DonYear
    {
        get { return _donYear; }
        set { _donYear = value; }
    }

    private DateTime _statingDate;
    public DateTime StatingDate
    {
        get { return _statingDate; }
        set { _statingDate = value; }
    }

    private DateTime _endDate;
    public DateTime EndDate
    {
        get { return _endDate; }
        set { _endDate = value; }
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
