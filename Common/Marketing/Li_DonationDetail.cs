using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_DonationDetail
{
    public Li_DonationDetail()
    {
    }

    public Li_DonationDetail
        (
  
        int detId, 
        int dold, 
        int doFId, 
        string doName, 
        string villRoBaz, 
        string postOff, 
        int thanaId, 
        string contactNo, 
        string chair_Prin, 
        string chair_PrinCont, 
        string sec_ViceP, 
        string sec_VicePCont, 
        int createdBy, 
        DateTime createdDate
        )
    {
       
        this.DetId = detId;
        this.Dold = dold;
        this.DoFId = doFId;
        this.DoName = doName;
        this.VillRoBaz = villRoBaz;
        this.PostOff = postOff;
        this.ThanaId = thanaId;
        this.ContactNo = contactNo;
        this.Chair_Prin = chair_Prin;
        this.Chair_PrinCont = chair_PrinCont;
        this.Sec_ViceP = sec_ViceP;
        this.Sec_VicePCont = sec_VicePCont;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
    }


 
    private int _detId;
    public int DetId
    {
        get { return _detId; }
        set { _detId = value; }
    }

    private int _dold;
    public int Dold
    {
        get { return _dold; }
        set { _dold = value; }
    }

    private int _doFId;
    public int DoFId
    {
        get { return _doFId; }
        set { _doFId = value; }
    }

    private string _doName;
    public string DoName
    {
        get { return _doName; }
        set { _doName = value; }
    }

    private string _villRoBaz;
    public string VillRoBaz
    {
        get { return _villRoBaz; }
        set { _villRoBaz = value; }
    }

    private string _postOff;
    public string PostOff
    {
        get { return _postOff; }
        set { _postOff = value; }
    }

    private int _thanaId;
    public int ThanaId
    {
        get { return _thanaId; }
        set { _thanaId = value; }
    }

    private string _contactNo;
    public string ContactNo
    {
        get { return _contactNo; }
        set { _contactNo = value; }
    }

    private string _chair_Prin;
    public string Chair_Prin
    {
        get { return _chair_Prin; }
        set { _chair_Prin = value; }
    }

    private string _chair_PrinCont;
    public string Chair_PrinCont
    {
        get { return _chair_PrinCont; }
        set { _chair_PrinCont = value; }
    }

    private string _sec_ViceP;
    public string Sec_ViceP
    {
        get { return _sec_ViceP; }
        set { _sec_ViceP = value; }
    }

    private string _sec_VicePCont;
    public string Sec_VicePCont
    {
        get { return _sec_VicePCont; }
        set { _sec_VicePCont = value; }
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
