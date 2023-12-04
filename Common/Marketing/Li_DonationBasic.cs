using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_DonationBasic
{
    public Li_DonationBasic()
    {
    }

    public Li_DonationBasic
        (
    
        int doId, 
        string agrNo, 
        string agrYNo, 
        string agrYear, 
        int thanaId, 
        int territorySl, 
        decimal donAmt, 
        int createdBy, 
        DateTime createdDate
        )
    {
       
        this.DoId = doId;
        this.AgrNo = agrNo;
        this.AgrYNo = agrYNo;
        this.AgrYear = agrYear;
        this.ThanaId = thanaId;
        this.TerritorySl = territorySl;
        this.DonAmt = donAmt;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
    }


 

    private int _doId;
    public int DoId
    {
        get { return _doId; }
        set { _doId = value; }
    }

    private string _agrNo;
    public string AgrNo
    {
        get { return _agrNo; }
        set { _agrNo = value; }
    }

    private string _agrYNo;
    public string AgrYNo
    {
        get { return _agrYNo; }
        set { _agrYNo = value; }
    }

    private string _agrYear;
    public string AgrYear
    {
        get { return _agrYear; }
        set { _agrYear = value; }
    }

    private int _thanaId;
    public int ThanaId
    {
        get { return _thanaId; }
        set { _thanaId = value; }
    }

    private int _territorySl;
    public int TerritorySl
    {
        get { return _territorySl; }
        set { _territorySl = value; }
    }

    private decimal _donAmt;
    public decimal DonAmt
    {
        get { return _donAmt; }
        set { _donAmt = value; }
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
