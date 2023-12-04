using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_DonationFor
{
    public Li_DonationFor()
    {
    }

    public Li_DonationFor
        (
 
        int doFId, 
        string donationFor, 
        int createdBy, 
        DateTime createdDate
        )
    {
     
        this.DoFId = doFId;
        this.DonationFor = donationFor;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
    }


 
    private int _doFId;
    public int DoFId
    {
        get { return _doFId; }
        set { _doFId = value; }
    }

    private string _donationFor;
    public string DonationFor
    {
        get { return _donationFor; }
        set { _donationFor = value; }
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
