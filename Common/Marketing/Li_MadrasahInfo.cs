using System;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_MadrasahInfo
{
    public Li_MadrasahInfo()
    {
    }

    public Li_MadrasahInfo
        (
      
        string madId, 
        int detId, 
        string madName, 
        string villRoBaz, 
        string postOff, 
        int madLevelId, 
        int thanaId, 
        string prinName, 
        string prinCont, 
        int createdBy, 
        DateTime createdDate
        )
    {
       
        this.MadId = madId;
        this.DetId = detId;
        this.MadName = madName;
        this.VillRoBaz = villRoBaz;
        this.PostOff = postOff;
        this.MadLevelId = madLevelId;
        this.ThanaId = thanaId;
        this.PrinName = prinName;
        this.PrinCont = prinCont;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
    }


 

    private string _madId;
    public string MadId
    {
        get { return _madId; }
        set { _madId = value; }
    }

    private int _detId;
    public int DetId
    {
        get { return _detId; }
        set { _detId = value; }
    }

    private string _madName;
    public string MadName
    {
        get { return _madName; }
        set { _madName = value; }
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

    private int _madLevelId;
    public int MadLevelId
    {
        get { return _madLevelId; }
        set { _madLevelId = value; }
    }

    private int _thanaId;
    public int ThanaId
    {
        get { return _thanaId; }
        set { _thanaId = value; }
    }

    private string _prinName;
    public string PrinName
    {
        get { return _prinName; }
        set { _prinName = value; }
    }

    private string _prinCont;
    public string PrinCont
    {
        get { return _prinCont; }
        set { _prinCont = value; }
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
