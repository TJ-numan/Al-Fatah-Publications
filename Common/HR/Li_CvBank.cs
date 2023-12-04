using System;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_CvBank
{
    public Li_CvBank()
    {
    }

    public Li_CvBank
        (
       
        int cvId, 
        int vacAnId, 
        string cvPath, 
        int createdBy, 
        DateTime createdDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int infStId
        )
    {
        
        this.CvId = cvId;
        this.VacAnId = vacAnId;
        this.CvPath = cvPath;
        this.CreatedBy = createdBy;
        this.CreatedDate = createdDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.InfStId = infStId;
    }


 

    private int _cvId;
    public int CvId
    {
        get { return _cvId; }
        set { _cvId = value; }
    }

    private int _vacAnId;
    public int VacAnId
    {
        get { return _vacAnId; }
        set { _vacAnId = value; }
    }

    private string _cvPath;
    public string CvPath
    {
        get { return _cvPath; }
        set { _cvPath = value; }
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
