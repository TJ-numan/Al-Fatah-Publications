using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpTraining
{
    public Li_EmpTraining()
    {
    }

    public Li_EmpTraining
        (
        
        int tranId, 
        string tranTitle, 
        string topicsCov, 
        string instituteName, 
        string certifPath, 
        string location, 
        string country, 
        string tranYr, 
        string duration, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId,
        int empSl
        )
    {
         
        this.TranId = tranId;
        this.TranTitle = tranTitle;
        this.TopicsCov = topicsCov;
        this.InstituteName = instituteName;
        this.CertifPath = certifPath;
        this.Location = location;
        this.Country = country;
        this.TranYr = tranYr;
        this.Duration = duration;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
        this.EmpSl = empSl;
    }

    public int EmpSl { get; set; }
 

    private int _tranId;
    public int TranId
    {
        get { return _tranId; }
        set { _tranId = value; }
    }

    private string _tranTitle;
    public string TranTitle
    {
        get { return _tranTitle; }
        set { _tranTitle = value; }
    }

    private string _topicsCov;
    public string TopicsCov
    {
        get { return _topicsCov; }
        set { _topicsCov = value; }
    }

    private string _instituteName;
    public string InstituteName
    {
        get { return _instituteName; }
        set { _instituteName = value; }
    }

    private string _certifPath;
    public string CertifPath
    {
        get { return _certifPath; }
        set { _certifPath = value; }
    }

    private string _location;
    public string Location
    {
        get { return _location; }
        set { _location = value; }
    }

    private string _country;
    public string Country
    {
        get { return _country; }
        set { _country = value; }
    }

    private string _tranYr;
    public string TranYr
    {
        get { return _tranYr; }
        set { _tranYr = value; }
    }

    private string _duration;
    public string Duration
    {
        get { return _duration; }
        set { _duration = value; }
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

    private int _modifiedBy;
    public int ModifiedBy
    {
        get { return _modifiedBy; }
        set { _modifiedBy = value; }
    }

    private DateTime _modifiedDate;
    public DateTime ModifiedDate
    {
        get { return _modifiedDate; }
        set { _modifiedDate = value; }
    }

    private int _infStId;
    public int InfStId
    {
        get { return _infStId; }
        set { _infStId = value; }
    }
}
